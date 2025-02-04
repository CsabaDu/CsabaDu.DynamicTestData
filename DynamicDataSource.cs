namespace CsabaDu.DynamicTestData;

public abstract class DynamicDataSource(ArgsCode argsCode)
{
    #region Properties
    /// <summary>
    /// Gets the ArgsCode instance used for argument conversion.
    /// </summary>
    internal ArgsCode ArgsCode { get; } = argsCode;
    #endregion

    #region Methods
    /// <summary>
    /// Gets the display name for the test method and its arguments.
    /// This method is called by the DynamicDataAttribute os MSTest framevork to get the display name of the test method
    /// when its DynamicDataDisplayName property is initialized by this method call. For sample usage see the <see href="path/to/README.md">README file</see>.
    /// This method's  return value can be used in NUnit framework when TestCaseData is used. The return valuse can be used as the
    /// parameter of the TestCaseData's SetName method. For sample usage see the <see href="path/to/README.md">README file</see>.
    /// </summary>
    /// <param name="testMethod">The test method for which the display name is generated.</param>
    /// <param name="args">The arguments passed to the test method.</param>
    /// <returns>A string representing the display name of the test method and its first argument.</returns>
    public string GetDisplayName(MethodInfo testMethod, object[] args)
    => $"{testMethod.Name}({args[0] as string})";

    #region TestDataToArgs
    /// <summary>
    /// Converts test data to an array of arguments.
    /// </summary>
    /// <typeparam name="T1">The type of the first argument.</typeparam>
    /// <param name="definition">The definition of the test data.</param>
    /// <param name="result">The expected result of the test.</param>
    /// <param name="arg1">The first argument.</param>
    /// <returns>An array of arguments.</returns>
    internal object?[] TestDataToArgs<T1>(string definition, string result, T1? arg1)
    => new TestData<T1>(definition, result, arg1).ToArgs(ArgsCode);
    /// <summary>
    /// Converts test data to an array of arguments.
    /// </summary>
    /// <typeparam name="T1">The type of the first argument.</typeparam>
    /// <typeparam name="T2">The type of the second argument.</typeparam>
    /// <param name="definition">The definition of the test data.</param>
    /// <param name="result">The expected result of the test.</param>
    /// <param name="arg1">The first argument.</param>
    /// <param name="arg2">The second argument.</param>
    /// <returns>An array of arguments.</returns>
    internal object?[] TestDataToArgs<T1, T2>(string definition, string result, T1? arg1, T2? arg2)
    => new TestData<T1, T2>(definition, result, arg1, arg2).ToArgs(ArgsCode);

    /// <summary>
    /// Converts test data to an array of arguments.
    /// </summary>
    /// <typeparam name="T1">The type of the first argument.</typeparam>
    /// <typeparam name="T2">The type of the second argument.</typeparam>
    /// <typeparam name="T3">The type of the third argument.</typeparam>
    /// <param name="definition">The definition of the test data.</param>
    /// <param name="result">The expected result of the test.</param>
    /// <param name="arg1">The first argument.</param>
    /// <param name="arg2">The second argument.</param>
    /// <param name="arg3">The third argument.</param>
    /// <returns>An array of arguments.</returns>
    internal object?[] TestDataToArgs<T1, T2, T3>(string definition, string result, T1? arg1, T2? arg2, T3? arg3)
    => new TestData<T1, T2, T3>(definition, result, arg1, arg2, arg3).ToArgs(ArgsCode);

    /// <summary>
    /// Converts test data to an array of arguments.
    /// </summary>
    /// <typeparam name="T1">The type of the first argument.</typeparam>
    /// <typeparam name="T2">The type of the second argument.</typeparam>
    /// <typeparam name="T3">The type of the third argument.</typeparam>
    /// <typeparam name="T4">The type of the fourth argument.</typeparam>
    /// <param name="definition">The definition of the test data.</param>
    /// <param name="result">The expected result of the test.</param>
    /// <param name="arg1">The first argument.</param>
    /// <param name="arg2">The second argument.</param>
    /// <param name="arg3">The third argument.</param>
    /// <param name="arg4">The fourth argument.</param>
    /// <returns>An array of arguments.</returns>
    internal object?[] TestDataToArgs<T1, T2, T3, T4>(string definition, string result, T1? arg1, T2? arg2, T3? arg3, T4? arg4)
    => new TestData<T1, T2, T3, T4>(definition, result, arg1, arg2, arg3, arg4).ToArgs(ArgsCode);

    /// <summary>
    /// Converts test data to an array of arguments.
    /// </summary>
    /// <typeparam name="T1">The type of the first argument.</typeparam>
    /// <typeparam name="T2">The type of the second argument.</typeparam>
    /// <typeparam name="T3">The type of the third argument.</typeparam>
    /// <typeparam name="T4">The type of the fourth argument.</typeparam>
    /// <typeparam name="T5">The type of the fifth argument.</typeparam>
    /// <param name="definition">The definition of the test data.</param>
    /// <param name="result">The expected result of the test.</param>
    /// <param name="arg1">The first argument.</param>
    /// <param name="arg2">The second argument.</param>
    /// <param name="arg3">The third argument.</param>
    /// <param name="arg4">The fourth argument.</param>
    /// <param name="arg5">The fifth argument.</param>
    /// <returns>An array of arguments.</returns>
    internal object?[] TestDataToArgs<T1, T2, T3, T4, T5>(string definition, string result, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5)
    => new TestData<T1, T2, T3, T4, T5>(definition, result, arg1, arg2, arg3, arg4, arg5).ToArgs(ArgsCode);

    /// <summary>
    /// Converts test data to an array of arguments.
    /// </summary>
    /// <typeparam name="T1">The type of the first argument.</typeparam>
    /// <typeparam name="T2">The type of the second argument.</typeparam>
    /// <typeparam name="T3">The type of the third argument.</typeparam>
    /// <typeparam name="T4">The type of the fourth argument.</typeparam>
    /// <typeparam name="T5">The type of the fifth argument.</typeparam>
    /// <typeparam name="T6">The type of the sixth argument.</typeparam>
    /// <param name="definition">The definition of the test data.</param>
    /// <param name="result">The expected result of the test.</param>
    /// <param name="arg1">The first argument.</param>
    /// <param name="arg2">The second argument.</param>
    /// <param name="arg3">The third argument.</param>
    /// <param name="arg4">The fourth argument.</param>
    /// <param name="arg5">The fifth argument.</param>
    /// <param name="arg6">The sixth argument.</param>
    /// <returns>An array of arguments.</returns>
    internal object?[] TestDataToArgs<T1, T2, T3, T4, T5, T6>(string definition, string result, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6)
    => new TestData<T1, T2, T3, T4, T5, T6>(definition, result, arg1, arg2, arg3, arg4, arg5, arg6).ToArgs(ArgsCode);

    /// <summary>
    /// Converts test data to an array of arguments.
    /// </summary>
    /// <typeparam name="T1">The type of the first argument.</typeparam>
    /// <typeparam name="T2">The type of the second argument.</typeparam>
    /// <typeparam name="T3">The type of the third argument.</typeparam>
    /// <typeparam name="T4">The type of the fourth argument.</typeparam>
    /// <typeparam name="T5">The type of the fifth argument.</typeparam>
    /// <typeparam name="T6">The type of the sixth argument.</typeparam>
    /// <typeparam name="T7">The type of the seventh argument.</typeparam>
    /// <param name="definition">The definition of the test data.</param>
    /// <param name="result">The expected result of the test.</param>
    /// <param name="arg1">The first argument.</param>
    /// <param name="arg2">The second argument.</param>
    /// <param name="arg3">The third argument.</param>
    /// <param name="arg4">The fourth argument.</param>
    /// <param name="arg5">The fifth argument.</param>
    /// <param name="arg6">The sixth argument.</param>
    /// <param name="arg7">The seventh argument.</param>
    /// <returns>An array of arguments.</returns>
    internal object?[] TestDataToArgs<T1, T2, T3, T4, T5, T6, T7>(string definition, string result, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7)
    => new TestData<T1, T2, T3, T4, T5, T6, T7>(definition, result, arg1, arg2, arg3, arg4, arg5, arg6, arg7).ToArgs(ArgsCode);

    /// <summary>
    /// Converts test data to an array of arguments.
    /// </summary>
    /// <typeparam name="T1">The type of the first argument.</typeparam>
    /// <typeparam name="T2">The type of the second argument.</typeparam>
    /// <typeparam name="T3">The type of the third argument.</typeparam>
    /// <typeparam name="T4">The type of the fourth argument.</typeparam>
    /// <typeparam name="T5">The type of the fifth argument.</typeparam>
    /// <typeparam name="T6">The type of the sixth argument.</typeparam>
    /// <typeparam name="T7">The type of the seventh argument.</typeparam>
    /// <typeparam name="T8">The type of the eighth argument.</typeparam>
    /// <param name="definition">The definition of the test data.</param>
    /// <param name="result">The expected result of the test.</param>
    /// <param name="arg1">The first argument.</param>
    /// <param name="arg2">The second argument.</param>
    /// <param name="arg3">The third argument.</param>
    /// <param name="arg4">The fourth argument.</param>
    /// <param name="arg5">The fifth argument.</param>
    /// <param name="arg6">The sixth argument.</param>
    /// <param name="arg7">The seventh argument.</param>
    /// <param name="arg8">The eighth argument.</param>
    /// <returns>An array of arguments.</returns>
    internal object?[] TestDataToArgs<T1, T2, T3, T4, T5, T6, T7, T8>(string definition, string result, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8)
    => new TestData<T1, T2, T3, T4, T5, T6, T7, T8>(definition, result, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8).ToArgs(ArgsCode);

    /// <summary>
    /// Converts test data to an array of arguments.
    /// </summary>
    /// <typeparam name="T1">The type of the first argument.</typeparam>
    /// <typeparam name="T2">The type of the second argument.</typeparam>
    /// <typeparam name="T3">The type of the third argument.</typeparam>
    /// <typeparam name="T4">The type of the fourth argument.</typeparam>
    /// <typeparam name="T5">The type of the fifth argument.</typeparam>
    /// <typeparam name="T6">The type of the sixth argument.</typeparam>
    /// <typeparam name="T7">The type of the seventh argument.</typeparam>
    /// <typeparam name="T8">The type of the eighth argument.</typeparam>
    /// <typeparam name="T9">The type of the ninth argument.</typeparam>
    /// <param name="definition">The definition of the test data.</param>
    /// <param name="result">The expected result of the test.</param>
    /// <param name="arg1">The first argument.</param>
    /// <param name="arg2">The second argument.</param>
    /// <param name="arg3">The third argument.</param>
    /// <param name="arg4">The fourth argument.</param>
    /// <param name="arg5">The fifth argument.</param>
    /// <param name="arg6">The sixth argument.</param>
    /// <param name="arg7">The seventh argument.</param>
    /// <param name="arg8">The eighth argument.</param>
    /// <param name="arg9">The ninth argument.</param>
    /// <returns>An array of arguments.</returns>
    internal object?[] TestDataToArgs<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string definition, string result, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8, T9? arg9)
    => new TestData<T1, T2, T3, T4, T5, T6, T7, T8, T9>(definition, result, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9).ToArgs(ArgsCode);
    #endregion

    #region TestDataReturnsToArgs
    /// <summary>
    /// Converts test data to an array of arguments.
    /// </summary>
    /// <typeparam name="TStruct">The type of the expected result, which must be a struct.</typeparam>
    /// <typeparam name="T1">The type of the first argument.</typeparam>
    /// <param name="definition">The definition of the test data.</param>
    /// <param name="expected">The expected result of the test.</param>
    /// <param name="arg1">The first argument.</param>
    /// <returns>An array of arguments.</returns>
    internal object?[] TestDataReturnsToArgs<TStruct, T1>(string definition, TStruct expected, T1? arg1) where TStruct : struct
    => new TestDataReturns<TStruct, T1>(definition, expected, arg1).ToArgs(ArgsCode);

    /// <summary>
    /// Converts test data to an array of arguments.
    /// </summary>
    /// <typeparam name="TStruct">The type of the expected result, which must be a struct.</typeparam>
    /// <typeparam name="T1">The type of the first argument.</typeparam>
    /// <typeparam name="T2">The type of the second argument.</typeparam>
    /// <param name="definition">The definition of the test data.</param>
    /// <param name="expected">The expected result of the test.</param>
    /// <param name="arg1">The first argument.</param>
    /// <param name="arg2">The second argument.</param>
    /// <returns>An array of arguments.</returns>
    internal object?[] TestDataReturnsToArgs<TStruct, T1, T2>(string definition, TStruct expected, T1? arg1, T2? arg2) where TStruct : struct
    => new TestDataReturns<TStruct, T1, T2>(definition, expected, arg1, arg2).ToArgs(ArgsCode);

    /// <summary>
    /// Converts test data to an array of arguments.
    /// </summary>
    /// <typeparam name="TStruct">The type of the expected result, which must be a struct.</typeparam>
    /// <typeparam name="T1">The type of the first argument.</typeparam>
    /// <typeparam name="T2">The type of the second argument.</typeparam>
    /// <typeparam name="T3">The type of the third argument.</typeparam>
    /// <param name="definition">The definition of the test data.</param>
    /// <param name="expected">The expected result of the test.</param>
    /// <param name="arg1">The first argument.</param>
    /// <param name="arg2">The second argument.</param>
    /// <param name="arg3">The third argument.</param>
    /// <returns>An array of arguments.</returns>
    internal object?[] TestDataReturnsToArgs<TStruct, T1, T2, T3>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3) where TStruct : struct
    => new TestDataReturns<TStruct, T1, T2, T3>(definition, expected, arg1, arg2, arg3).ToArgs(ArgsCode);

    /// <summary>
    /// Converts test data to an array of arguments.
    /// </summary>
    /// <typeparam name="TStruct">The type of the expected result, which must be a struct.</typeparam>
    /// <typeparam name="T1">The type of the first argument.</typeparam>
    /// <typeparam name="T2">The type of the second argument.</typeparam>
    /// <typeparam name="T3">The type of the third argument.</typeparam>
    /// <typeparam name="T4">The type of the fourth argument.</typeparam>
    /// <param name="definition">The definition of the test data.</param>
    /// <param name="expected">The expected result of the test.</param>
    /// <param name="arg1">The first argument.</param>
    /// <param name="arg2">The second argument.</param>
    /// <param name="arg3">The third argument.</param>
    /// <param name="arg4">The fourth argument.</param>
    /// <returns>An array of arguments.</returns>
    internal object?[] TestDataReturnsToArgs<TStruct, T1, T2, T3, T4>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4) where TStruct : struct
    => new TestDataReturns<TStruct, T1, T2, T3, T4>(definition, expected, arg1, arg2, arg3, arg4).ToArgs(ArgsCode);

    /// <summary>
    /// Converts test data to an array of arguments.
    /// </summary>
    /// <typeparam name="TStruct">The type of the expected result, which must be a struct.</typeparam>
    /// <typeparam name="T1">The type of the first argument.</typeparam>
    /// <typeparam name="T2">The type of the second argument.</typeparam>
    /// <typeparam name="T3">The type of the third argument.</typeparam>
    /// <typeparam name="T4">The type of the fourth argument.</typeparam>
    /// <typeparam name="T5">The type of the fifth argument.</typeparam>
    /// <param name="definition">The definition of the test data.</param>
    /// <param name="expected">The expected result of the test.</param>
    /// <param name="arg1">The first argument.</param>
    /// <param name="arg2">The second argument.</param>
    /// <param name="arg3">The third argument.</param>
    /// <param name="arg4">The fourth argument.</param>
    /// <param name="arg5">The fifth argument.</param>
    /// <returns>An array of arguments.</returns>
    internal object?[] TestDataReturnsToArgs<TStruct, T1, T2, T3, T4, T5>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5) where TStruct : struct
    => new TestDataReturns<TStruct, T1, T2, T3, T4, T5>(definition, expected, arg1, arg2, arg3, arg4, arg5).ToArgs(ArgsCode);

    /// <summary>
    /// Converts test data to an array of arguments.
    /// </summary>
    /// <typeparam name="TStruct">The type of the expected result, which must be a struct.</typeparam>
    /// <typeparam name="T1">The type of the first argument.</typeparam>
    /// <typeparam name="T2">The type of the second argument.</typeparam>
    /// <typeparam name="T3">The type of the third argument.</typeparam>
    /// <typeparam name="T4">The type of the fourth argument.</typeparam>
    /// <typeparam name="T5">The type of the fifth argument.</typeparam>
    /// <typeparam name="T6">The type of the sixth argument.</typeparam>
    /// <param name="definition">The definition of the test data.</param>
    /// <param name="expected">The expected result of the test.</param>
    /// <param name="arg1">The first argument.</param>
    /// <param name="arg2">The second argument.</param>
    /// <param name="arg3">The third argument.</param>
    /// <param name="arg4">The fourth argument.</param>
    /// <param name="arg5">The fifth argument.</param>
    /// <param name="arg6">The sixth argument.</param>
    /// <returns>An array of arguments.</returns>
    internal object?[] TestDataReturnsToArgs<TStruct, T1, T2, T3, T4, T5, T6>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? args6) where TStruct : struct
    => new TestDataReturns<TStruct, T1, T2, T3, T4, T5, T6>(definition, expected, arg1, arg2, arg3, arg4, arg5, args6).ToArgs(ArgsCode);

    /// <summary>
    /// Converts test data to an array of arguments.
    /// </summary>
    /// <typeparam name="TStruct">The type of the expected result, which must be a struct.</typeparam>
    /// <typeparam name="T1">The type of the first argument.</typeparam>
    /// <typeparam name="T2">The type of the second argument.</typeparam>
    /// <typeparam name="T3">The type of the third argument.</typeparam>
    /// <typeparam name="T4">The type of the fourth argument.</typeparam>
    /// <typeparam name="T5">The type of the fifth argument.</typeparam>
    /// <typeparam name="T6">The type of the sixth argument.</typeparam>
    /// <typeparam name="T7">The type of the seventh argument.</typeparam>
    /// <param name="definition">The definition of the test data.</param>
    /// <param name="expected">The expected result of the test.</param>
    /// <param name="arg1">The first argument.</param>
    /// <param name="arg2">The second argument.</param>
    /// <param name="arg3">The third argument.</param>
    /// <param name="arg4">The fourth argument.</param>
    /// <param name="arg5">The fifth argument.</param>
    /// <param name="arg6">The sixth argument.</param>
    /// <param name="arg7">The seventh argument.</param>
    /// <returns>An array of arguments.</returns>
    internal object?[] TestDataReturnsToArgs<TStruct, T1, T2, T3, T4, T5, T6, T7>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7) where TStruct : struct
    => new TestDataReturns<TStruct, T1, T2, T3, T4, T5, T6, T7>(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7).ToArgs(ArgsCode);

    /// <summary>
    /// Converts test data to an array of arguments.
    /// </summary>
    /// <typeparam name="TStruct">The type of the expected result, which must be a struct.</typeparam>
    /// <typeparam name="T1">The type of the first argument.</typeparam>
    /// <typeparam name="T2">The type of the second argument.</typeparam>
    /// <typeparam name="T3">The type of the third argument.</typeparam>
    /// <typeparam name="T4">The type of the fourth argument.</typeparam>
    /// <typeparam name="T5">The type of the fifth argument.</typeparam>
    /// <typeparam name="T6">The type of the sixth argument.</typeparam>
    /// <typeparam name="T7">The type of the seventh argument.</typeparam>
    /// <typeparam name="T8">The type of the eighth argument.</typeparam>
    /// <param name="definition">The definition of the test data.</param>
    /// <param name="expected">The expected result of the test.</param>
    /// <param name="arg1">The first argument.</param>
    /// <param name="arg2">The second argument.</param>
    /// <param name="arg3">The third argument.</param>
    /// <param name="arg4">The fourth argument.</param>
    /// <param name="arg5">The fifth argument.</param>
    /// <param name="arg6">The sixth argument.</param>
    /// <param name="arg7">The seventh argument.</param>
    /// <param name="arg8">The eighth argument.</param>
    /// <returns>An array of arguments.</returns>
    internal object?[] TestDataReturnsToArgs<TStruct, T1, T2, T3, T4, T5, T6, T7, T8>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8) where TStruct : struct
    => new TestDataReturns<TStruct, T1, T2, T3, T4, T5, T6, T7, T8>(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8).ToArgs(ArgsCode);

    /// <summary>
    /// Converts test data to an array of arguments.
    /// </summary>
    /// <typeparam name="TStruct">The type of the expected result, which must be a struct.</typeparam>
    /// <typeparam name="T1">The type of the first argument.</typeparam>
    /// <typeparam name="T2">The type of the second argument.</typeparam>
    /// <typeparam name="T3">The type of the third argument.</typeparam>
    /// <typeparam name="T4">The type of the fourth argument.</typeparam>
    /// <typeparam name="T5">The type of the fifth argument.</typeparam>
    /// <typeparam name="T6">The type of the sixth argument.</typeparam>
    /// <typeparam name="T7">The type of the seventh argument.</typeparam>
    /// <typeparam name="T8">The type of the eighth argument.</typeparam>
    /// <typeparam name="T9">The type of the ninth argument.</typeparam>
    /// <param name="definition">The definition of the test data.</param>
    /// <param name="expected">The expected result of the test.</param>
    /// <param name="arg1">The first argument.</param>
    /// <param name="arg2">The second argument.</param>
    /// <param name="arg3">The third argument.</param>
    /// <param name="arg4">The fourth argument.</param>
    /// <param name="arg5">The fifth argument.</param>
    /// <param name="arg6">The sixth argument.</param>
    /// <param name="arg7">The seventh argument.</param>
    /// <param name="arg8">The eighth argument.</param>
    /// <param name="arg9">The ninth argument.</param>
    /// <returns>An array of arguments.</returns>
    internal object?[] TestDataReturnsToArgs<TStruct, T1, T2, T3, T4, T5, T6, T7, T8, T9>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8, T9? arg9) where TStruct : struct
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
    /// <param name="paramName">The name of the parameter that causes the exception.</param>
    /// <param name="message">The message of the exception.</param>
    /// <param name="arg1">The first argument.</param>
    /// <returns>An array of arguments.</returns>
    internal object?[] TestDataThrowsToArgs<TException, T1>(string definition, TException expected, string paramName, string message, T1? arg1) where TException : Exception
    => new TestDataThrows<TException, T1>(definition, expected, paramName, message, arg1).ToArgs(ArgsCode);

    /// <summary>
    /// Converts test data to an array of arguments for a test that throws an exception.
    /// </summary>
    /// <typeparam name="TException">The type of the exception that is expected to be thrown.</typeparam>
    /// <typeparam name="T1">The type of the first argument.</typeparam>
    /// <typeparam name="T2">The type of the second argument.</typeparam>
    /// <param name="definition">The definition of the test data.</param>
    /// <param name="expected">The expected exception of the test data.</param>
    /// <param name="paramName">The name of the parameter that causes the exception.</param>
    /// <param name="message">The message of the exception.</param>
    /// <param name="arg1">The first argument.</param>
    /// <param name="arg2">The second argument.</param>
    /// <returns>An array of arguments.</returns>
    internal object?[] TestDataThrowsToArgs<TException, T1, T2>(string definition, TException expected, string paramName, string message, T1? arg1, T2? arg2) where TException : Exception
    => new TestDataThrows<TException, T1, T2>(definition, expected, paramName, message, arg1, arg2).ToArgs(ArgsCode);

    /// <summary>
    /// Converts test data to an array of arguments for a test that throws an exception.
    /// </summary>
    /// <typeparam name="TException">The type of the exception that is expected to be thrown.</typeparam>
    /// <typeparam name="T1">The type of the first argument.</typeparam>
    /// <typeparam name="T2">The type of the second argument.</typeparam>
    /// <typeparam name="T3">The type of the third argument.</typeparam>
    /// <param name="definition">The definition of the test data.</param>
    /// <param name="expected">The expected exception of the test data.</param>
    /// <param name="paramName">The name of the parameter that causes the exception.</param>
    /// <param name="message">The message of the exception.</param>
    /// <param name="arg1">The first argument.</param>
    /// <param name="arg2">The second argument.</param>
    /// <param name="arg3">The third argument.</param>
    /// <returns>An array of arguments.</returns>
    internal object?[] TestDataThrowsToArgs<TException, T1, T2, T3>(string definition, TException expected, string paramName, string message, T1? arg1, T2? arg2, T3? arg3) where TException : Exception
    => new TestDataThrows<TException, T1, T2, T3>(definition, expected, paramName, message, arg1, arg2, arg3).ToArgs(ArgsCode);

    /// <summary>
    /// Converts test data to an array of arguments for a test that throws an exception.
    /// </summary>
    /// <typeparam name="TException">The type of the exception that is expected to be thrown.</typeparam>
    /// <typeparam name="T1">The type of the first argument.</typeparam>
    /// <typeparam name="T2">The type of the second argument.</typeparam>
    /// <typeparam name="T3">The type of the third argument.</typeparam>
    /// <typeparam name="T4">The type of the fourth argument.</typeparam>
    /// <param name="definition">The definition of the test data.</param>
    /// <param name="expected">The expected exception of the test data.</param>
    /// <param name="paramName">The name of the parameter that causes the exception.</param>
    /// <param name="message">The message of the exception.</param>
    /// <param name="arg1">The first argument.</param>
    /// <param name="arg2">The second argument.</param>
    /// <param name="arg3">The third argument.</param>
    /// <param name="arg4">The fourth argument.</param>
    /// <returns>An array of arguments.</returns>
    internal object?[] TestDataThrowsToArgs<TException, T1, T2, T3, T4>(string definition, TException expected, string paramName, string message, T1? arg1, T2? arg2, T3? arg3, T4? arg4) where TException : Exception
    => new TestDataThrows<TException, T1, T2, T3, T4>(definition, expected, paramName, message, arg1, arg2, arg3, arg4).ToArgs(ArgsCode);

    /// <summary>
    /// Converts test data to an array of arguments for a test that throws an exception.
    /// </summary>
    /// <typeparam name="TException">The type of the exception that is expected to be thrown.</typeparam>
    /// <typeparam name="T1">The type of the first argument.</typeparam>
    /// <typeparam name="T2">The type of the second argument.</typeparam>
    /// <typeparam name="T3">The type of the third argument.</typeparam>
    /// <typeparam name="T4">The type of the fourth argument.</typeparam>
    /// <typeparam name="T5">The type of the fifth argument.</typeparam>
    /// <param name="definition">The definition of the test data.</param>
    /// <param name="expected">The expected exception of the test data.</param>
    /// <param name="paramName">The name of the parameter that causes the exception.</param>
    /// <param name="message">The message of the exception.</param>
    /// <param name="arg1">The first argument.</param>
    /// <param name="arg2">The second argument.</param>
    /// <param name="arg3">The third argument.</param>
    /// <param name="arg4">The fourth argument.</param>
    /// <param name="arg5">The fifth argument.</param>
    /// <returns>An array of arguments.</returns>
    internal object?[] TestDataThrowsToArgs<TException, T1, T2, T3, T4, T5>(string definition, TException expected, string paramName, string message, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5) where TException : Exception
    => new TestDataThrows<TException, T1, T2, T3, T4, T5>(definition, expected, paramName, message, arg1, arg2, arg3, arg4, arg5).ToArgs(ArgsCode);

    /// <summary>
    /// Converts test data to an array of arguments for a test that throws an exception.
    /// </summary>
    /// <typeparam name="TException">The type of the exception that is expected to be thrown.</typeparam>
    /// <typeparam name="T1">The type of the first argument.</typeparam>
    /// <typeparam name="T2">The type of the second argument.</typeparam>
    /// <typeparam name="T3">The type of the third argument.</typeparam>
    /// <typeparam name="T4">The type of the fourth argument.</typeparam>
    /// <typeparam name="T5">The type of the fifth argument.</typeparam>
    /// <typeparam name="T6">The type of the sixth argument.</typeparam>
    /// <param name="definition">The definition of the test data.</param>
    /// <param name="expected">The expected exception of the test data.</param>
    /// <param name="paramName">The name of the parameter that causes the exception.</param>
    /// <param name="message">The message of the exception.</param>
    /// <param name="arg1">The first argument.</param>
    /// <param name="arg2">The second argument.</param>
    /// <param name="arg3">The third argument.</param>
    /// <param name="arg4">The fourth argument.</param>
    /// <param name="arg5">The fifth argument.</param>
    /// <param name="arg6">The sixth argument.</param>
    /// <returns>An array of arguments.</returns>
    internal object?[] TestDataThrowsToArgs<TException, T1, T2, T3, T4, T5, T6>(string definition, TException expected, string paramName, string message, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6) where TException : Exception
    => new TestDataThrows<TException, T1, T2, T3, T4, T5, T6>(definition, expected, paramName, message, arg1, arg2, arg3, arg4, arg5, arg6).ToArgs(ArgsCode);

    /// <summary>
    /// Converts test data to an array of arguments for a test that throws an exception.
    /// </summary>
    /// <typeparam name="TException">The type of the exception that is expected to be thrown.</typeparam>
    /// <typeparam name="T1">The type of the first argument.</typeparam>
    /// <typeparam name="T2">The type of the second argument.</typeparam>
    /// <typeparam name="T3">The type of the third argument.</typeparam>
    /// <typeparam name="T4">The type of the fourth argument.</typeparam>
    /// <typeparam name="T5">The type of the fifth argument.</typeparam>
    /// <typeparam name="T6">The type of the sixth argument.</typeparam>
    /// <typeparam name="T7">The type of the seventh argument.</typeparam>
    /// <param name="definition">The definition of the test data.</param>
    /// <param name="expected">The expected exception of the test data.</param>
    /// <param name="paramName">The name of the parameter that causes the exception.</param>
    /// <param name="message">The message of the exception.</param>
    /// <param name="arg1">The first argument.</param>
    /// <param name="arg2">The second argument.</param>
    /// <param name="arg3">The third argument.</param>
    /// <param name="arg4">The fourth argument.</param>
    /// <param name="arg5">The fifth argument.</param>
    /// <param name="arg6">The sixth argument.</param>
    /// <param name="arg7">The seventh argument.</param>
    /// <returns>An array of arguments.</returns>
    internal object?[] TestDataThrowsToArgs<TException, T1, T2, T3, T4, T5, T6, T7>(string definition, TException expected, string paramName, string message, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7) where TException : Exception
    => new TestDataThrows<TException, T1, T2, T3, T4, T5, T6, T7>(definition, expected, paramName, message, arg1, arg2, arg3, arg4, arg5, arg6, arg7).ToArgs(ArgsCode);

    /// <summary>
    /// Converts test data to an array of arguments for a test that throws an exception.
    /// </summary>
    /// <typeparam name="TException">The type of the exception that is expected to be thrown.</typeparam>
    /// <typeparam name="T1">The type of the first argument.</typeparam>
    /// <typeparam name="T2">The type of the second argument.</typeparam>
    /// <typeparam name="T3">The type of the third argument.</typeparam>
    /// <typeparam name="T4">The type of the fourth argument.</typeparam>
    /// <typeparam name="T5">The type of the fifth argument.</typeparam>
    /// <typeparam name="T6">The type of the sixth argument.</typeparam>
    /// <typeparam name="T7">The type of the seventh argument.</typeparam>
    /// <typeparam name="T8">The type of the eighth argument.</typeparam>
    /// <param name="definition">The definition of the test data.</param>
    /// <param name="expected">The expected exception of the test data.</param>
    /// <param name="paramName">The name of the parameter that causes the exception.</param>
    /// <param name="message">The message of the exception.</param>
    /// <param name="arg1">The first argument.</param>
    /// <param name="arg2">The second argument.</param>
    /// <param name="arg3">The third argument.</param>
    /// <param name="arg4">The fourth argument.</param>
    /// <param name="arg5">The fifth argument.</param>
    /// <param name="arg6">The sixth argument.</param>
    /// <param name="arg7">The seventh argument.</param>
    /// <param name="arg8">The eighth argument.</param>
    /// <returns>An array of arguments.</returns>
    internal object?[] TestDataThrowsToArgs<TException, T1, T2, T3, T4, T5, T6, T7, T8>(string definition, TException expected, string paramName, string message, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8) where TException : Exception
    => new TestDataThrows<TException, T1, T2, T3, T4, T5, T6, T7, T8>(definition, expected, paramName, message, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8).ToArgs(ArgsCode);

    /// <summary>
    /// Converts test data to an array of arguments for a test that throws an exception.
    /// </summary>
    /// <typeparam name="TException">The type of the exception that is expected to be thrown.</typeparam>
    /// <typeparam name="T1">The type of the first argument.</typeparam>
    /// <typeparam name="T2">The type of the second argument.</typeparam>
    /// <typeparam name="T3">The type of the third argument.</typeparam>
    /// <typeparam name="T4">The type of the fourth argument.</typeparam>
    /// <typeparam name="T5">The type of the fifth argument.</typeparam>
    /// <typeparam name="T6">The type of the sixth argument.</typeparam>
    /// <typeparam name="T7">The type of the seventh argument.</typeparam>
    /// <typeparam name="T8">The type of the eighth argument.</typeparam>
    /// <typeparam name="T9">The type of the ninth argument.</typeparam>
    /// <param name="definition">The definition of the test data.</param>
    /// <param name="expected">The expected exception of the test data.</param>
    /// <param name="paramName">The name of the parameter that causes the exception.</param>
    /// <param name="message">The message of the exception.</param>
    /// <param name="arg1">The first argument.</param>
    /// <param name="arg2">The second argument.</param>
    /// <param name="arg3">The third argument.</param>
    /// <param name="arg4">The fourth argument.</param>
    /// <param name="arg5">The fifth argument.</param>
    /// <param name="arg6">The sixth argument.</param>
    /// <param name="arg7">The seventh argument.</param>
    /// <param name="arg8">The eighth argument.</param>
    /// <param name="arg9">The ninth argument.</param>
    /// <returns>An array of arguments.</returns>
    internal object?[] TestDataThrowsToArgs<TException, T1, T2, T3, T4, T5, T6, T7, T8, T9>(string definition, TException expected, string paramName, string message, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8, T9? arg9) where TException : Exception
    => new TestDataThrows<TException, T1, T2, T3, T4, T5, T6, T7, T8, T9>(definition, expected, paramName, message, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9).ToArgs(ArgsCode);
    #endregion
    #endregion
}
