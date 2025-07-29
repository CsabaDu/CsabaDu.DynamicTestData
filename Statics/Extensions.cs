// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.Statics;

public static class Extensions
{
    #region object?[]
    /// <summary>
    /// Adds a parameter to the array of arguments based on the specified argument code.
    /// This extension is primarily used when building test data arrays for <see cref="IDataStrategy"/>.
    /// </summary>
    /// <typeparam name="T">The type of the parameter to add.</typeparam>
    /// <param name="args">The array of arguments to which the parameter will be added.</param>
    /// <param name="argsCode">The argument code that determines the content of the returning array.</param>
    /// <param name="parameter">The parameter to add to the array of arguments.</param>
    /// <returns>
    /// A new array of arguments with the parameter added if the argument code is <see cref="ArgsCode.Properties"/>;
    /// otherwise, the original array of arguments.
    /// </returns>
    /// <exception cref="InvalidEnumArgumentException">Thrown if the <paramref name="argsCode"/> value is not defined in the enumeration.</exception>
    public static object?[] Add<T>(
        this object?[] args,
        ArgsCode argsCode,
        T? parameter)
    => argsCode switch
    {
        ArgsCode.Instance => args,
        ArgsCode.Properties => [.. args, parameter],
        _ => throw argsCode.GetInvalidEnumArgumentException(nameof(argsCode)),
    };
    #endregion

    #region ArgsCode
    /// <summary>
    /// Validates that the <see cref="ArgsCode"/> value is defined in the enumeration.
    /// This is typically used to ensure valid strategy configuration in <see cref="IDataStrategy"/>.
    /// </summary>
    /// <param name="argsCode">The argument code to validate.</param>
    /// <param name="paramName">The name of the parameter being validated.</param>
    /// <returns>The original <paramref name="argsCode"/> if it is defined.</returns>
    /// <exception cref="InvalidEnumArgumentException">
    /// Thrown when the <paramref name="argsCode"/> is not a defined value in the <see cref="ArgsCode"/> enumeration.
    /// </exception>
    public static ArgsCode Defined(
        this ArgsCode argsCode,
        string paramName)
    => Enum.IsDefined(argsCode) ?
        argsCode
        : throw argsCode.GetInvalidEnumArgumentException(paramName);

    /// <summary>
    /// Creates a standardized invalid enumeration exception for <see cref="ArgsCode"/> values.
    /// Used throughout the test data framework to maintain consistent error reporting.
    /// </summary>
    /// <param name="argsCode">The invalid argument code value.</param>
    /// <param name="paramName">The name of the parameter that contained the invalid value.</param>
    /// <returns>A new <see cref="InvalidEnumArgumentException"/> instance.</returns>
    public static InvalidEnumArgumentException GetInvalidEnumArgumentException(
        this ArgsCode argsCode,
        string paramName)
    => new(paramName, (int)argsCode, typeof(ArgsCode));
    #endregion

    #region PropertyCode
    /// <summary>
    /// Validates that the <see cref="PropertyCode"/> value is defined in the enumeration.
    /// This ensures proper property filtering behavior in <see cref="IDataStrategy"/> implementations.
    /// </summary>
    /// <param name="propertyCode">The property code to validate.</param>
    /// <param name="paramName">The name of the parameter being validated.</param>
    /// <returns>The original <paramref name="propertyCode"/> if it is defined.</returns>
    /// <exception cref="InvalidEnumArgumentException">
    /// Thrown when the <paramref name="propertyCode"/> is not a defined value in the <see cref="PropertyCode"/> enumeration.
    /// </exception>
    public static PropertyCode Defined(
        this PropertyCode propertyCode,
        string paramName)
    => Enum.IsDefined(propertyCode) ?
        propertyCode
        : throw propertyCode.GetInvalidEnumArgumentException(paramName);

    /// <summary>
    /// Creates a standardized invalid enumeration exception for <see cref="PropertyCode"/> values.
    /// Used to maintain consistent error handling across the test data framework.
    /// </summary>
    /// <param name="propertyCode">The invalid property code value.</param>
    /// <param name="paramName">The name of the parameter that contained the invalid value.</param>
    /// <returns>A new <see cref="InvalidEnumArgumentException"/> instance.</returns>
    public static InvalidEnumArgumentException GetInvalidEnumArgumentException(
        this PropertyCode propertyCode,
        string paramName)
    => new(paramName, (int)propertyCode, typeof(PropertyCode));
    #endregion
}