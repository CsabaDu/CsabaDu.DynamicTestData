namespace CsabaDu.DynamicTestData.TestDataTypes;

#region Abstract type
public abstract record TestDataThrows<TException>(string Definition, string ParamName, string Message)
    : TestData<TException>(Definition, typeof(TException).Name), ITestDataThrows<TException>
    where TException : Exception
{
    public Type ExceptionType => typeof(TException);

    public override object?[] ToArgs(ArgsCode argsCode)
    => argsCode == ArgsCode.Properties ? [TestCase, ParamName, Message, ExceptionType] : base.ToArgs(argsCode);
}
#endregion

#region Concrete types
public record TestDataThrows<TException, T1>(string Definition, string ParamName, string Message, T1? Arg1)
    : TestDataThrows<TException>(Definition, ParamName, Message)
    where TException : Exception
{
    public override object?[] ToArgs(ArgsCode argsCode)
    => argsCode == ArgsCode.Properties ? base.ToArgs(argsCode).Append(Arg1) : base.ToArgs(argsCode);
}

public record TestDataThrows<TException, T1, T2>(string Definition, string ParamName, string Message, T1? Arg1, T2? Arg2)
    : TestDataThrows<TException, T1>(Definition, ParamName, Message, Arg1)
    where TException : Exception
{
    public override object?[] ToArgs(ArgsCode argsCode)
    => argsCode == ArgsCode.Properties ? base.ToArgs(argsCode).Append(Arg2) : base.ToArgs(argsCode);
}

public record TestDataThrows<TException, T1, T2, T3>(string Definition, string ParamName, string Message, T1? Arg1, T2? Arg2, T3? Arg3)
    : TestDataThrows<TException, T1, T2>(Definition, ParamName, Message, Arg1, Arg2)
    where TException : Exception
{
    public override object?[] ToArgs(ArgsCode argsCode)
    => argsCode == ArgsCode.Properties ? base.ToArgs(argsCode).Append(Arg3) : base.ToArgs(argsCode);
}

public record TestDataThrows<TException, T1, T2, T3, T4>(string Definition, string ParamName, string Message, T1? Arg1, T2? Arg2, T3? Arg3, T4? Arg4)
    : TestDataThrows<TException, T1, T2, T3>(Definition, ParamName, Message, Arg1, Arg2, Arg3)
    where TException : Exception
{
    public override object?[] ToArgs(ArgsCode argsCode)
    => argsCode == ArgsCode.Properties ? base.ToArgs(argsCode).Append(Arg4) : base.ToArgs(argsCode);
}

public record TestDataThrows<TException, T1, T2, T3, T4, T5>(string Definition, string ParamName, string Message, T1? Arg1, T2? Arg2, T3? Arg3, T4? Arg4, T5? Arg5)
    : TestDataThrows<TException, T1, T2, T3, T4>(Definition, ParamName, Message, Arg1, Arg2, Arg3, Arg4)
    where TException : Exception
{
    public override object?[] ToArgs(ArgsCode argsCode)
    => argsCode == ArgsCode.Properties ? base.ToArgs(argsCode).Append(Arg5) : base.ToArgs(argsCode);
}

public record TestDataThrows<TException, T1, T2, T3, T4, T5, T6>(string Definition, string ParamName, string Message, T1? Arg1, T2? Arg2, T3? Arg3, T4? Arg4, T5? Arg5, T6? Arg6)
    : TestDataThrows<TException, T1, T2, T3, T4, T5>(Definition, ParamName, Message, Arg1, Arg2, Arg3, Arg4, Arg5)
    where TException : Exception
{
    public override object?[] ToArgs(ArgsCode argsCode)
    => argsCode == ArgsCode.Properties ? base.ToArgs(argsCode).Append(Arg6) : base.ToArgs(argsCode);
}

public record TestDataThrows<TException, T1, T2, T3, T4, T5, T6, T7>(string Definition, string ParamName, string Message, T1? Arg1, T2? Arg2, T3? Arg3, T4? Arg4, T5? Arg5, T6? Arg6, T7? Arg7)
    : TestDataThrows<TException, T1, T2, T3, T4, T5, T6>(Definition, ParamName, Message, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6)
    where TException : Exception
{
    public override object?[] ToArgs(ArgsCode argsCode)
    => argsCode == ArgsCode.Properties ? base.ToArgs(argsCode).Append(Arg7) : base.ToArgs(argsCode);
}
#endregion