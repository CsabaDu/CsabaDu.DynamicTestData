using static CsabaDu.DynamicTestData.Tests.DynamicDataSources.DynamicDataSourceTheoryData;

namespace CsabaDu.DynamicTestData.Tests.UnitTests;

public sealed class DynamicDataSourceTests
{
    //private DynamicDataSourceChild _sut;
    //private int _arg1;
    //private object _arg2;
    //private DateTime _arg3;
    //private string _arg4;
    //private double _arg5;
    //private bool _arg6;
    //private char _arg7;
    //private string _arg8;
    //private object[] _arg9;

    //private object[] _args = typeof(DynamicDataSourceTests).GetFields(BindingFlags.NonPublic)
    //    .Where(f => f.Name.StartsWith("_arg"))
    //    .Select(f => f.GetValue(new DynamicDataSourceTests())).ToArray();

    //[Theory, MemberData(nameof(TestDataToArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    //public void TestDataToArgs_args_returnsExpected(object[] argsIn, object[] expected)
    //{
    //    // Arrange
    //    ArgsCode argsCode = (ArgsCode)argsIn[0];
    //    string definition = (string)argsIn[1];
    //    string result = (string)argsIn[2];
    //    int length = argsIn.Length;
    //    for (int i = 3; i < length; i++)
    //    {
    //        _args[i - 3] = argsIn[i];
    //    }

    //    _sut = new(argsCode);

    //    // Act
    //    var actual = length switch
    //    {
    //        4 => _sut.TestDataToArgs(definition, result, _arg1),
    //        5 => _sut.TestDataToArgs(definition, result, _arg1, _arg2),
    //        6 => _sut.TestDataToArgs(definition, result, _arg1, _arg2, _arg3),
    //        7 => _sut.TestDataToArgs(definition, result, _arg1, _arg2, _arg3, _arg4),
    //        8 => _sut.TestDataToArgs(definition, result, _arg1, _arg2, _arg3, _arg4, _arg5),
    //        9 => _sut.TestDataToArgs(definition, result, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6),
    //        10 => _sut.TestDataToArgs(definition, result, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7),
    //        11 => _sut.TestDataToArgs(definition, result, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7, _arg8),
    //        12 => _sut.TestDataToArgs(definition, result, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7, _arg8, _arg9),
    //        _ => throw new ArgumentOutOfRangeException(nameof(length), length, "Invalid number of arguments.")
    //    };

    //    // Assert
    //    Assert.Equal(expected, actual);
    //}

    //[Fact]
    //public void TestDataToArgs_SingleArgument_ReturnsCorrectArray()
    //{
    //    // Arrange
    //    var dynamicDataSource = new TestDynamicDataSource(_argsCode);
    //    string definition = "Test Definition";
    //    string result = "Expected Result";
    //    int arg1 = 42;

    //    // Act
    //    var args = dynamicDataSource.TestDataToArgs(definition, result, arg1);

    //    // Assert
    //    Assert.NotNull(args);
    //    Assert.Equal(3, args.Length);
    //    Assert.Equal(definition, args[0]);
    //    Assert.Equal(result, args[1]);
    //    Assert.Equal(arg1, args[2]);
    //}

    //[Fact]
    //public void TestDataToArgs_TwoArguments_ReturnsCorrectArray()
    //{
    //    // Arrange
    //    var dynamicDataSource = new TestDynamicDataSource(_argsCode);
    //    string definition = "Test Definition";
    //    string result = "Expected Result";
    //    int arg1 = 42;
    //    string arg2 = "Second Argument";

    //    // Act
    //    var args = dynamicDataSource.TestDataToArgs(definition, result, arg1, arg2);

    //    // Assert
    //    Assert.NotNull(args);
    //    Assert.Equal(4, args.Length);
    //    Assert.Equal(definition, args[0]);
    //    Assert.Equal(result, args[1]);
    //    Assert.Equal(arg1, args[2]);
    //    Assert.Equal(arg2, args[3]);
    //}

    //[Fact]
    //public void TestDataToArgs_ThreeArguments_ReturnsCorrectArray()
    //{
    //    // Arrange
    //    var dynamicDataSource = new TestDynamicDataSource(_argsCode);
    //    string definition = "Test Definition";
    //    string result = "Expected Result";
    //    int arg1 = 42;
    //    string arg2 = "Second Argument";
    //    bool arg3 = true;

    //    // Act
    //    var args = dynamicDataSource.TestDataToArgs(definition, result, arg1, arg2, arg3);

    //    // Assert
    //    Assert.NotNull(args);
    //    Assert.Equal(5, args.Length);
    //    Assert.Equal(definition, args[0]);
    //    Assert.Equal(result, args[1]);
    //    Assert.Equal(arg1, args[2]);
    //    Assert.Equal(arg2, args[3]);
    //    Assert.Equal(arg3, args[4]);
    //}

    // Additional tests for more arguments can be added similarly
}
