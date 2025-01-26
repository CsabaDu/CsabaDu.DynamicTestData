namespace CsabaDu.DynamicTestData.Tests.DynamicDataSources;

public class ExtensionsTestsDataSources()
{
    private static readonly object[] args = [null, 1];

    public readonly object[] Args = args;

    public static TheoryData<ArgsCode, string, object[]> AddArgsList => new()
    {
        // Returns object array with same elements.
        { ArgsCode.Instance, "test", args },

        // Returns the object array with the new null element.
        { ArgsCode.Properties, "test", [.. args, "test"] },

        // Returns the object array with the new null element.
        { ArgsCode.Properties, null, [.. args, null] }
    };
}
