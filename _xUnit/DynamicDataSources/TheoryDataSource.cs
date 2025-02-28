namespace CsabaDu.DynamicTestData.xUnit.DynamicDataSources;

public class TheoryDataSource(ArgsCode argsCode) : DynamicDataSource(argsCode)
{
    protected TheoryData? TheoryData { get; set; }

    public void AddTestDataToTheoryData<T1>(string definition, string expected, T1? arg1)
    {
        TheoryData ??= ArgsCode switch
        {
            ArgsCode.Instance => new TheoryData<TestData<T1?>>(),
            ArgsCode.Properties => new TheoryData<T1?>(),
            _ => default,
        };

        if (ArgsCode == ArgsCode.Instance)
        {
            (TheoryData as TheoryData<TestData<T1?>>)!.Add(new TestData<T1?>(definition, expected, arg1));
        }
        else
        {
            (TheoryData as TheoryData<T1?>)!.Add(arg1);
        }
    }

    public void AddTestDataToTheoryData<T1, T2>(string definition, string expected, T1? arg1, T2? arg2)
    {
        TheoryData ??= ArgsCode switch
        {
            ArgsCode.Instance => new TheoryData<TestData<T1?, T2?>>(),
            ArgsCode.Properties => new TheoryData<T1?, T2?>(),
            _ => default,
        };

        if (ArgsCode == ArgsCode.Instance)
        {
            (TheoryData as TheoryData<TestData<T1?, T2?>>)!.Add(new TestData<T1?, T2?>(definition, expected, arg1, arg2));
        }
        else
        {
            (TheoryData as TheoryData<T1?, T2?>)!.Add(arg1, arg2);
        }
    }
}
