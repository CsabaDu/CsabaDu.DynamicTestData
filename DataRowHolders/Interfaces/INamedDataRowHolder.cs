// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.DataRowHolders.Interfaces;

/// <summary>
/// Represents a container for named strongly-typed test data rows that combines data strategy management
/// with named test case access capabilities.
/// </summary>
/// <typeparam name="TRow">The type of data rows contained in this holder.</typeparam>
/// <remarks>
/// <para>
/// This interface merges two essential test data capabilities:
/// <list type="bullet">
///   <item>Data strategy configuration and row management via <see cref="IDataRowHolder{TRow}"/></item>
///   <item>Test case retrieval by name via <see cref="INamedRows{TRow}"/></item>
/// </list>
/// </para>
/// <para>
/// Typical use cases include:
/// <list type="bullet">
///   <item>Test frameworks needing named test case access</item>
///   <item>Data-driven tests with multiple named scenarios</item>
///   <item>Test suites requiring both generic and specific test case retrieval</item>
/// </list>
/// </para>
/// </remarks>
public interface INamedDataRowHolder<TRow>
    : IDataRowHolder<TRow>,
      INamedRows<TRow>
{
    // Combines the data strategy management of IDataRowHolder<TRow>
    // with the named test case retrieval of INamedRows<TRow>
    // without introducing additional members
}
