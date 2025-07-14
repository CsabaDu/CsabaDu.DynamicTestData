// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.DynamicDataSources;

/// <summary>
/// Represents a dynamic data source that provides test data in the form of object arrays.
/// </summary>
/// <remarks>This abstract class serves as a base for creating dynamic data sources that generate test data rows
/// containing arrays of objects. It provides functionality to initialize and manage test data rows and their associated
/// holders.</remarks>
/// <param name="argsCode"></param>
/// <param name="expectedResultType"></param>
public abstract class DynamicObjectArraySource(ArgsCode argsCode, Type? expectedResultType)
: DynamicDataSource<object?[]>(argsCode, expectedResultType)
{
    protected override void InitDataRowHolder<TTestData>(
        TTestData testData)
    => DataRowHolder = new ObjectArrayRowHolder<TTestData>(
        testData,
        this);
}
