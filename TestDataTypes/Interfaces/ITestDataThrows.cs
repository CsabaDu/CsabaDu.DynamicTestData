// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.TestDataTypes.Interfaces;

/// <summary>
/// Represents a marker test data interface for test cases that throw exceptions.
/// </summary>
public interface ITestDataThrows;

/// <summary>
/// Represents an interface for test data that throw an exception of type <typeparamref name="TException".
/// </summary>
/// <typeparam name="TException">The type of exception that is expected to be thrown.</typeparam>
public interface ITestDataThrows<out TException> : ITestDataThrows, ITestData<TException> where TException : Exception;
