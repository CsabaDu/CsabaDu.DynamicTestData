namespace CsabaDu.DynamicTestData.Tests.DynamicDataSources;

public class TestDataReturnsTestsDataSource
{
    private static readonly TestDataReturns<DummyEnum, int> TestDataReturnsArgs1
        = new(ActualDefinition, DummyEnumTestValue, Arg1);

    private static readonly TestDataReturns<DummyEnum, int, object> TestDataReturnsArgs2
        = new(ActualDefinition, DummyEnumTestValue, Arg1, Arg2);

    private static readonly TestDataReturns<DummyEnum, int, object, DateTime> TestDataReturnsArgs3
        = new(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3);

    private static readonly TestDataReturns<DummyEnum, int, object, DateTime, string> TestDataReturnsArgs4 
        = new(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4);

    private static readonly TestDataReturns<DummyEnum, int, object, DateTime, string, double> TestDataReturnsArgs5
        = new(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5);

    private static readonly TestDataReturns<DummyEnum, int, object, DateTime, string, double, bool> TestDataReturnsArgs6
        = new(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6);

    private static readonly TestDataReturns<DummyEnum, int, object, DateTime, string, double, bool, char> TestDataReturnsArgs7
        = new(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7);

    private static readonly TestDataReturns<DummyEnum, int, object, DateTime, string, double, bool, char, DummyClass> TestDataReturnsArgs8
        = new(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8);

    private static readonly TestDataReturns<DummyEnum, int, object, DateTime, string, double, bool, char, DummyClass, object[]> TestDataReturnsArgs9
        = new(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9);

    public static TheoryData<ValueType, string> ReturnsArgsList => new()
    {
        { new DummyStruct(), string.Empty },
        { DummyEnumTestValue, Enum.GetName(DummyEnumTestValue) },
    };

    public static TheoryData<ArgsCode, ITestDataReturns<DummyEnum>, object[]> ToArgsArgsList => new()
    {
        #region ArgsCode.Properties
        { ArgsCode.Properties, TestDataReturnsArgs1, [DummyEnumTestValue, .. Args1] },
        { ArgsCode.Properties, TestDataReturnsArgs2, [DummyEnumTestValue, .. Args2] },
        { ArgsCode.Properties, TestDataReturnsArgs3, [DummyEnumTestValue, .. Args3] },
        { ArgsCode.Properties, TestDataReturnsArgs4, [DummyEnumTestValue, .. Args4] },
        { ArgsCode.Properties, TestDataReturnsArgs5, [DummyEnumTestValue, .. Args5] },
        { ArgsCode.Properties, TestDataReturnsArgs6, [DummyEnumTestValue, .. Args6] },
        { ArgsCode.Properties, TestDataReturnsArgs7, [DummyEnumTestValue, .. Args7] },
        { ArgsCode.Properties, TestDataReturnsArgs8, [DummyEnumTestValue, .. Args8] },
        { ArgsCode.Properties, TestDataReturnsArgs9, [DummyEnumTestValue, .. Args9] },
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
