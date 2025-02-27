using static CsabaDu.DynamicTestData.DynamicDataSources.DynamicDataSource;

namespace CsabaDu.DynamicTestData.NUnit.Statics;

/// <summary>
/// Provides extension methods for converting test data to TestCaseData.
/// </summary>
public static class Extensions
{
    #region TestCaseData
    /// <summary>
    /// Converts an instance of TestData to TestCaseData.
    /// </summary>
    /// <param name="testData">The test data to convert.</param>
    /// <param name="argsCode">The ArgsCode to determine the conversion method.</param>
    /// <param name="testMethodName">Optional. The name of the test method.</param>
    /// <returns>A TestCaseData object with the converted test data.</returns>
    public static TestCaseData ToTestCaseData(this TestData testData, ArgsCode argsCode, string? testMethodName = null)
    => testData.ToTestCaseData(argsCode, 1).SetDescriptionAndName(testData.TestCase, testMethodName);
    #endregion

    #region TestDataReturns<TStruct>
    /// <summary>
    /// Converts an instance of TestDataReturns<TStruct> to TestCaseData.
    /// </summary>
    /// <typeparam name="TStruct">The type of the expected return struct value.</typeparam>
    /// <param name="testData">The test data to convert.</param>
    /// <param name="argsCode">The ArgsCode to determine the conversion method.</param>
    /// <param name="testMethodName">Optional. The name of the test method.</param>
    /// <returns>A TestCaseData object with the converted test data and expected return value.</returns>
    public static TestCaseData ToTestCaseData<TStruct>(this TestDataReturns<TStruct> testData, ArgsCode argsCode, string? testMethodName = null)
    where TStruct : struct
    => testData.ToTestCaseData(argsCode, 2).SetDescriptionAndName(testData.TestCase, testMethodName).Returns(testData.Expected);

    private static TestCaseData ToTestCaseData(this TestData testData, ArgsCode argsCode, int index)
    => argsCode switch
    {
        ArgsCode.Instance => new(testData),
        ArgsCode.Properties => new(testData.ToArgs(argsCode)[index..]),
        _ => throw argsCode.GetInvalidEnumArgumentException(nameof(argsCode)),
    };

    private static TestCaseData SetDescriptionAndName(this TestCaseData testCaseData, string description, string? testMethodName)
    => string.IsNullOrEmpty(testMethodName) ?
        testCaseData.SetDescription(description)
        : testCaseData.SetDescription(description).SetName(GetDisplayName(testMethodName, description));
    #endregion
}
