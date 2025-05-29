// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.TestHelpers.TestParameters;

public class TypeArrays
{
    public static readonly Type[] Args1Types = [typeof(int)];
    public static readonly Type[] Args2Types = [.. Args1Types, typeof(object)];
    public static readonly Type[] Args3Types = [.. Args2Types, typeof(DateTime)];
    public static readonly Type[] Args4Types = [.. Args3Types, typeof(string)];
    public static readonly Type[] Args5Types = [.. Args4Types, typeof(double)];
    public static readonly Type[] Args6Types = [.. Args5Types, typeof(bool)];
    public static readonly Type[] Args7Types = [.. Args6Types, typeof(char)];
    public static readonly Type[] Args8Types = [.. Args7Types, typeof(DummyClass)];
    public static readonly Type[] Args9Types = [.. Args8Types, typeof(object[])];

    public static Type[] GetTypes(Type expectedType, Type[] types)
    => [expectedType, .. types];

    public static Type[] GetReturnsTypes(Type[] types)
    => GetTypes(typeof(DummyEnum), types);

    public static Type[]GetThrowsTypes(Type[] types)
    => GetTypes(typeof(DummyException), types);
}
