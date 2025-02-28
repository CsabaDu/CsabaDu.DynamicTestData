using Xunit;

namespace CsabaDu.DynamicTestData.SampleCodes.DynamicDataSources;

class TestDataToTheoryDataSource(ArgsCode argsCode) : xUnit.DynamicDataSources.TheoryDataSource(argsCode)
{
    private readonly DateTime DateTimeNow = DateTime.Now;
    private const string thisDateName = "thisDate";
    private const string otherDateName = "otherDate";

    private DateTime _thisDate;
    private DateTime _otherDate;

    public TheoryData? IsOlderReturnsToTheoryData()
    {
        TheoryData = null;

        bool expected = true;
        string definition = "thisDateName is greater than otherDateName";      
        _thisDate = DateTimeNow;
        _otherDate = DateTimeNow.AddDays(-1);
        addTestDataToTheoryData();

        expected = false;
        definition = "thisDateName equals otherDateName";
        _otherDate = DateTimeNow;
        addTestDataToTheoryData();

        definition = "thisDateName is less than otherDateName";
        _thisDate = DateTimeNow.AddDays(-1);
        addTestDataToTheoryData();

        return TheoryData;

        #region Local methods
        void addTestDataToTheoryData()
        => AddTestDataReturnsToTheoryData(definition, expected, _thisDate, _otherDate);
        #endregion
    }

    public TheoryData? IsOlderThrowsToTheoryData()
    {
        TheoryData = null;

        string paramName = otherDateName;
        _thisDate = DateTimeNow;
        _otherDate = DateTimeNow.AddDays(1);
        addTestDataToTheoryData();

        paramName = thisDateName;
        _thisDate = DateTimeNow.AddDays(1);
        addTestDataToTheoryData();

        return TheoryData;

        #region Local methods
        void addTestDataToTheoryData()
        => AddTestDataThrowsToTheoryData(getDefinition(), getExpected(), _thisDate, _otherDate);

        string getDefinition()
        => $"{paramName} is greater than the current date";

        ArgumentOutOfRangeException getExpected()
        => new(paramName, DemoClass.GreaterThanCurrentDateTimeMessage);
        #endregion
    }
}
