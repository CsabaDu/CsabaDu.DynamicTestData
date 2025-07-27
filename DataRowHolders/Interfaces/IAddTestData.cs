// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.DataRowHolders.Interfaces;

public interface  IAddTestData<TTestData>
where TTestData : notnull, ITestData
{
    void Add(TTestData testData);
}