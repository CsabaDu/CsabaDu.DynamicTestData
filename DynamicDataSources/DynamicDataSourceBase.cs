// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

using CsabaDu.DynamicTestData.DynamicDataSources.DynamicObjectArraySources;

namespace CsabaDu.DynamicTestData.DynamicDataSources;

/// <summary>
/// An base class that provides a dynamic data source with the ability to temporarily override argument codes.
/// </summary>
public abstract class DynamicDataSourceBase
: IDataStrategy
{
    #region Fields
    private readonly ArgsCode _argsCode;
    private readonly AsyncLocal<ArgsCode?> _tempArgsCode = new();


    #region Test helpers
    internal const string ArgsCodeName = nameof(_argsCode);
    internal const string TempArgsCodeName = nameof(_tempArgsCode);
    internal const string DisposableMementoName = nameof(DisposableMemento);
    #endregion
    #endregion

    #region Properties
    /// <summary>
    /// Gets the current ArgsCode value used for argument conversion,
    /// which is either the temporary override value or the default value.
    /// </summary>
    public ArgsCode ArgsCode
    => _tempArgsCode.Value ?? _argsCode;

    public abstract bool? WithExpected { get; init; }
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="DynamicArgs"/> class with the specified ArgsCode.
    /// </summary>
    /// <param name="argsCode">The default ArgsCode to use when no override is specified.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="argsCode"/> is null.</exception>
    protected DynamicDataSourceBase(ArgsCode argsCode)
    {
        _argsCode = argsCode.Defined(nameof(argsCode));
        _tempArgsCode.Value = null;
    }
    #endregion

    #region Embedded DisposableMemento Cless
    /// <summary>
    /// A disposable class that manages temporary ArgsCode overrides and restores the previous value when disposed.
    /// </summary>
    private sealed class DisposableMemento : IDisposable
    {
        #region Fields  
        [NotNull]
        private readonly DynamicDataSourceBase _dataSource;
        private readonly ArgsCode? _tempArgsCodeValue;
        private bool _disposed = false;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="DisposableMemento"/> class.
        /// </summary>
        /// <param name="dataSource">The enclosing data source to manage overrides for.</param>
        /// <param name="argsCode">The new ArgsCode to temporarily apply.</param>
        internal DisposableMemento(DynamicDataSourceBase dataSource, ArgsCode argsCode)
        {
            _dataSource = dataSource ?? throw new ArgumentNullException(nameof(dataSource));
            _tempArgsCodeValue = _dataSource._tempArgsCode.Value;
            _dataSource._tempArgsCode.Value = argsCode.Defined(nameof(argsCode));
        }
        #endregion

        #region Methods
        /// <summary>
        /// Restores the previous ArgsCode value.
        /// </summary>
        public void Dispose()
        {
            if (_disposed) return;

            _dataSource._tempArgsCode.Value = _tempArgsCodeValue;
            _disposed = true;
        }
        #endregion
    }
    #endregion

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
    => TestData.GetDisplayName(
        testMethodName,
        args?.FirstOrDefault());
    #endregion

    #region TestDataToParams
    /// <inheritdoc cref="TestDataToParams(ITestData, ArgsCode, out string) string"/>
    /// <param name="WithExpected">A value indicating whether the expected result should be included in the returned parameters.</param>
    public static object?[] TestDataToParams(
        [NotNull] ITestData testData,
        ArgsCode argsCode,
        bool WithExpected,
        out string testCaseName)
    {
        testCaseName = testData?.TestCaseName
            ?? throw new ArgumentNullException(nameof(testData));

        return testData.ToParams(
            argsCode,
            WithExpected);
    }

    /// <summary>
    /// Converts test data into an array of parameters for use in test execution.
    /// </summary>
    /// <param name="testData">The test data to be converted. Cannot be <see langword="null"/>.</param>
    /// <param name="argsCode">Specifies the argument configuration to use when converting the test data.</param>
    /// <param name="testCaseName">When this method returns, contains the test case identifier from the provided <paramref name="testData"/>.</param>
    /// <returns>An array of objects representing the parameters derived from the test data.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="testData"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidEnumArgumentException">Thrown if <paramref name="argsCode"/> is not a valid value.</exception>
    public static object?[] TestDataToParams(
        [NotNull] ITestData testData,
        ArgsCode argsCode,
        out string testCaseName)
    => TestDataToParams(
        testData,
        argsCode,
        testData is IExpected,
        out testCaseName);
    #endregion

    #region WithOptionalArgsCode
    /// <summary>
    /// Executes a test data generator within an optional memento pattern context.
    /// </summary>
    /// <typeparam name="TDataSource">The type of dynamic data source, must inherit from <see cref="DynamicArgs"/></typeparam>
    /// <typeparam name="T">The type of data to generate, must be non-nullable</typeparam>
    /// <param name="dataSource">The data source to use for memento creation (cannot be null)</param>
    /// <param name="testDataGenerator">The function that generates test data (cannot be null)</param>
    /// <param name="argsCode">
    /// The optional memento state code. When null, executes without memento pattern.
    /// When specified, creates a <see cref="DisposableMemento"/> for the operation.
    /// </param>
    /// <returns>The result of the test data generator</returns>
    /// <remarks>
    /// <para>
    /// This method provides thread-safe execution of data generation operations with optional
    /// state preservation through the memento pattern.
    /// </para>
    /// <para>
    /// When <paramref name="argsCode"/> is specified, the operation will be wrapped in a
    /// disposable memento context that automatically cleans up after execution.
    /// </para>
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="dataSource"/> or <paramref name="testDataGenerator"/> is null
    /// </exception>
    protected static T WithOptionalArgsCode<TDataSource, T>(
        [NotNull] TDataSource dataSource,
        [NotNull] Func<T> testDataGenerator,
        ArgsCode? argsCode)
    where TDataSource : DynamicDataSourceBase
    where T : notnull
    {
        if (!argsCode.HasValue)
        {
            return testDataGenerator();
        }

        using (new DisposableMemento(dataSource, argsCode.Value))
        {
            return testDataGenerator();
        }
    }

    /// <summary>
    /// Executes a test data processor within an optional memento pattern context.
    /// </summary>
    /// <typeparam name="TDataSource">The type of dynamic data source, must inherit from <see cref="DynamicArgs"/></typeparam>
    /// <param name="dataSource">The data source to use for memento creation (cannot be null)</param>
    /// <param name="testDataProcessor">The action that processes test data (cannot be null)</param>
    /// <param name="argsCode">
    /// The optional memento state code. When null, executes without memento pattern.
    /// When specified, creates a <see cref="DisposableMemento"/> for the operation.
    /// </param>
    /// <remarks>
    /// <para>
    /// This method provides thread-safe execution of data processing operations with optional
    /// state preservation through the memento pattern.
    /// </para>
    /// <para>
    /// The <typeparamref name="T"/> parameter ensures type safety while not being used directly
    /// in the method body.
    /// </para>
    /// <para>
    /// When <paramref name="argsCode"/> is specified, the operation will be wrapped in a
    /// disposable memento context that automatically cleans up after execution.
    /// </para>
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="dataSource"/> or <paramref name="testDataProcessor"/> is null
    /// </exception>
    protected static void WithOptionalArgsCode<TDataSource>(
        [NotNull] TDataSource dataSource,
        [NotNull] Action testDataProcessor,
        ArgsCode? argsCode)
    where TDataSource : DynamicDataSourceBase
    {
        if (!argsCode.HasValue)
        {
            testDataProcessor();
            return;
        }

        using (new DisposableMemento(dataSource, argsCode.Value))
        {
            testDataProcessor();
        }
    }
    #endregion
}

public abstract class DynamicDataSourceBase<TRow>(ArgsCode argsCode, bool? withExpected)
: DynamicDataSourceBase(argsCode),
IRows<TRow>
where TRow : notnull
{
    #region Properties
    protected IDataRowHolder<TRow>? DataRowHolder { get; set; }

    public override sealed bool? WithExpected { get; init; }
        = withExpected;
    #endregion

    #region Methods
    #region GetRows
    public IEnumerable<TRow>? GetRows()
    => DataRowHolder?.GetRows();
    #endregion

    #region ResetDataRowCollection
    public void ResetDataRowCollection()
    => DataRowHolder = null;
    #endregion

    #region AddOptional
    /// <summary>
    /// Executes the provided action with an optional temporary ArgsCode override.
    /// </summary>
    /// <param name="add"></param>
    /// <param name="argsCode"></param>
    protected void AddOptional(Action add, ArgsCode? argsCode)
    {
        ArgumentNullException.ThrowIfNull(add, nameof(add));
        WithOptionalArgsCode(this, add, argsCode);
    }
    #endregion

    #region Add
    #region Private Add
    private void Add<TTestData>(TTestData testData)
    where TTestData : notnull, ITestData
    {
        if (DataRowHolder is not
            IDataRowHolder<TTestData, TRow> typedCollection)
        {
            InitDataRowHolder(testData);
            return;
        }

        if (typedCollection.Any(testData.Equals))
        {
            return;
        }

        var testDataRow = CreateTestDataRow(testData);
        typedCollection.Add(testDataRow);
    }
    #endregion

    #region Protected Add
    protected void Add<T1>(
        string definition,
        string expected,
        T1? arg1)
    => Add(new TestData<T1>(
        definition,
        expected,
        arg1));

    protected void Add<T1, T2>(
        string definition,
        string expected,
        T1? arg1, T2? arg2)
    => Add(new TestData<T1, T2>(
        definition,
        expected,
        arg1, arg2));

    protected void Add<T1, T2, T3>(
        string definition,
        string expected,
        T1? arg1, T2? arg2, T3? arg3)
    => Add(new TestData<T1, T2, T3>(
        definition,
        expected,
        arg1, arg2, arg3));

    protected void Add<T1, T2, T3, T4>(
        string definition,
        string expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4)
    => Add(new TestData<T1, T2, T3, T4>(
        definition,
        expected,
        arg1, arg2, arg3, arg4));

    protected void Add<T1, T2, T3, T4, T5>(
        string definition,
        string expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5)
    => Add(new TestData<T1, T2, T3, T4, T5>(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5));

    protected void Add<T1, T2, T3, T4, T5, T6>(
        string definition,
        string expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6)
    => Add(new TestData<T1, T2, T3, T4, T5, T6>(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6));

    protected void Add<T1, T2, T3, T4, T5, T6, T7>(
        string definition,
        string expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7)
    => Add(new TestData<T1, T2, T3, T4, T5, T6, T7>(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6, arg7));

    protected void Add<T1, T2, T3, T4, T5, T6, T7, T8>(
        string definition,
        string expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8)
    => Add(new TestData<T1, T2, T3, T4, T5, T6, T7, T8>(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8));

    protected void Add<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
        string definition,
        string expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8, T9? arg9)
    => Add(new TestData<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9));
    #endregion
    #endregion

    #region AddReturns
    protected void AddReturns<TStruct, T1>(
        string definition,
        TStruct expected,
        T1? arg1)
    where TStruct : struct
    => Add(new TestDataReturns<TStruct, T1>(
        definition,
        expected,
        arg1));

    protected void AddReturns<TStruct, T1, T2>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2)
    where TStruct : struct
    => Add(new TestDataReturns<TStruct, T1, T2>(
        definition,
        expected,
        arg1, arg2));

    protected void AddReturns<TStruct, T1, T2, T3>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2, T3? arg3)
    where TStruct : struct
    => Add(new TestDataReturns<TStruct, T1, T2, T3>(
        definition,
        expected,
        arg1, arg2, arg3));

    protected void AddReturns<TStruct, T1, T2, T3, T4>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4)
    where TStruct : struct
    => Add(new TestDataReturns<TStruct, T1, T2, T3, T4>(
        definition,
        expected,
        arg1, arg2, arg3, arg4));

    protected void AddReturns<TStruct, T1, T2, T3, T4, T5>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5)
    where TStruct : struct
    => Add(new TestDataReturns<TStruct, T1, T2, T3, T4, T5>(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5));

    protected void AddReturns<TStruct, T1, T2, T3, T4, T5, T6>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6)
    where TStruct : struct
    => Add(new TestDataReturns<TStruct, T1, T2, T3, T4, T5, T6>(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6));

    protected void AddReturns<TStruct, T1, T2, T3, T4, T5, T6, T7>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7)
    where TStruct : struct
    => Add(new TestDataReturns<TStruct, T1, T2, T3, T4, T5, T6, T7>(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6, arg7));

    protected void AddReturns<TStruct, T1, T2, T3, T4, T5, T6, T7, T8>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8)
    where TStruct : struct
    => Add(new TestDataReturns<TStruct, T1, T2, T3, T4, T5, T6, T7, T8>(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8));

    protected void AddReturns<TStruct, T1, T2, T3, T4, T5, T6, T7, T8, T9>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8, T9? arg9)
    where TStruct : struct
    => Add(new TestDataReturns<TStruct, T1, T2, T3, T4, T5, T6, T7, T8, T9>(
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
    => Add(new TestDataThrows<TException, T1>(
        definition,
        expected,
        arg1));

    protected void AddThrows<TException, T1, T2>(
        string definition,
        TException expected,
        T1? arg1, T2? arg2)
    where TException : Exception
    => Add(new TestDataThrows<TException, T1, T2>(
        definition,
        expected,
        arg1, arg2));

    protected void AddThrows<TException, T1, T2, T3>(
        string definition,
        TException expected,
        T1? arg1, T2? arg2, T3? arg3)
    where TException : Exception
    => Add(new TestDataThrows<TException, T1, T2, T3>(
        definition,
        expected,
        arg1, arg2, arg3));

    protected void AddThrows<TException, T1, T2, T3, T4>(
        string definition,
        TException expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4)
    where TException : Exception
    => Add(new TestDataThrows<TException, T1, T2, T3, T4>(
        definition,
        expected,
        arg1, arg2, arg3, arg4));

    protected void AddThrows<TException, T1, T2, T3, T4, T5>(
        string definition,
        TException expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5)
    where TException : Exception
    => Add(new TestDataThrows<TException, T1, T2, T3, T4, T5>(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5));

    protected void AddThrows<TException, T1, T2, T3, T4, T5, T6>(
        string definition,
        TException expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6)
    where TException : Exception
    => Add(new TestDataThrows<TException, T1, T2, T3, T4, T5, T6>(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6));

    protected void AddThrows<TException, T1, T2, T3, T4, T5, T6, T7>(
        string definition,
        TException expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7)
    where TException : Exception
    => Add(new TestDataThrows<TException, T1, T2, T3, T4, T5, T6, T7>(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6, arg7));

    protected void AddThrows<TException, T1, T2, T3, T4, T5, T6, T7, T8>(
        string definition,
        TException expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8)
    where TException : Exception
    => Add(new TestDataThrows<TException, T1, T2, T3, T4, T5, T6, T7, T8>(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8));

    protected void AddThrows<TException, T1, T2, T3, T4, T5, T6, T7, T8, T9>(
        string definition,
        TException expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8, T9? arg9)
    where TException : Exception
    => Add(new TestDataThrows<TException, T1, T2, T3, T4, T5, T6, T7, T8, T9>(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9));
    #endregion

    #region Abstract methods
    protected abstract ITestDataRow<TTestData, TRow> CreateTestDataRow<TTestData>(TTestData testData)
    where TTestData : notnull, ITestData;

    protected abstract void InitDataRowHolder<TTestData>(TTestData testData)
    where TTestData : notnull, ITestData;
    #endregion
    #endregion
}