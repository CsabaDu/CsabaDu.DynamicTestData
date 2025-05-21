namespace CsabaDu.DynamicTestData.TestDataTypes.Interfaces;

/// <summary>
/// Represents a test case with a description.
/// </summary>
/// <remarks>This interface is intended to provide a standardized way to access the description of a test case.
/// Implementations of this interface should define the specific behavior and context of the test case.</remarks>
public interface ITestCase : IEquatable<ITestCase>
{
    /// <summary>
    /// Gets the test case description.
    /// </summary>
    string TestCase { get; }
}
