// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.xUnit.TheoryTestDataTypes.Interfaces;

public interface IInstance<TTestData>
: ITheoryTestData
where TTestData : ITestData
{
    void Add(TTestData testData);
}
