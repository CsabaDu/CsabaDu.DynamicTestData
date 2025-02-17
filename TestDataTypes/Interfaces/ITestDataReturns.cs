﻿namespace CsabaDu.DynamicTestData.TestDataTypes.Interfaces;

/// <summary>
/// Represents an interface for test data that returns a value of type <typeparamref name="TStruct"/>.
/// </summary>
/// <typeparam name="TStruct">The type of the value returned, which must be a struct.</typeparam>
public interface ITestDataReturns<out TStruct> : ITestData<TStruct> where TStruct : struct;
