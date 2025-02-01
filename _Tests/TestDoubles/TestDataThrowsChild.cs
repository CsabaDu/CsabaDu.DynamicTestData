namespace CsabaDu.DynamicTestData.Tests.TestDoubles;

/// <summary>
/// Represents a concrete record for test data that throws exceptions.
/// </summary>
/// <typeparam name="TException">The type of the exception, which must be derived from <see cref="Exception"/>.</typeparam>
/// <param name="Definition">The definition of the test data.</param>
/// <param name="Expected">The expected exception instance.</param>
/// <param name="ParamName">The name of the parameter that causes the exception.</param>
/// <param name="Message">The message associated with the exception.</param>
public record TestDataThrowsChild<TException>(string Definition, TException Expected, string ParamName, string Message)
    : TestDataThrows<TException>(Definition, Expected, ParamName, Message)
    where TException : Exception;
