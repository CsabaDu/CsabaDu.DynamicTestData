namespace CsabaDu.DynamicTestData.Tests.DynamicDataSources;

public class TestDataReturnsTestsDataSource
{
    private static readonly TestDataReturns<DummyEnum, int> TestDataReturnsArgs1
        = new(Params.ActualDefinition, DummyEnum.TestValue, Params.Arg1);

    private static readonly TestDataReturns<DummyEnum, int, object> TestDataReturnsArgs2
        = new(Params.ActualDefinition, DummyEnum.TestValue, Params.Arg1, Params.Arg2);

    private static readonly TestDataReturns<DummyEnum, int, object, DateTime> TestDataReturnsArgs3
        = new(Params.ActualDefinition, DummyEnum.TestValue, Params.Arg1, Params.Arg2, Params.Arg3);

    private static readonly TestDataReturns<DummyEnum, int, object, DateTime, string> TestDataReturnsArgs4 
        = new(Params.ActualDefinition, DummyEnum.TestValue, Params.Arg1, Params.Arg2, Params.Arg3, Params.Arg4);

    private static readonly TestDataReturns<DummyEnum, int, object, DateTime, string, double> TestDataReturnsArgs5
        = new(Params.ActualDefinition, DummyEnum.TestValue, Params.Arg1, Params.Arg2, Params.Arg3, Params.Arg4, Params.Arg5);

    private static readonly TestDataReturns<DummyEnum, int, object, DateTime, string, double, bool> TestDataReturnsArgs6
        = new(Params.ActualDefinition, DummyEnum.TestValue, Params.Arg1, Params.Arg2, Params.Arg3, Params.Arg4, Params.Arg5, Params.Arg6);

    private static readonly TestDataReturns<DummyEnum, int, object, DateTime, string, double, bool, char> TestDataReturnsArgs7
        = new(Params.ActualDefinition, DummyEnum.TestValue, Params.Arg1, Params.Arg2, Params.Arg3, Params.Arg4, Params.Arg5, Params.Arg6, Params.Arg7);

    private static readonly TestDataReturns<DummyEnum, int, object, DateTime, string, double, bool, char, DummyClass> TestDataReturnsArgs8
        = new(Params.ActualDefinition, DummyEnum.TestValue, Params.Arg1, Params.Arg2, Params.Arg3, Params.Arg4, Params.Arg5, Params.Arg6, Params.Arg7, Params.Arg8);

    private static readonly TestDataReturns<DummyEnum, int, object, DateTime, string, double, bool, char, DummyClass, object[]> TestDataReturnsArgs9
        = new(Params.ActualDefinition, DummyEnum.TestValue, Params.Arg1, Params.Arg2, Params.Arg3, Params.Arg4, Params.Arg5, Params.Arg6, Params.Arg7, Params.Arg8, Params.Arg9);

    public static TheoryData<ValueType, string> ReturnsArgsList => new()
    {
        { new DummyStruct(), string.Empty },
        { DummyEnum.TestValue, Enum.GetName(DummyEnum.TestValue) },
    };

    public static TheoryData<ArgsCode, ITestDataReturns<DummyEnum>, object[]> ToArgsArgsList => new()
    {
        #region ArgsCode.Properties
        { ArgsCode.Properties, TestDataReturnsArgs1, [DummyEnum.TestValue, .. Params.Args1] },
        { ArgsCode.Properties, TestDataReturnsArgs2, [DummyEnum.TestValue, .. Params.Args2] },
        { ArgsCode.Properties, TestDataReturnsArgs3, [DummyEnum.TestValue, .. Params.Args3] },
        { ArgsCode.Properties, TestDataReturnsArgs4, [DummyEnum.TestValue, .. Params.Args4] },
        { ArgsCode.Properties, TestDataReturnsArgs5, [DummyEnum.TestValue, .. Params.Args5] },
        { ArgsCode.Properties, TestDataReturnsArgs6, [DummyEnum.TestValue, .. Params.Args6] },
        { ArgsCode.Properties, TestDataReturnsArgs7, [DummyEnum.TestValue, .. Params.Args7] },
        { ArgsCode.Properties, TestDataReturnsArgs8, [DummyEnum.TestValue, .. Params.Args8] },
        { ArgsCode.Properties, TestDataReturnsArgs9, [DummyEnum.TestValue, .. Params.Args9] },
        #endregion

        #region ArgsCode.Instance
        { ArgsCode.Instance, TestDataReturnsArgs1, [TestDataReturnsArgs1] },
        { ArgsCode.Instance, TestDataReturnsArgs2, [TestDataReturnsArgs2] },
        { ArgsCode.Instance, TestDataReturnsArgs3, [TestDataReturnsArgs3] },
        { ArgsCode.Instance, TestDataReturnsArgs4, [TestDataReturnsArgs4] },
        { ArgsCode.Instance, TestDataReturnsArgs5, [TestDataReturnsArgs5] },
        { ArgsCode.Instance, TestDataReturnsArgs6, [TestDataReturnsArgs6] },
        { ArgsCode.Instance, TestDataReturnsArgs7, [TestDataReturnsArgs7] },
        { ArgsCode.Instance, TestDataReturnsArgs8, [TestDataReturnsArgs8] },
        { ArgsCode.Instance, TestDataReturnsArgs9, [TestDataReturnsArgs9] },
        #endregion
    };

}
