using NUnit.Framework;

namespace CsabaDu.DynamicTestData.TestHelpers.TestParameters;

public class TestCaseDataArgs
{
    public static TestCaseData GetTestCaseData(string description, params object[] args)
    => new TestCaseData(args).SetDescription(description);
}
