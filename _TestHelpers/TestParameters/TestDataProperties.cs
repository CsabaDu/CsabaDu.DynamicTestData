/* 
 * MIT License
 * 
 * Copyright (c) 2025. Csaba Dudas (CsabaDu)
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */
namespace CsabaDu.DynamicTestData.TestHelpers.TestParameters;

public class TestDataProperties
{
    /// <summary>
    /// Generates a test case string by combining the definition and exit mode result.
    /// </summary>
    /// <param name="definition">The definition of the test case.</param>
    /// <param name="exitModeResult">The exit mode result of the test case.</param>
    /// <returns>A string representing the test case in the format "definition => exitModeResult".</returns>
    public static string GetTestDataTestCase(string definition, string exitModeResult)
    => $"{definition} => {exitModeResult}";

    /// <summary>
    /// Generates an exit mode result string by combining the exit mode and result.
    /// </summary>
    /// <param name="exitMode">The exit mode of the test case.</param>
    /// <param name="result">The result of the test case.</param>
    /// <returns>A string representing the exit mode result in the format "exitMode result".</returns>
    public static string GetExitModeResult(string exitMode, string result)
    => $"{exitMode} {result}";

    /// <summary>
    /// Gets a test case string by combining the actual definition and expected string.
    /// </summary>
    public static string TestDataTestCase
    => $"{ActualDefinition} => {ExpectedString}";

    /// <summary>
    /// Gets a test case string by combining the actual definition and the exit mode result of the test data returns.
    /// </summary>
    public static string TestDataReturnsTestCase
    => $"{ActualDefinition} => {TestData.Returns} {DummyEnumTestValue}";

    /// <summary>
    /// Gets a test case string by combining the actual definition and the exit mode result of the test data throws.
    /// </summary>
    public static string TestDataThrowsTestCase
    => $"{ActualDefinition} => {TestData.Throws} {typeof(DummyException).Name}";
}
