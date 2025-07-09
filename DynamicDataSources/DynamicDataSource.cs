// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.DynamicDataSources;

/// <summary>
/// An base class that provides a dynamic dataRows source with the ability to temporarily override argument codes.
/// </summary>
public abstract class DynamicDataSource
: IArgsCode
{
    #region Fields
    private readonly ArgsCode _argsCode;
    private readonly AsyncLocal<ArgsCode?> _tempArgsCode = new();
    #endregion

    #region Properties
    /// <summary>
    /// Gets the current ArgsCode value used for argument conversion,
    /// which is either the temporary override value or the default value.
    /// </summary>
    public ArgsCode ArgsCode
    => _tempArgsCode.Value ?? _argsCode;
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="DynamicParams"/> class with the specified ArgsCode.
    /// </summary>
    /// <param name="argsCode">The default ArgsCode to use when no override is specified.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="argsCode"/> is null.</exception>
    protected DynamicDataSource(ArgsCode argsCode)
    {
        _argsCode = argsCode.Defined(nameof(argsCode));
        _tempArgsCode.Value = null;
    }
    #endregion

    #region Embedded ArgsCodeMemento Class
    /// <summary>
    /// A disposable class that manages temporary ArgsCode overrides and restores the previous value when disposed.
    /// </summary>
    private sealed class ArgsCodeMemento : IDisposable
    {
        #region Fields  
        [NotNull]
        private readonly DynamicDataSource _dataSource;
        private readonly ArgsCode? _tempArgsCodeValue;
        private bool _disposed = false;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ArgsCodeMemento"/> class.
        /// </summary>
        /// <param name="dataSource">The enclosing dataRows source to manage overrides for.</param>
        /// <param name="argsCode">The new ArgsCode to temporarily apply.</param>
        internal ArgsCodeMemento(
            DynamicDataSource dataSource,
            ArgsCode argsCode)
        {
            _dataSource = dataSource
                ?? throw new ArgumentNullException(nameof(dataSource));
            _tempArgsCodeValue =
                _dataSource._tempArgsCode.Value;
            _dataSource._tempArgsCode.Value =
                argsCode.Defined(nameof(argsCode));
        }
        #endregion

        #region Methods
        /// <summary>
        /// Restores the previous ArgsCode value.
        /// </summary>
        public void Dispose()
        {
            if (_disposed) return;

            _dataSource._tempArgsCode.Value =
                _tempArgsCodeValue;
            _disposed = true;
        }
        #endregion
    }
    #endregion

    #region Static methods
    #region GetDisplayName
    /// <summary>
    /// Gets the display name of the test method and the test case description, or null if any of these is null or empty.
    /// This method is called by the DynamicDataAttribute os MSTest framevork to get the display name of the test method
    /// when its DynamicDataDisplayName property is initialized by this method call. For sample usage see the <see href="path/to/README.md">README file</see>.
    /// This method's  return value can be used in NUnit framework when TestCaseData is used. The return valuse can be used as the
    /// parameter of the TestCaseData's SetName method. For sample usage see the <see href="path/to/README.md">README file</see>.
    /// </summary>
    /// <param name="testMethodName">The name of the test method for which the display name is generated.</param>
    /// <param name="args">The arguments passed to the test method.</param>
    /// <returns>A string representing the display name of the test method and its first argument.</returns>
    public static string? GetDisplayName(
        string? testMethodName,
        params object?[]? args)
    {
        if (string.IsNullOrEmpty(testMethodName))
        {
            return null;
        }

        var testCaseName = args?.FirstOrDefault();

        return !string.IsNullOrEmpty(testCaseName?.ToString()) ?
            $"{testMethodName}(testData: {testCaseName})"
            : null;
    }
    #endregion

    #region TestDataToParams
    /// <inheritdoc cref="TestDataToParams(ITestData, ArgsCode, out string) string"/>
    /// <param name="withExpected">A value indicating whether the expected result should be included in the returned parameters.</param>
    public static object?[] TestDataToParams(
        [NotNull] ITestData testData,
        ArgsCode argsCode,
        bool withExpected,
        out string testCaseName)
    {
        testCaseName = testData?.GetTestCaseName()
            ?? throw new ArgumentNullException(nameof(testData));

        return testData.ToParams(
            argsCode,
            withExpected);
    }
    #endregion

    #region WithOptionalArgsCode
    /// <summary>
    /// Executes a test dataRows generator within an optional memento pattern context.
    /// </summary>
    /// <typeparam name="TDataSource">The type of dynamic dataRows source, must inherit from <see cref="DynamicParams"/></typeparam>
    /// <typeparam name="T">The type of dataRows to generate, must be non-nullable</typeparam>
    /// <param name="dataSource">The dataRows source to use for memento creation (cannot be null)</param>
    /// <param name="dataRowGenerator">The function that generates test dataRows (cannot be null)</param>
    /// <param name="argsCode">
    /// The optional memento state code. When null, executes without memento pattern.
    /// When specified, creates a <see cref="ArgsCodeMemento"/> for the operation.
    /// </param>
    /// <returns>The result of the test dataRows generator</returns>
    /// <remarks>
    /// <para>
    /// This method provides thread-safe execution of dataRows generation operations with optional
    /// state preservation through the memento pattern.
    /// </para>
    /// <para>
    /// When <paramref name="argsCode"/> is specified, the operation will be wrapped in a
    /// disposable memento context that automatically cleans up after execution.
    /// </para>
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="dataSource"/> or <paramref name="dataRowGenerator"/> is null
    /// </exception>
    protected T WithOptionalArgsCode<T>(
        [NotNull] Func<T> dataRowGenerator,
        string paramName,
        ArgsCode? argsCode)
    {
        ArgumentNullException.ThrowIfNull(
            dataRowGenerator,
            paramName);

        if (!argsCode.HasValue)
        {
            return dataRowGenerator();
        }

        using (new ArgsCodeMemento(this, argsCode.Value))
        {
            return dataRowGenerator();
        }
    }
    #endregion
    #endregion
}

/// <summary>
/// Represents an abstract base class for managing dynamic data sources, providing functionality for handling test data
/// rows and strategies for data-driven testing.
/// </summary>
/// <remarks>This class provides methods for adding, retrieving, and resetting test data rows, as well as managing
/// data strategies. It supports scenarios where test data is dynamically generated or manipulated during runtime.
/// Derived classes must implement methods for creating and initializing test data rows.</remarks>
/// <typeparam name="TRow">The type of the data row managed by the data source.</typeparam>
/// <param name="argsCode"></param>
/// <param name="expectedResultType"></param>
public abstract class DynamicDataSource<TRow>(ArgsCode argsCode, Type? expectedResultType)
: DynamicDataSource(argsCode),
IDataStrategy,
ITestDataRows,
IRows<TRow>
{
    #region Fields
    private readonly Type? _expectedResultType = expectedResultType;
    #endregion

    #region Properties
    public bool? WithExpected { get; protected set; }
    protected IDataRowHolder<TRow>? DataRowHolder { get; set; }
    #endregion

    #region Methods
    #region Public methods
    #region Equals
    public bool Equals(IDataStrategy? other)
    => other is not null
        && ArgsCode == other.ArgsCode
        && WithExpected == other.WithExpected;

    public override bool Equals(object? obj)
    => obj is IDataStrategy other
        && Equals(other);
    #endregion

    #region GetHashCode
    public override int GetHashCode()
    => HashCode.Combine(
        ArgsCode,
        WithExpected);
    #endregion

    #region GetDataStrategy
    public IDataStrategy GetDataStrategy(ArgsCode? argsCode)
    => GetStoredDataStrategy(argsCode, this);
    #endregion

    #region GetTestDataRows
    public IEnumerable<ITestDataRow>? GetTestDataRows()
    => DataRowHolder?.GetTestDataRows();
    #endregion

    #region GetRows
    public IEnumerable<TRow>? GetRows(ArgsCode? argsCode)
    => DataRowHolder?.GetRows(argsCode);
    #endregion

    #region ResetDataRowCollection
    public virtual void ResetDataRowHolder()
    => DataRowHolder = null;
    #endregion
    #endregion

    #region Protected methods
    #region Virtual methods
    #region Add
    protected virtual void Add<TTestData>(TTestData testData)
    where TTestData : notnull, ITestData
    {
        bool rowCreated = TryGetTestDataRow<ITestDataRow, TTestData>(
            testData,
            out ITestDataRow<TRow, TTestData>? testDataRow);

        if (rowCreated && DataRowHolder is IDataRowHolder<TRow, TTestData> dataRowHolder)
        {
            dataRowHolder.Add(testDataRow!);
        }
    }
    #endregion

    #region TryGetTestDataRow
    protected virtual bool TryGetTestDataRow<TDataRow, TTestData>(
        TTestData testData,
        out ITestDataRow<TRow, TTestData>? testDataRow)
    where TTestData : notnull, ITestData
    {
        testDataRow = default;

        if (DataRowHolder is not IEnumerable<TDataRow> rows
            || !Equals((rows as IDataRowHolder)?.DataStrategy)
            || DataRowHolder.TestDataType != typeof(TTestData)
            || rows.FirstOrDefault() is not ITestDataRow)
        {
            WithExpected =
                _expectedResultType?.IsAssignableFrom(
                    typeof(TTestData));

            InitDataRowHolder(testData);
            return false;
        }

        if ((rows as IEnumerable<INamedTestCase>)!.Any(testData.Equals))
        {
            return false;
        }

        testDataRow = CreateTestDataRow(testData);
        return testDataRow != default;
    }
    #endregion
    #endregion

    #region Add
    protected void Add<T1>(
        string definition,
        string expected,
        T1? arg1)
    => Add(CreateTestData(
        definition,
        expected,
        arg1));

    protected void Add<T1, T2>(
        string definition,
        string expected,
        T1? arg1, T2? arg2)
    => Add(CreateTestData(
        definition,
        expected,
        arg1, arg2));

    protected void Add<T1, T2, T3>(
        string definition,
        string expected,
        T1? arg1, T2? arg2, T3? arg3)
    => Add(CreateTestData(
        definition,
        expected,
        arg1, arg2, arg3));

    protected void Add<T1, T2, T3, T4>(
        string definition,
        string expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4)
    => Add(CreateTestData(
        definition,
        expected,
        arg1, arg2, arg3, arg4));

    protected void Add<T1, T2, T3, T4, T5>(
        string definition,
        string expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5)
    => Add(CreateTestData(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5));

    protected void Add<T1, T2, T3, T4, T5, T6>(
        string definition,
        string expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6)
    => Add(CreateTestData(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6));

    protected void Add<T1, T2, T3, T4, T5, T6, T7>(
        string definition,
        string expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7)
    => Add(CreateTestData(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6, arg7));

    protected void Add<T1, T2, T3, T4, T5, T6, T7, T8>(
        string definition,
        string expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8)
    => Add(CreateTestData(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8));

    protected void Add<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
        string definition,
        string expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8, T9? arg9)
    => Add(CreateTestData(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9));
    #endregion

    #region AddReturns
    protected void AddReturns<TStruct, T1>(
        string definition,
        TStruct expected,
        T1? arg1)
    where TStruct : struct
    => Add(CreateTestDataReturns(
        definition,
        expected,
        arg1));

    protected void AddReturns<TStruct, T1, T2>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2)
    where TStruct : struct
    => Add(CreateTestDataReturns(
        definition,
        expected,
        arg1, arg2));

    protected void AddReturns<TStruct, T1, T2, T3>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2, T3? arg3)
    where TStruct : struct
    => Add(CreateTestDataReturns(
        definition,
        expected,
        arg1, arg2, arg3));

    protected void AddReturns<TStruct, T1, T2, T3, T4>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4)
    where TStruct : struct
    => Add(CreateTestDataReturns(
        definition,
        expected,
        arg1, arg2, arg3, arg4));

    protected void AddReturns<TStruct, T1, T2, T3, T4, T5>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5)
    where TStruct : struct
    => Add(CreateTestDataReturns(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5));

    protected void AddReturns<TStruct, T1, T2, T3, T4, T5, T6>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6)
    where TStruct : struct
    => Add(CreateTestDataReturns(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6));

    protected void AddReturns<TStruct, T1, T2, T3, T4, T5, T6, T7>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7)
    where TStruct : struct
    => Add(CreateTestDataReturns(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6, arg7));

    protected void AddReturns<TStruct, T1, T2, T3, T4, T5, T6, T7, T8>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8)
    where TStruct : struct
    => Add(CreateTestDataReturns(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8));

    protected void AddReturns<TStruct, T1, T2, T3, T4, T5, T6, T7, T8, T9>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8, T9? arg9)
    where TStruct : struct
    => Add(CreateTestDataReturns(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9));
    #endregion

    #region AddThrows
    protected void AddThrows<TException, T1>(
        string definition,
        TException expected,
        T1? arg1)
    where TException : Exception
    => Add(CreateTestDataThrows(
        definition,
        expected,
        arg1));

    protected void AddThrows<TException, T1, T2>(
        string definition,
        TException expected,
        T1? arg1, T2? arg2)
    where TException : Exception
    => Add(CreateTestDataThrows(
        definition,
        expected,
        arg1, arg2));

    protected void AddThrows<TException, T1, T2, T3>(
        string definition,
        TException expected,
        T1? arg1, T2? arg2, T3? arg3)
    where TException : Exception
    => Add(CreateTestDataThrows(
        definition,
        expected,
        arg1, arg2, arg3));

    protected void AddThrows<TException, T1, T2, T3, T4>(
        string definition,
        TException expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4)
    where TException : Exception
    => Add(CreateTestDataThrows(
        definition,
        expected,
        arg1, arg2, arg3, arg4));

    protected void AddThrows<TException, T1, T2, T3, T4, T5>(
        string definition,
        TException expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5)
    where TException : Exception
    => Add(CreateTestDataThrows(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5));

    protected void AddThrows<TException, T1, T2, T3, T4, T5, T6>(
        string definition,
        TException expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6)
    where TException : Exception
    => Add(CreateTestDataThrows(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6));

    protected void AddThrows<TException, T1, T2, T3, T4, T5, T6, T7>(
        string definition,
        TException expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7)
    where TException : Exception
    => Add(CreateTestDataThrows(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6, arg7));

    protected void AddThrows<TException, T1, T2, T3, T4, T5, T6, T7, T8>(
        string definition,
        TException expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8)
    where TException : Exception
    => Add(CreateTestDataThrows(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8));

    protected void AddThrows<TException, T1, T2, T3, T4, T5, T6, T7, T8, T9>(
        string definition,
        TException expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8, T9? arg9)
    where TException : Exception
    => Add(CreateTestDataThrows(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9));
    #endregion

    #region GetTestDataType
    protected Type? GetTestDataType()
    => DataRowHolder?.TestDataType;
    #endregion

    #region Abstract methods
    protected abstract ITestDataRow<TRow, TTestData> CreateTestDataRow<TTestData>(TTestData testData)
    where TTestData : notnull, ITestData;

    protected abstract void InitDataRowHolder<TTestData>(TTestData testData)
    where TTestData : notnull, ITestData;
    #endregion
    #endregion
    #endregion
}
