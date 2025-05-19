// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.TestHelpers.TestParameters;

public class DisplayNames
{
    public static readonly string? TestDataDisplayName = GetDisplayName(TestDataTestCase);
    public static readonly string? TestDataReturnsDisplayName = GetDisplayName(TestDataReturnsTestCase);
    public static readonly string? TestDataThrowsDisplayName = GetDisplayName(TestDataThrowsTestCase);

    private static string? GetDisplayName(string testCase) => DynamicDataSource.GetDisplayName(TestMethodName, testCase);
}
