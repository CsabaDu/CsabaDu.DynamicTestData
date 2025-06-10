// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.NUnit.TestDataHolders.Interfaces;

public interface ITestCaseDataRow : ITestDataRow<TestCaseData>
{
    TestCaseData Convert(string? testMethodName);
}
