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
public abstract class DynamicDataSource
: IDataStrategy
{
    #region Fields
    private readonly ArgsCode _argsCode;
    private readonly PropertyCode _propertyCode;

    private readonly AsyncLocal<ArgsCode?> _tempArgsCode = new();
    private readonly AsyncLocal<PropertyCode?> _tempPropertyCode = new();

    #endregion

    #region Properties
    /// <summary>
    /// Gets the active ArgsCode, preferring any temporary override value.
    /// </summary>
    /// <value>The current ArgsCode for argument conversion.</value>
    public ArgsCode ArgsCode
    => _tempArgsCode.Value ?? _argsCode;

    public PropertyCode PropertyCode
    => _tempPropertyCode.Value ?? _propertyCode;
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes the data source with a default argument code.
    /// </summary>
    /// <param name="argsCode">The default argument code (required).</param>
    /// <exception cref="ArgumentNullException">Thrown if propertyCode is null.</exception>
    protected DynamicDataSource(ArgsCode argsCode, PropertyCode propertyCode)
    {
        _argsCode = argsCode.Defined(nameof(argsCode));
        _tempArgsCode.Value = null;

        _propertyCode = propertyCode.Defined(nameof(propertyCode));
        _tempPropertyCode.Value = null;
    }
    #endregion

    #region Embedded ArgsCodeMemento Class
    /// <summary>
    /// Disposable context for temporary ArgsCode overrides.
    /// </summary>
    private sealed class DataStrategyMemento : IDisposable
    {
        #region Fields  
        [NotNull]
        private readonly DynamicDataSource _dataSource;
        private readonly ArgsCode? _tempArgsCodeValue;
        private readonly PropertyCode? _tempPropertyCodeValue;
        private bool _disposed = false;
        #endregion

        #region Constructors
        internal DataStrategyMemento(
            DynamicDataSource dataSource,
            ArgsCode argsCode,
            PropertyCode propertyCode)
        {
            _dataSource = dataSource ?? throw new ArgumentNullException(nameof(dataSource));

            _tempArgsCodeValue = _dataSource._tempArgsCode.Value;
            _dataSource._tempArgsCode.Value = argsCode.Defined(nameof(argsCode));

            _tempPropertyCodeValue = _dataSource._tempPropertyCode.Value;
            _dataSource._tempPropertyCode.Value = propertyCode.Defined(nameof(propertyCode));
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
            _dataSource._tempPropertyCode.Value = _tempPropertyCodeValue;
            _disposed = true;
        }
        #endregion
    }
    #endregion

    #region WithOptionalDataStrategy
    protected T WithOptionalDataStrategy<T>(
        [NotNull] Func<T> dataGenerator,
        string paramName,
        ArgsCode? argsCode,
        PropertyCode? propertyCode)
    {
        ArgumentNullException.ThrowIfNull(
            dataGenerator,
            paramName);

        var argsCodeMathches =
            !argsCode.HasValue
            || argsCode.Value == ArgsCode;

        var propertyCodeMatches
            = !propertyCode.HasValue
            || propertyCode.Value == PropertyCode;

        if (argsCodeMathches && propertyCodeMatches)
        {
            return dataGenerator();
        }

        if (propertyCodeMatches)
        {
            using (new DataStrategyMemento(
                this,
                argsCode!.Value,
                PropertyCode))
            {
                return dataGenerator();
            }
        }

        if (argsCodeMathches)
        {
            using (new DataStrategyMemento(
                this,
                ArgsCode,
                propertyCode!.Value))
            {
                return dataGenerator();
            }
        }

        using (new DataStrategyMemento(
            this,
            argsCode!.Value,
            propertyCode!.Value))
        {
            return dataGenerator();
        }
    }
    #endregion

    #region Equals
    /// <summary>
    /// Determines if another data strategy matches this instance's configuration.
    /// </summary>
    /// <param name="other">The strategy to compare (may be null).</param>
    /// <returns>
    /// True if other strategy has matching ArgsCode and PropertyCode values.
    /// </returns>
    public bool Equals(IDataStrategy? other)
    => other is not null
        && ArgsCode == other.ArgsCode
        && PropertyCode == other.PropertyCode;

    /// <summary>
    /// Determines if an object is an equivalent data strategy.
    /// </summary>
    /// <param name="obj">The object to compare.</param>
    /// <returns>
    /// True if obj is an IDataStrategy with matching configuration.
    /// </returns>
    public override bool Equals(object? obj)
    => obj is IDataStrategy other
        && Equals(other);
    #endregion

    #region GetHashCode
    /// <summary>
    /// Gets a hash code representing this strategy's configuration.
    /// </summary>
    /// <returns>
    /// Combined hash code of ArgsCode and PropertyCode values.
    /// </returns>
    public override int GetHashCode()
    => HashCode.Combine(ArgsCode, PropertyCode);
    #endregion
}

public abstract class DynamicDataSource<TDataHolder>(ArgsCode argsCode, PropertyCode propertyCode)
: DynamicDataSource(argsCode, propertyCode)
where TDataHolder : class
{
    private readonly AsyncLocal<TDataHolder?> _tempDataHolder = new();
    private TDataHolder? _dataHolder;

    protected Type? TestDataType { get; set; }

    protected TDataHolder? DataHolder
    {
        get => _tempDataHolder.Value ?? _dataHolder;
        set => _dataHolder = value;
    }

    public virtual void ResetDataHolder()
        => DataHolder = default;

    #region DataHolderMemento
    private sealed class DataHolderMemento : IDisposable
    {
        private readonly DynamicDataSource<TDataHolder> _dataSource;
        private readonly TDataHolder? _dataSourceDataHolder;
        private bool _disposed = false;

        internal DataHolderMemento(
            DynamicDataSource<TDataHolder> dataSource,
            TDataHolder? tempDataHolder)
        {
            _dataSource = dataSource ?? throw new ArgumentNullException(nameof(dataSource));
            _dataSourceDataHolder = _dataSource.DataHolder;
            _dataSource._tempDataHolder.Value = tempDataHolder;
        }

        public void Dispose()
        {
            if (_disposed) return;

            _dataSource._tempDataHolder.Value
                = _dataSourceDataHolder;
            _disposed = true;
        }
    }
    #endregion

    //protected T WithOptionalDataHolder<T>(
    //    [NotNull] Func<T> dataGenerator,
    //    string paramName,
    //    TDataHolder dataHolder,
    //    ArgsCode? argsCode,
    //    PropertyCode? propertyCode)
    //{
    //    ArgumentNullException.ThrowIfNull(
    //        dataGenerator,
    //        paramName);

    //    using (new DataHolderMemento(this, dataHolder))
    //    {
    //        return WithOptionalDataStrategy(
    //            dataGenerator,
    //            paramName,
    //            argsCode,
    //            propertyCode);
    //    }
    //}

    protected void WithOptionalDataHolder<TTestData>(
        [NotNull] Action<TTestData> addTestData,
        string paramName,
        TTestData testData,
        TDataHolder dataHolder)
    where TTestData : notnull, ITestData
    {
        ArgumentNullException.ThrowIfNull(
            addTestData,
            paramName);

        using (new DataHolderMemento(this, dataHolder))
        {
            addTestData(testData);
        }
    }

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

    protected abstract void Add<TTestData>(TTestData testData)
    where TTestData : notnull, ITestData;

    protected abstract void InitDataHolder<TTestData>(TTestData testData)
    where TTestData : notnull, ITestData;
}
