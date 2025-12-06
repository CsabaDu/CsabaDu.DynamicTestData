// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.DynamicDataRowSources;

/// <summary>
/// Represents a dynamic data source that provides test data in the form of object arrays, with pre-set <see cref="PropsCode.Expected"/> value of <see cref="DynamicDataSource.PropsCode"/> property.
/// </summary>
/// <remarks>
/// This abstract class serves as a specialized base for dynamic data sources that generate test data objects
/// which implement the <see cref="IExpected"/> interface. It inherits from <see cref="DynamicObjectArrayRowSource"/>
/// and automatically configures the property code to <see cref="PropsCode.Expected"/> for consistent
/// expected result handling.
/// <para>
/// Derived classes should implement specific logic for generating test data cases where the expected result
/// needs special handling or verification.
/// </para>
/// </remarks>
/// <param name="argsCode">The code representing the arguments configuration for test data generation.
/// Defines how input arguments should be processed for the test cases.</param>
public abstract class DynamicExpectedObjectArrayRowSource(ArgsCode argsCode)
: DynamicObjectArrayRowSource(argsCode, PropsCode.Expected);
