﻿namespace CsabaDu.DynamicTestData;

public abstract class DynamicDataSource(ArgsCode argsCode)
{
    #region Properties
    protected ArgsCode ArgsCode { get; } = argsCode;

    protected string Definition { private get; set; } = "(Not defined testcase)";

    protected string ParamName { get; set; } = string.Empty;

    protected string MessageContent { private get; set; } = string.Empty;
    #endregion

    #region Methods
    #region TestDataToArgs
    protected object?[] TestDataToArgs<T1>(string outcome, T1? arg1)
    => new TestData<string, T1>(Definition, outcome, arg1).ToArgs(ArgsCode);

    protected object?[] TestDataToArgs<T1, T2>(string outcome, T1? arg1, T2? arg2)
    => new TestData<string, T1, T2>(Definition, outcome, arg1, arg2).ToArgs(ArgsCode);

    protected object?[] TestDataToArgs<T1, T2, T3>(string outcome, T1? arg1, T2? arg2, T3? arg3)
    => new TestData<string, T1, T2, T3>(Definition, outcome, arg1, arg2, arg3).ToArgs(ArgsCode);

    protected object?[] TestDataToArgs<T1, T2, T3, T4>(string outcome, T1? arg1, T2? arg2, T3? arg3, T4? arg4)
    => new TestData<string, T1, T2, T3, T4>(Definition, outcome, arg1, arg2, arg3, arg4).ToArgs(ArgsCode);

    protected object?[] TestDataToArgs<T1, T2, T3, T4, T5>(string outcome, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5)
    => new TestData<string, T1, T2, T3, T4, T5>(Definition, outcome, arg1, arg2, arg3, arg4, arg5).ToArgs(ArgsCode);

    protected object?[] TestDataToArgs<T1, T2, T3, T4, T5, T6>(string outcome, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6)
    => new TestData<string, T1, T2, T3, T4, T5, T6>(Definition, outcome, arg1, arg2, arg3, arg4, arg5, arg6).ToArgs(ArgsCode);

    protected object?[] TestDataToArgs<T1, T2, T3, T4, T5, T6, T7>(string outcome, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7)
    => new TestData<string, T1, T2, T3, T4, T5, T6, T7>(Definition, outcome, arg1, arg2, arg3, arg4, arg5, arg6, arg7).ToArgs(ArgsCode);
    #endregion

    #region TestDataReturnsToArgs
    protected object?[] TestDataReturnsToArgs<TStruct, T1>(TStruct expected, T1? arg1) where TStruct : struct
    => new TestDataReturns<TStruct, T1>(Definition, expected, arg1).ToArgs(ArgsCode);

    protected object?[] TestDataReturnsToArgs<TStruct, T1, T2>(TStruct expected, T1? arg1, T2? arg2) where TStruct : struct
    => new TestDataReturns<TStruct, T1, T2>(Definition, expected, arg1, arg2).ToArgs(ArgsCode);

    protected object?[] TestDataReturnsToArgs<TStruct, T1, T2, T3>(TStruct expected, T1? arg1, T2? arg2, T3? arg3) where TStruct : struct
    => new TestDataReturns<TStruct, T1, T2, T3>(Definition, expected, arg1, arg2, arg3).ToArgs(ArgsCode);

    protected object?[] TestDataReturnsToArgs<TStruct, T1, T2, T3, T4>(TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4) where TStruct : struct
    => new TestDataReturns<TStruct, T1, T2, T3, T4>(Definition, expected, arg1, arg2, arg3, arg4).ToArgs(ArgsCode);

    protected object?[] TestDataReturnsToArgs<TStruct, T1, T2, T3, T4, T5>(TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5) where TStruct : struct
    => new TestDataReturns<TStruct, T1, T2, T3, T4, T5>(Definition, expected, arg1, arg2, arg3, arg4, arg5).ToArgs(ArgsCode);

    protected object?[] TestDataReturnsToArgs<TStruct, T1, T2, T3, T4, T5, T6>(TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? args6) where TStruct : struct
    => new TestDataReturns<TStruct, T1, T2, T3, T4, T5, T6>(Definition, expected, arg1, arg2, arg3, arg4, arg5, args6).ToArgs(ArgsCode);

    protected object?[] TestDataReturnsToArgs<TStruct, T1, T2, T3, T4, T5, T6, T7>(TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7) where TStruct : struct
    => new TestDataReturns<TStruct, T1, T2, T3, T4, T5, T6, T7>(Definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7).ToArgs(ArgsCode);
    #endregion

    #region TestDataThrowsToArgs
    protected object?[] TestDataThrowsToArgs<TException, T1>(T1? arg1, object? value = null) where TException : Exception
    => new TestDataThrows<TException, T1>(Definition, ParamName, MessageContent, arg1).SetMessage(value).ToArgs(ArgsCode);

    protected object?[] TestDataThrowsToArgs<TException, T1, T2>(T1? arg1, T2? arg2, object? value = null) where TException : Exception
    => new TestDataThrows<TException, T1, T2>(Definition, ParamName, MessageContent, arg1, arg2).SetMessage(value).ToArgs(ArgsCode);

    protected object?[] TestDataThrowsToArgs<TException, T1, T2, T3>(T1? arg1, T2? arg2, T3? arg3, object? value = null) where TException : Exception
    => new TestDataThrows<TException, T1, T2, T3>(Definition, ParamName, MessageContent, arg1, arg2, arg3).SetMessage(value).ToArgs(ArgsCode);

    protected object?[] TestDataThrowsToArgs<TException, T1, T2, T3, T4>(T1? arg1, T2? arg2, T3? arg3, T4? arg4, object? value = null) where TException : Exception
    => new TestDataThrows<TException, T1, T2, T3, T4>(Definition, ParamName, MessageContent, arg1, arg2, arg3, arg4).SetMessage(value).ToArgs(ArgsCode);

    protected object?[] TestDataThrowsToArgs<TException, T1, T2, T3, T4, T5>(T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, object? value = null) where TException : Exception
    => new TestDataThrows<TException, T1, T2, T3, T4, T5>(Definition, ParamName, MessageContent, arg1, arg2, arg3, arg4, arg5).SetMessage(value).ToArgs(ArgsCode);

    protected object?[] TestDataThrowsToArgs<TException, T1, T2, T3, T4, T5, T6>(T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, object? value = null) where TException : Exception
    => new TestDataThrows<TException, T1, T2, T3, T4, T5, T6>(Definition, ParamName, MessageContent, arg1, arg2, arg3, arg4, arg5, arg6).SetMessage(value).ToArgs(ArgsCode);

    protected object?[] TestDataThrowsToArgs<TException, T1, T2, T3, T4, T5, T6, T7>(T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, object? value = null) where TException : Exception
    => new TestDataThrows<TException, T1, T2, T3, T4, T5, T6, T7>(Definition, ParamName, MessageContent, arg1, arg2, arg3, arg4, arg5, arg6, arg7).SetMessage(value).ToArgs(ArgsCode);
    #endregion
    #endregion
}
