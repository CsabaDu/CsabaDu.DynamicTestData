﻿namespace CsabaDu.DynamicTestData.TestDataTypes.Interfaces;

/// <summary>
/// Represents a test data interface with properties for test case and result, and a method to convert arguments.
/// </summary>
public interface ITestData
{
    /// <summary>
    /// Gets the definition of the test case.
    /// </summary>
    string Definition { get; init; }

    /// <summary>
    /// Gets the expected exit mode of the test.
    /// </summary>
    string ExitMode { get; }

    /// <summary>
    /// Gets the name of the result of the test case.
    /// </summary>
    string Result { get; }
 
    /// <summary>
    /// Gets the test case description.
    /// </summary>
    string TestCase { get; }

    /// <summary>
    /// Converts the test data to an array of arguments based on the specified <see cref="ArgsCode"/>.
    /// </summary>
    /// <param name="argsCode">The code indicating how to convert the arguments.</param>
    /// <returns>An array of arguments.</returns>
    object?[] ToArgs(ArgsCode argsCode);
}

/// <summary>
/// Represents a generic test data interface that extends <see cref="ITestData"/>.
/// </summary>
/// <typeparam name="TResult">The type of the expected result of the test.</typeparam>
public interface ITestData<TResult> : ITestData where TResult : notnull
{
    /// <summary>
    /// Gets the result of the test case.
    /// </summary>
    TResult Expected { get; init; }
}