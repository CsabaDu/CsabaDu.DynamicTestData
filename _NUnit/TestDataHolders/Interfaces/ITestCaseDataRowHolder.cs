// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.NUnit.TestDataHolders.Interfaces;

public interface ITestCaseDataRowHolder
: INamedDataRowHolder<TestCaseData>,
INamedRows<TestCaseData>;

public interface ITestCaseDataRowHolder<TTestData>
: ITestCaseDataRowHolder,
IDataRowHolder<TTestData, TestCaseData>
where TTestData : notnull, ITestData;
