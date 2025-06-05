// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.TestDataRows.Interfaces;

public interface ITestDataType : IEquatable<ITestDataType>
{
    Type TestDataType { get; }
}
