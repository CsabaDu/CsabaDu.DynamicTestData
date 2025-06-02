// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.xUnit.Attributes;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public class MemberTestDataAttribute(string memberName)
: MemberDataAttributeBase(memberName, null)
{
    protected override object[] ConvertDataItem(
        MethodInfo testMethod,
        object item)
    {
        if (item is null) return null!;

        if (item is ITestDataRow testDataRow)
        {
            return testDataRow.GetParameters()!;
        }

        return item is object[] objectArray ?
            objectArray
            : throw new ArgumentException(
                $"{MemberName} member of " +
                $"{testMethod.DeclaringType} " +
                $"yielded an item that is not an object[]");
    }
}
