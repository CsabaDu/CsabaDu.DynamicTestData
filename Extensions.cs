namespace CsabaDu.DynamicTestData;

internal static class Extensions
{
    /// <summary>
    /// Adds parameters of specific type to the array of arguments based on the specified argument code.
    /// </summary>
    /// <typeparam name="T">The type of the parameters to add.</typeparam>
    /// <param name="args">The array of arguments to which the parameters will be added.</param>
    /// <param name="parameters">The parameters to add to the array of arguments.</param>
    /// <param name="argsCode">The argument code that determines the content of the returning array.</param>
    /// <returns>
    /// A new array of arguments with the parameters added if the argument code is <see cref="ArgsCode.Properties"/>;
    /// otherwise, the original array of arguments.
    /// </returns>
    public static object?[] Add<T>(this object?[] args, ArgsCode argsCode, params T[] parameters)
    => argsCode == ArgsCode.Properties ? [.. args, .. parameters] : args;
}
