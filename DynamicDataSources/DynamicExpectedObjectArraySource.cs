// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.DynamicDataSources;

/// <summary>
/// Represents a dynamic data source that supports IExpected test data opjects treating differently.
/// </summary>
/// <remarks>This abstract class serves as a base for implementing dynamic data sources that supply objects
/// conforming to the <see cref="IExpected"/> interface. It inherits from <see cref="DynamicObjectArraySource"/> and
/// utilizes the specified <see cref="ArgsCode"/> to configure the data source.</remarks>
/// <param name="argsCode"></param>
public abstract class DynamicExpectedObjectArraySource(ArgsCode argsCode)
: DynamicObjectArraySource(argsCode, typeof(IExpected));