namespace CsabaDu.DynamicTestData.TestDataRowTypes.Interfaces
{
    public interface ITestDataRow
    {
        ArgsCode GetArgsCode();
        ITestDataRow GetTestDataRow();
        object?[] GetParameters();
    }

    public interface ITestDataRow<TPrimary>
    : ITestDataRow
    where TPrimary : notnull
    {
        TPrimary GetPrimaryMember();
    }

    public interface ITestDataReturnsRow<TStruct>
    : ITestDataRow<TStruct>,
    ITestDataReturns<TStruct>
    where TStruct : struct;

    public interface ITestDataThrowsRow<TException>
    : ITestDataRow<TException>,
    ITestDataThrows<TException>
    where TException : Exception;

    public interface ITestDataInstanceRow<TTestData>
    : ITestDataRow<TTestData>
    where TTestData : ITestData;
}