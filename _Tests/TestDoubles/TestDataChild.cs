namespace CsabaDu.DynamicTestData.Tests.TestDoubles;

public record TestDataChild <TResult> : TestData<TResult> where TResult : notnull
{
    public TestDataChild(string Definition, string Result, string exitMode) : base(Definition, Result)
    {
        ExitMode = exitMode;
    }

    protected override string ExitMode { get; }
}
