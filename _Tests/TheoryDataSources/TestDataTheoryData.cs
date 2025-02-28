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
namespace CsabaDu.DynamicTestData.Tests.TheoryDataSources;

public class TestDataTheoryData
{
    public static TheoryData<string, string>PropertyTheoryData => new()
    {
        { null, null },
        { string.Empty, string.Empty },
        { NotNullProperty, NotNullProperty },
    };

    public static TheoryData<string, string, string, string> TestCaseTheoryData => new()
    {
        #region null
        { null, null, null, GetTestDataTestCase(Definition, Result) },
        { ActualDefinition, null, null , GetTestDataTestCase(ActualDefinition, Result) },
        { ActualDefinition, ActualExitMode, null, GetTestDataTestCase(ActualDefinition, GetExitModeResult(ActualExitMode, Result)) },
        { ActualDefinition, ActualExitMode, ActualResult, GetTestDataTestCase(ActualDefinition, GetExitModeResult(ActualExitMode, ActualResult)) },
        { null, null, ActualResult, GetTestDataTestCase(Definition, ActualResult) },
        { null, ActualExitMode, ActualResult, GetTestDataTestCase(Definition, GetExitModeResult(ActualExitMode, ActualResult)) },
        { ActualDefinition, null, ActualResult, GetTestDataTestCase(ActualDefinition, ActualResult) },
        { null, ActualExitMode, null, GetTestDataTestCase(Definition, GetExitModeResult(ActualExitMode, Result)) },
        #endregion

        #region string.Empty
        { string.Empty, ActualExitMode, ActualResult, GetTestDataTestCase(Definition, GetExitModeResult(ActualExitMode, ActualResult)) },
        { ActualDefinition, string.Empty, ActualResult, GetTestDataTestCase(ActualDefinition, ActualResult) },
        { ActualDefinition, ActualExitMode, string.Empty, GetTestDataTestCase(ActualDefinition, GetExitModeResult(ActualExitMode, Result)) },
        #endregion
    };

    public static TheoryData<ArgsCode, object[]> VirtualToArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataChildInstance] },
        { ArgsCode.Properties, [TestDataChildInstance.TestCase] },
    };

    public static TheoryData<ArgsCode, ITestData<string>, object[]> ToArgsTheoryData => new()
    {
        #region ArgsCode.Properties
        { ArgsCode.Properties, TestDataArgs1, [TestDataTestCase, .. Args1] },
        { ArgsCode.Properties, TestDataArgs2, [TestDataTestCase, .. Args2] },
        { ArgsCode.Properties, TestDataArgs3, [TestDataTestCase, .. Args3] },
        { ArgsCode.Properties, TestDataArgs4, [TestDataTestCase, .. Args4] },
        { ArgsCode.Properties, TestDataArgs5, [TestDataTestCase, .. Args5] },
        { ArgsCode.Properties, TestDataArgs6, [TestDataTestCase, .. Args6] },
        { ArgsCode.Properties, TestDataArgs7, [TestDataTestCase, .. Args7] },
        { ArgsCode.Properties, TestDataArgs8, [TestDataTestCase, .. Args8] },
        { ArgsCode.Properties, TestDataArgs9, [TestDataTestCase, .. Args9] },
        #endregion

        #region ArgsCode.Instance
        { ArgsCode.Instance, TestDataArgs1, [TestDataArgs1] },
        { ArgsCode.Instance, TestDataArgs2, [TestDataArgs2] },
        { ArgsCode.Instance, TestDataArgs3, [TestDataArgs3] },
        { ArgsCode.Instance, TestDataArgs4, [TestDataArgs4] },
        { ArgsCode.Instance, TestDataArgs5, [TestDataArgs5] },
        { ArgsCode.Instance, TestDataArgs6, [TestDataArgs6] },
        { ArgsCode.Instance, TestDataArgs7, [TestDataArgs7] },
        { ArgsCode.Instance, TestDataArgs8, [TestDataArgs8] },
        { ArgsCode.Instance, TestDataArgs9, [TestDataArgs9] },
        #endregion
    };

    public static TheoryData<string, string> ResultOverrideTheoryData => new()
    {
        { null, ExpectedPropertyName },
        { string.Empty, ExpectedPropertyName },
        { ExpectedString, ExpectedString },
    };
}
