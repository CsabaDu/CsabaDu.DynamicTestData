namespace CsabaDu.DynamicTestData.TestDataTypes;

internal interface ITestData
{
    string TestCase { get; }
    string Result { get; }

    object?[] ToArgs(ArgsCode argsCode);
}

internal interface ITestData<String> : ITestData;
