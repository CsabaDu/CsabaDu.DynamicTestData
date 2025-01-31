using CsabaDu.DynamicTestData.Tests.DummyTypes;

namespace CsabaDu.DynamicTestData.Tests.TestDoubles;

public record TestDataThrowsChild<TException>(string Definition, string ParamName, string Message)
    : TestDataThrows<TException>(Definition, ParamName, Message)
    where TException : Exception;

public sealed record TestDataThrowsChild(string Definition, string ParamName, string Message)
    : TestDataThrowsChild<DummyException>(Definition, ParamName, Message);
