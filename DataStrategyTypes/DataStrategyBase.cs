// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.DataStrategyTypes;

/// <summary>
/// Serves as the base class for data strategy implementations that encapsulate behavior  related to a specific <see
/// cref="TestDataTypes.ArgsCode"/>.
/// </summary>
/// <remarks>This abstract record provides a foundation for defining data strategies that operate  based on an
/// <see cref="ArgsCode"/>. Derived types should implement specific behavior  as required by their use case.</remarks>
/// <param name="ArgsCode">The <see cref="TestDataTypes.ArgsCode"/> instance associated with the data strategy.</param>
public abstract record DataStrategyBase(ArgsCode ArgsCode)
: IArgsCode;
