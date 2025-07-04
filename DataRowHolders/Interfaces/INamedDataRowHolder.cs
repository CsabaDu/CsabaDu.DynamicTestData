// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.DataRowHolders.Interfaces;

/// <summary>
/// Represents a holder for named data rows, providing functionality to manage and access rows by name.
/// </summary>
/// <typeparam name="TRow">The type of the data rows managed by the holder.</typeparam>
public interface INamedDataRowHolder<TRow>
: IDataRowHolder<TRow>,
INamedRows<TRow>;