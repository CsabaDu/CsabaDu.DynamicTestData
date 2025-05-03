// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

using Xunit;

namespace CsabaDu.DynamicTestData.TestHelpers.TestParameters;

public class SharedTheoryData
{
    public static TheoryData<ArgsCode> ArgsCodeTheoryData => new()
    {
        { ArgsCode.Instance },
        { ArgsCode.Properties },
    };

    public static TheoryData<ArgsCode?> OptionalArgsCodeTheoryData
    {
        get
        {
            TheoryData<ArgsCode?> theoryData = [null];

            foreach (ArgsCode item in ArgsCodeTheoryData)
            {
                theoryData.Add(item);
            }

            return theoryData;
        }
    }
}
