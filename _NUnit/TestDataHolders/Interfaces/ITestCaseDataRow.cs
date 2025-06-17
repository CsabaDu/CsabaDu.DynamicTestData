// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.NUnit.TestDataHolders.Interfaces;

public interface ITestCaseDataRow
: INamedTestDataRow<TestCaseData>;

public interface ITestCaseDataRow<TTestData>
: ITestCaseDataRow, ITestDataRow<TTestData, TestCaseData>
where TTestData : notnull, ITestData;

//INamedRow<TestCaseData>;
