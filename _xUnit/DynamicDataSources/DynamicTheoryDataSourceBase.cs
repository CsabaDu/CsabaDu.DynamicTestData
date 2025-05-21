// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.xUnit.DynamicDataSources;

public abstract class DynamicTheoryDataSourceBase(ArgsCode argsCode)
    : DynamicDataSource(argsCode)
{
    #region Exception message elements constant strings
    internal protected const string ArgsCodePropertyHasInvalidValue_ =
        "ArgsCode property has invalid value: ";

    internal protected const string ArgumentsAreSuitableForCreating_ =
        "Arguments do not match with the ";

    internal protected const string ArgumentsMismatchMessageEnd
    = " instance's type parameters.";
    #endregion

    #region Properties
    protected abstract string TheoryDataTypeName { get; }

    internal static void ThrowArgumentExceptionIfMisMatch<TTestData>(ITestData testData, string theoryDataTypeName, out TTestData validTestData)
    {
        if (testData is TTestData tTestData)
        {
            validTestData = tTestData;
        }
        else
        {
            throw ArgumentsMismatchException(theoryDataTypeName);
        }
    }

    /// <summary>
    /// Generates a descriptive error message for an arguments mismatch exception.
    /// This message indicates that the provided arguments are suitable for creating elements of the specified <paramref name="theoryDataType"/>
    /// but do not match the type parameters of the currently initiated <see cref="TheoryData"/> instance.
    /// </summary>
    /// <returns>A formatted error message describing the mismatch between the arguments and the expected type parameters.</returns>
    internal protected static string GetArgumentsMismatchMessage(string theoryDataTypeName)
    => ArgumentsAreSuitableForCreating_
        + theoryDataTypeName
        + ArgumentsMismatchMessageEnd;
    #endregion

    #region Methods
    protected InvalidOperationException ArgsCodeProperyValueInvalidOperationException
    => new(ArgsCodePropertyHasInvalidValue_ + (int)ArgsCode);

    internal protected static ArgumentException ArgumentsMismatchException(string theoryDataTypeName)
    => new(GetArgumentsMismatchMessage(theoryDataTypeName));
    #endregion
}
