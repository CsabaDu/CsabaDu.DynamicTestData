namespace CsabaDu.DynamicTestData.Tests.TestDoubles;

/// <summary>
/// Represents a concrete record for test data with a definition, result, and exit mode.
/// </summary>
/// <param name="Definition">The definition of the test data.</param>
/// <param name="exitMode">The exit mode of the test data.</param>
/// <param name="result">The result of the test data.</param>
public sealed record TestDataChild(string Definition, string exitMode, string result) : TestData(Definition)
{
    /// <summary>
    /// Gets the result of the test data.
    /// </summary>
    public override string Result => result;

    /// <summary>
    /// Gets the exit mode of the test data.
    /// </summary>
    public override string ExitMode => exitMode;
}
