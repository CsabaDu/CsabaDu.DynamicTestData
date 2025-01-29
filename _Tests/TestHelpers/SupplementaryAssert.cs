namespace CsabaDu.DynamicTestData.Tests.TestHelpers;

public static class SupplementaryAssert
{
    /// <summary>
    /// Asserts that two object arrays are equal.
    /// </summary>
    /// <param name="expected">The expected array.</param>
    /// <param name="actual">The actual array.</param>
    /// <exception cref="ArgumentNullException">Thrown when the expected or actual array is null.</exception>
    public static void ObjectArraysEqual<T>(T[] expected, T[] actual)
    {
        int expectedLength = expected?.Length ?? throw ArrayArgumentNullException(nameof(expected));

        Assert.Equal(expectedLength, actual?.Length ?? throw ArrayArgumentNullException(nameof(actual)));

        for (int i = 0; i < expectedLength; i++)
        {
            Assert.Equal(expected[i], actual[i]);
        }
    }

    /// <summary>
    /// Asserts that two collections are equal.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collections.</typeparam>
    /// <param name="expected">The expected collection.</param>
    /// <param name="actual">The actual collection.</param>
    /// <exception cref="ArgumentNullException">Thrown when the expected or actual collection is null.</exception>
    public static void CollectionsEqual<T>(IEnumerable<T> expected, IEnumerable<T> actual)
    {
        if (expected is T[] expectedArray && actual is T[] actualArray)
        {
            ObjectArraysEqual(expectedArray, actualArray);
        }

        int expectedCount = expected?.Count() ?? throw ArrayArgumentNullException(nameof(expected));

        Assert.Equal(expectedCount, actual?.Count() ?? throw ArrayArgumentNullException(nameof(actual)));

        IEnumerator<T> expectedEnumerator = expected.GetEnumerator();

        while (expectedEnumerator.MoveNext())
        {
            Assert.Equal(expectedEnumerator.Current, actual.GetEnumerator().Current);
        }
    }

    private static ArgumentNullException ArrayArgumentNullException(string paramName)
    {
        return new(paramName, $"{paramName} array cannot be null");
    }
}
