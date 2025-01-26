namespace CsabaDu.DynamicTestData.Tests.DynamicDataSources;

public class ExtensionsTestsDataSources()
{
    private static readonly object[] Args = [null, 1];

    public readonly object[] Sut = Args;

    public static TheoryData<ArgsCode, string, object[]> AddArgsList => new()
    {
        // Returns object array with same elements.
        { ArgsCode.Instance, "test", Args },

        // Returns the object array with the new null element.
        { ArgsCode.Properties, "test", [.. Args, "test"] },

        // Returns the object array with the new null element.
        { ArgsCode.Properties, null, [.. Args, null] }
    };
}
