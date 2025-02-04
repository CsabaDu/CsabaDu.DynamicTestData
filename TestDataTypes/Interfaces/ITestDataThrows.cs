﻿namespace CsabaDu.DynamicTestData.TestDataTypes.Interfaces;

/// <summary>
/// Represents an interface for test data that throws exceptions.
/// </summary>
/// <typeparam name="TException">The type of exception that is thrown.</typeparam>
public interface ITestDataThrows<TException> : ITestData<TException> where TException : Exception
{
    /// <summary>
    /// Gets the name of the parameter that caused the exception.
    /// </summary>
    string? ParamName { get; init; }

    /// <summary>
    /// Gets the message associated with the exception.
    /// </summary>
    string? Message { get; init; }

    Type ExceptionType { get; }
}
