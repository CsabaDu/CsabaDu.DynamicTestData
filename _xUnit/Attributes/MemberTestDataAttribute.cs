// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

using System.Reflection;

namespace CsabaDu.DynamicTestData.xUnit.Attributes;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public class MemberTestDataAttribute
: MemberDataAttributeBase
{
    public MemberTestDataAttribute(string memberName, ArgsCode argsCode)
    : base(memberName, null)
    {
        _argsCode = argsCode.Defined(nameof(ArgsCode));
    }

    public MemberTestDataAttribute(string memberName)
    : this(memberName, default)
    {
    }

    private readonly ArgsCode _argsCode;

    protected override object[] ConvertDataItem(
        MethodInfo testMethod,
        object item)
    {
        if (item is null) return null!;

        if (item is ITestData testData)
        {
            return testData.ToParams(
                _argsCode,
                testData is IExpected)!;
        }

        return item is object[] objectArray ?
            objectArray
            : throw new ArgumentException(
                $"{MemberName} member of " +
                $"{testMethod.DeclaringType} " +
                $"yielded an item that is not an object[]");
    }
}
