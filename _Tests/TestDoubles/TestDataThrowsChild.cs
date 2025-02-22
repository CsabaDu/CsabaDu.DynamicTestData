﻿namespace CsabaDu.DynamicTestData.NUnit.Tests.TestDoubles;

/// <summary>
/// Represents a concrete record for test data that throws exceptions.
/// </summary>
/// <typeparam name="TException">The type of the exception, which must be derived from <see cref="Exception"/>.</typeparam>
/// <param name="Definition">The definition of the test data.</param>
/// <param name="Expected">The expected exception instance.</param>
public record TestDataThrowsChild<TException>(string Definition, TException Expected)
    : TestDataThrows<TException>(Definition, Expected)
    where TException : Exception;
