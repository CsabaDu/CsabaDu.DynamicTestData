namespace CsabaDu.DynamicTestData.Tests.UnitTests;

public sealed class ExtensionsTests
{
    private readonly object?[] _args = [null, "test"];

    [Fact]
    public void Add_ShouldReturnOriginalArray_WhenArgsCodeIsNotProperties()
    {
        // Arrange
        ArgsCode argsCode = ArgsCode.Instance;
        int[] parameters = [2, 3];

        // Act
        var actual = _args.Add(argsCode, parameters);

        // Assert
        Assert.Equal(_args, actual);
    }

    [Fact]
    public void Add_ShouldReturnNewArrayWithParameters_WhenArgsCodeIsProperties()
    {
        // Arrange
        ArgsCode argsCode = ArgsCode.Properties;
        int[] parameters = [2, 3];

        // Act
        var actual = _args.Add(argsCode, parameters);

        // Assert
        Assert.Equal([.. _args, 2, 3], actual);
    }

    [Fact]
    public void Add_ShouldHandleNullParameters()
    {
        // Arrange
        ArgsCode argsCode = ArgsCode.Properties;
        int?[] parameters = [null, 3];

        // Act
        var actual = _args.Add(argsCode, parameters);

        // Assert
        Assert.Equal([.._args, null, 3], actual);
    }

    [Fact]
    public void Add_ShouldHandleEmptyParameters()
    {
        // Arrange
        ArgsCode argsCode = ArgsCode.Properties;
        int[] parameters = [];

        // Act
        var actual = _args.Add(argsCode, parameters);

        // Assert
        Assert.Equal(_args, actual);
    }
}
