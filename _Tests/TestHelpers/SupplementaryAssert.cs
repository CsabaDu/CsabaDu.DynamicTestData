namespace CsabaDu.DynamicTestData.Tests.TestHelpers;

public static class SupplementaryAssert
{
    /// <summary>
    /// Asserts that two object arrays are equal.
    /// </summary>
    /// <param name="expected">The expected array.</param>
    /// <param name="actual">The actual array.</param>
    /// <exception cref="ArgumentNullException">Thrown when the expected or actual array is null.</exception>
    public static void ObjectArraysEqual(object[] expected, object[] actual)
    {
        int expectedLength = expected?.Length ?? throw argumentNullException(nameof(expected));

        Assert.Equal(expectedLength, actual?.Length ?? throw argumentNullException(nameof(actual)));

        for (int i = 0; i < expectedLength; i++)
        {
            Assert.Equal(expected[i], actual[i]);
        }

        static ArgumentNullException argumentNullException(string paramName)
        => new(paramName, $"{paramName} array cannot be null");
    }
}
