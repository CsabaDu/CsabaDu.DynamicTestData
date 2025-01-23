namespace CsabaDu.DynamicTestData;

public abstract class DynamicDataSource(ArgsCode argsCode)
{
    #region Properties
    protected ArgsCode ArgsCode { get; } = argsCode;
    #endregion

    #region Methods
    #region TestDataToArgs
    protected object?[] TestDataToArgs<T1>(string definition, string result, T1? arg1)
    => new TestData<string, T1>(definition, result, arg1).ToArgs(ArgsCode);

    protected object?[] TestDataToArgs<T1, T2>(string definition, string result, T1? arg1, T2? arg2)
    => new TestData<string, T1, T2>(definition, result, arg1, arg2).ToArgs(ArgsCode);

    protected object?[] TestDataToArgs<T1, T2, T3>(string definition, string result, T1? arg1, T2? arg2, T3? arg3)
    => new TestData<string, T1, T2, T3>(definition, result, arg1, arg2, arg3).ToArgs(ArgsCode);

    protected object?[] TestDataToArgs<T1, T2, T3, T4>(string definition, string result, T1? arg1, T2? arg2, T3? arg3, T4? arg4)
    => new TestData<string, T1, T2, T3, T4>(definition, result, arg1, arg2, arg3, arg4).ToArgs(ArgsCode);

    protected object?[] TestDataToArgs<T1, T2, T3, T4, T5>(string definition, string result, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5)
    => new TestData<string, T1, T2, T3, T4, T5>(definition, result, arg1, arg2, arg3, arg4, arg5).ToArgs(ArgsCode);

    protected object?[] TestDataToArgs<T1, T2, T3, T4, T5, T6>(string definition, string result, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6)
    => new TestData<string, T1, T2, T3, T4, T5, T6>(definition, result, arg1, arg2, arg3, arg4, arg5, arg6).ToArgs(ArgsCode);

    protected object?[] TestDataToArgs<T1, T2, T3, T4, T5, T6, T7>(string definition, string result, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7)
    => new TestData<string, T1, T2, T3, T4, T5, T6, T7>(definition, result, arg1, arg2, arg3, arg4, arg5, arg6, arg7).ToArgs(ArgsCode);
    #endregion

    #region TestDataReturnsToArgs
    protected object?[] TestDataReturnsToArgs<TStruct, T1>(string definition, TStruct expected, T1? arg1) where TStruct : struct
    => new TestDataReturns<TStruct, T1>(definition, expected, arg1).ToArgs(ArgsCode);

    protected object?[] TestDataReturnsToArgs<TStruct, T1, T2>(string definition, TStruct expected, T1? arg1, T2? arg2) where TStruct : struct
    => new TestDataReturns<TStruct, T1, T2>(definition, expected, arg1, arg2).ToArgs(ArgsCode);

    protected object?[] TestDataReturnsToArgs<TStruct, T1, T2, T3>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3) where TStruct : struct
    => new TestDataReturns<TStruct, T1, T2, T3>(definition, expected, arg1, arg2, arg3).ToArgs(ArgsCode);

    protected object?[] TestDataReturnsToArgs<TStruct, T1, T2, T3, T4>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4) where TStruct : struct
    => new TestDataReturns<TStruct, T1, T2, T3, T4>(definition, expected, arg1, arg2, arg3, arg4).ToArgs(ArgsCode);

    protected object?[] TestDataReturnsToArgs<TStruct, T1, T2, T3, T4, T5>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5) where TStruct : struct
    => new TestDataReturns<TStruct, T1, T2, T3, T4, T5>(definition, expected, arg1, arg2, arg3, arg4, arg5).ToArgs(ArgsCode);

    protected object?[] TestDataReturnsToArgs<TStruct, T1, T2, T3, T4, T5, T6>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? args6) where TStruct : struct
    => new TestDataReturns<TStruct, T1, T2, T3, T4, T5, T6>(definition, expected, arg1, arg2, arg3, arg4, arg5, args6).ToArgs(ArgsCode);

    protected object?[] TestDataReturnsToArgs<TStruct, T1, T2, T3, T4, T5, T6, T7>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7) where TStruct : struct
    => new TestDataReturns<TStruct, T1, T2, T3, T4, T5, T6, T7>(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7).ToArgs(ArgsCode);
    #endregion

    #region TestDataThrowsToArgs
    protected object?[] TestDataThrowsToArgs<TException, T1>(string definition, string paramName, string message, T1? arg1) where TException : Exception
    => new TestDataThrows<TException, T1>(definition, paramName, message, arg1).ToArgs(ArgsCode);

    protected object?[] TestDataThrowsToArgs<TException, T1, T2>(string definition, string paramName, string message, T1? arg1, T2? arg2) where TException : Exception
    => new TestDataThrows<TException, T1, T2>(definition, paramName, message, arg1, arg2).ToArgs(ArgsCode);

    protected object?[] TestDataThrowsToArgs<TException, T1, T2, T3>(string definition, string paramName, string message, T1? arg1, T2? arg2, T3? arg3) where TException : Exception
    => new TestDataThrows<TException, T1, T2, T3>(definition, paramName, message, arg1, arg2, arg3).ToArgs(ArgsCode);

    protected object?[] TestDataThrowsToArgs<TException, T1, T2, T3, T4>(string definition, string paramName, string message, T1? arg1, T2? arg2, T3? arg3, T4? arg4) where TException : Exception
    => new TestDataThrows<TException, T1, T2, T3, T4>(definition, paramName, message, arg1, arg2, arg3, arg4).ToArgs(ArgsCode);

    protected object?[] TestDataThrowsToArgs<TException, T1, T2, T3, T4, T5>(string definition, string paramName, string message, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5) where TException : Exception
    => new TestDataThrows<TException, T1, T2, T3, T4, T5>(definition, paramName, message, arg1, arg2, arg3, arg4, arg5).ToArgs(ArgsCode);

    protected object?[] TestDataThrowsToArgs<TException, T1, T2, T3, T4, T5, T6>(string definition, string paramName, string message, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6) where TException : Exception
    => new TestDataThrows<TException, T1, T2, T3, T4, T5, T6>(definition, paramName, message, arg1, arg2, arg3, arg4, arg5, arg6).ToArgs(ArgsCode);

    protected object?[] TestDataThrowsToArgs<TException, T1, T2, T3, T4, T5, T6, T7>(string definition, string paramName, string message, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7) where TException : Exception
    => new TestDataThrows<TException, T1, T2, T3, T4, T5, T6, T7>(definition, paramName, message, arg1, arg2, arg3, arg4, arg5, arg6, arg7).ToArgs(ArgsCode);
    #endregion
    #endregion
}
