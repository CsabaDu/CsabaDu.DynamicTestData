namespace CsabaDu.DynamicTestData.Tests.DynamicDataSources;

public record TestDataRecord(string TestCaseName, params object[] Params)
{
    internal object[] ToArgs() => [this];
    public override sealed string ToString() => TestCaseName;
}
