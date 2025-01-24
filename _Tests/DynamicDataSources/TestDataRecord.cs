namespace CsabaDu.DynamicTestData.Tests.DynamicDataSources;

public record TestDataRecord(string TestCaseName, params object[] TestParams)
{
    internal object[] ToArgs() => [this];
    public override sealed string ToString() => TestCaseName;
}
