// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.TestDataTypes.Interfaces;

/// <summary>
/// Represents a marker test data interface for test cases that return values.
/// </summary>
public interface ITestDataReturns : IExpected;

/// <summary>
/// Represents an interface for test data that returns a value of type <typeparamref name="TStruct"/>.
/// </summary>
/// <typeparam name="TStruct">
/// The type of the value expected to return, which must be a not null <see cref="ValueType"/> object.
/// </typeparam>
public interface ITestDataReturns<out TStruct>
: ITestDataReturns, ITestData<TStruct>
where TStruct : struct;
