// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.DynamicDataSources;

/// <summary>
/// Base class providing dynamic test data source capabilities with temporary argument code overrides.
/// </summary>
/// <remarks>
/// <para>Manages argument code state through a memento pattern, allowing temporary overrides that automatically revert.</para>
/// <para>Thread-safe implementation using <see cref="AsyncLocal{T}"/> for async/await support.</para>
/// </remarks>
public abstract class DynamicDataSource : IArgsCode
{
    #region Fields
    private readonly ArgsCode _argsCode;
    private readonly AsyncLocal<ArgsCode?> _tempArgsCode = new();
    #endregion

    #region Properties
    /// <summary>
    /// Gets the active ArgsCode, preferring any temporary override value.
    /// </summary>
    /// <value>The current ArgsCode for argument conversion.</value>
    public ArgsCode ArgsCode
    => _tempArgsCode.Value ?? _argsCode;
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes the data source with a default argument code.
    /// </summary>
    /// <param name="argsCode">The default argument code (required).</param>
    /// <exception cref="ArgumentNullException">Thrown if argsCode is null.</exception>
    protected DynamicDataSource(ArgsCode argsCode)
    {
        _argsCode = argsCode.Defined(nameof(argsCode));
        _tempArgsCode.Value = null;
    }
    #endregion

    #region Embedded ArgsCodeMemento Class
    /// <summary>
    /// Disposable context for temporary ArgsCode overrides.
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
        internal ArgsCodeMemento(DynamicDataSource dataSource, ArgsCode argsCode)
        {
            _dataSource = dataSource ?? throw new ArgumentNullException(nameof(dataSource));
            _tempArgsCodeValue = _dataSource._tempArgsCode.Value;
            _dataSource._tempArgsCode.Value = argsCode.Defined(nameof(argsCode));
        }
        #endregion

        #region Methods
        /// <summary>
        /// Restores the previous ArgsCode state.
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

    #region Static methods
    #region GetDisplayName
    /// <summary>
    /// Generates a standardized test case display name.
    /// </summary>
    /// <param name="testMethodName">The test method name (required).</param>
    /// <param name="args">Test arguments (first argument used for description).</param>
    /// <returns>Formatted display name or null if inputs are invalid.</returns>
    /// <remarks>
    /// <para>Format: "{testMethodName}(testData: {firstArgument})"</para>
    /// <para>Used by MSTest DynamicDataAttribute and NUnit TestCaseData.SetName().</para>
    /// </remarks>
    public static string? GetDisplayName(string? testMethodName, params object?[]? args)
    {
        if (string.IsNullOrEmpty(testMethodName)) return null;

        var testCaseName = args?.FirstOrDefault();
        return !string.IsNullOrEmpty(testCaseName?.ToString())
            ? $"{testMethodName}(testData: {testCaseName})"
            : null;
    }
    #endregion

    #region TestDataToParams
    /// <summary>
    /// Converts test data to parameter array with optional expected result inclusion.
    /// </summary>
    /// <param name="testData">The test data to convert (required).</param>
    /// <param name="argsCode">Conversion strategy arguments.</param>
    /// <param name="withExpected">Include expected result in output.</param>
    /// <param name="testCaseName">Output parameter for the generated test case name.</param>
    /// <returns>Parameter array for test invocation.</returns>
    /// <exception cref="ArgumentNullException">Thrown if testData is null.</exception>
    public static object?[] TestDataToParams(
        [NotNull] ITestData testData,
        ArgsCode argsCode,
        bool withExpected,
        out string testCaseName)
    {
        testCaseName = testData?.GetTestCaseName()
            ?? throw new ArgumentNullException(nameof(testData));

        return testData.ToParams(argsCode, withExpected);
    }
    #endregion

    #region WithOptionalArgsCode
    /// <summary>
    /// Executes a generator function with optional temporary ArgsCode context.
    /// </summary>
    /// <typeparam name="T">Result type (non-nullable).</typeparam>
    /// <param name="dataRowGenerator">Data generation function (required).</param>
    /// <param name="paramName">Parameter name for null checking.</param>
    /// <param name="argsCode">Optional temporary ArgsCode.</param>
    /// <returns>The generated data result.</returns>
    /// <remarks>
    /// When argsCode is provided, creates a scoped ArgsCode override that automatically reverts.
    /// </remarks>
    /// <exception cref="ArgumentNullException">Thrown if dataRowGenerator is null.</exception>
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
/// Generic base class for dynamic test data sources with typed rows.
/// </summary>
/// <typeparam name="TRow">The data row type.</typeparam>
/// <param name="argsCode">Default argument conversion code.</param>
/// <param name="expectedResultType">Optional expected result type for validation.</param>
/// <remarks>
/// <para>Manages collections of typed test data rows with conversion strategies.</para>
/// <para>Provides methods for adding test cases with various argument combinations.</para>
/// </remarks>
public abstract class DynamicDataSource<TRow>(ArgsCode argsCode, Type? expectedResultType)
    : DynamicDataSource(argsCode), IDataStrategy, ITestDataRows, IRows<TRow>
{
    #region Fields
    private readonly Type? _expectedResultType = expectedResultType;
    #endregion

    #region Properties
    /// <summary>
    /// Indicates whether expected results should be included in output.
    /// </summary>
    public bool? WithExpected { get; protected set; }

    /// <summary>
    /// Gets or sets the current data row holder.
    /// </summary>
    protected IDataRowHolder<TRow>? DataRowHolder { get; set; }
    #endregion

    #region Methods
    #region Public Methods
    #region Equals
    /// <summary>
    /// Determines if another data strategy matches this instance's configuration.
    /// </summary>
    /// <param name="other">The strategy to compare (may be null).</param>
    /// <returns>
    /// True if other strategy has matching ArgsCode and WithExpected values.
    /// </returns>
    public bool Equals(IDataStrategy? other)
        => other is not null
            && ArgsCode == other.ArgsCode
            && WithExpected == other.WithExpected;

    /// <summary>
    /// Determines if an object is an equivalent data strategy.
    /// </summary>
    /// <param name="obj">The object to compare.</param>
    /// <returns>
    /// True if obj is an IDataStrategy with matching configuration.
    /// </returns>
    public override bool Equals(object? obj)
        => obj is IDataStrategy other && Equals(other);
    #endregion

    #region GetHashCode
    /// <summary>
    /// Gets a hash code representing this strategy's configuration.
    /// </summary>
    /// <returns>
    /// Combined hash code of ArgsCode and WithExpected values.
    /// </returns>
    public override int GetHashCode()
        => HashCode.Combine(ArgsCode, WithExpected);
    #endregion

    #region GetDataStrategy
    /// <summary>
    /// Gets the appropriate data strategy for the given ArgsCode.
    /// </summary>
    /// <param name="argsCode">Optional override ArgsCode.</param>
    /// <returns>
    /// Current strategy if argsCode matches, otherwise a new strategy with the specified code.
    /// </returns>
    public IDataStrategy GetDataStrategy(ArgsCode? argsCode)
    => GetStoredDataStrategy(argsCode, this);
    #endregion

    #region GetTestDataRows
    /// <summary>
    /// Retrieves all stored test data rows.
    /// </summary>
    /// <returns>
    /// Enumerable of test data rows, or null if no rows exist.
    /// </returns>
    public IEnumerable<ITestDataRow>? GetTestDataRows()
    => DataRowHolder?.GetTestDataRows();
    #endregion

    #region GetRows
    /// <summary>
    /// Gets converted test rows using the specified ArgsCode.
    /// </summary>
    /// <param name="argsCode">Optional ArgsCode override for conversion.</param>
    /// <returns>
    /// Enumerable of converted rows, or null if no rows exist.
    /// </returns>
    public IEnumerable<TRow>? GetRows(ArgsCode? argsCode)
    => DataRowHolder?.GetRows(argsCode);
    #endregion

    #region ResetDataRowHolder
    /// <summary>
    /// Clears the current data row holder collection.
    /// </summary>
    public virtual void ResetDataRowHolder()
    => DataRowHolder = null;
    #endregion
    #endregion

    #region Protected methods
    #region Virtual methods
    #region Add
    /// <summary>
    /// Adds a test data instance to the data row holder collection.
    /// </summary>
    /// <typeparam name="TTestData">The type of test data to add, which must implement <see cref="ITestData"/> and be non-nullable.</typeparam>
    /// <param name="testData">The test data instance to add.</param>
    /// <remarks>
    /// <para>
    /// This method attempts to create a new test data row from the provided test data. If successful,
    /// the row is added to the current data row holder if it matches the expected type.
    /// </para>
    /// <para>
    /// The method handles initialization of a new data row holder if the current holder is not
    /// compatible with the provided test data type.
    /// </para>
    /// </remarks>
    protected virtual void Add<TTestData>(TTestData testData)
    where TTestData : notnull, ITestData
    {
        bool rowCreated = TryCreateTestDataRow<ITestDataRow, TTestData>(
            testData,
            out ITestDataRow<TRow, TTestData>? testDataRow);

        if (rowCreated && DataRowHolder is IDataRowHolder<TRow, TTestData> dataRowHolder)
        {
            dataRowHolder.Add(testDataRow!);
        }
    }
    #endregion

    #region TryCreateTestDataRow
    /// <summary>
    /// Attempts to create a test data row from the specified test data.
    /// </summary>
    /// <typeparam name="TDataRow">The expected row interface type.</typeparam>
    /// <typeparam name="TTestData">The test data type.</typeparam>
    /// <param name="testData">The test data to convert.</param>
    /// <param name="testDataRow">Output parameter for the created row.</param>
    /// <returns>
    /// True if row was created, false if existing holder needs initialization.
    /// </returns>
    protected virtual bool TryCreateTestDataRow<TDataRow, TTestData>(
        TTestData testData,
        out ITestDataRow<TRow, TTestData>? testDataRow)
    where TTestData : notnull, ITestData
    {
        Type testDataType = typeof(TTestData);

        bool isValidDataRowHolder =
            DataRowHolder is IEnumerable<TDataRow> &&
            Equals(DataRowHolder.DataStrategy) &&
            GetTestDataType() == testDataType &&
            typeof(TDataRow).IsAssignableTo(typeof(ITestDataRow));

        bool? withExpected =
            _expectedResultType?.IsAssignableFrom(testDataType);

        return TryCreateTestDataRow(
            testData,
            isValidDataRowHolder,
            withExpected,
            out testDataRow);
    }
    #endregion
    #endregion

    #region TryCreateTestDataRow
    /// <summary>
    /// Attempts to create a test data row from the provided test data.
    /// </summary>
    /// <typeparam name="TTestData">The type of test data, which must implement <see cref="ITestData"/> and be non-nullable.</typeparam>
    /// <param name="testData">The test data instance to convert to a row.</param>
    /// <param name="isValidDataRowHolder">Indicates whether the current data row holder is valid for this test data type.</param>
    /// <param name="withExpected">Specifies whether the test data includes an expected result.</param>
    /// <param name="testDataRow">Output parameter for the created test data row.</param>
    /// <returns>
    /// <c>true</c> if a test data row was successfully created; otherwise, <c>false</c>.
    /// </returns>
    /// <remarks>
    /// <para>
    /// This method performs several checks before attempting to create a test data row:
    /// 1. If the current holder is invalid, it initializes a new holder and returns false.
    /// 2. If the test data already exists in the holder (by equality comparison), returns false.
    /// </para>
    /// <para>
    /// If all checks pass, it attempts to create a new row using the holder's factory capability.
    /// </para>
    /// </remarks>
    protected bool TryCreateTestDataRow<TTestData>(
        TTestData testData,
        bool isValidDataRowHolder,
        bool? withExpected,
        out ITestDataRow<TRow, TTestData>? testDataRow)
    where TTestData : notnull, ITestData
    {
        testDataRow = default;

        if (!isValidDataRowHolder)
        {
            WithExpected = withExpected;
            InitDataRowHolder(testData);
            return false;
        }

        if (DataRowHolder is  IEnumerable<INamedTestCase> namedTestCases
            && namedTestCases.Any(testData.Equals))
        {
            return false;
        }

        var factory = DataRowHolder as ITestDataRowFactory<TRow, TTestData>;
        testDataRow = factory?.CreateTestDataRow(testData);

        return testDataRow != default;
    }
    #endregion

    #region Add
    /// <summary>
    /// Adds a test case with string expected result and 1-9 arguments.
    /// </summary>
    /// <typeparam name="T1">First argument type.</typeparam>
    /// <param name="definition">Test case description.</param>
    /// <param name="expected">Expected result string.</param>
    /// <param name="arg1">First argument value.</param>
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
    /// <summary>
    /// Adds a test case with struct expected result and 1-9 arguments.
    /// </summary>
    /// <typeparam name="TStruct">Expected result struct type.</typeparam>
    /// <typeparam name="T1">First argument type.</typeparam>
    /// <param name="definition">Test case description.</param>
    /// <param name="expected">Expected struct value.</param>
    /// <param name="arg1">First argument value.</param>
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
    /// <summary>
    /// Adds a test case expecting an exception with 1-9 arguments.
    /// </summary>
    /// <typeparam name="TException">Expected exception type.</typeparam>
    /// <typeparam name="T1">First argument type.</typeparam>
    /// <param name="definition">Test case description.</param>
    /// <param name="expected">Expected exception instance.</param>
    /// <param name="arg1">First argument value.</param>
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
    /// <summary>
    /// Gets the test data type from the current holder.
    /// </summary>
    /// <returns>The test data type, or null if no holder exists.</returns>
    protected Type? GetTestDataType()
    => DataRowHolder?.TestDataType;
    #endregion

    #region Abstract methods
    /// <summary>
    /// Initializes the data row holder for the specified test data type.
    /// </summary>
    /// <typeparam name="TTestData">The test data type.</typeparam>
    /// <param name="testData">The test data used for initialization.</param>
    protected abstract void InitDataRowHolder<TTestData>(TTestData testData)
    where TTestData : notnull, ITestData;
    #endregion
    #endregion
    #endregion
}
