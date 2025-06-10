// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.xUnit.Attributes;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public class MemberTestDataAttribute(string memberName, params object[] parameters)
: MemberDataAttributeBase(memberName, parameters)
{
    protected override object[] ConvertDataItem(
        MethodInfo testMethod,
        object item)
    {
        if (item is ITestDataXunitRow xunitRow)
        {
            return xunitRow.Convert() as object[];
        }

        return item switch
        {
            null => null!,
            object[] args => args,
            _ => throw new ArgumentException(
                $"{MemberName} member of {testMethod.DeclaringType} " +
                "yielded an item that is not an 'object[]'"),
        };
    }
}
