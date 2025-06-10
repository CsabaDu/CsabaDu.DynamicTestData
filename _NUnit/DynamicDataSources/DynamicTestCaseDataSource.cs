// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.NUnit.DynamicDataSources;

public abstract class DynamicTestCaseDataSource(ArgsCode argsCode)
: DynamicDataSource<TestCaseData>(argsCode, null),
INamedRows
{
    public ITestCaseDataRowHolder? GetTestCaseDataRowHolder()
    => DataRowHolder as ITestCaseDataRowHolder;

    public IEnumerable<TestCaseData>? GetNamedRows(
        string? testMethodName)
    => GetTestCaseDataRowHolder()?
        .GetNamedRows(
            testMethodName);

    public IEnumerable<TestCaseData>? GetNamedRows(
        string? testMethodName,
        ArgsCode? argsCode)
    => GetTestCaseDataRowHolder()?
        .GetNamedRows(
            testMethodName,
            argsCode);
}
