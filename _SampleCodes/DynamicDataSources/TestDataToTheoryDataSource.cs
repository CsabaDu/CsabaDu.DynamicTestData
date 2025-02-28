using Xunit;

namespace CsabaDu.DynamicTestData.SampleCodes.DynamicDataSources;

class TestDataToTheoryDataSource(ArgsCode argsCode) : xUnit.DynamicDataSources.TheoryDataSource(argsCode)
{
    private readonly DateTime DateTimeNow = DateTime.Now;

    private DateTime _thisDate;
    private DateTime _otherDate;

    public TheoryData? IsOlderReturnsToTheoryData()
    {
        TheoryData = null;

        bool expected = true;
        string definition = "thisDate is greater than otherDate";      
        _thisDate = DateTimeNow;
        _otherDate = DateTimeNow.AddDays(-1);
        addTestDataToTheoryData();

        expected = false;
        definition = "thisDate equals otherDate";
        _otherDate = DateTimeNow;
        addTestDataToTheoryData();

        definition = "thisDate is less than otherDate";
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

        string paramName = "otherDate";
        _thisDate = DateTimeNow;
        _otherDate = DateTimeNow.AddDays(1);
        addTestDataToTheoryData();

        paramName = "thisDate";
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
