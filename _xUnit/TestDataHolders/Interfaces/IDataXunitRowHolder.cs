// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.xUnit.TestDataHolders.Interfaces;

public interface IDataXunitRowHolder : IDataRowHolder<object?[]>
{

}
///// <summary>
///// Represents a contract for providing test data for parameterized unit tests.
///// </summary>
///// <remarks>Implementations of this interface are used to supply data to theories in unit testing frameworks,
///// such as xUnit.net. The data provided by implementations is typically used to test a method or functionality with
///// multiple input values.</remarks>
//public interface ITheoryTestData : ITestDataRow<ITestDataRow>;

//public interface ITheoryTestData<TTestData> : ITheoryTestData
//where TTestData : notnull, ITestData
//{
//    void Add(TTestData testData, ArgsCode argsCode);
//}
