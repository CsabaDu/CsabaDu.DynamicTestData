﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsabaDu.DynamicTestData.xUnit.Statics;

internal static class Common
{
    internal static bool IsExpected(ITestData testData)
    => testData is IExpected;
}
