// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.DynamicDataSources;

/// <summary>
/// Abstract base class for dynamic test data sources that manage strongly-typed data rows.
/// </summary>
/// <typeparam name="TDataRowHolder">The type of data holder (must implement <see cref="IDataRowHolder{TRow}"/>).</typeparam>
/// <typeparam name="TRow">The type of data rows produced by this source.</typeparam>
/// <param name="argsCode">The default argument processing strategy.</param>
/// <param name="propsCode">The default property inclusion strategy.</param>
/// <remarks>
/// <para>
/// Combines functionality from:
/// <list type="bullet">
///   <item><see cref="DynamicDataSource{TDataHolder}"/> for base data management</item>
///   <item><see cref="ITestDataRows"/> for test row enumeration</item>
///   <item><see cref="IRows{TRow}"/> for typed row access</item>
/// </list>
/// </para>
/// <para>
/// Key features:
/// <list type="bullet">
///   <item>Type-safe row conversion and retrieval</item>
///   <item>Configurable argument processing</item>
///   <item>Duplicate test case prevention</item>
///   <item>Automatic holder initialization</item>
/// </list>
/// </para>
/// </remarks>
public abstract class DynamicDataRowSource<TDataRowHolder, TRow>(ArgsCode argsCode, PropsCode propsCode)
: DynamicDataSource<TDataRowHolder>(argsCode, propsCode),
    ITestDataRows,
    IRows<TRow>
where TDataRowHolder : class, IDataRowHolder<TRow>
{
    #region Public Methods
    #region GetTestDataRows
    /// <summary>
    /// Retrieves all managed test data rows.
    /// </summary>
    /// <returns>
    /// The complete collection of test data rows, or null if no rows exist.
    /// </returns>
    public IEnumerable<ITestDataRow>? GetTestDataRows()
        => DataHolder?.GetTestDataRows();
    #endregion

    #region GetRows
    /// <summary>
    /// Retrieves converted data rows with optional <see cref="ArgsCode"/> override.
    /// </summary>
    /// <param name="argsCode">Optional argument processing override.</param>
    /// <returns>
    /// The converted data rows, or null if no rows exist.
    /// </returns>
    public IEnumerable<TRow>? GetRows(ArgsCode? argsCode)
        => DataHolder?.GetRows(argsCode);

    /// <summary>
    /// Retrieves converted data rows with optional <see cref="ArgsCode"/> and  <see cref="PropsCode"/> overrides.
    /// </summary>
    /// <param name="argsCode">Argument processing override.</param>
    /// <param name="propsCode">Property inclusion override.</param>
    /// <returns>
    /// The converted data rows, or null if no rows exist.
    /// </returns>
    public IEnumerable<TRow>? GetRows(ArgsCode? argsCode, PropsCode? propsCode)
        => DataHolder?.GetRows(argsCode, propsCode);
    #endregion

    #region GetDataStrategy
    /// <summary>
    /// argument code override.
    /// </summary>
    /// <param name="argsCode">Optional argument processing override.</param>
    /// <returns>
    /// The configured data strategy instance.
    /// </returns>
    public IDataStrategy GetDataStrategy(ArgsCode? argsCode)
        => GetStoredDataStrategy(argsCode, this);

    /// <summary>
    /// Gets the data strategy with argument and property overrides.
    /// </summary>
    /// <param name="argsCode">Argument processing override.</param>
    /// <param name="propsCode">Property inclusion override.</param>
    /// <returns>
    /// The configured data strategy instance.
    /// </returns>
    public IDataStrategy GetDataStrategy(ArgsCode? argsCode, PropsCode? propsCode)
        => GetStoredDataStrategy(argsCode ?? ArgsCode, propsCode ?? PropsCode);
    #endregion
    #endregion

    #region Protected methods
    #region Virtual Add
    /// <summary>
    /// Adds test data to the holder, initializing if necessary and preventing duplicates.
    /// </summary>
    /// <typeparam name="TTestData">The test data type (must implement <see cref="ITestData"/>).</typeparam>
    /// <param name="testData">The test data to add.</param>
    protected override void Add<TTestData>(TTestData testData)
    {
        if (DataHolder is not IDataRowHolder<TRow, TTestData> dataRowHolder)
        {
            InitDataHolder(testData);
            return;
        }

        if (dataRowHolder.Any(testData.Equals))
        {
            return;
        }

        dataRowHolder.Add(testData);
    }
    #endregion

    #region Add (Standard test cases)
    /// <summary>
    /// Adds a standard test case with string expected result and one argument.
    /// </summary>
    /// <typeparam name="T1">Type of the first argument.</typeparam>
    /// <param name="definition">Description of the test scenario.</param>
    /// <param name="expected">Description of the expected result.</param>
    /// <param name="arg1">First argument value.</param>
    protected void Add<T1>(
        string definition,
        string expected,
        T1? arg1)
        => Add(CreateTestData(definition, expected, arg1));

    /// <summary>
    /// Adds a standard test case with string expected result and two arguments.
    /// </summary>
    /// <typeparam name="T1">Type of the first argument.</typeparam>
    /// <typeparam name="T2">Type of the second argument.</typeparam>
    /// <inheritdoc cref="Add{T1}"/>
    protected void Add<T1, T2>(
        string definition,
        string expected,
        T1? arg1, T2? arg2)
        => Add(CreateTestData(definition, expected, arg1, arg2));

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

    #region AddReturns (Value-returning test cases)
    /// <summary>
    /// Adds a test case expecting a value type return with one argument.
    /// </summary>
    /// <typeparam name="TStruct">Type of expected return value (non-nullable struct).</typeparam>
    /// <typeparam name="T1">Type of the first argument.</typeparam>
    /// <param name="definition">Description of the test scenario.</param>
    /// <param name="expected">Expected return value.</param>
    /// <param name="arg1">First argument value.</param>
    protected void AddReturns<TStruct, T1>(
        string definition,
        TStruct expected,
        T1? arg1)
        where TStruct : struct
        => Add(CreateTestDataReturns(definition, expected, arg1));

    /// <summary>
    /// Adds a test case expecting a value type return with two arguments.
    /// </summary>
    /// <typeparam name="TStruct">Type of expected return value.</typeparam>
    /// <typeparam name="T1">Type of the first argument.</typeparam>
    /// <typeparam name="T2">Type of the second argument.</typeparam>
    /// <inheritdoc cref="AddReturns{TStruct, T1}"/>
    protected void AddReturns<TStruct, T1, T2>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2)
        where TStruct : struct
        => Add(CreateTestDataReturns(definition, expected, arg1, arg2));

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

    #region AddThrows (Exception test cases)
    /// <summary>
    /// Adds a test case expecting an exception with one argument.
    /// </summary>
    /// <typeparam name="TException">Type of expected exception.</typeparam>
    /// <typeparam name="T1">Type of the first argument.</typeparam>
    /// <param name="definition">Description of the test scenario.</param>
    /// <param name="expected">Expected exception instance.</param>
    /// <param name="arg1">First argument value.</param>
    protected void AddThrows<TException, T1>(
        string definition,
        TException expected,
        T1? arg1)
        where TException : Exception
        => Add(CreateTestDataThrows(definition, expected, arg1));

    /// <summary>
    /// Adds a test case expecting an exception with two arguments.
    /// </summary>
    /// <typeparam name="TException">Type of expected exception.</typeparam>
    /// <typeparam name="T1">Type of the first argument.</typeparam>
    /// <typeparam name="T2">Type of the second argument.</typeparam>
    /// <inheritdoc cref="AddThrows{TException, T1}"/>
    protected void AddThrows<TException, T1, T2>(
        string definition,
        TException expected,
        T1? arg1, T2? arg2)
        where TException : Exception
        => Add(CreateTestDataThrows(definition, expected, arg1, arg2));

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

    #region abstract methods
    /// <summary>
    /// Initializes the data holder with the first test data instance.
    /// </summary>
    /// <typeparam name="TTestData">Type of test data (must implement ITestData and be non-nullable).</typeparam>
    /// <param name="testData">The test data used for initialization.</param>
    protected abstract void InitDataHolder<TTestData>(TTestData testData)
    where TTestData : notnull, ITestData;
    #endregion
    #endregion
}

/// <summary>
/// Abstract base class for dynamic test data sources with simplified row holder management.
/// </summary>
/// <typeparam name="TRow">The type of data rows produced by this source.</typeparam>
/// <param name="argsCode">The default argument processing strategy.</param>
/// <param name="propsCode">The default property inclusion strategy.</param>
/// <remarks>
/// <para>
/// Specializes <see cref="DynamicDataRowSource{TDataRowHolder, TRow}"/> using <see cref="IDataRowHolder{TRow}"/>
/// as the default holder type, simplifying common use cases.
/// </para>
/// <para>
/// Inherits all functionality from the base class while providing a more focused interface
/// for standard test data scenarios.
/// </para>
/// </remarks>
public abstract class DynamicDataRowSource<TRow>(ArgsCode argsCode, PropsCode propsCode)
    : DynamicDataRowSource<IDataRowHolder<TRow>, TRow>(argsCode, propsCode);