namespace CsabaDu.DynamicTestData.Tests.TestDoubles;

public sealed record TestDataChild(string Definition, string result, string exitMode) : TestData(Definition)
{
    public override string Result => result;
    public override string ExitMode => exitMode;
}
