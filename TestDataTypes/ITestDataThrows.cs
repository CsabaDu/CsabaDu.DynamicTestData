namespace CsabaDu.DynamicTestData.TestDataTypes;

internal interface ITestDataThrows<TException> : ITestData<TException> where TException : Exception
{
    string ParamName { get; init; }
    string Message { get; }
    Type ExceptionType { get; }
}
