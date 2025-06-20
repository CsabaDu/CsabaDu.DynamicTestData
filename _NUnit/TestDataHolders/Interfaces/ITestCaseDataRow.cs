// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.NUnit.TestDataHolders.Interfaces;

public interface ITestCaseDataRow
: INamedTestDataRow<TestCaseTestData>;

public interface ITestCaseDataRow<TTestData>
: ITestCaseDataRow, ITestDataRow<TTestData, TestCaseTestData>
where TTestData : notnull, ITestData;

//INamedRow<TestCaseData>;
