namespace CsabaDu.DynamicTestData.SampleCodes;

public class DemoClassTestsDataSource_Native(ArgsCode argsCode) : DynamicDataSource(argsCode)
{
    private readonly DateTime DateTimeNow = DateTime.Now;

    private DateTime _thisDate;
    private DateTime _otherDate;

    public IEnumerable<object?[]> IsOlderReturnsArgsToList()
    {
        bool expected = true;
        _thisDate = DateTimeNow;
        _otherDate = DateTimeNow.AddDays(-1);
        yield return testDataToArgs("thisDate is greater than otherDate");

        expected = false;
        _otherDate = DateTimeNow;
        yield return testDataToArgs("thisDate equals otherDate");

        _thisDate = DateTimeNow.AddDays(-1);
        yield return testDataToArgs("thisDate is less than otherDate");

        #region local methods
        object?[] testDataToArgs(string definition)
        => TestDataReturnsToArgs(definition, expected, _thisDate, _otherDate);
        #endregion
    }

    public IEnumerable<object?[]> IsOlderThrowsArgsToList()
    {
        ArgumentOutOfRangeException expected = new();
        string message = DemoClass.GreaterThanCurrentDateTimeMessage;

        string paramName = "otherDate";
        _thisDate = DateTimeNow;
        _otherDate = DateTimeNow.AddDays(1);
        yield return testDataToArgs();

        paramName = "thisDate";
        _thisDate = DateTimeNow.AddDays(1);
        yield return testDataToArgs();

        #region Local methods
        string getDefinition()
        => $"{paramName} is greater than the current date";

        object?[] testDataToArgs()
        => TestDataThrowsToArgs(getDefinition(), expected, paramName, message, _thisDate, _otherDate);
        #endregion
    }
}
