// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

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
