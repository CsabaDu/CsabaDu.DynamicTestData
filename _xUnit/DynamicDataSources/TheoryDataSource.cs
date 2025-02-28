namespace CsabaDu.DynamicTestData.xUnit.DynamicDataSources;

public abstract class TheoryDataSource(ArgsCode argsCode) : DynamicDataSource(argsCode)
{
    protected TheoryData? TheoryData { get; set; }

    #region AddTestDataToTheoryData
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
            TestData<T1?> testData = new(definition, expected, arg1);
            (TheoryData as TheoryData<TestData<T1?>>)!.Add(testData);
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
            TestData<T1?, T2?> testData = new(definition, expected, arg1, arg2);
            (TheoryData as TheoryData<TestData<T1?, T2?>>)!.Add(testData);
        }
        else
        {
            (TheoryData as TheoryData<T1?, T2?>)!.Add(arg1, arg2);
        }
    }

    public void AddTestDataToTheoryData<T1, T2, T3>(string definition, string expected, T1? arg1, T2? arg2, T3? arg3)
    {
        TheoryData ??= ArgsCode switch
        {
            ArgsCode.Instance => new TheoryData<TestData<T1?, T2?, T3?>>(),
            ArgsCode.Properties => new TheoryData<T1?, T2?, T3?>(),
            _ => default,
        };

        if (ArgsCode == ArgsCode.Instance)
        {
            TestData<T1?, T2?, T3?> testData = new(definition, expected, arg1, arg2, arg3);
            (TheoryData as TheoryData<TestData<T1?, T2?, T3?>>)!.Add(testData);
        }
        else
        {
            (TheoryData as TheoryData<T1?, T2?, T3?>)!.Add(arg1, arg2, arg3);
        }
    }

    public void AddTestDataToTheoryData<T1, T2, T3, T4>(string definition, string expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4)
    {
        TheoryData ??= ArgsCode switch
        {
            ArgsCode.Instance => new TheoryData<TestData<T1?, T2?, T3?, T4?>>(),
            ArgsCode.Properties => new TheoryData<T1?, T2?, T3?, T4?>(),
            _ => default,
        };
        if (ArgsCode == ArgsCode.Instance)
        {
            TestData<T1?, T2?, T3?, T4?> testData = new(definition, expected, arg1, arg2, arg3, arg4);
            (TheoryData as TheoryData<TestData<T1?, T2?, T3?, T4?>>)!.Add(testData);
        }
        else
        {
            (TheoryData as TheoryData<T1?, T2?, T3?, T4?>)!.Add(arg1, arg2, arg3, arg4);
        }
    }

    public void AddTestDataToTheoryData<T1, T2, T3, T4, T5>(string definition, string expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5)
    {
        TheoryData ??= ArgsCode switch
        {
            ArgsCode.Instance => new TheoryData<TestData<T1?, T2?, T3?, T4?, T5?>>(),
            ArgsCode.Properties => new TheoryData<T1?, T2?, T3?, T4?, T5?>(),
            _ => default,
        };
        if (ArgsCode == ArgsCode.Instance)
        {
            TestData<T1?, T2?, T3?, T4?, T5?> testData = new(definition, expected, arg1, arg2, arg3, arg4, arg5);
            (TheoryData as TheoryData<TestData<T1?, T2?, T3?, T4?, T5?>>)!.Add(testData);
        }
        else
        {
            (TheoryData as TheoryData<T1?, T2?, T3?, T4?, T5?>)!.Add(arg1, arg2, arg3, arg4, arg5);
        }
    }

    public void AddTestDataToTheoryData<T1, T2, T3, T4, T5, T6>(string definition, string expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6)
    {
        TheoryData ??= ArgsCode switch
        {
            ArgsCode.Instance => new TheoryData<TestData<T1?, T2?, T3?, T4?, T5?, T6?>>(),
            ArgsCode.Properties => new TheoryData<T1?, T2?, T3?, T4?, T5?, T6?>(),
            _ => default,
        };
        if (ArgsCode == ArgsCode.Instance)
        {
            TestData<T1?, T2?, T3?, T4?, T5?, T6?> testData = new(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6);
            (TheoryData as TheoryData<TestData<T1?, T2?, T3?, T4?, T5?, T6?>>)!.Add(testData);
        }
        else
        {
            (TheoryData as TheoryData<T1?, T2?, T3?, T4?, T5?, T6?>)!.Add(arg1, arg2, arg3, arg4, arg5, arg6);
        }
    }

    public void AddTestDataToTheoryData<T1, T2, T3, T4, T5, T6, T7>(string definition, string expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7)
    {
        TheoryData ??= ArgsCode switch
        {
            ArgsCode.Instance => new TheoryData<TestData<T1?, T2?, T3?, T4?, T5?, T6?, T7?>>(),
            ArgsCode.Properties => new TheoryData<T1?, T2?, T3?, T4?, T5?, T6?, T7?>(),
            _ => default,
        };
        if (ArgsCode == ArgsCode.Instance)
        {
            TestData<T1?, T2?, T3?, T4?, T5?, T6?, T7?> testData = new(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
            (TheoryData as TheoryData<TestData<T1?, T2?, T3?, T4?, T5?, T6?, T7?>>)!.Add(testData);
        }
        else
        {
            (TheoryData as TheoryData<T1?, T2?, T3?, T4?, T5?, T6?, T7?>)!.Add(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }
    }

    public void AddTestDataToTheoryData<T1, T2, T3, T4, T5, T6, T7, T8>(string definition, string expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8)
    {
        TheoryData ??= ArgsCode switch
        {
            ArgsCode.Instance => new TheoryData<TestData<T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?>>(),
            ArgsCode.Properties => new TheoryData<T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?>(),
            _ => default,
        };
        if (ArgsCode == ArgsCode.Instance)
        {
            TestData<T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?> testData = new(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
            (TheoryData as TheoryData<TestData<T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?>>)!.Add(testData);
        }
        else
        {
            (TheoryData as TheoryData<T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?>)!.Add(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
        }
    }

    public void AddTestDataToTheoryData<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string definition, string expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8, T9? arg9)
    {
        TheoryData ??= ArgsCode switch
        {
            ArgsCode.Instance => new TheoryData<TestData<T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?>>(),
            ArgsCode.Properties => new TheoryData<T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?>(),
            _ => default,
        };
        if (ArgsCode == ArgsCode.Instance)
        {
            TestData<T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?> testData = new(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
            (TheoryData as TheoryData<TestData<T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?>>)!.Add(testData);
        }
        else
        {
            (TheoryData as TheoryData<T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?>)!.Add(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
        }
    }
    #endregion

    #region AddTestDataReturnsToTheoryData
    public void AddTestDataReturnsToTheoryData<TStruct, T1>(string definition, TStruct expected, T1? arg1) where TStruct : struct
    {
        TheoryData ??= ArgsCode switch
        {
            ArgsCode.Instance => new TheoryData<TestDataReturns<TStruct, T1?>>(),
            ArgsCode.Properties => new TheoryData<TStruct, T1?>(),
            _ => default,
        };

        if (ArgsCode == ArgsCode.Instance)
        {
            TestDataReturns<TStruct, T1?> testData = new(definition, expected, arg1);
            (TheoryData as TheoryData<TestDataReturns<TStruct, T1?>>)!.Add(testData);
        }
        else
        {
            (TheoryData as TheoryData<TStruct, T1?>)!.Add(expected, arg1);
        }
    }

    public void AddTestDataReturnsToTheoryData<TStruct, T1, T2>(string definition, TStruct expected, T1? arg1, T2? arg2) where TStruct : struct
    {
        TheoryData ??= ArgsCode switch
        {
            ArgsCode.Instance => new TheoryData<TestDataReturns<TStruct, T1?, T2?>>(),
            ArgsCode.Properties => new TheoryData<TStruct, T1?, T2?>(),
            _ => default,
        };
        if (ArgsCode == ArgsCode.Instance)
        {
            TestDataReturns<TStruct, T1?, T2?> testData = new(definition, expected, arg1, arg2);
            (TheoryData as TheoryData<TestDataReturns<TStruct, T1?, T2?>>)!.Add(testData);
        }
        else
        {
            (TheoryData as TheoryData<TStruct, T1?, T2?>)!.Add(expected, arg1, arg2);
        }
    }

    public void AddTestDataReturnsToTheoryData<TStruct, T1, T2, T3>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3) where TStruct : struct
    {
        TheoryData ??= ArgsCode switch
        {
            ArgsCode.Instance => new TheoryData<TestDataReturns<TStruct, T1?, T2?, T3?>>(),
            ArgsCode.Properties => new TheoryData<TStruct, T1?, T2?, T3?>(),
            _ => default,
        };
        if (ArgsCode == ArgsCode.Instance)
        {
            TestDataReturns<TStruct, T1?, T2?, T3?> testData = new(definition, expected, arg1, arg2, arg3);
            (TheoryData as TheoryData<TestDataReturns<TStruct, T1?, T2?, T3?>>)!.Add(testData);
        }
        else
        {
            (TheoryData as TheoryData<TStruct, T1?, T2?, T3?>)!.Add(expected, arg1, arg2, arg3);
        }
    }

    public void AddTestDataReturnsToTheoryData<TStruct, T1, T2, T3, T4>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4) where TStruct : struct
    {
        TheoryData ??= ArgsCode switch
        {
            ArgsCode.Instance => new TheoryData<TestDataReturns<TStruct, T1?, T2?, T3?, T4?>>(),
            ArgsCode.Properties => new TheoryData<TStruct, T1?, T2?, T3?, T4?>(),
            _ => default,
        };
        if (ArgsCode == ArgsCode.Instance)
        {
            TestDataReturns<TStruct, T1?, T2?, T3?, T4?> testData = new(definition, expected, arg1, arg2, arg3, arg4);
            (TheoryData as TheoryData<TestDataReturns<TStruct, T1?, T2?, T3?, T4?>>)!.Add(testData);
        }
        else
        {
            (TheoryData as TheoryData<TStruct, T1?, T2?, T3?, T4?>)!.Add(expected, arg1, arg2, arg3, arg4);
        }
    }

    public void AddTestDataReturnsToTheoryData<TStruct, T1, T2, T3, T4, T5>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5) where TStruct : struct
    {
        TheoryData ??= ArgsCode switch
        {
            ArgsCode.Instance => new TheoryData<TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?>>(),
            ArgsCode.Properties => new TheoryData<TStruct, T1?, T2?, T3?, T4?, T5?>(),
            _ => default,
        };
        if (ArgsCode == ArgsCode.Instance)
        {
            TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?> testData = new(definition, expected, arg1, arg2, arg3, arg4, arg5);
            (TheoryData as TheoryData<TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?>>)!.Add(testData);
        }
        else
        {
            (TheoryData as TheoryData<TStruct, T1?, T2?, T3?, T4?, T5?>)!.Add(expected, arg1, arg2, arg3, arg4, arg5);
        }
    }

    public void AddTestDataReturnsToTheoryData<TStruct, T1, T2, T3, T4, T5, T6>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6) where TStruct : struct
    {
        TheoryData ??= ArgsCode switch
        {
            ArgsCode.Instance => new TheoryData<TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?, T6?>>(),
            ArgsCode.Properties => new TheoryData<TStruct, T1?, T2?, T3?, T4?, T5?, T6?>(),
            _ => default,
        };
        if (ArgsCode == ArgsCode.Instance)
        {
            TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?, T6?> testData = new(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6);
            (TheoryData as TheoryData<TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?, T6?>>)!.Add(testData);
        }
        else
        {
            (TheoryData as TheoryData<TStruct, T1?, T2?, T3?, T4?, T5?, T6?>)!.Add(expected, arg1, arg2, arg3, arg4, arg5, arg6);
        }
    }

    public void AddTestDataReturnsToTheoryData<TStruct, T1, T2, T3, T4, T5, T6, T7>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7) where TStruct : struct
    {
        TheoryData ??= ArgsCode switch
        {
            ArgsCode.Instance => new TheoryData<TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?, T6?, T7?>>(),
            ArgsCode.Properties => new TheoryData<TStruct, T1?, T2?, T3?, T4?, T5?, T6?, T7?>(),
            _ => default,
        };
        if (ArgsCode == ArgsCode.Instance)
        {
            TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?, T6?, T7?> testData = new(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
            (TheoryData as TheoryData<TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?, T6?, T7?>>)!.Add(testData);
        }
        else
        {
            (TheoryData as TheoryData<TStruct, T1?, T2?, T3?, T4?, T5?, T6?, T7?>)!.Add(expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }
    }

    public void AddTestDataReturnsToTheoryData<TStruct, T1, T2, T3, T4, T5, T6, T7, T8>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8) where TStruct : struct
    {
        TheoryData ??= ArgsCode switch
        {
            ArgsCode.Instance => new TheoryData<TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?>>(),
            ArgsCode.Properties => new TheoryData<TStruct, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?>(),
            _ => default,
        };
        if (ArgsCode == ArgsCode.Instance)
        {
            TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?> testData = new(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
            (TheoryData as TheoryData<TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?>>)!.Add(testData);
        }
        else
        {
            (TheoryData as TheoryData<TStruct, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?>)!.Add(expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
        }
    }

    public void AddTestDataReturnsToTheoryData<TStruct, T1, T2, T3, T4, T5, T6, T7, T8, T9>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8, T9? arg9) where TStruct : struct
    {
        TheoryData ??= ArgsCode switch
        {
            ArgsCode.Instance => new TheoryData<TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?>>(),
            ArgsCode.Properties => new TheoryData<TStruct, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?>(),
            _ => default,
        };
        if (ArgsCode == ArgsCode.Instance)
        {
            TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?> testData = new(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
            (TheoryData as TheoryData<TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?>>)!.Add(testData);
        }
        else
        {
            (TheoryData as TheoryData<TStruct, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?>)!.Add(expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
        }
    }
    #endregion

    #region AddTestDataThrowsToTheoryData
    public void AddTestDataThrowsToTheoryData<TException, T1>(string definition, TException expected, T1? arg1) where TException : Exception
    {
        TheoryData ??= ArgsCode switch
        {
            ArgsCode.Instance => new TheoryData<TestDataThrows<TException, T1?>>(),
            ArgsCode.Properties => new TheoryData<TException, T1?>(),
            _ => default,
        };

        if (ArgsCode == ArgsCode.Instance)
        {
            TestDataThrows<TException, T1?> testData = new(definition, expected, arg1);
            (TheoryData as TheoryData<TestDataThrows<TException, T1?>>)!.Add(testData);
        }
        else
        {
            (TheoryData as TheoryData<TException, T1?>)!.Add(expected, arg1);
        }
    }

    public void AddTestDataThrowsToTheoryData<TException, T1, T2>(string definition, TException expected, T1? arg1, T2? arg2) where TException : Exception
    {
        TheoryData ??= ArgsCode switch
        {
            ArgsCode.Instance => new TheoryData<TestDataThrows<TException, T1?, T2?>>(),
            ArgsCode.Properties => new TheoryData<TException, T1?, T2?>(),
            _ => default,
        };
        if (ArgsCode == ArgsCode.Instance)
        {
            TestDataThrows<TException, T1?, T2?> testData = new(definition, expected, arg1, arg2);
            (TheoryData as TheoryData<TestDataThrows<TException, T1?, T2?>>)!.Add(testData);
        }
        else
        {
            (TheoryData as TheoryData<TException, T1?, T2?>)!.Add(expected, arg1, arg2);
        }
    }

    public void AddTestDataThrowsToTheoryData<TException, T1, T2, T3>(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3) where TException : Exception
    {
        TheoryData ??= ArgsCode switch
        {
            ArgsCode.Instance => new TheoryData<TestDataThrows<TException, T1?, T2?, T3?>>(),
            ArgsCode.Properties => new TheoryData<TException, T1?, T2?, T3?>(),
            _ => default,
        };
        if (ArgsCode == ArgsCode.Instance)
        {
            TestDataThrows<TException, T1?, T2?, T3?> testData = new(definition, expected, arg1, arg2, arg3);
            (TheoryData as TheoryData<TestDataThrows<TException, T1?, T2?, T3?>>)!.Add(testData);
        }
        else
        {
            (TheoryData as TheoryData<TException, T1?, T2?, T3?>)!.Add(expected, arg1, arg2, arg3);
        }
    }

    public void AddTestDataThrowsToTheoryData<TException, T1, T2, T3, T4>(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4) where TException : Exception
    {
        TheoryData ??= ArgsCode switch
        {
            ArgsCode.Instance => new TheoryData<TestDataThrows<TException, T1?, T2?, T3?, T4?>>(),
            ArgsCode.Properties => new TheoryData<TException, T1?, T2?, T3?, T4?>(),
            _ => default,
        };
        if (ArgsCode == ArgsCode.Instance)
        {
            TestDataThrows<TException, T1?, T2?, T3?, T4?> testData = new(definition, expected, arg1, arg2, arg3, arg4);
            (TheoryData as TheoryData<TestDataThrows<TException, T1?, T2?, T3?, T4?>>)!.Add(testData);
        }
        else
        {
            (TheoryData as TheoryData<TException, T1?, T2?, T3?, T4?>)!.Add(expected, arg1, arg2, arg3, arg4);
        }
    }

    public void AddTestDataThrowsToTheoryData<TException, T1, T2, T3, T4, T5>(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5) where TException : Exception
    {
        TheoryData ??= ArgsCode switch
        {
            ArgsCode.Instance => new TheoryData<TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?>>(),
            ArgsCode.Properties => new TheoryData<TException, T1?, T2?, T3?, T4?, T5?>(),
            _ => default,
        };
        if (ArgsCode == ArgsCode.Instance)
        {
            TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?> testData = new(definition, expected, arg1, arg2, arg3, arg4, arg5);
            (TheoryData as TheoryData<TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?>>)!.Add(testData);
        }
        else
        {
            (TheoryData as TheoryData<TException, T1?, T2?, T3?, T4?, T5?>)!.Add(expected, arg1, arg2, arg3, arg4, arg5);
        }
    }

    public void AddTestDataThrowsToTheoryData<TException, T1, T2, T3, T4, T5, T6>(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6) where TException : Exception
    {
        TheoryData ??= ArgsCode switch
        {
            ArgsCode.Instance => new TheoryData<TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?, T6?>>(),
            ArgsCode.Properties => new TheoryData<TException, T1?, T2?, T3?, T4?, T5?, T6?>(),
            _ => default,
        };
        if (ArgsCode == ArgsCode.Instance)
        {
            TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?, T6?> testData = new(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6);
            (TheoryData as TheoryData<TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?, T6?>>)!.Add(testData);
        }
        else
        {
            (TheoryData as TheoryData<TException, T1?, T2?, T3?, T4?, T5?, T6?>)!.Add(expected, arg1, arg2, arg3, arg4, arg5, arg6);
        }
    }

    public void AddTestDataThrowsToTheoryData<TException, T1, T2, T3, T4, T5, T6, T7>(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7) where TException : Exception
    {
        TheoryData ??= ArgsCode switch
        {
            ArgsCode.Instance => new TheoryData<TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?, T6?, T7?>>(),
            ArgsCode.Properties => new TheoryData<TException, T1?, T2?, T3?, T4?, T5?, T6?, T7?>(),
            _ => default,
        };
        if (ArgsCode == ArgsCode.Instance)
        {
            TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?, T6?, T7?> testData = new(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
            (TheoryData as TheoryData<TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?, T6?, T7?>>)!.Add(testData);
        }
        else
        {
            (TheoryData as TheoryData<TException, T1?, T2?, T3?, T4?, T5?, T6?, T7?>)!.Add(expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }
    }

    public void AddTestDataThrowsToTheoryData<TException, T1, T2, T3, T4, T5, T6, T7, T8>(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8) where TException : Exception
    {
        TheoryData ??= ArgsCode switch
        {
            ArgsCode.Instance => new TheoryData<TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?>>(),
            ArgsCode.Properties => new TheoryData<TException, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?>(),
            _ => default,
        };
        if (ArgsCode == ArgsCode.Instance)
        {
            TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?> testData = new(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
            (TheoryData as TheoryData<TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?>>)!.Add(testData);
        }
        else
        {
            (TheoryData as TheoryData<TException, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?>)!.Add(expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
        }
    }

    public void AddTestDataThrowsToTheoryData<TException, T1, T2, T3, T4, T5, T6, T7, T8, T9>(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8, T9? arg9) where TException : Exception
    {
        TheoryData ??= ArgsCode switch
        {
            ArgsCode.Instance => new TheoryData<TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?>>(),
            ArgsCode.Properties => new TheoryData<TException, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?>(),
            _ => default,
        };
        if (ArgsCode == ArgsCode.Instance)
        {
            TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?> testData = new(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
            (TheoryData as TheoryData<TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?>>)!.Add(testData);
        }
        else
        {
            (TheoryData as TheoryData<TException, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?>)!.Add(expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
        }
    }
    #endregion
}
