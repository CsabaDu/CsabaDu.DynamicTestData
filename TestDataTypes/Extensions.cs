namespace CsabaDu.DynamicTestData.TestDataTypes;

public static class Extensions
{
    /// <summary>
    /// Appends an item to the end of the given array.
    /// </summary>
    /// <typeparam name="T">The type of the parameter to append.</typeparam>
    /// <param name="args">The array to which the parameter will be appended.</param>
    /// <param name="param">The parameter to append to the array.</param>
    /// <returns>A new array with the parameter appended to the end.</returns>
    public static object?[] Append<T>(this object?[] args, T? param)
    {
        var result = new object?[args.Length + 1];
        Array.Copy(args, result, args.Length);
        result[args.Length] = param;

        return result;
    }
}
