// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.DataRowHolders.Interfaces;

/// <summary>
/// Represents a collection of test data rows and provides methods to retrieve them and their associated data strategy.
/// </summary>
/// <remarks>This interface is designed to facilitate access to test data rows and their corresponding data
/// strategies. Implementations of this interface should define how test data rows are retrieved and how the data
/// strategy is determined based on the provided arguments.</remarks>
public interface ITestDataRows
{
    IEnumerable<ITestDataRow>? GetTestDataRows();
    IDataStrategy GetDataStrategy(ArgsCode? argsCode);
}
