namespace CsabaDu.DynamicTestData.TestDataTypes.Interfaces;

/// <summary>
/// Represents an interface for test data that throws exceptions.
/// </summary>
/// <typeparam name="TException">The type of exception that is thrown.</typeparam>
public interface ITestDataThrows<out TException> : ITestData<TException> where TException : Exception;
