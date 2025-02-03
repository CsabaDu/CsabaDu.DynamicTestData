namespace CsabaDu.DynamicTestData.Tests.DynamicDataSources;

public class DynamicDataSourceTheoryData
{
    #region GetDisplayName data sources
    public static TheoryData<ArgsCode> GetDisplayNameTheoryData => new()
    {
        { ArgsCode.Instance },
        { ArgsCode.Properties },
    };
    #endregion

    #region TestDataToArgs data sources
    public static TheoryData<ArgsCode, object[]> TestDataToArgs1ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataArgs1] },
        { ArgsCode.Properties, [.. TestDataArgs0, Arg1] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataToArgs2ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataArgs2] },
        { ArgsCode.Properties, [.. TestDataArgs0, .. Args2] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataToArgs3ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataArgs3] },
        { ArgsCode.Properties, [.. TestDataArgs0, .. Args3] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataToArgs4ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataArgs4] },
        { ArgsCode.Properties, [.. TestDataArgs0, .. Args4] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataToArgs5ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataArgs5] },
        { ArgsCode.Properties, [.. TestDataArgs0, .. Args5] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataToArgs6ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataArgs6] },
        { ArgsCode.Properties, [.. TestDataArgs0, .. Args6] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataToArgs7ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataArgs7] },
        { ArgsCode.Properties, [.. TestDataArgs0, .. Args7] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataToArgs8ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataArgs8] },
        { ArgsCode.Properties, [.. TestDataArgs0, .. Args8] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataToArgs9ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataArgs9] },
        { ArgsCode.Properties, [.. TestDataArgs0, .. Args9] },
    };
    #endregion

    #region TestDataReturnsToArgs data sources
    public static TheoryData<ArgsCode, object[]> TestDataReturnsToArgs1ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataReturnsArgs1] },
        { ArgsCode.Properties, [.. TestDataReturnsArgs0, Arg1] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataReturnsToArgs2ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataReturnsArgs2] },
        { ArgsCode.Properties, [.. TestDataReturnsArgs0, .. Args2] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataReturnsToArgs3ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataReturnsArgs3] },
        { ArgsCode.Properties, [.. TestDataReturnsArgs0, .. Args3] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataReturnsToArgs4ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataReturnsArgs4] },
        { ArgsCode.Properties, [.. TestDataReturnsArgs0, .. Args4] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataReturnsToArgs5ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataReturnsArgs5] },
        { ArgsCode.Properties, [.. TestDataReturnsArgs0, .. Args5] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataReturnsToArgs6ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataReturnsArgs6] },
        { ArgsCode.Properties, [.. TestDataReturnsArgs0, .. Args6] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataReturnsToArgs7ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataReturnsArgs7] },
        { ArgsCode.Properties, [.. TestDataReturnsArgs0, .. Args7] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataReturnsToArgs8ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataReturnsArgs8] },
        { ArgsCode.Properties, [.. TestDataReturnsArgs0, .. Args8] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataReturnsToArgs9ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataReturnsArgs9] },
        { ArgsCode.Properties, [.. TestDataReturnsArgs0, .. Args9] },
    };
    #endregion

    #region TestDataThrowsToArgs data sources
    public static TheoryData<ArgsCode, object[]> TestDataThrowsToArgs1ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataThrowsArgs1] },
        { ArgsCode.Properties, [.. TestDataThrowsArgs0, Arg1] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataThrowsToArgs2ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataThrowsArgs2] },
        { ArgsCode.Properties, [.. TestDataThrowsArgs0, .. Args2] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataThrowsToArgs3ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataThrowsArgs3] },
        { ArgsCode.Properties, [.. TestDataThrowsArgs0, .. Args3] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataThrowsToArgs4ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataThrowsArgs4] },
        { ArgsCode.Properties, [.. TestDataThrowsArgs0, .. Args4] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataThrowsToArgs5ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataThrowsArgs5] },
        { ArgsCode.Properties, [.. TestDataThrowsArgs0, .. Args5] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataThrowsToArgs6ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataThrowsArgs6] },
        { ArgsCode.Properties, [.. TestDataThrowsArgs0, .. Args6] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataThrowsToArgs7ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataThrowsArgs7] },
        { ArgsCode.Properties, [.. TestDataThrowsArgs0, .. Args7] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataThrowsToArgs8ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataThrowsArgs8] },
        { ArgsCode.Properties, [.. TestDataThrowsArgs0, .. Args8] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataThrowsToArgs9ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataThrowsArgs9] },
        { ArgsCode.Properties, [.. TestDataThrowsArgs0, .. Args9] },
    };
    #endregion
}
