namespace CsabaDu.DynamicTestData.Tests.TestDoubles;

public sealed record TestDataThrowsChild<TException>(string Definition, string ParamName, string Message)
    : TestDataThrows<TException>(Definition, ParamName, Message)
    where TException : Exception;

