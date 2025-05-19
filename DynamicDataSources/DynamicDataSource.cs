// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.DynamicDataSources;


/// <summary>
/// An abstract base class that provides a dynamic data source with the ability to temporarily override argument codes.
/// </summary>
public abstract class DynamicDataSource
{
    #region Fields
    private readonly ArgsCode _argsCode;
    private readonly AsyncLocal<ArgsCode?> _tempArgsCode = new();

    private static readonly string? ObjectArrayTypeName =
        Array.Empty<object>().GetType().FullName;

    #endregion

    #region Properties
    /// <summary>
    /// Gets the current ArgsCode value used for argument conversion, which is either the temporary override value or the default value.
    /// </summary>
    protected ArgsCode ArgsCode => _tempArgsCode.Value ?? _argsCode;
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="DynamicDataSource"/> class with the specified ArgsCode.
    /// </summary>
    /// <param name="argsCode">The default ArgsCode to use when no override is specified.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="argsCode"/> is null.</exception>
    protected DynamicDataSource(ArgsCode argsCode)
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
        private readonly DynamicDataSource _dataSource;
        private readonly ArgsCode? _tempArgsCodeValue;
        private bool _disposed = false;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="DisposableMemento"/> class.
        /// </summary>
        /// <param name="dataSource">The enclosing data source to manage overrides for.</param>
        /// <param name="argsCode">The new ArgsCode to temporarily apply.</param>
        internal DisposableMemento(DynamicDataSource dataSource, ArgsCode argsCode)
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

    #region Methods
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
        // The following code is replaced in the v1.6.0 implementation.

        //=> !string.IsNullOrEmpty(testMethodName) ?
        //    $"{testMethodName}({args?[0]})"
        //    : null;

        // Change: Besides checking if test method name is null or an empty string,
        // the method returns null too if 'args' or the first elemnt is null or empty or
        // the or 'ToString()' method of the first element returns null or an empty string.

        if (string.IsNullOrEmpty(testMethodName))
        {
            return null;
        }

        var firstElement = args?.FirstOrDefault();
        string? firstElementString = firstElement?.ToString();

        if (string.IsNullOrEmpty(firstElementString)
            || firstElementString == ObjectArrayTypeName)
        {
            return null;
        }

        return $"{testMethodName}({firstElement})";
    }
    #endregion

    #region OptionalToArgs
    /// <summary>
    /// Executes the provided test data function with an optional temporary ArgsCode override.
    /// </summary>
    /// <param name="testDataToArgs">A function that generates test data arguments.</param>
    /// <param name="argsCode">An optional ArgsCode to temporarily use during the execution of <paramref name="testDataToArgs"/>.</param>
    /// <returns>The array of arguments generated by <paramref name="testDataToArgs"/>.</returns>
    /// <remarks>
    /// If <paramref name="argsCode"/> is provided, it will be used during the execution of <paramref name="testDataToArgs"/>
    /// and then automatically restored to the previous value afterward.
    /// </remarks>
    public object?[] OptionalToArgs(Func<object?[]> testDataToArgs, ArgsCode? argsCode)
    {
        ArgumentNullException.ThrowIfNull(testDataToArgs, nameof(testDataToArgs));
        return WithOptionalArgsCode(this, testDataToArgs, argsCode);
    }
    #endregion

    #region TestDataToArgs
    /// <summary>
    /// Converts test data to an array of arguments.
    /// </summary>
    /// <typeparam name="T1">The type of the first argument.</typeparam>
    /// <param name="definition">The definition of the test data.</param>
    /// <param name="expected">The expected result of the test.</param>
    /// <param name="arg1">The first argument.</param>
    /// <returns>An array of arguments.</returns>
    public object?[] TestDataToArgs<T1>(string definition, string expected, T1? arg1)
    => new TestData<T1>(definition, expected, arg1).ToArgs(ArgsCode);

    /// <inheritdoc cref="TestDataToArgs{T1}" />
    /// <typeparam name="T2">The type of the second argument.</typeparam>
    /// <param name="arg2">The second argument.</param>
    /// <returns>An array of arguments.</returns>
    public object?[] TestDataToArgs<T1, T2>(string definition, string expected, T1? arg1, T2? arg2)
    => new TestData<T1, T2>(definition, expected, arg1, arg2).ToArgs(ArgsCode);

    /// <inheritdoc cref="TestDataToArgs{T1, T2}" />
    /// <typeparam name="T3">The type of the third argument.</typeparam>
    /// <param name="arg3">The third argument.</param>
    /// <returns>An array of arguments.</returns>
    public object?[] TestDataToArgs<T1, T2, T3>(string definition, string expected, T1? arg1, T2? arg2, T3? arg3)
    => new TestData<T1, T2, T3>(definition, expected, arg1, arg2, arg3).ToArgs(ArgsCode);

    /// <inheritdoc cref="TestDataToArgs{T1, T2, T3}" />
    /// <typeparam name="T4">The type of the fourth argument.</typeparam>
    /// <param name="arg4">The fourth argument.</param>
    /// <returns>An array of arguments.</returns>
    public object?[] TestDataToArgs<T1, T2, T3, T4>(string definition, string expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4)
    => new TestData<T1, T2, T3, T4>(definition, expected, arg1, arg2, arg3, arg4).ToArgs(ArgsCode);

    /// <inheritdoc cref="TestDataToArgs{T1, T2, T3, T4}" />
    /// <typeparam name="T5">The type of the fifth argument.</typeparam>
    /// <param name="arg5">The fifth argument.</param>
    /// <returns>An array of arguments.</returns>
    public object?[] TestDataToArgs<T1, T2, T3, T4, T5>(string definition, string expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5)
    => new TestData<T1, T2, T3, T4, T5>(definition, expected, arg1, arg2, arg3, arg4, arg5).ToArgs(ArgsCode);

    /// <inheritdoc cref="TestDataToArgs{T1, T2, T3, T4, T5}" />
    /// <typeparam name="T6">The type of the sixth argument.</typeparam>
    /// <param name="arg6">The sixth argument.</param>
    /// <returns>An array of arguments.</returns>
    public object?[] TestDataToArgs<T1, T2, T3, T4, T5, T6>(string definition, string expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6)
    => new TestData<T1, T2, T3, T4, T5, T6>(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6).ToArgs(ArgsCode);

    /// <inheritdoc cref="TestDataToArgs{T1, T2, T3, T4, T5, T6}" />
    /// <typeparam name="T7">The type of the seventh argument.</typeparam>
    /// <param name="arg7">The seventh argument.</param>
    /// <returns>An array of arguments.</returns>
    public object?[] TestDataToArgs<T1, T2, T3, T4, T5, T6, T7>(string definition, string expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7)
    => new TestData<T1, T2, T3, T4, T5, T6, T7>(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7).ToArgs(ArgsCode);

    /// <inheritdoc cref="TestDataToArgs{T1, T2, T3, T4, T5, T6, T7}" />
    /// <typeparam name="T8">The type of the eighth argument.</typeparam>
    /// <param name="arg8">The eighth argument.</param>
    /// <returns>An array of arguments.</returns>
    public object?[] TestDataToArgs<T1, T2, T3, T4, T5, T6, T7, T8>(string definition, string expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8)
    => new TestData<T1, T2, T3, T4, T5, T6, T7, T8>(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8).ToArgs(ArgsCode);

    /// <inheritdoc cref="TestDataToArgs{T1, T2, T3, T4, T5, T6, T7, T8}" />
    /// <typeparam name="T9">The type of the ninth argument.</typeparam>
    /// <param name="arg9">The ninth argument.</param>
    /// <returns>An array of arguments.</returns>
    public object?[] TestDataToArgs<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string definition, string expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8, T9? arg9)
    => new TestData<T1, T2, T3, T4, T5, T6, T7, T8, T9>(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9).ToArgs(ArgsCode);
    #endregion

    #region TestDataReturnsToArgs
    /// <summary>
    /// Converts test data to an array of arguments for a test that expects a struct to assert.
    /// </summary>
    /// <typeparam name="TStruct">The type of the expected result, which must be a not null <see cref="ValueType"/> object.</typeparam>
    /// <typeparam name="T1">The type of the first argument.</typeparam>
    /// <param name="definition">The definition of the test data.</param>
    /// <param name="expected">The expected struct of the test.</param>
    /// <param name="arg1">The first argument.</param>
    /// <returns>An array of arguments.</returns>
    public object?[] TestDataReturnsToArgs<TStruct, T1>(string definition, TStruct expected, T1? arg1)
    where TStruct : struct
    => new TestDataReturns<TStruct, T1>(definition, expected, arg1).ToArgs(ArgsCode);

    /// <inheritdoc cref="TestDataReturnsToArgs{TStruct, T1}" />
    /// <typeparam name="T2">The type of the second argument.</typeparam>
    /// <param name="arg2">The second argument.</param>
    /// <returns>An array of arguments.</returns>
    public object?[] TestDataReturnsToArgs<TStruct, T1, T2>(string definition, TStruct expected, T1? arg1, T2? arg2)
    where TStruct : struct
    => new TestDataReturns<TStruct, T1, T2>(definition, expected, arg1, arg2).ToArgs(ArgsCode);

    /// <inheritdoc cref="TestDataReturnsToArgs{TStruct, T1, T2}" />
    /// <typeparam name="T3">The type of the third argument.</typeparam>
    /// <param name="arg3">The third argument.</param>
    /// <returns>An array of arguments.</returns>
    public object?[] TestDataReturnsToArgs<TStruct, T1, T2, T3>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3)
    where TStruct : struct
    => new TestDataReturns<TStruct, T1, T2, T3>(definition, expected, arg1, arg2, arg3).ToArgs(ArgsCode);

    /// <inheritdoc cref="TestDataReturnsToArgs{TStruct, T1, T2, T3}" />
    /// <typeparam name="T4">The type of the fourth argument.</typeparam>
    /// <param name="arg4">The fourth argument.</param>
    /// <returns>An array of arguments.</returns>
    public object?[] TestDataReturnsToArgs<TStruct, T1, T2, T3, T4>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4)
    where TStruct : struct
    => new TestDataReturns<TStruct, T1, T2, T3, T4>(definition, expected, arg1, arg2, arg3, arg4).ToArgs(ArgsCode);

    /// <inheritdoc cref="TestDataReturnsToArgs{TStruct, T1, T2, T3, T4}" />
    /// <typeparam name="T5">The type of the fifth argument.</typeparam>
    /// <param name="arg5">The fifth argument.</param>
    /// <returns>An array of arguments.</returns>
    public object?[] TestDataReturnsToArgs<TStruct, T1, T2, T3, T4, T5>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5)
    where TStruct : struct
    => new TestDataReturns<TStruct, T1, T2, T3, T4, T5>(definition, expected, arg1, arg2, arg3, arg4, arg5).ToArgs(ArgsCode);

    /// <inheritdoc cref="TestDataReturnsToArgs{TStruct, T1, T2, T3, T4, T5}" />
    /// <typeparam name="T6">The type of the sixth argument.</typeparam>
    /// <param name="arg6">The sixth argument.</param>
    /// <returns>An array of arguments.</returns>
    public object?[] TestDataReturnsToArgs<TStruct, T1, T2, T3, T4, T5, T6>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? args6)
    where TStruct : struct
    => new TestDataReturns<TStruct, T1, T2, T3, T4, T5, T6>(definition, expected, arg1, arg2, arg3, arg4, arg5, args6).ToArgs(ArgsCode);

    /// <inheritdoc cref="TestDataReturnsToArgs{TStruct, T1, T2, T3, T4, T5, T6}" />
    /// <typeparam name="T7">The type of the seventh argument.</typeparam>
    /// <param name="arg7">The seventh argument.</param>
    /// <returns>An array of arguments.</returns>
    public object?[] TestDataReturnsToArgs<TStruct, T1, T2, T3, T4, T5, T6, T7>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7)
    where TStruct : struct
    => new TestDataReturns<TStruct, T1, T2, T3, T4, T5, T6, T7>(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7).ToArgs(ArgsCode);

    /// <inheritdoc cref="TestDataReturnsToArgs{TStruct, T1, T2, T3, T4, T5, T6, T7}" />
    /// <typeparam name="T8">The type of the eighth argument.</typeparam>
    /// <param name="arg8">The eighth argument.</param>
    /// <returns>An array of arguments.</returns>
    public object?[] TestDataReturnsToArgs<TStruct, T1, T2, T3, T4, T5, T6, T7, T8>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8)
    where TStruct : struct
    => new TestDataReturns<TStruct, T1, T2, T3, T4, T5, T6, T7, T8>(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8).ToArgs(ArgsCode);

    /// <inheritdoc cref="TestDataReturnsToArgs{TStruct, T1, T2, T3, T4, T5, T6, T7, t8}" />
    /// <typeparam name="T9">The type of the ninth argument.</typeparam>
    /// <param name="arg9">The ninth argument.</param>
    /// <returns>An array of arguments.</returns>
    public object?[] TestDataReturnsToArgs<TStruct, T1, T2, T3, T4, T5, T6, T7, T8, T9>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8, T9? arg9)
    where TStruct : struct
    => new TestDataReturns<TStruct, T1, T2, T3, T4, T5, T6, T7, T8, T9>(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9).ToArgs(ArgsCode);
    #endregion

    #region TestDataThrowsToArgs
    /// <summary>
    /// Converts test data to an array of arguments for a test that throws an exception.
    /// </summary>
    /// <typeparam name="TException">The type of the exception that is expected to be thrown.</typeparam>
    /// <typeparam name="T1">The type of the first argument.</typeparam>
    /// <param name="definition">The definition of the test data.</param>
    /// <param name="expected">The expected exception of the test data.</param>
    /// <param name="arg1">The first argument.</param>
    /// <returns>An array of arguments to be used in a test that expects an exception of type <typeparamref name="TException"/>.</returns>
    public object?[] TestDataThrowsToArgs<TException, T1>(string definition, TException expected, T1? arg1)
    where TException : Exception
    => new TestDataThrows<TException, T1>(definition, expected, arg1).ToArgs(ArgsCode);

    /// <inheritdoc cref="TestDataThrowsToArgs{TException, T1}" />
    /// <typeparam name="T2">The type of the second argument.</typeparam>
    /// <param name="arg2">The second argument.</param>
    /// <returns>An array of arguments to be used in a test that expects an exception of type <typeparamref name="TException"/>.</returns>
    public object?[] TestDataThrowsToArgs<TException, T1, T2>(string definition, TException expected, T1? arg1, T2? arg2)
    where TException : Exception
    => new TestDataThrows<TException, T1, T2>(definition, expected, arg1, arg2).ToArgs(ArgsCode);

    /// <inheritdoc cref="TestDataThrowsToArgs{TException, T1, T2}" />
    /// <typeparam name="T3">The type of the third argument.</typeparam>
    /// <param name="arg3">The third argument.</param>
    /// <returns>An array of arguments to be used in a test that expects an exception of type <typeparamref name="TException"/>.</returns>
    public object?[] TestDataThrowsToArgs<TException, T1, T2, T3>(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3)
    where TException : Exception
    => new TestDataThrows<TException, T1, T2, T3>(definition, expected, arg1, arg2, arg3).ToArgs(ArgsCode);

    /// <inheritdoc cref="TestDataThrowsToArgs{TException, T1, T2, T3}" />
    /// <typeparam name="T4">The type of the fourth argument.</typeparam>
    /// <param name="arg4">The fourth argument.</param>
    /// <returns>An array of arguments to be used in a test that expects an exception of type <typeparamref name="TException"/>.</returns>
    public object?[] TestDataThrowsToArgs<TException, T1, T2, T3, T4>(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4)
    where TException : Exception
    => new TestDataThrows<TException, T1, T2, T3, T4>(definition, expected, arg1, arg2, arg3, arg4).ToArgs(ArgsCode);

    /// <inheritdoc cref="TestDataThrowsToArgs{TException, T1, T2, T3, T4}" />
    /// <typeparam name="T5">The type of the fifth argument.</typeparam>
    /// <param name="arg5">The fifth argument.</param>
    /// <returns>An array of arguments.</returns>
    public object?[] TestDataThrowsToArgs<TException, T1, T2, T3, T4, T5>(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5)
    where TException : Exception
    => new TestDataThrows<TException, T1, T2, T3, T4, T5>(definition, expected, arg1, arg2, arg3, arg4, arg5).ToArgs(ArgsCode);

    /// <inheritdoc cref="TestDataThrowsToArgs{TException, T1, T2, T3, T4, T5}" />
    /// <typeparam name="T6">The type of the sixth argument.</typeparam>
    /// <param name="arg6">The sixth argument.</param>
    /// <returns>An array of arguments.</returns>
    public object?[] TestDataThrowsToArgs<TException, T1, T2, T3, T4, T5, T6>(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6)
    where TException : Exception
    => new TestDataThrows<TException, T1, T2, T3, T4, T5, T6>(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6).ToArgs(ArgsCode);

    /// <inheritdoc cref="TestDataThrowsToArgs{TException, T1, T2, T3, T4, T5, T6}" />
    /// <typeparam name="T7">The type of the seventh argument.</typeparam>
    /// <param name="arg7">The seventh argument.</param>
    /// <returns>An array of arguments.</returns>
    public object?[] TestDataThrowsToArgs<TException, T1, T2, T3, T4, T5, T6, T7>(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7)
    where TException : Exception
    => new TestDataThrows<TException, T1, T2, T3, T4, T5, T6, T7>(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7).ToArgs(ArgsCode);

    /// <inheritdoc cref="TestDataThrowsToArgs{TException, T1, T2, T3, T4, T5, T6, T7}" />
    /// <typeparam name="T8">The type of the eighth argument.</typeparam>
    /// <param name="arg8">The eighth argument.</param>
    /// <returns>An array of arguments.</returns>
    public object?[] TestDataThrowsToArgs<TException, T1, T2, T3, T4, T5, T6, T7, T8>(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8)
    where TException : Exception
    => new TestDataThrows<TException, T1, T2, T3, T4, T5, T6, T7, T8>(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8).ToArgs(ArgsCode);

    /// <inheritdoc cref="TestDataThrowsToArgs{TException, T1, T2, T3, T4, T5, T6, T7, T8}" />
    /// <typeparam name="T9">The type of the ninth argument.</typeparam>
    /// <param name="arg9">The ninth argument.</param>
    /// <returns>An array of arguments.</returns>
    public object?[] TestDataThrowsToArgs<TException, T1, T2, T3, T4, T5, T6, T7, T8, T9>(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8, T9? arg9)
    where TException : Exception
    => new TestDataThrows<TException, T1, T2, T3, T4, T5, T6, T7, T8, T9>(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9).ToArgs(ArgsCode);
    #endregion

    #region WithOptionalArgsCode
    /// <summary>
    /// Executes a test data generator within an optional memento pattern context.
    /// </summary>
    /// <typeparam name="TDataSource">The type of dynamic data source, must inherit from <see cref="DynamicDataSource"/></typeparam>
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
    where TDataSource : DynamicDataSource
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
    /// <typeparam name="TDataSource">The type of dynamic data source, must inherit from <see cref="DynamicDataSource"/></typeparam>
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
    where TDataSource : DynamicDataSource
    {
        if (!argsCode.HasValue)
        {
            testDataProcessor();
        }
        else using (new DisposableMemento(dataSource, argsCode.Value))
        {
            testDataProcessor();
        }
    }
    #endregion
    #endregion

    #region Test helpers
    internal const string ArgsCodeName = nameof(_argsCode);
    internal const string TempArgsCodeName = nameof(_tempArgsCode);
    internal const string DisposableMementoName = nameof(DisposableMemento);
    #endregion
}
