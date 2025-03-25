using static CsabaDu.DynamicTestData.DynamicDataSources.DynamicDataSource;


namespace CsabaDu.DynamicTestData.Tests.UnitTests.DynamicDataSources;

public class DynamicDataSourceDisposableMementoTests
{
    DynamicDataSourceChild _sut;

    private class TestDataSource : DynamicDataSource
    {
        public TestDataSource(ArgsCode argsCode) : base(argsCode) { }

        // Public wrapper to create memento
        public IDisposable CreateMemento(ArgsCode argsCode)
        {
            Type dataSourceType = typeof(DynamicDataSource);

            Type mementoType = dataSourceType.GetNestedType(
                DisposableMementoName,
                BindingFlags.NonPublic);

            ConstructorInfo ctor = mementoType?.GetConstructor(
                BindingFlags.Instance | BindingFlags.NonPublic,
                null,
                [dataSourceType, typeof(ArgsCode)],
                null);

            return (IDisposable)ctor!.Invoke([this, argsCode]);
        }

        // Helper to get current ArgsCode
        public ArgsCode CurrentArgsCode => ArgsCode;
    }

    private static IDisposable CreateDisposableMemento(DynamicDataSource dataSource, ArgsCode argsCode)
    {
        const BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;

        var dataSourceType = typeof(DynamicDataSource);

        var mementoType = dataSourceType.GetNestedType(DisposableMementoName, bindingFlags)
            ?? throw new MissingTypeException(DisposableMementoName);

        var ctor = mementoType.GetConstructor(bindingFlags, null, [dataSourceType, typeof(ArgsCode)], null)
            ?? throw new MissingMethodException($"{DisposableMementoName} constructor");

        return (IDisposable)ctor.Invoke([dataSource, argsCode]);
    }

    private sealed class MissingTypeException(string typeName) : Exception($"Could not find type: {typeName}")
    {
    }

    [Fact]
    public void Constructor_nullArg_DynamicDataSource_ThrowsArgumentNullException()
    {
        // Arrange
        DynamicDataSource _sut = null;
        string epectedParamName = "dataSource";

        // Act
        void attempt() => DynamicDataSourceChild.CreateDisposableMemento(_sut, default);

        // Assert
        var exception = Assert.Throws<TargetInvocationException>(attempt);
        var innerException = exception.InnerException
            ?? throw new InvalidOperationException("TargetInvocationException.InnerException was null");
        var actual = Assert.IsType<ArgumentNullException>(innerException);
        Assert.Equal(epectedParamName, actual.ParamName);
    }

    //[Fact]
    //public void Constructor_ThrowsArgumentNullException_WhenDataSourceIsNull()
    //{
    //    // Arrange
    //    DynamicDataSource _sut = null;
    //    void attempt() => DynamicDataSourceChild.CreateDisposableMemento(_sut, default);

    //    // Act
    //    var ex = Record.Exception(attempt);

    //    // Assert
    //    Assert.NotNull(ex); // Ensure we got an exception

    //    // Handle both direct and reflection-invoked cases
    //    var actualException = ex is TargetInvocationException tie ? tie.InnerException : ex;

    //    Assert.NotNull(actualException); // Ensure we have an inner exception
    //    var argEx = Assert.IsType<ArgumentNullException>(actualException);
    //    Assert.Equal("dataSource", argEx.ParamName);
    //}

    [Fact]
    public void Memento_SetsNewValue_WhenCreated()
    {
        // Arrange
        var dataSource = new TestDataSource(ArgsCode.Properties);

        // Act
        using (dataSource.CreateMemento(ArgsCode.Instance))
        {
            // Assert
            Assert.Equal(ArgsCode.Instance, dataSource.CurrentArgsCode);
        }
    }

    [Fact]
    public void Memento_RestoresOriginalValue_WhenDisposed()
    {
        // Arrange
        var dataSource = new TestDataSource(ArgsCode.Properties);

        // Act
        var memento = dataSource.CreateMemento(ArgsCode.Instance);
        memento.Dispose();

        // Assert
        Assert.Equal(ArgsCode.Properties, dataSource.CurrentArgsCode);
    }

    [Fact]
    public void Memento_IsIdempotent_OnMultipleDisposes()
    {
        // Arrange
        var dataSource = new TestDataSource(ArgsCode.Properties);
        var memento = dataSource.CreateMemento(ArgsCode.Instance);

        // Act
        memento.Dispose();
        memento.Dispose(); // Second dispose

        // Assert
        Assert.Equal(ArgsCode.Properties, dataSource.CurrentArgsCode);
    }

    [Fact]
    public async Task Memento_RespectsAsyncFlow()
    {
        // Arrange
        var dataSource = new TestDataSource(ArgsCode.Properties);
        ArgsCode? asyncValue = null;

        // Act
        using (dataSource.CreateMemento(ArgsCode.Instance))
        {
            await Task.Run(() =>
            {
                asyncValue = dataSource.CurrentArgsCode;
            });
        }

        // Assert
        Assert.Equal(ArgsCode.Instance, asyncValue); // Different async flow
        Assert.Equal(ArgsCode.Properties, dataSource.CurrentArgsCode);
    }

    [Fact]
    public void Memento_WorksWithUsingStatement()
    {
        // Arrange
        var dataSource = new TestDataSource(ArgsCode.Properties);

        // Act & Assert
        using (dataSource.CreateMemento(ArgsCode.Instance))
        {
            Assert.Equal(ArgsCode.Instance, dataSource.CurrentArgsCode);
        }
        Assert.Equal(ArgsCode.Properties, dataSource.CurrentArgsCode);
    }

    [Fact]
    public void Memento_RestoresNull_WhenOriginalWasNull()
    {
        // Arrange
        var dataSource = new TestDataSource(ArgsCode.Properties);
        SetTempArgsCodeViaReflection(dataSource, null);

        // Act
        using (dataSource.CreateMemento(ArgsCode.Instance))
        {
            Assert.Equal(ArgsCode.Instance, dataSource.CurrentArgsCode);
        }

        // Assert
        Assert.Null(GetTempArgsCodeViaReflection(dataSource));
    }

    private static void SetTempArgsCodeViaReflection(DynamicDataSource source, ArgsCode? value)
    {
        var field = typeof(DynamicDataSource).GetField(
            "_tempArgsCode",
            BindingFlags.NonPublic | BindingFlags.Instance);
        var asyncLocal = (AsyncLocal<ArgsCode?>)field.GetValue(source);
        asyncLocal.Value = value;
    }

    private static ArgsCode? GetTempArgsCodeViaReflection(DynamicDataSource source)
    {
        var field = typeof(DynamicDataSource).GetField(
            "_tempArgsCode",
            BindingFlags.NonPublic | BindingFlags.Instance);
        var asyncLocal = (AsyncLocal<ArgsCode?>)field.GetValue(source);
        return asyncLocal.Value;
    }
}