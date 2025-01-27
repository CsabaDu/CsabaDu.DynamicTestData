namespace CsabaDu.DynamicTestData.Tests.DynamicDataSources;

public class ExtensionsTestsDataSources()
{
    public static readonly object[] Args = [null, 1];
    private static readonly string Parameter = "test";

    public static TheoryData<ArgsCode, string, object[]> AddArgsList => new()
    {
        // Returns the object array with same elements.
        { ArgsCode.Instance, Parameter, Args },

        // Returns the same object array with the new null element.
        { ArgsCode.Properties, Parameter, [.. Args, Parameter] },

        // Returns the sam me object array with the new null element.
        { ArgsCode.Properties, null, [.. Args, null] }
    };
}
