﻿namespace CsabaDu.DynamicTestData.Tests.TestHelpers;

/// <summary>
/// A dummy struct used for testing purposes.
/// </summary>
/// <param name="testValue">The test value to initialize the struct with.</param>
public readonly struct DummyStruct()
{
    /// <summary>
    /// Returns a null string.
    /// </summary>
    /// <returns>A null string.</returns>
    public override readonly string ToString() => null;
}
