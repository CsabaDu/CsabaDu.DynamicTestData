namespace CsabaDu.DynamicTestData.Tests.TestDoubles;

public record TestDataThrowsChild<TException>(string Definition, string ParamName, string Message)
    : TestDataThrows<TException>(Definition, ParamName, Message)
    where TException : Exception;

public sealed record TestDataThrowsChild(string Definition, string ParamName, string Message)
    : TestDataThrows<DummyException>(Definition, ParamName, Message);
