namespace CsabaDu.DynamicTestData.TestHelpers.TestParameters;

public class TestDataInstances
{
    /// <summary>
    /// Test data instance with one argument.
    /// </summary>
    public static readonly TestData<int> TestDataArgs1
        = new(ActualDefinition, ExpectedString, Arg1);

    /// <summary>
    /// Test data instance with two arguments.
    /// </summary>
    public static readonly TestData<int, object> TestDataArgs2
        = new(ActualDefinition, ExpectedString, Arg1, Arg2);

    /// <summary>
    /// Test data instance with three arguments.
    /// </summary>
    public static readonly TestData<int, object, DateTime> TestDataArgs3
        = new(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3);

    /// <summary>
    /// Test data instance with four arguments.
    /// </summary>
    public static readonly TestData<int, object, DateTime, string> TestDataArgs4
        = new(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4);

    /// <summary>
    /// Test data instance with five arguments.
    /// </summary>
    public static readonly TestData<int, object, DateTime, string, double> TestDataArgs5
        = new(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5);

    /// <summary>
    /// Test data instance with six arguments.
    /// </summary>
    public static readonly TestData<int, object, DateTime, string, double, bool> TestDataArgs6
        = new(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6);

    /// <summary>
    /// Test data instance with seven arguments.
    /// </summary>
    public static readonly TestData<int, object, DateTime, string, double, bool, char> TestDataArgs7
        = new(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7);

    /// <summary>
    /// Test data instance with eight arguments.
    /// </summary>
    public static readonly TestData<int, object, DateTime, string, double, bool, char, DummyClass> TestDataArgs8
        = new(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8);

    /// <summary>
    /// Test data instance with nine arguments.
    /// </summary>
    public static readonly TestData<int, object, DateTime, string, double, bool, char, DummyClass, object[]> TestDataArgs9
        = new(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9);
}
