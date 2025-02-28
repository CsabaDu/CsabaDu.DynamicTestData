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

public class ArgsArrays
{
    /// <summary>
    /// A static readonly array of objects used in tests, initialized with Arg1.
    /// </summary>
    public static readonly object[] Args1 = [Arg1];

    /// <summary>
    /// A static readonly array of objects used in tests, initialized with Arg1 and Arg2.
    /// </summary>
    public static readonly object[] Args2 = [Arg1, Arg2];

    /// <summary>
    /// A static readonly array of objects used in tests, initialized with Arg1, Arg2, and Arg3.
    /// </summary>
    public static readonly object[] Args3 = [.. Args2, Arg3];

    /// <summary>
    /// A static readonly array of objects used in tests, initialized with Arg1, Arg2, Arg3, and Arg4.
    /// </summary>
    public static readonly object[] Args4 = [.. Args3, Arg4];

    /// <summary>
    /// A static readonly array of objects used in tests, initialized with Arg1, Arg2, Arg3, Arg4, and Arg5.
    /// </summary>
    public static readonly object[] Args5 = [.. Args4, Arg5];

    /// <summary>
    /// A static readonly array of objects used in tests, initialized with Arg1, Arg2, Arg3, Arg4, Arg5, and Arg6.
    /// </summary>
    public static readonly object[] Args6 = [.. Args5, Arg6];

    /// <summary>
    /// A static readonly array of objects used in tests, initialized with Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, and Arg7.
    /// </summary>
    public static readonly object[] Args7 = [.. Args6, Arg7];

    /// <summary>
    /// A static readonly array of objects used in tests, initialized with Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, and Arg8.
    /// </summary>
    public static readonly object[] Args8 = [.. Args7, Arg8];

    /// <summary>
    /// A static readonly array of objects used in tests, initialized with Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, and Arg9.
    /// </summary>
    public static readonly object[] Args9 = [.. Args8, Arg9];

}
