namespace CsabaDu.DynamicTestData.Tests.DynamicDataSources;

public class TestDataThrowsTestsDataSource
{
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
}
