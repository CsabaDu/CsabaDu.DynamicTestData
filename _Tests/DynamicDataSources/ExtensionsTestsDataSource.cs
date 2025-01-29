namespace CsabaDu.DynamicTestData.Tests.DynamicDataSources;

public class ExtensionsTestsDataSource()
{
    public static readonly object[] Args = [null, 1];

    public static TheoryData<ArgsCode, string, object[]> AddArgsList => new()
    {
        // Returns the object array with same elements.
        { ArgsCode.Instance, Params.Parameter, Args },

        // Returns the same object array with the new null element.
        { ArgsCode.Properties, Params.Parameter, [.. Args, Params.Parameter] },

        // Returns the same object array with the new null element.
        { ArgsCode.Properties, null, [.. Args, null] }
    };
}
