using CsabaDu.DynamicTestData.Statics;
using Xunit;

namespace CsabaDu.DynamicTestData.SampleCodes.DynamicDataSources;

public class TheoryDataSource(ArgsCode argsCode)
{
    protected ArgsCode ArgsCode { get; init; } = argsCode.Defined(nameof(argsCode));

    private readonly DateTime DateTimeNow = DateTime.Now;

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
        var testData = _testData as ITestData<TResult, DateTime, DateTime>;

        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                (theoryData as TheoryData<ITestData<TResult, DateTime, DateTime>>)!.Add(testData!);
                break;
            case ArgsCode.Properties:
                (theoryData as TheoryData<TResult, DateTime, DateTime>)!.Add(testData!.Expected, testData.Arg1, testData.Arg2);
                break;
            default:
                break;
        }
    }

    public TheoryData IsOlderReturnsToTheoryData()
    {
        TheoryData? theoryData = ArgsCode switch
        {
            ArgsCode.Instance => new TheoryData<ITestData<bool, DateTime, DateTime>>(),
            ArgsCode.Properties => new TheoryData<bool, DateTime, DateTime>(),
            _ => default,
        };

        bool expected = true;
        string definition = "thisDate is greater than otherDate";
        _thisDate = DateTimeNow;
        _otherDate = DateTimeNow.AddDays(-1);
        addTestData();

        expected = false;
        definition = "thisDate equals otherDate";
        _otherDate = DateTimeNow;
        addTestData();

        definition = "thisDate is less than otherDate";
        _thisDate = DateTimeNow.AddDays(-1);
        addTestData();

        return theoryData!;

        #region Local methods
        void addTestData()
        => AddTestDataReturns(theoryData!, definition, expected);
        #endregion
    }

    public TheoryData IsOlderThrowsToTheoryData()
    {
        TheoryData? theoryData = ArgsCode switch
        {
            ArgsCode.Instance => new TheoryData<ITestData<ArgumentOutOfRangeException, DateTime, DateTime>>(),
            ArgsCode.Properties => new TheoryData<ArgumentOutOfRangeException, DateTime, DateTime>(),
            _ => default,
        };

        string paramName = "otherDate";
        _thisDate = DateTimeNow;
        _otherDate = DateTimeNow.AddDays(1);
        addTestData();

        paramName = "thisDate";
        _thisDate = DateTimeNow.AddDays(1);
        addTestData();

        return theoryData!;

        #region Local methods
        void addTestData()
        => AddTestDataThrows(theoryData!, paramName);
        #endregion
    }
}
