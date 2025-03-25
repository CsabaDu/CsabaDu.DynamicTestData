/* 
 * MIT License
 * 
 * Copyright (c) 2025. Csaba Dudas (CsabaDu)
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */
namespace CsabaDu.DynamicTestData.DynamicDataSources;

/// <summary>
/// An abstract base class that provides a dynamic data source with the ability to temporarily override argument codes.
/// </summary>
public abstract class DynamicDataSource
{
    #region Fields
    private readonly ArgsCode _argsCode;
    private readonly AsyncLocal<ArgsCode?> _tempArgsCode = new();
    #endregion

    #region Properties
    /// <summary>
    /// Gets the current ArgsCode value, which is either the temporary override value or the default value.
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
    /// Gets the display name of the test method and the test case description.
    /// This method is called by the DynamicDataAttribute os MSTest framevork to get the display name of the test method
    /// when its DynamicDataDisplayName property is initialized by this method call. For sample usage see the <see href="path/to/README.md">README file</see>.
    /// This method's  return value can be used in NUnit framework when TestCaseData is used. The return valuse can be used as the
    /// parameter of the TestCaseData's SetName method. For sample usage see the <see href="path/to/README.md">README file</see>.
    /// </summary>
    /// <param name="testMethod">The test method for which the display name is generated.</param>
    /// <param name="args">The arguments passed to the test method.</param>
    /// <returns>A string representing the display name of the test method and its first argument.</returns>
    /// <exception cref="InvalidEnumArgumentException">Thrown when the <paramref name="argsCode"/> is not valid.</exception>
    public static string GetDisplayName(string? testMethodName, params object?[]? args)
    => $"{testMethodName}({args?[0]})";
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
    public object?[] OptionalToArgs([NotNull] Func<object?[]> testDataToArgs, ArgsCode? argsCode)
    {
        ArgumentNullException.ThrowIfNull(testDataToArgs, nameof(testDataToArgs));

        if (!argsCode.HasValue)
        {
            return testDataToArgs();
        }

        using (new DisposableMemento(this, argsCode.Value))
        {
            return testDataToArgs();
        }
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
    /// <typeparam name="TStruct">The type of the expected result, which must be a struct.</typeparam>
    /// <typeparam name="T1">The type of the first argument.</typeparam>
    /// <param name="definition">The definition of the test data.</param>
    /// <param name="expected">The expected struct of the test.</param>
    /// <param name="arg1">The first argument.</param>
    /// <returns>An array of arguments.</returns>
    public object?[] TestDataReturnsToArgs<TStruct, T1>(string definition, TStruct expected, T1? arg1) where TStruct : struct
    => new TestDataReturns<TStruct, T1>(definition, expected, arg1).ToArgs(ArgsCode);

    /// <inheritdoc cref="TestDataReturnsToArgs{TStruct, T1}" />
    /// <typeparam name="T2">The type of the second argument.</typeparam>
    /// <param name="arg2">The second argument.</param>
    /// <returns>An array of arguments.</returns>
    public object?[] TestDataReturnsToArgs<TStruct, T1, T2>(string definition, TStruct expected, T1? arg1, T2? arg2) where TStruct : struct
    => new TestDataReturns<TStruct, T1, T2>(definition, expected, arg1, arg2).ToArgs(ArgsCode);

    /// <inheritdoc cref="TestDataReturnsToArgs{TStruct, T1, T2}" />
    /// <typeparam name="T3">The type of the third argument.</typeparam>
    /// <param name="arg3">The third argument.</param>
    /// <returns>An array of arguments.</returns>
    public object?[] TestDataReturnsToArgs<TStruct, T1, T2, T3>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3) where TStruct : struct
    => new TestDataReturns<TStruct, T1, T2, T3>(definition, expected, arg1, arg2, arg3).ToArgs(ArgsCode);

    /// <inheritdoc cref="TestDataReturnsToArgs{TStruct, T1, T2, T3}" />
    /// <typeparam name="T4">The type of the fourth argument.</typeparam>
    /// <param name="arg4">The fourth argument.</param>
    /// <returns>An array of arguments.</returns>
    public object?[] TestDataReturnsToArgs<TStruct, T1, T2, T3, T4>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4) where TStruct : struct
    => new TestDataReturns<TStruct, T1, T2, T3, T4>(definition, expected, arg1, arg2, arg3, arg4).ToArgs(ArgsCode);

    /// <inheritdoc cref="TestDataReturnsToArgs{TStruct, T1, T2, T3, T4}" />
    /// <typeparam name="T5">The type of the fifth argument.</typeparam>
    /// <param name="arg5">The fifth argument.</param>
    /// <returns>An array of arguments.</returns>
    public object?[] TestDataReturnsToArgs<TStruct, T1, T2, T3, T4, T5>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5) where TStruct : struct
    => new TestDataReturns<TStruct, T1, T2, T3, T4, T5>(definition, expected, arg1, arg2, arg3, arg4, arg5).ToArgs(ArgsCode);

    /// <inheritdoc cref="TestDataReturnsToArgs{TStruct, T1, T2, T3, T4, T5}" />
    /// <typeparam name="T6">The type of the sixth argument.</typeparam>
    /// <param name="arg6">The sixth argument.</param>
    /// <returns>An array of arguments.</returns>
    public object?[] TestDataReturnsToArgs<TStruct, T1, T2, T3, T4, T5, T6>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? args6) where TStruct : struct
    => new TestDataReturns<TStruct, T1, T2, T3, T4, T5, T6>(definition, expected, arg1, arg2, arg3, arg4, arg5, args6).ToArgs(ArgsCode);

    /// <inheritdoc cref="TestDataReturnsToArgs{TStruct, T1, T2, T3, T4, T5, T6}" />
    /// <typeparam name="T7">The type of the seventh argument.</typeparam>
    /// <param name="arg7">The seventh argument.</param>
    /// <returns>An array of arguments.</returns>
    public object?[] TestDataReturnsToArgs<TStruct, T1, T2, T3, T4, T5, T6, T7>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7) where TStruct : struct
    => new TestDataReturns<TStruct, T1, T2, T3, T4, T5, T6, T7>(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7).ToArgs(ArgsCode);

    /// <inheritdoc cref="TestDataReturnsToArgs{TStruct, T1, T2, T3, T4, T5, T6, T7}" />
    /// <typeparam name="T8">The type of the eighth argument.</typeparam>
    /// <param name="arg8">The eighth argument.</param>
    /// <returns>An array of arguments.</returns>
    public object?[] TestDataReturnsToArgs<TStruct, T1, T2, T3, T4, T5, T6, T7, T8>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8) where TStruct : struct
    => new TestDataReturns<TStruct, T1, T2, T3, T4, T5, T6, T7, T8>(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8).ToArgs(ArgsCode);

    /// <inheritdoc cref="TestDataReturnsToArgs{TStruct, T1, T2, T3, T4, T5, T6, T7, t8}" />
    /// <typeparam name="T9">The type of the ninth argument.</typeparam>
    /// <param name="arg9">The ninth argument.</param>
    /// <returns>An array of arguments.</returns>
    public object?[] TestDataReturnsToArgs<TStruct, T1, T2, T3, T4, T5, T6, T7, T8, T9>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8, T9? arg9) where TStruct : struct
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
    public object?[] TestDataThrowsToArgs<TException, T1>(string definition, TException expected, T1? arg1) where TException : Exception
        => new TestDataThrows<TException, T1>(definition, expected, arg1).ToArgs(ArgsCode);

    /// <inheritdoc cref="TestDataThrowsToArgs{TException, T1}" />
    /// <typeparam name="T2">The type of the second argument.</typeparam>
    /// <param name="arg2">The second argument.</param>
    /// <returns>An array of arguments to be used in a test that expects an exception of type <typeparamref name="TException"/>.</returns>
    public object?[] TestDataThrowsToArgs<TException, T1, T2>(string definition, TException expected, T1? arg1, T2? arg2) where TException : Exception
        => new TestDataThrows<TException, T1, T2>(definition, expected, arg1, arg2).ToArgs(ArgsCode);

    /// <inheritdoc cref="TestDataThrowsToArgs{TException, T1, T2}" />
    /// <typeparam name="T3">The type of the third argument.</typeparam>
    /// <param name="arg3">The third argument.</param>
    /// <returns>An array of arguments to be used in a test that expects an exception of type <typeparamref name="TException"/>.</returns>
    public object?[] TestDataThrowsToArgs<TException, T1, T2, T3>(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3) where TException : Exception
        => new TestDataThrows<TException, T1, T2, T3>(definition, expected, arg1, arg2, arg3).ToArgs(ArgsCode);

    /// <inheritdoc cref="TestDataThrowsToArgs{TException, T1, T2, T3}" />
    /// <typeparam name="T4">The type of the fourth argument.</typeparam>
    /// <param name="arg4">The fourth argument.</param>
    /// <returns>An array of arguments to be used in a test that expects an exception of type <typeparamref name="TException"/>.</returns>
    public object?[] TestDataThrowsToArgs<TException, T1, T2, T3, T4>(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4) where TException : Exception
        => new TestDataThrows<TException, T1, T2, T3, T4>(definition, expected, arg1, arg2, arg3, arg4).ToArgs(ArgsCode);

    /// <inheritdoc cref="TestDataThrowsToArgs{TException, T1, T2, T3, T4}" />
    /// <typeparam name="T5">The type of the fifth argument.</typeparam>
    /// <param name="arg5">The fifth argument.</param>
    /// <returns>An array of arguments.</returns>
    public object?[] TestDataThrowsToArgs<TException, T1, T2, T3, T4, T5>(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5) where TException : Exception
    => new TestDataThrows<TException, T1, T2, T3, T4, T5>(definition, expected, arg1, arg2, arg3, arg4, arg5).ToArgs(ArgsCode);

    /// <inheritdoc cref="TestDataThrowsToArgs{TException, T1, T2, T3, T4, T5}" />
    /// <typeparam name="T6">The type of the sixth argument.</typeparam>
    /// <param name="arg6">The sixth argument.</param>
    /// <returns>An array of arguments.</returns>
    public object?[] TestDataThrowsToArgs<TException, T1, T2, T3, T4, T5, T6>(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6) where TException : Exception
    => new TestDataThrows<TException, T1, T2, T3, T4, T5, T6>(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6).ToArgs(ArgsCode);

    /// <inheritdoc cref="TestDataThrowsToArgs{TException, T1, T2, T3, T4, T5, T6}" />
    /// <typeparam name="T7">The type of the seventh argument.</typeparam>
    /// <param name="arg7">The seventh argument.</param>
    /// <returns>An array of arguments.</returns>
    public object?[] TestDataThrowsToArgs<TException, T1, T2, T3, T4, T5, T6, T7>(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7) where TException : Exception
    => new TestDataThrows<TException, T1, T2, T3, T4, T5, T6, T7>(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7).ToArgs(ArgsCode);

    /// <inheritdoc cref="TestDataThrowsToArgs{TException, T1, T2, T3, T4, T5, T6, T7}" />
    /// <typeparam name="T8">The type of the eighth argument.</typeparam>
    /// <param name="arg8">The eighth argument.</param>
    /// <returns>An array of arguments.</returns>
    public object?[] TestDataThrowsToArgs<TException, T1, T2, T3, T4, T5, T6, T7, T8>(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8) where TException : Exception
    => new TestDataThrows<TException, T1, T2, T3, T4, T5, T6, T7, T8>(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8).ToArgs(ArgsCode);

    /// <inheritdoc cref="TestDataThrowsToArgs{TException, T1, T2, T3, T4, T5, T6, T7, T8}" />
    /// <typeparam name="T9">The type of the ninth argument.</typeparam>
    /// <param name="arg9">The ninth argument.</param>
    /// <returns>An array of arguments.</returns>
    public object?[] TestDataThrowsToArgs<TException, T1, T2, T3, T4, T5, T6, T7, T8, T9>(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8, T9? arg9) where TException : Exception
    => new TestDataThrows<TException, T1, T2, T3, T4, T5, T6, T7, T8, T9>(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9).ToArgs(ArgsCode);
    #endregion
    #endregion
}
