namespace CsabaDu.DynamicTestData.Tests;

internal sealed class Params
{
    public static readonly string ActualDefinition = "Test Definition";
    public static readonly string ExpectedString = "Test Expected";
    public static readonly string ActualResult = "Test Result";
    public static readonly string ActualExitMode = "Test Exit Mode";
    public const string Definiton = nameof(TestData.Definition);
    public const string Result = nameof(TestData.Result);
    public static readonly string NotNullProperty = "Test Property";

    public const int Arg1 = 1;
    public const object Arg2 = null;
    public static readonly DateTime Arg3 = DateTime.MinValue;
    public const string Arg4 = "Test";
    public const double Arg5 = double.MinValue;
    public const bool Arg6 = true;
    public const char Arg7 = 'a';
    public const float Arg8 = float.Tau;
    public static readonly object[] Arg9 = [];

    public static readonly TestDataChild TestData = new(ActualDefinition, ActualResult, ActualExitMode);

}
