namespace CsabaDu.DynamicTestData.SampleCodes;

public class DemoClassTestsDataSource_Native(ArgsCode argsCode) : DynamicDataSource(argsCode)
{
    public IEnumerable<object?[]> IsOlderReturnsArgsToList()
    {
        DateTime dateTimeNow = DateTime.Now;

        bool expected = true;
        string definition = "thisDate is greater than otherDate";
        DateTime thisDate = dateTimeNow.AddDays(1);
        DateTime otherDate = dateTimeNow;
        yield return testDataToArgs();

        expected = false;
        definition = "thisDate equals otherDate";
        otherDate = otherDate.AddDays(1);
        yield return testDataToArgs();

        definition = "thisDate is less thann otherDate";
        thisDate = thisDate.AddDays(-1);
        yield return testDataToArgs();

        object?[] testDataToArgs() => TestDataReturnsToArgs(definition, expected, thisDate, otherDate);
    }
}
