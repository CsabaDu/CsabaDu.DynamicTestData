// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.xUnit.DynamicDataSources;

public abstract class DynamicTheoryDataSourceBase(ArgsCode argsCode)
    : DynamicDataSource(argsCode)
{
    #region Exception message elements constant strings
    internal const string ArgsCodePropertyHasInvalidValue_ =
        "ArgsCode property has invalid value: ";

    internal const string ArgumentsDMismatchMessage =
        "Arguments do not match with the type of the existing 'TheoryTestData' property.";
    #endregion

    #region Properties
    protected InvalidOperationException ArgsCodeProperyValueInvalidOperationException
    => new(ArgsCodePropertyHasInvalidValue_ + (int)ArgsCode);

    protected static ArgumentException ArgumentsMismatchException
    => new(ArgumentsDMismatchMessage);
    #endregion
}
