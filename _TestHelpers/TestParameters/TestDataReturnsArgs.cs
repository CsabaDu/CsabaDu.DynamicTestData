namespace CsabaDu.DynamicTestData.TestHelpers.TestParameters;

public class TestDataReturnsArgs
{
    /// <summary>
    /// Test data returns arguments with one additional argument.
    /// </summary>
    public static readonly TestDataReturns<DummyEnum, int> TestDataReturnsArgs1
        = new(ActualDefinition, DummyEnumTestValue, Arg1);

    /// <summary>
    /// Test data returns arguments with two additional arguments.
    /// </summary>
    public static readonly TestDataReturns<DummyEnum, int, object> TestDataReturnsArgs2
        = new(ActualDefinition, DummyEnumTestValue, Arg1, Arg2);

    /// <summary>
    /// Test data returns arguments with three additional arguments.
    /// </summary>
    public static readonly TestDataReturns<DummyEnum, int, object, DateTime> TestDataReturnsArgs3
        = new(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3);

    /// <summary>
    /// Test data returns arguments with four additional arguments.
    /// </summary>
    public static readonly TestDataReturns<DummyEnum, int, object, DateTime, string> TestDataReturnsArgs4
        = new(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4);

    /// <summary>
    /// Test data returns arguments with five additional arguments.
    /// </summary>
    public static readonly TestDataReturns<DummyEnum, int, object, DateTime, string, double> TestDataReturnsArgs5
        = new(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5);

    /// <summary>
    /// Test data returns arguments with six additional arguments.
    /// </summary>
    public static readonly TestDataReturns<DummyEnum, int, object, DateTime, string, double, bool> TestDataReturnsArgs6
        = new(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6);

    /// <summary>
    /// Test data returns arguments with seven additional arguments.
    /// </summary>
    public static readonly TestDataReturns<DummyEnum, int, object, DateTime, string, double, bool, char> TestDataReturnsArgs7
        = new(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7);

    /// <summary>
    /// Test data returns arguments with eight additional arguments.
    /// </summary>
    public static readonly TestDataReturns<DummyEnum, int, object, DateTime, string, double, bool, char, DummyClass> TestDataReturnsArgs8
        = new(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8);

    /// <summary>
    /// Test data returns arguments with nine additional arguments.
    /// </summary>
    public static readonly TestDataReturns<DummyEnum, int, object, DateTime, string, double, bool, char, DummyClass, object[]> TestDataReturnsArgs9
        = new(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9);
}
