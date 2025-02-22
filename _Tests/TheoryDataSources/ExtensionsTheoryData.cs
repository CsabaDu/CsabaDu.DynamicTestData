namespace CsabaDu.DynamicTestData.Tests.TheoryDataSources;

public class ExtensionsTheoryData()
{
    public static TheoryData<ArgsCode, string, object[]> AddTheoryData => new()
    {
        // Returns the object array with same elements.
        { ArgsCode.Instance, Parameter, ExtensionsArgs0 },

        // Returns the same object array with the new notnull element.
        { ArgsCode.Properties, Parameter, [.. ExtensionsArgs0, Parameter] },

        // Returns the same object array with the new null element.
        { ArgsCode.Properties, null, [.. ExtensionsArgs0, null] }
    };
}
