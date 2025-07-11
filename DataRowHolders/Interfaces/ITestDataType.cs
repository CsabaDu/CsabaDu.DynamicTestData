// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.DataRowHolders.Interfaces;

/// <summary>
/// Represents a contract for types that expose a test data type.
/// </summary>
/// <remarks>This interface is intended to provide a mechanism for accessing the type of test data associated with
/// an implementing class. It can be used in scenarios where the type of test data needs to be dynamically inspected or
/// utilized.</remarks>
public interface ITestDataType
{
    Type TestDataType { get; }
}
