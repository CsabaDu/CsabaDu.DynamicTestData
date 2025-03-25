namespace CsabaDu.DynamicTestData.Tests.UnitTests.DynamicDataSources;

public class DisposableMementoTests
{
    private class TestDataSource : DynamicDataSource
    {
        public TestDataSource(ArgsCode argsCode) : base(argsCode) { }

        // Public wrapper to create memento
        public IDisposable CreateMemento(ArgsCode argsCode)
        {
            var mementoType = typeof(DynamicDataSource).GetNestedType(
                DisposableMementoName,
                BindingFlags.NonPublic);

            var ctor = mementoType?.GetConstructor(
                BindingFlags.Instance | BindingFlags.NonPublic,
                null,
                [typeof(DynamicDataSource), typeof(ArgsCode)],
                null);

            return (IDisposable)ctor!.Invoke([this, argsCode]);
        }

        // Helper to get current ArgsCode
        public ArgsCode CurrentArgsCode => ArgsCode;
    }

    [Fact]
    public void Constructor_ThrowsArgumentNullException_WhenDataSourceIsNull()
    {
        // Arrange
        DynamicDataSource nullDataSource = null!;
        var validArgsCode = ArgsCode.Instance;
        void attempt() => DynamicDataSourceChild.CreateDisposableMemento(nullDataSource, validArgsCode);

        // Act
        var ex = Record.Exception(attempt);

        // Assert
        Assert.NotNull(ex); // Ensure we got an exception

        // Handle both direct and reflection-invoked cases
        var actualException = ex is TargetInvocationException tie ? tie.InnerException : ex;

        Assert.NotNull(actualException); // Ensure we have an inner exception
        var argEx = Assert.IsType<ArgumentNullException>(actualException);
        Assert.Equal("dataSource", argEx.ParamName);
    }

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