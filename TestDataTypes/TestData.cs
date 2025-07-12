// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.TestDataTypes;

#region Abstract type
/// <summary>
/// Represents an abstract record for test data.
/// </summary>
/// <param name="Definition">The definition of the test case.</param>
/// 
public abstract record TestData(string Definition)
: ITestData
{
    #region Methods
    /// <summary>
    /// Determines whether the current instance is equal to another <see cref="INamedTestCase"/> instance.
    /// </summary>
    /// <param name="other">The <see cref="INamedTestCase"/> instance to compare with the current instance, or <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if the specified <see cref="INamedTestCase"/> instance is equal to the current instance; 
    /// otherwise, <see langword="false"/>.</returns>
    public bool Equals(INamedTestCase? other)
    => other?.GetTestCaseName() == GetTestCaseName();

    /// <inheritdoc />
    public override int GetHashCode()
    => GetTestCaseName().GetHashCode();

    /// <summary>
    /// Converts the test dataRows to an array of arguments based on the specified <see cref="ArgsCode"/>.
    /// </summary>
    /// <param name="argsCode">The code indicating how to convert the test dataRows to arguments.</param>
    /// <returns>An array of arguments, containing
    /// - This instance if <paramref name="argsCode"/> value is <enum cref="ArgsCode.Instance" />,
    /// - The defined properties of this instance if <paramref name="argsCode"/> value is <enum cref="ArgsCode.Properties" />
    /// .</returns>
    /// <exception cref="InvalidEnumArgumentException">Thrown when the <paramref name="argsCode"/> is not valid.</exception>
    public virtual object?[] ToArgs(ArgsCode argsCode)
    => argsCode switch
    {
        ArgsCode.Instance => [this],
        ArgsCode.Properties => [GetTestCaseName()],
        _ => throw argsCode.GetInvalidEnumArgumentException(nameof(argsCode)),
    };

    /// <inheritdoc cref="ITestData.ToParams(ArgsCode, bool)"/>
    public object?[] ToParams(ArgsCode argsCode, bool? withExpected)
    {
        if (argsCode == ArgsCode.Instance
            || !withExpected.HasValue)
        {
            return ToArgs(argsCode);
        }

        var propertiesArgs = ToArgs(ArgsCode.Properties);
        int count = propertiesArgs?.Length ?? 0;

        return this is not IExpected || withExpected.Value ?
            propertiesArgsStartingFrom(1)
            : propertiesArgsStartingFrom(2);

        #region Local methods
        object?[] propertiesArgsStartingFrom(int index)
        => count > index ?
            propertiesArgs![index..]
            : throw new InvalidOperationException(
                PropsCountNotEnoughMessage);
        #endregion
    }

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>The test case string representation.</returns>
    public override sealed string ToString()
    => GetTestCaseName();

    #region Abstract methods
    public abstract string GetTestCaseName();
    #endregion
    #endregion

    #region Helper members
    /// <summary>
    /// Represents an error message indicating that the number of test dataRows properties is insufficient for the current
    /// operation.
    /// </summary>
    internal const string PropsCountNotEnoughMessage =
        "The test data properties count is " +
        "not enough for the current operation.";

    protected string GetDefinitionAndArrow()
    => (string.IsNullOrWhiteSpace(Definition) ?
            nameof(Definition)
            : Definition) +
        " => ";
    #endregion
}
#endregion

#region Concrete types
/// <summary>
/// Represents a concrete record for test dataRows with one argument.
/// </summary>
/// <typeparam name="T1">The type of the first argument.</typeparam>
/// <param name="Definition">The definition of the test dataRows.</param>
/// <param name="Expected">The result of the test dataRows.</param>
/// <param name="Arg1">The first argument.</param>
public record TestData<T1>(
    string Definition,
    string Expected,
    T1? Arg1)
: TestData(Definition),
ITestData<string, T1>
{
    /// <summary>
    /// Gets the test case string representation.
    /// </summary>
    public string TestCaseName
    => $"{GetDefinitionAndArrow()}" +
        $"{(string.IsNullOrWhiteSpace(Expected) ?
            nameof(Expected)
            : Expected)}";

    public override sealed string GetTestCaseName()
    => TestCaseName;

    /// <inheritdoc cref="TestData.ToArgs(ArgsCode)" />
    public override object?[] ToArgs(ArgsCode argsCode)
    => base.ToArgs(argsCode).Add(argsCode, Arg1);
}

/// <inheritdoc cref="TestData{T1}" />
/// <typeparam name="T2">The type of the second argument.</typeparam>
/// <param name="Arg2">The second argument.</param>
public record TestData<T1, T2>(
    string Definition,
    string Expected,
    T1? Arg1, T2? Arg2)
: TestData<T1>(
    Definition,
    Expected,
    Arg1), ITestData<string, T1, T2>
{
    /// <inheritdoc cref="TestData.ToArgs(ArgsCode)" />
    public override object?[] ToArgs(ArgsCode argsCode)
    => base.ToArgs(argsCode).Add(argsCode, Arg2);
}

/// <inheritdoc cref="TestData{T1, T2}" />
/// <typeparam name="T3">The type of the third argument.</typeparam>
/// <param name="Arg3">The third argument.</param>
public record TestData<T1, T2, T3>(
    string Definition,
    string Expected,
    T1? Arg1, T2? Arg2, T3? Arg3)
: TestData<T1, T2>(
    Definition,
    Expected,
    Arg1, Arg2),
    ITestData<string, T1, T2, T3>
{
    /// <inheritdoc cref="TestData.ToArgs(ArgsCode)" />
    public override object?[] ToArgs(ArgsCode argsCode)
    => base.ToArgs(argsCode).Add(argsCode, Arg3);
}

/// <inheritdoc cref="TestData{T1, T2, T3}" />
/// <typeparam name="T4">The type of the fourth argument.</typeparam>
/// <param name="Arg4">The fourth argument.</param>
public record TestData<T1, T2, T3, T4>(
    string Definition,
    string Expected,
    T1? Arg1, T2? Arg2, T3? Arg3, T4? Arg4)
: TestData<T1, T2, T3>(
    Definition,
    Expected,
    Arg1, Arg2, Arg3),
    ITestData<string, T1, T2, T3, T4>
{
    /// <inheritdoc cref="TestData.ToArgs(ArgsCode)" />
    public override object?[] ToArgs(ArgsCode argsCode)
    => base.ToArgs(argsCode).Add(argsCode, Arg4);
}

/// <inheritdoc cref="TestData{T1, T2, T3, T4}" />
/// <typeparam name="T5">The type of the fifth argument.</typeparam>
/// <param name="Arg5">The fifth argument.</param>
public record TestData<T1, T2, T3, T4, T5>(
    string Definition,
    string Expected,
    T1? Arg1, T2? Arg2, T3? Arg3, T4? Arg4, T5? Arg5)
: TestData<T1, T2, T3, T4>(
    Definition,
    Expected,
    Arg1, Arg2, Arg3, Arg4),
    ITestData<string, T1, T2, T3, T4, T5>
{
    /// <inheritdoc cref="TestData.ToArgs(ArgsCode)" />
    public override object?[] ToArgs(ArgsCode argsCode)
    => base.ToArgs(argsCode).Add(argsCode, Arg5);
}

/// <inheritdoc cref="TestData{T1, T2, T3, T4, T5}" />
/// <typeparam name="T6">The type of the sixth argument.</typeparam>
/// <param name="Arg6">The sixth argument.</param>
public record TestData<T1, T2, T3, T4, T5, T6>(
    string Definition,
    string Expected,
    T1? Arg1, T2? Arg2, T3? Arg3, T4? Arg4, T5? Arg5, T6? Arg6)
: TestData<T1, T2, T3, T4, T5>(
    Definition,
    Expected,
    Arg1, Arg2, Arg3, Arg4, Arg5),
    ITestData<string, T1, T2, T3, T4, T5, T6>
{
    /// <inheritdoc cref="TestData.ToArgs(ArgsCode)" />
    public override object?[] ToArgs(ArgsCode argsCode)
    => base.ToArgs(argsCode).Add(argsCode, Arg6);
}

/// <inheritdoc cref="TestData{T1, T2, T3, T4, T5, T6}" />
/// <typeparam name="T7">The type of the seventh argument.</typeparam>
/// <param name="Arg7">The seventh argument.</param>
public record TestData<T1, T2, T3, T4, T5, T6, T7>(
    string Definition,
    string Expected,
    T1? Arg1, T2? Arg2, T3? Arg3, T4? Arg4, T5? Arg5, T6? Arg6, T7? Arg7)
: TestData<T1, T2, T3, T4, T5, T6>(
    Definition,
    Expected,
    Arg1, Arg2, Arg3, Arg4, Arg5, Arg6),
    ITestData<string, T1, T2, T3, T4, T5, T6, T7>
{
    /// <inheritdoc cref="TestData.ToArgs(ArgsCode)" />
    public override object?[] ToArgs(ArgsCode argsCode)
    => base.ToArgs(argsCode).Add(argsCode, Arg7);
}

/// <inheritdoc cref="TestData{T1, T2, T3, T4, T5, T6, T7}" />
/// <typeparam name="T8">The type of the eighth argument.</typeparam>
/// <param name="Arg8">The eighth argument.</param>
public record TestData<T1, T2, T3, T4, T5, T6, T7, T8>(
    string Definition,
    string Expected,
    T1? Arg1, T2? Arg2, T3? Arg3, T4? Arg4, T5? Arg5, T6? Arg6, T7? Arg7, T8? Arg8)
: TestData<T1, T2, T3, T4, T5, T6, T7>(
    Definition,
    Expected,
    Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7),
    ITestData<string, T1, T2, T3, T4, T5, T6, T7, T8>
{
    /// <inheritdoc cref="TestData.ToArgs(ArgsCode)" />
    public override object?[] ToArgs(ArgsCode argsCode)
    => base.ToArgs(argsCode).Add(argsCode, Arg8);
}

/// <inheritdoc cref="TestData{T1, T2, T3, T4, T5, T6, T7, T8}" />
/// <typeparam name="T9">The type of the ninth argument.</typeparam>
/// <param name="Arg9">The ninth argument.</param>
public record TestData<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
    string Definition,
    string Expected,
    T1? Arg1, T2? Arg2, T3? Arg3, T4? Arg4, T5? Arg5, T6? Arg6, T7? Arg7, T8? Arg8, T9? Arg9)
: TestData<T1, T2, T3, T4, T5, T6, T7, T8>(
    Definition,
    Expected,
    Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8),
    ITestData<string, T1, T2, T3, T4, T5, T6, T7, T8, T9>
{
    /// <inheritdoc cref="TestData.ToArgs(ArgsCode)" />
    public override object?[] ToArgs(ArgsCode argsCode)
    => base.ToArgs(argsCode).Add(argsCode, Arg9);
}
#endregion
