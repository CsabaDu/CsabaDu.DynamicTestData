using CsabaDu.DynamicTestData.Statics;
using Xunit;

namespace CsabaDu.DynamicTestData.SampleCodes.DynamicDataSources;

public class TheoryDataSource(ArgsCode argsCode)
{
    protected ArgsCode ArgsCode { get; init; } = argsCode.Defined(nameof(argsCode));

    private readonly DateTime DateTimeNow = DateTime.Now;
    private const string thisDateIsGreaterThanOtherDate = $"{thisDateName} is greater than {otherDateName}";
    private const string thisDateIsLessThanOtherDate = $"{thisDateName} is less than {otherDateName}";
    private const string thisDateEqualsOtherDate = $"{thisDateName} equals {otherDateName}";
    private const string thisDateName = "thisDate";
    private const string otherDateName = "otherDate";

    private DateTime _thisDate;
    private DateTime _otherDate;
    private ITestData? _testData;

    private void AddTestDataReturns(TheoryData theoryData, string definition, bool expected)
    {
        _testData = new TestDataReturns<bool, DateTime, DateTime>(definition, expected, _thisDate, _otherDate);
        AddTestData<bool>(theoryData);
    }

    private void AddTestDataThrows(TheoryData theoryData, string paramName)
    {
        _testData = new TestDataThrows<ArgumentOutOfRangeException, DateTime, DateTime>(getDefinition(), getExpected(), _thisDate, _otherDate);
        AddTestData<ArgumentOutOfRangeException>(theoryData);

        #region Local methods
        string getDefinition()
        => $"{paramName} is greater than the current date";

        ArgumentOutOfRangeException getExpected()
        => new(paramName, DemoClass.GreaterThanCurrentDateTimeMessage);
        #endregion
    }

    private void AddTestData<TResult>(TheoryData theoryData) where TResult : notnull
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                var testData = _testData as ITestData<TResult, DateTime, DateTime>;
                (theoryData as TheoryData<ITestData<TResult, DateTime, DateTime>>)!.Add(testData!);
                break;
            case ArgsCode.Properties:
                testData = _testData as ITestData<TResult, DateTime, DateTime>;
                (theoryData as TheoryData<TResult, DateTime, DateTime>)!.Add(testData!.Expected, testData.Arg1, testData.Arg2);
                break;
            default:
                throw new InvalidOperationException("ArgsCode property has invalid value.");
        }
    }

    public TheoryData<ITestData<bool, DateTime, DateTime>> IsOlderReturnsInstanceToTheoryData()
    {
        var theoryData = new TheoryData<ITestData<bool, DateTime, DateTime>>();

        bool expected = true;
        _thisDate = DateTimeNow;
        _otherDate = DateTimeNow.AddDays(-1);
        addTestData(thisDateIsGreaterThanOtherDate);

        expected = false;
        _otherDate = DateTimeNow;
        addTestData(thisDateEqualsOtherDate);

        _thisDate = DateTimeNow.AddDays(-1);
        addTestData(thisDateIsLessThanOtherDate);

        return theoryData;

        #region local methods
        void addTestData(string definition)
        => AddTestDataReturns(theoryData, definition, expected);
        #endregion
    }

    public TheoryData<ITestData<ArgumentOutOfRangeException, DateTime, DateTime>> IsOlderThrowsInstanceToTheoryData()
    {
        var theoryData = new TheoryData<ITestData<ArgumentOutOfRangeException, DateTime, DateTime>>();

        string paramName = otherDateName;
        _thisDate = DateTimeNow;
        _otherDate = DateTimeNow.AddDays(1);
        addTestData();

        paramName = thisDateName;
        _thisDate = DateTimeNow.AddDays(1);
        addTestData();

        return theoryData;

        #region Local methods
        void addTestData()
        => AddTestDataThrows(theoryData, paramName);
        #endregion
    }

    public TheoryData<bool, DateTime, DateTime> IsOlderReturnsPropertiesToTheoryData()
    {
        var theoryData = new TheoryData<bool, DateTime, DateTime>();

        bool expected = true;
        _thisDate = DateTimeNow;
        _otherDate = DateTimeNow.AddDays(-1);
        addTestData(thisDateIsGreaterThanOtherDate);

        expected = false;
        _otherDate = DateTimeNow;
        addTestData(thisDateEqualsOtherDate);

        _thisDate = DateTimeNow.AddDays(-1);
        addTestData(thisDateIsLessThanOtherDate);

        return theoryData;

        #region local methods
        void addTestData(string definition)
        => AddTestDataReturns(theoryData, definition, expected);
        #endregion
    }

    public TheoryData<ArgumentOutOfRangeException, DateTime, DateTime> IsOlderThrowsPropertiesToTheoryData()
    {
        var theoryData = new TheoryData<ArgumentOutOfRangeException, DateTime, DateTime>();

        string paramName = otherDateName;
        _thisDate = DateTimeNow;
        _otherDate = DateTimeNow.AddDays(1);
        addTestData();

        paramName = thisDateName;
        _thisDate = DateTimeNow.AddDays(1);
        addTestData();

        return theoryData;

        #region Local methods
        void addTestData()
        => AddTestDataThrows(theoryData, paramName);
        #endregion
    }
}
