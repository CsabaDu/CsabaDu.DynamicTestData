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
using static CsabaDu.DynamicTestData.TestHelpers.TestParameters.TestCaseDataArgs;

namespace CsabaDu.DynamicTestData.NUnit.Tests.TheoryDataSources;

public sealed class ExtensionsTheoryData
{
    public static TheoryData<TestData, ArgsCode, TestCaseData> ToTestCaseDataTheoryData => new()
    {
        { TestDataArgs1, ArgsCode.Instance, GetTestCaseData(TestDataTestCase, TestDataArgs1) },
        { TestDataArgs2, ArgsCode.Instance, GetTestCaseData(TestDataTestCase, TestDataArgs2) },
        { TestDataArgs3, ArgsCode.Instance, GetTestCaseData(TestDataTestCase, TestDataArgs3) },
        { TestDataArgs4, ArgsCode.Instance, GetTestCaseData(TestDataTestCase, TestDataArgs4) },
        { TestDataArgs5, ArgsCode.Instance, GetTestCaseData(TestDataTestCase, TestDataArgs5) },
        { TestDataArgs6, ArgsCode.Instance, GetTestCaseData(TestDataTestCase, TestDataArgs6) },
        { TestDataArgs7, ArgsCode.Instance, GetTestCaseData(TestDataTestCase, TestDataArgs7) },
        { TestDataArgs8, ArgsCode.Instance, GetTestCaseData(TestDataTestCase, TestDataArgs8) },
        { TestDataArgs9, ArgsCode.Instance, GetTestCaseData(TestDataTestCase, TestDataArgs9) },

        { TestDataReturnsArgs1, ArgsCode.Instance, GetTestCaseData(TestDataReturnsTestCase, TestDataReturnsArgs1) },
        { TestDataReturnsArgs2, ArgsCode.Instance, GetTestCaseData(TestDataReturnsTestCase, TestDataReturnsArgs2) },
        { TestDataReturnsArgs3, ArgsCode.Instance, GetTestCaseData(TestDataReturnsTestCase, TestDataReturnsArgs3) },
        { TestDataReturnsArgs4, ArgsCode.Instance, GetTestCaseData(TestDataReturnsTestCase, TestDataReturnsArgs4) },
        { TestDataReturnsArgs5, ArgsCode.Instance, GetTestCaseData(TestDataReturnsTestCase, TestDataReturnsArgs5) },
        { TestDataReturnsArgs6, ArgsCode.Instance, GetTestCaseData(TestDataReturnsTestCase, TestDataReturnsArgs6) },
        { TestDataReturnsArgs7, ArgsCode.Instance, GetTestCaseData(TestDataReturnsTestCase, TestDataReturnsArgs7) },
        { TestDataReturnsArgs8, ArgsCode.Instance, GetTestCaseData(TestDataReturnsTestCase, TestDataReturnsArgs8) },
        { TestDataReturnsArgs9, ArgsCode.Instance, GetTestCaseData(TestDataReturnsTestCase, TestDataReturnsArgs9) },

        { TestDataThrowsArgs1, ArgsCode.Instance, GetTestCaseData(TestDataThrowsTestCase, TestDataThrowsArgs1) },
        { TestDataThrowsArgs2, ArgsCode.Instance, GetTestCaseData(TestDataThrowsTestCase, TestDataThrowsArgs2) },
        { TestDataThrowsArgs3, ArgsCode.Instance, GetTestCaseData(TestDataThrowsTestCase, TestDataThrowsArgs3) },
        { TestDataThrowsArgs4, ArgsCode.Instance, GetTestCaseData(TestDataThrowsTestCase, TestDataThrowsArgs4) },
        { TestDataThrowsArgs5, ArgsCode.Instance, GetTestCaseData(TestDataThrowsTestCase, TestDataThrowsArgs5) },
        { TestDataThrowsArgs6, ArgsCode.Instance, GetTestCaseData(TestDataThrowsTestCase, TestDataThrowsArgs6) },
        { TestDataThrowsArgs7, ArgsCode.Instance, GetTestCaseData(TestDataThrowsTestCase, TestDataThrowsArgs7) },
        { TestDataThrowsArgs8, ArgsCode.Instance, GetTestCaseData(TestDataThrowsTestCase, TestDataThrowsArgs8) },
        { TestDataThrowsArgs9, ArgsCode.Instance, GetTestCaseData(TestDataThrowsTestCase, TestDataThrowsArgs9) },

        { TestDataArgs1, ArgsCode.Properties, GetTestCaseData(TestDataTestCase, Arg1) },
        { TestDataArgs2, ArgsCode.Properties, GetTestCaseData(TestDataTestCase, Args2) },
        { TestDataArgs3, ArgsCode.Properties, GetTestCaseData(TestDataTestCase, Args3) },
        { TestDataArgs4, ArgsCode.Properties, GetTestCaseData(TestDataTestCase, Args4) },
        { TestDataArgs5, ArgsCode.Properties, GetTestCaseData(TestDataTestCase, Args5) },
        { TestDataArgs6, ArgsCode.Properties, GetTestCaseData(TestDataTestCase, Args6) },
        { TestDataArgs7, ArgsCode.Properties, GetTestCaseData(TestDataTestCase, Args7) },
        { TestDataArgs8, ArgsCode.Properties, GetTestCaseData(TestDataTestCase, Args8) },
        { TestDataArgs9, ArgsCode.Properties, GetTestCaseData(TestDataTestCase, Args9) },

        { TestDataReturnsArgs1, ArgsCode.Properties, GetTestCaseData(TestDataReturnsTestCase, DummyEnumTestValue, Arg1) },
        { TestDataReturnsArgs2, ArgsCode.Properties, GetTestCaseData(TestDataReturnsTestCase, [DummyEnumTestValue, .. Args2]) },
        { TestDataReturnsArgs3, ArgsCode.Properties, GetTestCaseData(TestDataReturnsTestCase, [DummyEnumTestValue, .. Args3]) },
        { TestDataReturnsArgs4, ArgsCode.Properties, GetTestCaseData(TestDataReturnsTestCase, [DummyEnumTestValue, .. Args4]) },
        { TestDataReturnsArgs5, ArgsCode.Properties, GetTestCaseData(TestDataReturnsTestCase, [DummyEnumTestValue, .. Args5]) },
        { TestDataReturnsArgs6, ArgsCode.Properties, GetTestCaseData(TestDataReturnsTestCase, [DummyEnumTestValue, .. Args6]) },
        { TestDataReturnsArgs7, ArgsCode.Properties, GetTestCaseData(TestDataReturnsTestCase, [DummyEnumTestValue, .. Args7]) },
        { TestDataReturnsArgs8, ArgsCode.Properties, GetTestCaseData(TestDataReturnsTestCase, [DummyEnumTestValue, .. Args8]) },
        { TestDataReturnsArgs9, ArgsCode.Properties, GetTestCaseData(TestDataReturnsTestCase, [DummyEnumTestValue, .. Args9]) },

        { TestDataThrowsArgs1, ArgsCode.Properties, GetTestCaseData(TestDataThrowsTestCase, DummyExceptionInstance, Arg1) },
        { TestDataThrowsArgs2, ArgsCode.Properties, GetTestCaseData(TestDataThrowsTestCase, [DummyExceptionInstance, .. Args2]) },
        { TestDataThrowsArgs3, ArgsCode.Properties, GetTestCaseData(TestDataThrowsTestCase, [DummyExceptionInstance, .. Args3]) },
        { TestDataThrowsArgs4, ArgsCode.Properties, GetTestCaseData(TestDataThrowsTestCase, [DummyExceptionInstance, .. Args4]) },
        { TestDataThrowsArgs5, ArgsCode.Properties, GetTestCaseData(TestDataThrowsTestCase, [DummyExceptionInstance, .. Args5]) },
        { TestDataThrowsArgs6, ArgsCode.Properties, GetTestCaseData(TestDataThrowsTestCase, [DummyExceptionInstance, .. Args6]) },
        { TestDataThrowsArgs7, ArgsCode.Properties, GetTestCaseData(TestDataThrowsTestCase, [DummyExceptionInstance, .. Args7]) },
        { TestDataThrowsArgs8, ArgsCode.Properties, GetTestCaseData(TestDataThrowsTestCase, [DummyExceptionInstance, .. Args8]) },
        { TestDataThrowsArgs9, ArgsCode.Properties, GetTestCaseData(TestDataThrowsTestCase, [DummyExceptionInstance, .. Args9]) },
    };

    public static TheoryData<string, bool> ToTestCaseDataSetNameTheoryData => new()
    {
        { null, false },
        { string.Empty, false },
        { TestMethodName, true },
    };
}
