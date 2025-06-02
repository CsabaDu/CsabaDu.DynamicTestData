// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

using CsabaDu.DynamicTestData.TestDataRows.Interfaces;

namespace CsabaDu.DynamicTestData.TestDataRows;

public class TestDataRow<TTestData>(
    TTestData testData,
    ArgsCode argsCode,
    bool withExpected)
: ITestDataRow
where TTestData : ITestData
{
    public TestDataRow(
        TTestData testData,
        ArgsCode argsCode)
    : this(
          testData,
          argsCode,
          testData is IExpected)
    {
    }

    private readonly TTestData _testData = testData;
    private readonly bool _withExpected = withExpected;

    public ArgsCode ArgsCode { get; init; } =
        argsCode.Defined(nameof(argsCode));

    public object?[] GetParameters()
    => _testData.ToParams(
        ArgsCode,
        _withExpected);
}
