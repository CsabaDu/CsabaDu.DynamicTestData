using Xunit;

namespace CsabaDu.DynamicTestData.SampleCodes.DynamicDataSources;

public class TheoryDataSource
{
    private readonly DateTime DateTimeNow = DateTime.Now;

    private DateTime _thisDate;
    private DateTime _otherDate;
    private ITestData? _testData;

    private void AddTestData<TResult>(TheoryData<ITestData<TResult, DateTime, DateTime>> theoryData) where TResult : notnull
    => theoryData.Add((_testData as ITestData<TResult, DateTime, DateTime>)!);

    public TheoryData<ITestData<bool, DateTime, DateTime>> IsOlderReturnsArgsToTheoryData()
    {
        var theoryData = new TheoryData<ITestData<bool, DateTime, DateTime>>();

        bool expected = true;
        _thisDate = DateTimeNow;
        _otherDate = DateTimeNow.AddDays(-1);
        addTestData("thisDate is greater than otherDate");

        expected = false;
        _otherDate = DateTimeNow;
        addTestData("thisDate equals otherDate");

        _thisDate = DateTimeNow.AddDays(-1);
        addTestData("thisDate is less than otherDate");

        return theoryData;

        #region local methods
        void addTestData(string definition)
        {
            _testData = new TestDataReturns<bool, DateTime, DateTime>(definition, expected, _thisDate, _otherDate);
            AddTestData(theoryData);
        }
        #endregion
    }

    public TheoryData<ITestData<ArgumentOutOfRangeException, DateTime, DateTime>> IsOlderThrowsArgsToTheoryData()
    {
        var theoryData = new TheoryData<ITestData<ArgumentOutOfRangeException, DateTime, DateTime>>();

        string paramName = "otherDate";
        _thisDate = DateTimeNow;
        _otherDate = DateTimeNow.AddDays(1);
        addTestData();

        paramName = "thisDate";
        _thisDate = DateTimeNow.AddDays(1);
        addTestData();

        return theoryData;

        #region Local methods
        void addTestData()
        {
            _testData = new TestDataThrows<ArgumentOutOfRangeException, DateTime, DateTime>(getDefinition(), getExpected(), _thisDate, _otherDate);
            AddTestData(theoryData);
        }

        string getDefinition()
        => $"{paramName} is greater than the current date";

        ArgumentOutOfRangeException getExpected()
        => new(paramName, DemoClass.GreaterThanCurrentDateTimeMessage);
        #endregion
    }
}
