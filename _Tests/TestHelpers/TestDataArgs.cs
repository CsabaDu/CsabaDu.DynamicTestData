namespace CsabaDu.DynamicTestData.Tests.TestHelpers;

public class TestDataArgs
{
    public static readonly TestData<int> TestDataArgs1
        = new(ActualDefinition, ExpectedString, Arg1);

    public static readonly TestData<int, object> TestDataArgs2
        = new(ActualDefinition, ExpectedString, Arg1, Arg2);

    public static readonly TestData<int, object, DateTime> TestDataArgs3
        = new(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3);

    public static readonly TestData<int, object, DateTime, string> TestDataArgs4
        = new(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4);

    public static readonly TestData<int, object, DateTime, string, double> TestDataArgs5
        = new(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5);

    public static readonly TestData<int, object, DateTime, string, double, bool> TestDataArgs6
        = new(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6);

    public static readonly TestData<int, object, DateTime, string, double, bool, char> TestDataArgs7
        = new(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7);

    public static readonly TestData<int, object, DateTime, string, double, bool, char, DummyClass> TestDataArgs8
        = new(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8);

    public static readonly TestData<int, object, DateTime, string, double, bool, char, DummyClass, object[]> TestDataArgs9
        = new(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9);
}
