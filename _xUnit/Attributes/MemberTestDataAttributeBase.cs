// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.xUnit.Attributes;

public abstract class MemberTestDataAttributeBase(
    string memberName,
    params object[] parameters)
: MemberDataAttributeBase(
    memberName,
    parameters)
{
    protected override object[] ConvertDataItem(
        MethodInfo testMethod,
        object item)
    {
        if (item is ITestDataRow<object?[]> testDataRow)
        {
            return testDataRow.Convert()!;
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
