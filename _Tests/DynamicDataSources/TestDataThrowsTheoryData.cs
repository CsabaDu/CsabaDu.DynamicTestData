﻿namespace CsabaDu.DynamicTestData.Tests.DynamicDataSources;

public class TestDataThrowsTheoryData
{
    private static readonly object[] Args0
        = [Params.TestDataThrowsChild.TestCase, Parameter, ErrorMessage, typeof(DummyException)];

    private static readonly TestDataThrows<DummyException, int> TestDataThrowsArgs1
        = new(ActualDefinition, Parameter, ErrorMessage, Arg1);

    private static readonly TestDataThrows<DummyException, int, object> TestDataThrowsArgs2
        = new(ActualDefinition, Parameter, ErrorMessage, Arg1, Arg2);

    private static readonly TestDataThrows<DummyException, int, object, DateTime> TestDataThrowsArgs3
        = new(ActualDefinition, Parameter, ErrorMessage, Arg1, Arg2, Arg3);

    private static readonly TestDataThrows<DummyException, int, object, DateTime, string> TestDataThrowsArgs4
        = new(ActualDefinition, Parameter, ErrorMessage, Arg1, Arg2, Arg3, Arg4);

    private static readonly TestDataThrows<DummyException, int, object, DateTime, string, double> TestDataThrowsArgs5
        = new(ActualDefinition, Parameter, ErrorMessage, Arg1, Arg2, Arg3, Arg4, Arg5);

    private static readonly TestDataThrows<DummyException, int, object, DateTime, string, double, bool> TestDataThrowsArgs6
        = new(ActualDefinition, Parameter, ErrorMessage, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6);

    private static readonly TestDataThrows<DummyException, int, object, DateTime, string, double, bool, char> TestDataThrowsArgs7
        = new(ActualDefinition, Parameter, ErrorMessage, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7);

    private static readonly TestDataThrows<DummyException, int, object, DateTime, string, double, bool, char, DummyClass> TestDataThrowsArgs8
        = new(ActualDefinition, Parameter, ErrorMessage, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8);

    private static readonly TestDataThrows<DummyException, int, object, DateTime, string, double, bool, char, DummyClass, object[]> TestDataThrowsArgs9
        = new(ActualDefinition, Parameter, ErrorMessage, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9);

    public static TheoryData<ArgsCode, ITestDataThrows<DummyException>, object[]> ToArgsTheoryData => new()
    {
        #region ArgsCode.Properties
        { ArgsCode.Properties, TestDataThrowsArgs1, [.. Args0, .. Args1] },
        { ArgsCode.Properties, TestDataThrowsArgs2, [.. Args0, .. Args2] },
        { ArgsCode.Properties, TestDataThrowsArgs3, [.. Args0, .. Args3] },
        { ArgsCode.Properties, TestDataThrowsArgs4, [.. Args0, .. Args4] },
        { ArgsCode.Properties, TestDataThrowsArgs5, [.. Args0, .. Args5] },
        { ArgsCode.Properties, TestDataThrowsArgs6, [.. Args0, .. Args6] },
        { ArgsCode.Properties, TestDataThrowsArgs7, [.. Args0, .. Args7] },
        { ArgsCode.Properties, TestDataThrowsArgs8, [.. Args0, .. Args8] },
        { ArgsCode.Properties, TestDataThrowsArgs9, [.. Args0, .. Args9] },
        #endregion

        #region ArgsCode.Instance
        { ArgsCode.Instance, TestDataThrowsArgs1, [TestDataThrowsArgs1] },
        { ArgsCode.Instance, TestDataThrowsArgs2, [TestDataThrowsArgs2] },
        { ArgsCode.Instance, TestDataThrowsArgs3, [TestDataThrowsArgs3] },
        { ArgsCode.Instance, TestDataThrowsArgs4, [TestDataThrowsArgs4] },
        { ArgsCode.Instance, TestDataThrowsArgs5, [TestDataThrowsArgs5] },
        { ArgsCode.Instance, TestDataThrowsArgs6, [TestDataThrowsArgs6] },
        { ArgsCode.Instance, TestDataThrowsArgs7, [TestDataThrowsArgs7] },
        { ArgsCode.Instance, TestDataThrowsArgs8, [TestDataThrowsArgs8] },
        { ArgsCode.Instance, TestDataThrowsArgs9, [TestDataThrowsArgs9] },
        #endregion
    };
}
