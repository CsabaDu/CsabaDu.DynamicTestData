namespace CsabaDu.DynamicTestData.Tests.DynamicDataSources;

public class DynamicDataSourceTheoryData
{
    private static object[] GetArgs(ArgsCode argsCode) => [argsCode, ActualDefinition, ExpectedString];

    public static TheoryData<object[], object[]> TestDataToArgsTheoryData
    {
        get
        {
            TheoryData<object[], object[]> theoryData = [];
            object[] instanceArgs = GetArgs(ArgsCode.Instance);
            object[] propertiesArgs = GetArgs(ArgsCode.Properties);
            object[] expectedArgs = [TestDataTestCase];
            object[] testDataArray = typeof(TestDataTheoryData)
                .GetFields(BindingFlags.Public | BindingFlags.Static)
                //.Where(p => nameof(p).StartsWith("TestDataArgs"))
                .Select(p => p.GetValue(null))
                .OfType<ITestData<string>>().ToArray();

            for (int i = 0; i < Args9.Length; i++)
            {
                add(instanceArgs, [testDataArray[i]], i);

                expectedArgs = [.. expectedArgs, Args9[i]];
                add(propertiesArgs, expectedArgs, i);
            }

            return theoryData;

            void add(object[] argsIn, object[] expectedArgs, int index)
            {
                argsIn = [.. argsIn, Args9[index]];
                theoryData.Add(argsIn, expectedArgs);
            }
        }
    }
}
