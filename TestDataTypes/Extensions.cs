namespace CsabaDu.DynamicTestData.TestDataTypes;

public static class Extensions
{
    public static object?[] Append<T>(this object?[] args, T? item)
    {
        var result = new object?[args.Length + 1];
        Array.Copy(args, result, args.Length);
        result[args.Length] = item;

        return result;
    }
}
