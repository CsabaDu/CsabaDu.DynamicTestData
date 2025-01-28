namespace CsabaDu.DynamicTestData.Tests.TestHelpers;

public static class SupplementaryAssert
{
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
