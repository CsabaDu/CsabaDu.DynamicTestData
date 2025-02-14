namespace CsabaDu.DynamicTestData.Statics;

public static class Extensions
{
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
    public static object?[] Add<T>(this object?[] args, ArgsCode argsCode, T? parameter)
    => argsCode == ArgsCode.Properties ? [.. args, parameter] : args;
}
