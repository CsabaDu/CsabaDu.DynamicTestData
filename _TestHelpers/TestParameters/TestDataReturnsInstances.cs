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

public class TestDataReturnsInstances
{
    /// <summary>
    /// Test data returns arguments with one additional argument.
    /// </summary>
    public static readonly TestDataReturns<DummyEnum, int> TestDataReturnsArgs1
        = new(ActualDefinition, DummyEnumTestValue, Arg1);

    /// <summary>
    /// Test data returns arguments with two additional arguments.
    /// </summary>
    public static readonly TestDataReturns<DummyEnum, int, object> TestDataReturnsArgs2
        = new(ActualDefinition, DummyEnumTestValue, Arg1, Arg2);

    /// <summary>
    /// Test data returns arguments with three additional arguments.
    /// </summary>
    public static readonly TestDataReturns<DummyEnum, int, object, DateTime> TestDataReturnsArgs3
        = new(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3);

    /// <summary>
    /// Test data returns arguments with four additional arguments.
    /// </summary>
    public static readonly TestDataReturns<DummyEnum, int, object, DateTime, string> TestDataReturnsArgs4
        = new(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4);

    /// <summary>
    /// Test data returns arguments with five additional arguments.
    /// </summary>
    public static readonly TestDataReturns<DummyEnum, int, object, DateTime, string, double> TestDataReturnsArgs5
        = new(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5);

    /// <summary>
    /// Test data returns arguments with six additional arguments.
    /// </summary>
    public static readonly TestDataReturns<DummyEnum, int, object, DateTime, string, double, bool> TestDataReturnsArgs6
        = new(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6);

    /// <summary>
    /// Test data returns arguments with seven additional arguments.
    /// </summary>
    public static readonly TestDataReturns<DummyEnum, int, object, DateTime, string, double, bool, char> TestDataReturnsArgs7
        = new(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7);

    /// <summary>
    /// Test data returns arguments with eight additional arguments.
    /// </summary>
    public static readonly TestDataReturns<DummyEnum, int, object, DateTime, string, double, bool, char, DummyClass> TestDataReturnsArgs8
        = new(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8);

    /// <summary>
    /// Test data returns arguments with nine additional arguments.
    /// </summary>
    public static readonly TestDataReturns<DummyEnum, int, object, DateTime, string, double, bool, char, DummyClass, object[]> TestDataReturnsArgs9
        = new(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9);
}
