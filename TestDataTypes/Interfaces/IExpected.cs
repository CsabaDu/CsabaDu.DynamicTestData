// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.TestDataTypes.Interfaces;

public interface IExpected
{
    /// <summary>
    /// Gets the expected value of the test case.
    /// </summary>
    object GetExpected();
}
