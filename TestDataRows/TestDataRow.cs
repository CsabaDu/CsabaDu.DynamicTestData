// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

using CsabaDu.DynamicTestData.TestDataRows.Interfaces;

namespace CsabaDu.DynamicTestData.TestDataRows;

public class TestDataRow<TTestData> : ITestDataRow
where TTestData : ITestData
{
    public TestDataRow(
        TTestData testData,
        ArgsCode argsCode,
        bool withExpected)
    {
        _testData = testData;
        ArgsCode = argsCode.Defined(nameof(argsCode));
        _withExpected = withExpected;
    }

    public TestDataRow(
        TTestData testData,
        ArgsCode argsCode)
    : this(
          testData,
          argsCode,
          testData is IExpected)
    {
    }

    private readonly TTestData _testData;
    private readonly bool _withExpected;

    public ArgsCode ArgsCode { get; init; }

    public object?[] GetParameters()
    => _testData.ToParams(
        ArgsCode,
        _withExpected);
}
