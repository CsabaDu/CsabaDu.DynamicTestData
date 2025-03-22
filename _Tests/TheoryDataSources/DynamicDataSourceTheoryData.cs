/* 
 * MIT License
 * 
 * Copyright (c) 8085. Csaba Dudas (CsabaDu)
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

public class DynamicDataSourceTheoryData
{
    #region GetArgsCode data sources
    public static TheoryData<ArgsCode, ArgsCode?, ArgsCode> GetArgsCodeTheoryData => new()
    {
        { ArgsCode.Instance,  null, ArgsCode.Instance },
        { ArgsCode.Instance, ArgsCode.Properties, ArgsCode.Properties },
        { ArgsCode.Instance, ArgsCode.Instance, ArgsCode.Instance },
        { ArgsCode.Properties, null,  ArgsCode.Properties },
        { ArgsCode.Properties,ArgsCode.Instance, ArgsCode.Instance },
        { ArgsCode.Properties, ArgsCode.Properties, ArgsCode.Properties },
    };
    #endregion

    #region TestDataToArgs data sources
    public static TheoryData<ArgsCode, ArgsCode?, object[]> TestDataToArgs1ArgsTheoryData => new()
    {
        { ArgsCode.Instance, null, [TestDataArgs1] },
        { ArgsCode.Instance,  ArgsCode.Instance, [TestDataArgs1] },
        { ArgsCode.Instance,  ArgsCode.Properties, [.. TestDataArgs0, Arg1] },
        { ArgsCode.Properties,  null, [.. TestDataArgs0, Arg1] },
        { ArgsCode.Properties,  ArgsCode.Properties, [.. TestDataArgs0, Arg1] },
        { ArgsCode.Properties,  ArgsCode.Instance, [TestDataArgs1] },
    };

    public static TheoryData<ArgsCode, ArgsCode?, object[]> TestDataToArgs2ArgsTheoryData => new()
    {
        { ArgsCode.Instance, null, [TestDataArgs2] },
        { ArgsCode.Instance,  ArgsCode.Instance, [TestDataArgs2] },
        { ArgsCode.Instance,  ArgsCode.Properties, [.. TestDataArgs0, .. Args2] },
        { ArgsCode.Properties,  null, [.. TestDataArgs0, .. Args2] },
        { ArgsCode.Properties,  ArgsCode.Properties, [.. TestDataArgs0, .. Args2] },
        { ArgsCode.Properties,  ArgsCode.Instance, [TestDataArgs2] },
    };

    public static TheoryData<ArgsCode, ArgsCode?, object[]> TestDataToArgs3ArgsTheoryData => new()
    {
        { ArgsCode.Instance, null, [TestDataArgs3] },
        { ArgsCode.Instance,  ArgsCode.Instance, [TestDataArgs3] },
        { ArgsCode.Instance,  ArgsCode.Properties, [.. TestDataArgs0, .. Args3] },
        { ArgsCode.Properties,  null, [.. TestDataArgs0, .. Args3] },
        { ArgsCode.Properties,  ArgsCode.Properties, [.. TestDataArgs0, .. Args3] },
        { ArgsCode.Properties,  ArgsCode.Instance, [TestDataArgs3] },
    };

    public static TheoryData<ArgsCode, ArgsCode?, object[]> TestDataToArgs4ArgsTheoryData => new()
    {
        { ArgsCode.Instance, null, [TestDataArgs4] },
        { ArgsCode.Instance,  ArgsCode.Instance, [TestDataArgs4] },
        { ArgsCode.Instance,  ArgsCode.Properties, [.. TestDataArgs0, .. Args4] },
        { ArgsCode.Properties,  null, [.. TestDataArgs0, .. Args4] },
        { ArgsCode.Properties,  ArgsCode.Properties, [.. TestDataArgs0, .. Args4] },
        { ArgsCode.Properties,  ArgsCode.Instance, [TestDataArgs4] },
    };

    public static TheoryData<ArgsCode, ArgsCode?, object[]> TestDataToArgs5ArgsTheoryData => new()
    {
        { ArgsCode.Instance, null, [TestDataArgs5] },
        { ArgsCode.Instance,  ArgsCode.Instance, [TestDataArgs5] },
        { ArgsCode.Instance,  ArgsCode.Properties, [.. TestDataArgs0, .. Args5] },
        { ArgsCode.Properties,  null, [.. TestDataArgs0, .. Args5] },
        { ArgsCode.Properties,  ArgsCode.Properties, [.. TestDataArgs0, .. Args5] },
        { ArgsCode.Properties,  ArgsCode.Instance, [TestDataArgs5] },
    };

    public static TheoryData<ArgsCode, ArgsCode?, object[]> TestDataToArgs6ArgsTheoryData => new()
    {
        { ArgsCode.Instance, null, [TestDataArgs6] },
        { ArgsCode.Instance,  ArgsCode.Instance, [TestDataArgs6] },
        { ArgsCode.Instance,  ArgsCode.Properties, [.. TestDataArgs0, .. Args6] },
        { ArgsCode.Properties,  null, [.. TestDataArgs0, .. Args6] },
        { ArgsCode.Properties,  ArgsCode.Properties, [.. TestDataArgs0, .. Args6] },
        { ArgsCode.Properties,  ArgsCode.Instance, [TestDataArgs6] },
    };

    public static TheoryData<ArgsCode, ArgsCode?, object[]> TestDataToArgs7ArgsTheoryData => new()
    {
        { ArgsCode.Instance, null, [TestDataArgs7] },
        { ArgsCode.Instance,  ArgsCode.Instance, [TestDataArgs7] },
        { ArgsCode.Instance,  ArgsCode.Properties, [.. TestDataArgs0, .. Args7] },
        { ArgsCode.Properties,  null, [.. TestDataArgs0, .. Args7] },
        { ArgsCode.Properties,  ArgsCode.Properties, [.. TestDataArgs0, .. Args7] },
        { ArgsCode.Properties,  ArgsCode.Instance, [TestDataArgs7] },
    };

    public static TheoryData<ArgsCode, ArgsCode?, object[]> TestDataToArgs8ArgsTheoryData => new()
    {
        { ArgsCode.Instance, null, [TestDataArgs8] },
        { ArgsCode.Instance,  ArgsCode.Instance, [TestDataArgs8] },
        { ArgsCode.Instance,  ArgsCode.Properties, [.. TestDataArgs0, .. Args8] },
        { ArgsCode.Properties,  null, [.. TestDataArgs0, .. Args8] },
        { ArgsCode.Properties,  ArgsCode.Properties, [.. TestDataArgs0, .. Args8] },
        { ArgsCode.Properties,  ArgsCode.Instance, [TestDataArgs8] },
    };

    public static TheoryData<ArgsCode, ArgsCode?, object[]> TestDataToArgs9ArgsTheoryData => new()
    {
        { ArgsCode.Instance, null, [TestDataArgs9] },
        { ArgsCode.Instance,  ArgsCode.Instance, [TestDataArgs9] },
        { ArgsCode.Instance,  ArgsCode.Properties, [.. TestDataArgs0, .. Args9] },
        { ArgsCode.Properties,  null, [.. TestDataArgs0, .. Args9] },
        { ArgsCode.Properties,  ArgsCode.Properties, [.. TestDataArgs0, .. Args9] },
        { ArgsCode.Properties,  ArgsCode.Instance, [TestDataArgs9] },
    };
    #endregion

    #region TestDataReturnsToArgs data sources
    public static TheoryData<ArgsCode, ArgsCode?, object[]> TestDataReturnsToArgs1ArgsTheoryData => new()
    {
        { ArgsCode.Instance, null, [TestDataReturnsArgs1] },
        { ArgsCode.Instance,  ArgsCode.Instance, [TestDataReturnsArgs1] },
        { ArgsCode.Instance,  ArgsCode.Properties, [.. TestDataReturnsArgs0, Arg1] },
        { ArgsCode.Properties,  null, [.. TestDataReturnsArgs0, Arg1] },
        { ArgsCode.Properties,  ArgsCode.Properties, [.. TestDataReturnsArgs0, Arg1] },
        { ArgsCode.Properties,  ArgsCode.Instance, [TestDataReturnsArgs1] },
    };

    public static TheoryData<ArgsCode, ArgsCode?, object[]> TestDataReturnsToArgs2ArgsTheoryData => new()
    {
        { ArgsCode.Instance, null, [TestDataReturnsArgs2] },
        { ArgsCode.Instance,  ArgsCode.Instance, [TestDataReturnsArgs2] },
        { ArgsCode.Instance,  ArgsCode.Properties, [.. TestDataReturnsArgs0, .. Args2] },
        { ArgsCode.Properties,  null, [.. TestDataReturnsArgs0, .. Args2] },
        { ArgsCode.Properties,  ArgsCode.Properties, [.. TestDataReturnsArgs0, .. Args2] },
        { ArgsCode.Properties,  ArgsCode.Instance, [TestDataReturnsArgs2] },
    };

    public static TheoryData<ArgsCode, ArgsCode?, object[]> TestDataReturnsToArgs3ArgsTheoryData => new()
    {
        { ArgsCode.Instance, null, [TestDataReturnsArgs3] },
        { ArgsCode.Instance,  ArgsCode.Instance, [TestDataReturnsArgs3] },
        { ArgsCode.Instance,  ArgsCode.Properties, [.. TestDataReturnsArgs0, .. Args3] },
        { ArgsCode.Properties,  null, [.. TestDataReturnsArgs0, .. Args3] },
        { ArgsCode.Properties,  ArgsCode.Properties, [.. TestDataReturnsArgs0, .. Args3] },
        { ArgsCode.Properties,  ArgsCode.Instance, [TestDataReturnsArgs3] },
    };

    public static TheoryData<ArgsCode, ArgsCode?, object[]> TestDataReturnsToArgs4ArgsTheoryData => new()
    {
        { ArgsCode.Instance, null, [TestDataReturnsArgs4] },
        { ArgsCode.Instance,  ArgsCode.Instance, [TestDataReturnsArgs4] },
        { ArgsCode.Instance,  ArgsCode.Properties, [.. TestDataReturnsArgs0, .. Args4] },
        { ArgsCode.Properties,  null, [.. TestDataReturnsArgs0, .. Args4] },
        { ArgsCode.Properties,  ArgsCode.Properties, [.. TestDataReturnsArgs0, .. Args4] },
        { ArgsCode.Properties,  ArgsCode.Instance, [TestDataReturnsArgs4] },
    };

    public static TheoryData<ArgsCode, ArgsCode?, object[]> TestDataReturnsToArgs5ArgsTheoryData => new()
    {
        { ArgsCode.Instance, null, [TestDataReturnsArgs5] },
        { ArgsCode.Instance,  ArgsCode.Instance, [TestDataReturnsArgs5] },
        { ArgsCode.Instance,  ArgsCode.Properties, [.. TestDataReturnsArgs0, .. Args5] },
        { ArgsCode.Properties,  null, [.. TestDataReturnsArgs0, .. Args5] },
        { ArgsCode.Properties,  ArgsCode.Properties, [.. TestDataReturnsArgs0, .. Args5] },
        { ArgsCode.Properties,  ArgsCode.Instance, [TestDataReturnsArgs5] },
    };

    public static TheoryData<ArgsCode, ArgsCode?, object[]> TestDataReturnsToArgs6ArgsTheoryData => new()
    {
        { ArgsCode.Instance, null, [TestDataReturnsArgs6] },
        { ArgsCode.Instance,  ArgsCode.Instance, [TestDataReturnsArgs6] },
        { ArgsCode.Instance,  ArgsCode.Properties, [.. TestDataReturnsArgs0, .. Args6] },
        { ArgsCode.Properties,  null, [.. TestDataReturnsArgs0, .. Args6] },
        { ArgsCode.Properties,  ArgsCode.Properties, [.. TestDataReturnsArgs0, .. Args6] },
        { ArgsCode.Properties,  ArgsCode.Instance, [TestDataReturnsArgs6] },
    };

    public static TheoryData<ArgsCode, ArgsCode?, object[]> TestDataReturnsToArgs7ArgsTheoryData => new()
    {
        { ArgsCode.Instance, null, [TestDataReturnsArgs7] },
        { ArgsCode.Instance,  ArgsCode.Instance, [TestDataReturnsArgs7] },
        { ArgsCode.Instance,  ArgsCode.Properties, [.. TestDataReturnsArgs0, .. Args7] },
        { ArgsCode.Properties,  null, [.. TestDataReturnsArgs0, .. Args7] },
        { ArgsCode.Properties,  ArgsCode.Properties, [.. TestDataReturnsArgs0, .. Args7] },
        { ArgsCode.Properties,  ArgsCode.Instance, [TestDataReturnsArgs7] },
    };

    public static TheoryData<ArgsCode, ArgsCode?, object[]> TestDataReturnsToArgs8ArgsTheoryData => new()
    {
        { ArgsCode.Instance, null, [TestDataReturnsArgs8] },
        { ArgsCode.Instance,  ArgsCode.Instance, [TestDataReturnsArgs8] },
        { ArgsCode.Instance,  ArgsCode.Properties, [.. TestDataReturnsArgs0, .. Args8] },
        { ArgsCode.Properties,  null, [.. TestDataReturnsArgs0, .. Args8] },
        { ArgsCode.Properties,  ArgsCode.Properties, [.. TestDataReturnsArgs0, .. Args8] },
        { ArgsCode.Properties,  ArgsCode.Instance, [TestDataReturnsArgs8] },
    };

    public static TheoryData<ArgsCode, ArgsCode?, object[]> TestDataReturnsToArgs9ArgsTheoryData => new()
    {
        { ArgsCode.Instance, null, [TestDataReturnsArgs9] },
        { ArgsCode.Instance,  ArgsCode.Instance, [TestDataReturnsArgs9] },
        { ArgsCode.Instance,  ArgsCode.Properties, [.. TestDataReturnsArgs0, .. Args9] },
        { ArgsCode.Properties,  null, [.. TestDataReturnsArgs0, .. Args9] },
        { ArgsCode.Properties,  ArgsCode.Properties, [.. TestDataReturnsArgs0, .. Args9] },
        { ArgsCode.Properties,  ArgsCode.Instance, [TestDataReturnsArgs9] },
    };
    #endregion

    #region TestDataThrowsToArgs data sources
    public static TheoryData<ArgsCode, ArgsCode?, object[]> TestDataThrowsToArgs1ArgsTheoryData => new()
    {
        { ArgsCode.Instance, null, [TestDataThrowsArgs1] },
        { ArgsCode.Instance,  ArgsCode.Instance, [TestDataThrowsArgs1] },
        { ArgsCode.Instance,  ArgsCode.Properties, [.. TestDataThrowsArgs0, Arg1] },
        { ArgsCode.Properties,  null, [.. TestDataThrowsArgs0, Arg1] },
        { ArgsCode.Properties,  ArgsCode.Properties, [.. TestDataThrowsArgs0, Arg1] },
        { ArgsCode.Properties,  ArgsCode.Instance, [TestDataThrowsArgs1] },
    };

    public static TheoryData<ArgsCode, ArgsCode?, object[]> TestDataThrowsToArgs2ArgsTheoryData => new()
    {
        { ArgsCode.Instance, null, [TestDataThrowsArgs2] },
        { ArgsCode.Instance,  ArgsCode.Instance, [TestDataThrowsArgs2] },
        { ArgsCode.Instance,  ArgsCode.Properties, [.. TestDataThrowsArgs0, .. Args2] },
        { ArgsCode.Properties,  null, [.. TestDataThrowsArgs0, .. Args2] },
        { ArgsCode.Properties,  ArgsCode.Properties, [.. TestDataThrowsArgs0, .. Args2] },
        { ArgsCode.Properties,  ArgsCode.Instance, [TestDataThrowsArgs2] },
    };

    public static TheoryData<ArgsCode, ArgsCode?, object[]> TestDataThrowsToArgs3ArgsTheoryData => new()
    {
        { ArgsCode.Instance, null, [TestDataThrowsArgs3] },
        { ArgsCode.Instance,  ArgsCode.Instance, [TestDataThrowsArgs3] },
        { ArgsCode.Instance,  ArgsCode.Properties, [.. TestDataThrowsArgs0, .. Args3] },
        { ArgsCode.Properties,  null, [.. TestDataThrowsArgs0, .. Args3] },
        { ArgsCode.Properties,  ArgsCode.Properties, [.. TestDataThrowsArgs0, .. Args3] },
        { ArgsCode.Properties,  ArgsCode.Instance, [TestDataThrowsArgs3] },
    };

    public static TheoryData<ArgsCode, ArgsCode?, object[]> TestDataThrowsToArgs4ArgsTheoryData => new()
    {
        { ArgsCode.Instance, null, [TestDataThrowsArgs4] },
        { ArgsCode.Instance,  ArgsCode.Instance, [TestDataThrowsArgs4] },
        { ArgsCode.Instance,  ArgsCode.Properties, [.. TestDataThrowsArgs0, .. Args4] },
        { ArgsCode.Properties,  null, [.. TestDataThrowsArgs0, .. Args4] },
        { ArgsCode.Properties,  ArgsCode.Properties, [.. TestDataThrowsArgs0, .. Args4] },
        { ArgsCode.Properties,  ArgsCode.Instance, [TestDataThrowsArgs4] },
    };

    public static TheoryData<ArgsCode, ArgsCode?, object[]> TestDataThrowsToArgs5ArgsTheoryData => new()
    {
        { ArgsCode.Instance, null, [TestDataThrowsArgs5] },
        { ArgsCode.Instance,  ArgsCode.Instance, [TestDataThrowsArgs5] },
        { ArgsCode.Instance,  ArgsCode.Properties, [.. TestDataThrowsArgs0, .. Args5] },
        { ArgsCode.Properties,  null, [.. TestDataThrowsArgs0, .. Args5] },
        { ArgsCode.Properties,  ArgsCode.Properties, [.. TestDataThrowsArgs0, .. Args5] },
        { ArgsCode.Properties,  ArgsCode.Instance, [TestDataThrowsArgs5] },
    };

    public static TheoryData<ArgsCode, ArgsCode?, object[]> TestDataThrowsToArgs6ArgsTheoryData => new()
    {
        { ArgsCode.Instance, null, [TestDataThrowsArgs6] },
        { ArgsCode.Instance,  ArgsCode.Instance, [TestDataThrowsArgs6] },
        { ArgsCode.Instance,  ArgsCode.Properties, [.. TestDataThrowsArgs0, .. Args6] },
        { ArgsCode.Properties,  null, [.. TestDataThrowsArgs0, .. Args6] },
        { ArgsCode.Properties,  ArgsCode.Properties, [.. TestDataThrowsArgs0, .. Args6] },
        { ArgsCode.Properties,  ArgsCode.Instance, [TestDataThrowsArgs6] },
    };

    public static TheoryData<ArgsCode, ArgsCode?, object[]> TestDataThrowsToArgs7ArgsTheoryData => new()
    {
        { ArgsCode.Instance, null, [TestDataThrowsArgs7] },
        { ArgsCode.Instance,  ArgsCode.Instance, [TestDataThrowsArgs7] },
        { ArgsCode.Instance,  ArgsCode.Properties, [.. TestDataThrowsArgs0, .. Args7] },
        { ArgsCode.Properties,  null, [.. TestDataThrowsArgs0, .. Args7] },
        { ArgsCode.Properties,  ArgsCode.Properties, [.. TestDataThrowsArgs0, .. Args7] },
        { ArgsCode.Properties,  ArgsCode.Instance, [TestDataThrowsArgs7] },
    };

    public static TheoryData<ArgsCode, ArgsCode?, object[]> TestDataThrowsToArgs8ArgsTheoryData => new()
    {
        { ArgsCode.Instance, null, [TestDataThrowsArgs8] },
        { ArgsCode.Instance,  ArgsCode.Instance, [TestDataThrowsArgs8] },
        { ArgsCode.Instance,  ArgsCode.Properties, [.. TestDataThrowsArgs0, .. Args8] },
        { ArgsCode.Properties,  null, [.. TestDataThrowsArgs0, .. Args8] },
        { ArgsCode.Properties,  ArgsCode.Properties, [.. TestDataThrowsArgs0, .. Args8] },
        { ArgsCode.Properties,  ArgsCode.Instance, [TestDataThrowsArgs8] },
    };

    public static TheoryData<ArgsCode, ArgsCode?, object[]> TestDataThrowsToArgs9ArgsTheoryData => new()
    {
        { ArgsCode.Instance, null, [TestDataThrowsArgs9] },
        { ArgsCode.Instance,  ArgsCode.Instance, [TestDataThrowsArgs9] },
        { ArgsCode.Instance,  ArgsCode.Properties, [.. TestDataThrowsArgs0, .. Args9] },
        { ArgsCode.Properties,  null, [.. TestDataThrowsArgs0, .. Args9] },
        { ArgsCode.Properties,  ArgsCode.Properties, [.. TestDataThrowsArgs0, .. Args9] },
        { ArgsCode.Properties,  ArgsCode.Instance, [TestDataThrowsArgs9] },
    };
    #endregion
}
