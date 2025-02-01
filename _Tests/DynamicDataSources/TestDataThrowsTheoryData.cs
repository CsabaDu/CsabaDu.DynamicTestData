namespace CsabaDu.DynamicTestData.Tests.DynamicDataSources;

public class TestDataThrowsTheoryData
{
    public static TheoryData<ArgsCode, ITestDataThrows<DummyException>, object[]> ToArgsTheoryData => new()
    {
        #region ArgsCode.Properties
        { ArgsCode.Properties, TestDataThrowsArgs1, [.. TestDataThrowsArgs0, .. Args1] },
        { ArgsCode.Properties, TestDataThrowsArgs2, [.. TestDataThrowsArgs0, .. Args2] },
        { ArgsCode.Properties, TestDataThrowsArgs3, [.. TestDataThrowsArgs0, .. Args3] },
        { ArgsCode.Properties, TestDataThrowsArgs4, [.. TestDataThrowsArgs0, .. Args4] },
        { ArgsCode.Properties, TestDataThrowsArgs5, [.. TestDataThrowsArgs0, .. Args5] },
        { ArgsCode.Properties, TestDataThrowsArgs6, [.. TestDataThrowsArgs0, .. Args6] },
        { ArgsCode.Properties, TestDataThrowsArgs7, [.. TestDataThrowsArgs0, .. Args7] },
        { ArgsCode.Properties, TestDataThrowsArgs8, [.. TestDataThrowsArgs0, .. Args8] },
        { ArgsCode.Properties, TestDataThrowsArgs9, [.. TestDataThrowsArgs0, .. Args9] },
        #endregion

        #region ArgsCode.Instance
        { ArgsCode.Instance, TestDataThrowsArgs1, [TestDataThrowsArgs1] },
        { ArgsCode.Instance, TestDataThrowsArgs2, [TestDataThrowsArgs2] },
        { ArgsCode.Instance, TestDataThrowsArgs3, [TestDataThrowsArgs3] },
        { ArgsCode.Instance, TestDataThrowsArgs4, [TestDataThrowsArgs4] },
        { ArgsCode.Instance, TestDataThrowsArgs5, [TestDataThrowsArgs5] },
        { ArgsCode.Instance, TestDataThrowsArgs6, [TestDataThrowsArgs6] },
        { ArgsCode.Instance, TestDataThrowsArgs7, [TestDataThrowsArgs7] },
        { ArgsCode.Instance, TestDataThrowsArgs8, [TestDataThrowsArgs8] },
        { ArgsCode.Instance, TestDataThrowsArgs9, [TestDataThrowsArgs9] },
        #endregion
    };
}
