using NUnit.Framework;

namespace CsabaDu.DynamicTestData.SampleCodes.NUnitSamples;

internal class TestCaseDataSource(ArgsCode argsCode) : DynamicDataSource(argsCode)
{
    private readonly DateTime DateTimeNow = DateTime.Now;

    private DateTime _thisDate;
    private DateTime _otherDate;

    private TestCaseData TestDataToTestCaseData<TResult>(Func<object?[]> testDataToArgs, string testMethodName) where TResult : notnull
    {
        object?[] args = testDataToArgs.Invoke();
        string displayName = GetDisplayName(testMethodName, args);
        TestCaseData testCaseData = ArgsCode switch
        {
            ArgsCode.Instance => new(args),
            ArgsCode.Properties => new(args[1..]),
            _ => throw new InvalidOperationException("ArgsCode property has invalid value."),
        };

        return testCaseData.SetName(displayName);
    }

    public IEnumerable<TestCaseData> IsOlderReturnsArgsToList(string testMethodName)
    {
        bool expected = true;
        _thisDate = DateTimeNow;
        _otherDate = DateTimeNow.AddDays(-1);
        yield return testDataToTestCaseData("thisDate is greater than otherDate");

        expected = false;
        _otherDate = DateTimeNow;
        yield return testDataToTestCaseData("thisDate equals otherDate");

        _thisDate = DateTimeNow.AddDays(-1);
        yield return testDataToTestCaseData("thisDate is less than otherDate");

        #region local methods
        TestCaseData testDataToTestCaseData(string definition)
        => TestDataToTestCaseData<bool>(() => testDataToArgs(definition), testMethodName);

        object?[] testDataToArgs(string definition)
        => TestDataReturnsToArgs(definition, expected, _thisDate, _otherDate);
        #endregion
    }

    public IEnumerable<TestCaseData> IsOlderThrowsArgsToList(string testMethodName)
    {
        string paramName = "otherDate";
        _thisDate = DateTimeNow;
        _otherDate = DateTimeNow.AddDays(1);
        yield return testDataToTestCaseData();

        paramName = "thisDate";
        _thisDate = DateTimeNow.AddDays(1);
        yield return testDataToTestCaseData();

        #region Local methods
        TestCaseData testDataToTestCaseData()
        => TestDataToTestCaseData<ArgumentOutOfRangeException>(testDataToArgs, testMethodName);

        object?[] testDataToArgs()
        => TestDataThrowsToArgs(getDefinition(), getExpected(), _thisDate, _otherDate);

        string getDefinition()
        => $"{paramName} is greater than the current date";

        ArgumentOutOfRangeException getExpected()
        => new(paramName, DemoClass.GreaterThanCurrentDateTimeMessage);
        #endregion
    }
}
