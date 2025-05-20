// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.xUnit.DynamicDataSources;

public abstract class DynamicTheoryDataSourceBase(ArgsCode argsCode)
    : DynamicDataSource(argsCode)
{
    #region Exception message elements constant strings
    internal protected const string ArgumentsAreSuitableForCreating_ =
        "Arguments are suitable for creating ";

    internal protected const string ArgsCodePropertyHasInvalidValue_ =
        "ArgsCode property has invalid value: ";
    #endregion

    #region Properties
    protected abstract string TheoryDataTypeName { get; }

    /// <summary>
    /// Gets or sets the TheoryData used for parameterized tests.
    /// </summary>
    internal protected string ArgumentsMismatchMessageEnd
    => " elements and do not match with the initiated "
        + TheoryDataTypeName
        + " instance's type parameters.";

    /// <summary>
    /// Generates a descriptive error message for an arguments mismatch exception.
    /// This message indicates that the provided arguments are suitable for creating elements of the specified <paramref name="theoryDataType"/>
    /// but do not match the type parameters of the currently initiated <see cref="TheoryData"/> instance.
    /// </summary>
    /// <returns>A formatted error message describing the mismatch between the arguments and the expected type parameters.</returns>
    internal protected string GetArgumentsMismatchMessage
    => ArgumentsAreSuitableForCreating_
        + TheoryDataTypeName
        + ArgumentsMismatchMessageEnd;
    #endregion

    #region Methods
    protected InvalidOperationException ArgsCodeProperyValueInvalidOperationException
    => new(ArgsCodePropertyHasInvalidValue_ + (int)ArgsCode);

    protected ArgumentException ArgumentsMismatchException(ITestData testData)
    => new(ArgumentsAreSuitableForCreating_
        + testData.GetType().Name
        + ArgumentsMismatchMessageEnd);
    #endregion
}
