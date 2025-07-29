// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.Statics;

/// <summary>
/// Provides extension methods for adding elements to object arrays and to validate Argscode enum parameter.
/// </summary>
public static class Extensions
{
    #region object?[]
    /// <summary>
    /// Adds a parameter to the array of arguments based on the specified argument code.
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
    /// Validates whether the specified <see cref="ArgsCode"/> is defined in the enumeration.
    /// If the value is not defined, an <see cref="InvalidEnumArgumentException"/> is thrown.
    /// </summary>
    /// <param name="argsCode">The <see cref="ArgsCode"/> value to validate.</param>
    /// <param name="paramName">The name of the parameter to include in the exception message if the value is not defined.</param>
    /// <returns>The validated <see cref="ArgsCode"/> value if it is defined in the enumeration.</returns>
    /// <exception cref="InvalidEnumArgumentException">Thrown if the <paramref name="argsCode"/> value is not defined in the enumeration.</exception>
    public static ArgsCode Defined(
        this ArgsCode argsCode,
        string paramName)
    => Enum.IsDefined(argsCode) ?
        argsCode
        : throw argsCode.GetInvalidEnumArgumentException(paramName);

    /// <summary>
    /// Creates a new <see cref="InvalidEnumArgumentException"/> for the specified <see cref="ArgsCode"/> value.
    /// </summary>
    /// <param name="argsCode">The <see cref="ArgsCode"/> value that is invalid.</param>
    /// <param name="paramName">The name of the parameter that contains the invalid value.</param>
    /// <returns>A new instance of <see cref="InvalidEnumArgumentException"/> initialized with the specified arguments.</returns>
    public static InvalidEnumArgumentException GetInvalidEnumArgumentException(
        this ArgsCode argsCode,
        string paramName)
    => new(paramName, (int)argsCode, typeof(ArgsCode));
    #endregion

    #region PropertyCode
    /// <summary>
    /// Validates whether the specified <see cref="PropertyCode"/> is defined in the enumeration.
    /// If the value is not defined, an <see cref="InvalidEnumArgumentException"/> is thrown.
    /// </summary>
    /// <param name="propertyCode">The <see cref="PropertyCode"/> value to validate.</param>
    /// <param name="paramName">The name of the parameter to include in the exception message if the value is not defined.</param>
    /// <returns>The validated <see cref="PropertyCode"/> value if it is defined in the enumeration.</returns>
    /// <exception cref="InvalidEnumArgumentException">Thrown if the <paramref name="propertyCode"/> value is not defined in the enumeration.</exception>
    public static PropertyCode Defined(
        this PropertyCode propertyCode,
        string paramName)
    => Enum.IsDefined(propertyCode) ?
        propertyCode
        : throw propertyCode.GetInvalidEnumArgumentException(paramName);

    /// <summary>
    /// Creates a new <see cref="InvalidEnumArgumentException"/> for the specified <see cref="PropertyCode"/> value.
    /// </summary>
    /// <param name="propertyCode">The <see cref="PropertyCode"/> value that is invalid.</param>
    /// <param name="paramName">The name of the parameter that contains the invalid value.</param>
    /// <returns>A new instance of <see cref="InvalidEnumArgumentException"/> initialized with the specified arguments.</returns>
    public static InvalidEnumArgumentException GetInvalidEnumArgumentException(
        this PropertyCode propertyCode,
        string paramName)
    => new(paramName, (int)propertyCode, typeof(PropertyCode));
    #endregion
}
