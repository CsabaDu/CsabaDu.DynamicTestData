//using static CsabaDu.DynamicTestData.DynamicDataSources.DynamicDataSource;


//namespace CsabaDu.DynamicTestData.Tests.UnitTests.DynamicDataSources;

//public class DynamicDataSourceDisposableMementoTests
//{
//    DynamicDataSourceChild _sut;

//    private static IDisposable CreateDisposableMemento(DynamicDataSource dataSource, ArgsCode argsCode)
//    {
//        const BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;

//        var dataSourceType = typeof(DynamicDataSource);

//        var mementoType = dataSourceType.GetNestedType(DisposableMementoName, bindingFlags)
//            ?? throw new MissingTypeException(DisposableMementoName);

//        var ctor = mementoType.GetConstructor(bindingFlags, null, [dataSourceType, typeof(ArgsCode)], null)
//            ?? throw new MissingMethodException($"{DisposableMementoName} constructor");

//        return (IDisposable)ctor.Invoke([dataSource, argsCode]);
//    }

//    private sealed class MissingTypeException(string typeName) : Exception($"Could not find type: {typeName}")
//    {
//    }

//    [Fact]
//    public void Constructor_nullArg_DynamicDataSource_ThrowsArgumentNullException()
//    {
//        // Arrange
//        _sut = null;
//        string expectedParamName = "dataSource";

//        // Act
//        void attempt() => DynamicDataSourceChild.CreateDisposableMemento(_sut, default);

//        // Assert
//        var exception = Assert.Throws<TargetInvocationException>(attempt);
//        var innerException = exception.InnerException ?? throw new InvalidOperationException("TargetInvocationException.InnerException was null");
//        var actual = Assert.IsType<ArgumentNullException>(innerException);
//        Assert.Equal(expectedParamName, actual.ParamName);
//    }

//    [Fact]
//    public void Memento_SetsNewValue_WhenCreated()
//    {
//        // Arrange
//        _sut = new(ArgsCode.Properties);

//        // Act
//        using (CreateDisposableMemento(_sut, ArgsCode.Instance))
//        {
//            // Assert
//            Assert.Equal(ArgsCode.Instance, _sut.GetArgsCode());
//        }
//    }

//    [Fact]
//    public void Memento_RestoresOriginalValue_WhenDisposed()
//    {
//        // Arrange
//        _sut = new(ArgsCode.Properties);

//        // Act
//        var memento = CreateDisposableMemento(_sut, ArgsCode.Instance);
//        memento.Dispose();

//        // Assert
//        Assert.Equal(ArgsCode.Properties, _sut.GetArgsCode());
//    }

//    [Fact]
//    public void Memento_IsIdempotent_OnMultipleDisposes()
//    {
//        // Arrange
//        _sut = new(ArgsCode.Properties);
//        var memento = CreateDisposableMemento(_sut, ArgsCode.Instance);

//        // Act
//        memento.Dispose();
//        memento.Dispose(); // Second dispose

//        // Assert
//        Assert.Equal(ArgsCode.Properties, _sut.GetArgsCode());
//    }

//    [Fact]
//    public async Task Memento_RespectsAsyncFlow()
//    {
//        // Arrange
//        _sut = new(ArgsCode.Properties);
//        ArgsCode? asyncValue = null;

//        // Act
//        using (CreateDisposableMemento(_sut, ArgsCode.Instance))
//        {
//            await Task.Run(() =>
//            {
//                asyncValue = _sut.GetArgsCode();
//            });
//        }

//        // Assert
//        Assert.Equal(ArgsCode.Instance, asyncValue); // Different async flow
//        Assert.Equal(ArgsCode.Properties, _sut.GetArgsCode());
//    }

//    [Fact]
//    public void Memento_WorksWithUsingStatement()
//    {
//        // Arrange
//        _sut = new(ArgsCode.Properties);

//        // Act & Assert
//        using (CreateDisposableMemento(_sut, ArgsCode.Instance))
//        {
//            Assert.Equal(ArgsCode.Instance, _sut.GetArgsCode());
//        }
//        Assert.Equal(ArgsCode.Properties, _sut.GetArgsCode());
//    }

//    [Fact]
//    public void Memento_RestoresNull_WhenOriginalWasNull()
//    {
//        // Arrange
//        _sut = new(ArgsCode.Properties);
//        SetTempArgsCodeViaReflection(_sut, null);

//        // Act
//        using (CreateDisposableMemento(_sut, ArgsCode.Instance))
//        {
//            Assert.Equal(ArgsCode.Instance, _sut.GetArgsCode());
//        }

//        // Assert
//        Assert.Null(GetTempArgsCodeViaReflection(_sut));
//    }

//    private static void SetTempArgsCodeViaReflection(DynamicDataSource source, ArgsCode? value)
//    {
//        var field = typeof(DynamicDataSource).GetField(
//            "_tempArgsCode",
//            BindingFlags.NonPublic | BindingFlags.Instance);
//        var asyncLocal = (AsyncLocal<ArgsCode?>)field.GetValue(source);
//        asyncLocal.Value = value;
//    }

//    private static ArgsCode? GetTempArgsCodeViaReflection(DynamicDataSource source)
//    {
//        var field = typeof(DynamicDataSource).GetField(
//            "_tempArgsCode",
//            BindingFlags.NonPublic | BindingFlags.Instance);
//        var asyncLocal = (AsyncLocal<ArgsCode?>)field.GetValue(source);
//        return asyncLocal.Value;
//    }
//}