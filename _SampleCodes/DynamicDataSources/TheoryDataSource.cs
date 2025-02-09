using Xunit;

namespace CsabaDu.DynamicTestData.SampleCodes.DynamicDataSources;

internal class TheoryDataSource
{
    private readonly DateTime DateTimeNow = DateTime.Now;

    private DateTime _thisDate;
    private DateTime _otherDate;

    private static void AddTestData<TResult>(TheoryData<ITestData<TResult, DateTime, DateTime>> theoryData, ITestData<TResult, DateTime, DateTime> testData) where TResult : notnull
    => theoryData.Add(testData);

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
        => AddTestData(theoryData, getTestData(definition));

        ITestData<bool, DateTime, DateTime> getTestData(string definition)
        => new TestDataReturns<bool, DateTime, DateTime>(definition, expected, _thisDate, _otherDate);
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
        => AddTestData(theoryData, getTestData());

        ITestData<ArgumentOutOfRangeException, DateTime, DateTime> getTestData()
        => new TestDataThrows<ArgumentOutOfRangeException, DateTime, DateTime>(getDefinition(), getExpected(), _thisDate, _otherDate);

        string getDefinition()
        => $"{paramName} is greater than the current date";

        ArgumentOutOfRangeException getExpected()
        => new(paramName, DemoClass.GreaterThanCurrentDateTimeMessage);
        #endregion
    }
}
