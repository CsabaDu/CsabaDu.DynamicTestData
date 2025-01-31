namespace CsabaDu.DynamicTestData.Tests.DynamicDataSources;

public class DynamicDataSourceTheoryData
{
    //public static TheoryData<ITestData<string>[]> TestDataToArgsInstanceTheoryData
    //{
    //    get
    //    {
    //        var testDataArgsList = GetArgs(typeof(TestDataArgs));
    //        var result = new TheoryData<ITestData<string>[]>();

    //        foreach (var testDataArg in testDataArgsList)
    //        {
    //            result.Add([testDataArg as ITestData<string>]);
    //        }

    //        return result;
    //    }
    //}

    //public static TheoryData<object[]> TestDataToArgsTheoryData
    //{
    //    get
    //    {
    //        var testDataArgsList = GetArgs(typeof(Args));
    //        object[] args = [];
    //        var result = new TheoryData<object[]>();

    //        foreach (var arg in testDataArgsList)
    //        {
    //            result.Add([.. args, arg]);
    //        }

    //        return result;
    //    }
    //}

    //private static IEnumerable<object> GetArgs(Type type)
    //=> type.GetFields(BindingFlags.Static | BindingFlags.Public).OrderBy(n => nameof(n)).Select(f => f.GetValue(null));

    //public static IEnumerable<object[]> TestDataToArgsTheoryData
    //=>
    //[
    //    Args1,
    //    Args2,
    //    Args3,
    //    Args4,
    //    Args5,
    //    Args6,
    //    Args7,
    //    Args8,
    //    Args9,
    //];
}