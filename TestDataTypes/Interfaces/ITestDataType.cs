// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.TestDataTypes.Interfaces;

public interface ITestDataType : IEqualityComparer<ITestDataType>
{
    Type TestDataType { get; }
}
