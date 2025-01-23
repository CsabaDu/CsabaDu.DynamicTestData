namespace CsabaDu.DynamicTestData.TestDataTypes;

public abstract record TestData<TResult>(string Definition, string Result) : ITestData where TResult : notnull
{
    private readonly string NotNullResult = Result ?? string.Empty;

    private string ExitMode
    {
        get
        {
            const char GraveAccent = '`';
            string typeName = GetType().Name;
            int testDataNameLength = nameof(TestData<TResult>).Length;
            int graveAccentIndex = typeName.IndexOf(GraveAccent, testDataNameLength);

            return graveAccentIndex > -1 ?
                typeName[testDataNameLength..graveAccentIndex]
                : typeName[testDataNameLength..];
        }
    }

    public string TestCase => ExitMode == string.Empty ?
        $"{Definition} => {NotNullResult}"
        : $"{Definition} => {ExitMode} {NotNullResult}";

    public virtual object?[] ToArgs(ArgsCode argsCode)
    {
        return argsCode switch
        {
            ArgsCode.Instance => [this],
            ArgsCode.Properties => [TestCase],
            _ => throw new InvalidEnumArgumentException(nameof(argsCode), (int)(object)argsCode, typeof(ArgsCode)),
        };
    }

    public override sealed string ToString() => TestCase;
}

public record TestData<String, T1>(string Definition, string Result, T1? Arg1)
    : TestData<string>(Definition, Result), ITestData<String>
{
    public override object?[] ToArgs(ArgsCode argsCode)
    => argsCode == ArgsCode.Properties ? base.ToArgs(argsCode).Append(Arg1) : base.ToArgs(argsCode);
}

public record TestData<String, T1, T2>(string Definition, string Result, T1? Arg1, T2? Arg2)
    : TestData<string, T1>(Definition, Result, Arg1)
{
    public override object?[] ToArgs(ArgsCode argsCode)
    => argsCode == ArgsCode.Properties ? base.ToArgs(argsCode).Append(Arg2) : base.ToArgs(argsCode);
}

public record TestData<String, T1, T2, T3>(string Definition, string Result, T1? Arg1, T2? Arg2, T3? Arg3)
    : TestData<string, T1, T2>(Definition, Result, Arg1, Arg2)
{
    public override object?[] ToArgs(ArgsCode argsCode)
    => argsCode == ArgsCode.Properties ? base.ToArgs(argsCode).Append(Arg3) : base.ToArgs(argsCode);
}

public record TestData<String, T1, T2, T3, T4>(string Definition, string Result, T1? Arg1, T2? Arg2, T3? Arg3, T4? Arg4)
    : TestData<string, T1, T2, T3>(Definition, Result, Arg1, Arg2, Arg3)
{
    public override object?[] ToArgs(ArgsCode argsCode)
    => argsCode == ArgsCode.Properties ? base.ToArgs(argsCode).Append(Arg4) : base.ToArgs(argsCode);
}

public record TestData<String, T1, T2, T3, T4, T5>(string Definition, string Result, T1? Arg1, T2? Arg2, T3? Arg3, T4? Arg4, T5? Arg5)
    : TestData<string, T1, T2, T3, T4>(Definition, Result, Arg1, Arg2, Arg3, Arg4)
{
    public override object?[] ToArgs(ArgsCode argsCode)
    => argsCode == ArgsCode.Properties ? base.ToArgs(argsCode).Append(Arg5) : base.ToArgs(argsCode);
}

public record TestData<String, T1, T2, T3, T4, T5, T6>(string Definition, string Result, T1? Arg1, T2? Arg2, T3? Arg3, T4? Arg4, T5? Arg5, T6? Arg6)
    : TestData<string, T1, T2, T3, T4, T5>(Definition, Result, Arg1, Arg2, Arg3, Arg4, Arg5)
{
    public override object?[] ToArgs(ArgsCode argsCode)
    => argsCode == ArgsCode.Properties ? base.ToArgs(argsCode).Append(Arg6) : base.ToArgs(argsCode);
}

public record TestData<String, T1, T2, T3, T4, T5, T6, T7>(string Definition, string Result, T1? Arg1, T2? Arg2, T3? Arg3, T4? Arg4, T5? Arg5, T6? Arg6, T7? Arg7)
    : TestData<string, T1, T2, T3, T4, T5, T6>(Definition, Result, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6)
{
    public override object?[] ToArgs(ArgsCode argsCode)
    => argsCode == ArgsCode.Properties ? base.ToArgs(argsCode).Append(Arg7) : base.ToArgs(argsCode);
}
