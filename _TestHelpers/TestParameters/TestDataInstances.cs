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

public class TestDataInstances
{
    /// <summary>
    /// Test data instance with one argument.
    /// </summary>
    public static readonly TestData<int> TestDataArgs1
        = new(ActualDefinition, ExpectedString, Arg1);

    /// <summary>
    /// Test data instance with two arguments.
    /// </summary>
    public static readonly TestData<int, object> TestDataArgs2
        = new(ActualDefinition, ExpectedString, Arg1, Arg2);

    /// <summary>
    /// Test data instance with three arguments.
    /// </summary>
    public static readonly TestData<int, object, DateTime> TestDataArgs3
        = new(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3);

    /// <summary>
    /// Test data instance with four arguments.
    /// </summary>
    public static readonly TestData<int, object, DateTime, string> TestDataArgs4
        = new(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4);

    /// <summary>
    /// Test data instance with five arguments.
    /// </summary>
    public static readonly TestData<int, object, DateTime, string, double> TestDataArgs5
        = new(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5);

    /// <summary>
    /// Test data instance with six arguments.
    /// </summary>
    public static readonly TestData<int, object, DateTime, string, double, bool> TestDataArgs6
        = new(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6);

    /// <summary>
    /// Test data instance with seven arguments.
    /// </summary>
    public static readonly TestData<int, object, DateTime, string, double, bool, char> TestDataArgs7
        = new(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7);

    /// <summary>
    /// Test data instance with eight arguments.
    /// </summary>
    public static readonly TestData<int, object, DateTime, string, double, bool, char, DummyClass> TestDataArgs8
        = new(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8);

    /// <summary>
    /// Test data instance with nine arguments.
    /// </summary>
    public static readonly TestData<int, object, DateTime, string, double, bool, char, DummyClass, object[]> TestDataArgs9
        = new(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9);
}
