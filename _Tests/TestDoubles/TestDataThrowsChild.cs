namespace CsabaDu.DynamicTestData.Tests.TestDoubles;

public record TestDataThrowsChild<TException>(string Definition, TException Expected, string ParamName, string Message)
    : TestDataThrows<TException>(Definition, Expected, ParamName, Message)
    where TException : Exception;

//public sealed record TestDataThrowsChild(string Definition, string ParamName, string Message)
//    : TestDataThrowsChild<DummyException>(Definition, new DummyException(), ParamName, Message);
