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
        _ = expected ?? throw new ArgumentNullException(nameof(expected), "Expected array cannot be null");

        int actualLength = actual?.Length ?? throw new ArgumentNullException(nameof(actual), "Actual array cannot be null");

        Assert.Equal(expected.Length, actualLength);

        for (int i = 0; i < actualLength; i++)
        {
            Assert.Equal(expected[i], actual[i]);
        }
    }
}
