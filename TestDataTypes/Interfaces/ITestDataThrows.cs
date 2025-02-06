namespace CsabaDu.DynamicTestData.TestDataTypes.Interfaces;

/// <summary>
/// Represents an interface for test data that throws exceptions.
/// </summary>
/// <typeparam name="TException">The type of exception that is thrown.</typeparam>
public interface ITestDataThrows<out TException> : ITestData<TException> where TException : Exception
{
    /// <summary>
    /// Gets the expected name of the parameter that caused the exception.
    /// </summary>
    string? ParamName { get; }

    /// <summary>
    /// Gets the expected message associated with the exception.
    /// </summary>
    string? Message { get; }

    /// <summary>
    /// Gets the expected type of the associated exception.
    /// </summary>
    Type ExceptionType { get; }
}
