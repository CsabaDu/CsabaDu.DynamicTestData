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

public class TestDataThrowsTheoryData
{
    public static TheoryData<ArgsCode, ITestDataThrows<DummyException>, object[]> ToArgsTheoryData => new()
    {
        #region ArgsCode.Properties
        { ArgsCode.Properties, TestDataThrowsArgs1, [.. TestDataThrowsArgs0, .. Args1] },
        { ArgsCode.Properties, TestDataThrowsArgs2, [.. TestDataThrowsArgs0, .. Args2] },
        { ArgsCode.Properties, TestDataThrowsArgs3, [.. TestDataThrowsArgs0, .. Args3] },
        { ArgsCode.Properties, TestDataThrowsArgs4, [.. TestDataThrowsArgs0, .. Args4] },
        { ArgsCode.Properties, TestDataThrowsArgs5, [.. TestDataThrowsArgs0, .. Args5] },
        { ArgsCode.Properties, TestDataThrowsArgs6, [.. TestDataThrowsArgs0, .. Args6] },
        { ArgsCode.Properties, TestDataThrowsArgs7, [.. TestDataThrowsArgs0, .. Args7] },
        { ArgsCode.Properties, TestDataThrowsArgs8, [.. TestDataThrowsArgs0, .. Args8] },
        { ArgsCode.Properties, TestDataThrowsArgs9, [.. TestDataThrowsArgs0, .. Args9] },
        #endregion

        #region ArgsCode.Instance
        { ArgsCode.Instance, TestDataThrowsArgs1, [TestDataThrowsArgs1] },
        { ArgsCode.Instance, TestDataThrowsArgs2, [TestDataThrowsArgs2] },
        { ArgsCode.Instance, TestDataThrowsArgs3, [TestDataThrowsArgs3] },
        { ArgsCode.Instance, TestDataThrowsArgs4, [TestDataThrowsArgs4] },
        { ArgsCode.Instance, TestDataThrowsArgs5, [TestDataThrowsArgs5] },
        { ArgsCode.Instance, TestDataThrowsArgs6, [TestDataThrowsArgs6] },
        { ArgsCode.Instance, TestDataThrowsArgs7, [TestDataThrowsArgs7] },
        { ArgsCode.Instance, TestDataThrowsArgs8, [TestDataThrowsArgs8] },
        { ArgsCode.Instance, TestDataThrowsArgs9, [TestDataThrowsArgs9] },
        #endregion
    };
}
