// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.DynamicDataSources;

/// <summary>
/// Provides a thread-safe base for dynamic test data sources.
/// Implements <see cref="IDataStrategy"/> and serves as strategy controller
/// for test data generation with temporary strategy overrides.
/// </summary>
/// <remarks>
/// <para>
/// Implements a memento pattern for temporarily modifying data strategy parameters (ArgsCode and PropsCode)
/// within a specific scope. Changes automatically revert when the scope exits.
/// </para>
/// <para>
/// Key features:
/// <list type="bullet">
///   <item>Thread-safe operation using <see cref="AsyncLocal{T}"/> for async/await support</item>
///   <item>Scoped strategy modifications via disposable mementos</item>
///   <item>Default strategy fallback behavior</item>
///   <item>Value equality based on strategy configuration</item>
/// </list>
/// </para>
/// </remarks>
public abstract class DynamicDataSource : IDataStrategy
{
    #region Embedded DataStrategyMemento Class
    /// <summary>
    /// Represents a snapshot of strategy state that can be temporarily applied and reverted.
    /// </summary>
    private sealed class DataStrategyMemento : IDisposable
    {
        private readonly DynamicDataSource _dataSource;
        private readonly ArgsCode? _tempArgsCodeValue;
        private readonly PropsCode? _tempPropsCodeValue;
        private bool _disposed = false;

        /// <summary>
        /// Captures current state and applies new strategy values.
        /// </summary>
        internal DataStrategyMemento(
            DynamicDataSource dataSource,
            ArgsCode argsCode,
            PropsCode propsCode)
        {
            _dataSource = dataSource
                ?? throw new ArgumentNullException(nameof(dataSource));

            _tempArgsCodeValue = _dataSource._tempArgsCode.Value;
            _dataSource._tempArgsCode.Value = argsCode.Defined(nameof(argsCode));

            _tempPropsCodeValue = _dataSource._tempPropsCode.Value;
            _dataSource._tempPropsCode.Value = propsCode.Defined(nameof(propsCode));
        }

        /// <summary>
        /// Restores the previous strategy values.
        /// </summary>
        public void Dispose()
        {
            if (_disposed) return;
            _dataSource._tempArgsCode.Value = _tempArgsCodeValue;
            _dataSource._tempPropsCode.Value = _tempPropsCodeValue;
            _disposed = true;
        }
    }
    #endregion

    #region Fields
    private readonly ArgsCode _argsCode;
    private readonly PropsCode _propsCode;
    private readonly AsyncLocal<ArgsCode?> _tempArgsCode = new();
    private readonly AsyncLocal<PropsCode?> _tempPropsCode = new();
    #endregion

    #region Properties
    /// <summary>
    /// Gets the currently active <see cref="ArgsCode"/>, preferring any temporary override.
    /// </summary>
    /// <value>
    /// The temporary <see cref="ArgsCode"/> set, otherwise the default <see cref="Statics.ArgsCode"/>.
    /// </value>
    public ArgsCode ArgsCode => _tempArgsCode.Value ?? _argsCode;

    /// <summary>
    /// Gets the currently active <see cref="PropsCode"/>, preferring any temporary override.
    /// </summary>
    /// <value>
    /// The temporary <see cref="PropsCode"/> if set, otherwise the default <see cref="Statics.PropsCode"/>.
    /// </value>
    public PropsCode PropsCode => _tempPropsCode.Value ?? _propsCode;
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance with default strategy values.
    /// </summary>
    /// <param name="argsCode">The default argument processing mode.</param>
    /// <param name="propsCode">The default currentPropValue inclusion mode.</param>
    /// <exception cref="ArgumentNullException">
    /// Thrown if either parameter is null.
    /// </exception>
    protected DynamicDataSource(ArgsCode argsCode, PropsCode propsCode)
    {
        _argsCode = argsCode.Defined(nameof(argsCode));
        _propsCode = propsCode.Defined(nameof(propsCode));
        _tempArgsCode.Value = null;
        _tempPropsCode.Value = null;
    }
    #endregion

    #region Methods
    #region Protected methods
    /// <summary>
    /// Executes a generator function with optional temporary strategy overrides, allowing dynamic data customization.  
    /// Designed for use in derivatives of <see cref="DynamicObjectArraySource"/>..
    /// </summary>
    /// <typeparam name="T">The type of data to generate.</typeparam>
    /// <param name="dataGenerator">The function to execute.</param>
    /// <param name="paramName">Parameter name for error reporting.</param>
    /// <param name="argsCode">Optional temporary ArgsCode override.</param>
    /// <param name="propsCode">Optional temporary PropsCode override.</param>
    /// <returns>The generated data.</returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown if dataGenerator is null.
    /// </exception>
    /// <remarks>
    /// <para>
    /// Only applies temporary overrides when they differ from current values.
    /// Minimizes memento creation when possible.
    /// </para>
    /// </remarks>
    protected T WithOptionalDataStrategy<T>(
        [NotNull] Func<T> dataGenerator,
        string paramName,
        ArgsCode? argsCode,
        PropsCode? propsCode)
    {
        ArgumentNullException.ThrowIfNull(dataGenerator, paramName);

        if (codeUnchanged(argsCode, ArgsCode) &&
            codeUnchanged(propsCode, PropsCode))
        {
            return dataGenerator();
        }

        using var memento = new DataStrategyMemento(
            this,
            argsCode ?? ArgsCode,
            propsCode ?? PropsCode);

        return dataGenerator();

        #region Local methods
        static bool codeUnchanged<TCode>(
            TCode? nullableParam,
            TCode currentPropValue)
        where TCode : struct, Enum
        => nullableParam?.Equals(currentPropValue) != false;
        #endregion
    }
    #endregion

    #region Public methods
    /// <inheritdoc/>
    public bool Equals(IDataStrategy? other)
        => other is not null
            && ArgsCode == other.ArgsCode
            && PropsCode == other.PropsCode;

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => obj is IDataStrategy other && Equals(other);

    /// <inheritdoc/>
    public override int GetHashCode()
        => HashCode.Combine(ArgsCode, PropsCode);
    #endregion
    #endregion
}

/// <summary>
/// Abstract base class for dynamic test data sources that manage typed data holders.
/// </summary>
/// <typeparam name="TDataHolder">The type of data holder used to store test cases (must be a class).</typeparam>
/// <remarks>
/// <para>
/// Extends <see cref="DynamicDataSource"/> with:
/// <list type="bullet">
///   <item>Typed data holder management</item>
///   <item>Test case registration methods</item>
///   <item>Holder initialization/reset capabilities</item>
/// </list>
/// </para>
/// <para>
/// Provides three categories of test case registration:
/// <list type="bullet">
///   <item>Standard cases with string expectations</item>
///   <item>Value-returning cases with struct expectations</item>
///   <item>Exception-throwing cases</item>
/// </list>
/// </para>
/// </remarks>
public abstract class DynamicDataSource<TDataHolder>(ArgsCode argsCode, PropsCode propsCode)
    : DynamicDataSource(argsCode, propsCode)
    where TDataHolder : class
{
    /// <summary>
    /// Gets or sets the current data holder instance.
    /// </summary>
    protected TDataHolder? DataHolder { get; set; }

    /// <summary>
    /// Resets the current data holder to its default state.
    /// </summary>
    public virtual void ResetDataHolder()
    => DataHolder = default;

    #region Protected methods
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

    #region Abstract methods
    /// <summary>
    /// Adds test data to the data holder.
    /// </summary>
    /// <typeparam name="TTestData">Type of test data (must implement <see cref="ITestData"/> and be non-nullable).</typeparam>
    /// <param name="testData">The test data to add.</param>
    protected abstract void Add<TTestData>(TTestData testData)
        where TTestData : notnull, ITestData;

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