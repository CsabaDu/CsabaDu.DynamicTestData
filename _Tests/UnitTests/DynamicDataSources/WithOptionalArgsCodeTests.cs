//using Xunit;
//using Moq;
//using System;
//using YourNamespace; // Replace with your actual namespace

//public class WithOptionalArgsCodeTests
//{
//    public class TestDynamicDataSource : DynamicDataSource
//    {
//        // Implement any required abstract members
//    }

//    public class DisposableMemento : IDisposable
//    {
//        public DynamicDataSource DataSource { get; }
//        public ArgsCode ArgsCode { get; }

//        public DisposableMemento(DynamicDataSource dataSource, ArgsCode argsCode)
//        {
//            DataSource = dataSource;
//            ArgsCode = argsCode;
//        }

//        public void Dispose()
//        {
//            // Cleanup if needed
//        }
//    }

//    [Fact]
//    public void WithOptionalArgsCode_Func_NoArgsCode_CallsGeneratorDirectly()
//    {
//        // Arrange
//        var dataSource = new TestDynamicDataSource();
//        var expectedResult = "test result";
//        var generatorCalled = false;

//        Func<string> testDataGenerator = () =>
//        {
//            generatorCalled = true;
//            return expectedResult;
//        };

//        // Act
//        var result = WithOptionalArgsCode(dataSource, testDataGenerator, null);

//        // Assert
//        Assert.True(generatorCalled);
//        Assert.Equal(expectedResult, result);
//    }

//    [Theory]
//    [InlineData(ArgsCode.Instance)]
//    [InlineData(ArgsCode.Properties)]
//    public void WithOptionalArgsCode_Func_WithArgsCode_CreatesMementoAndCallsGenerator(ArgsCode argsCode)
//    {
//        // Arrange
//        var dataSource = new TestDynamicDataSource();
//        var expectedResult = "test result";
//        var generatorCalled = false;

//        Func<string> testDataGenerator = () =>
//        {
//            generatorCalled = true;
//            return expectedResult;
//        };

//        // Act
//        var result = WithOptionalArgsCode(dataSource, testDataGenerator, argsCode);

//        // Assert
//        Assert.True(generatorCalled);
//        Assert.Equal(expectedResult, result);
//        // Verify memento was created with correct parameters (would need proper mocking)
//    }

//    [Fact]
//    public void WithOptionalArgsCode_Action_NoArgsCode_CallsProcessorDirectly()
//    {
//        // Arrange
//        var dataSource = new TestDynamicDataSource();
//        var processorCalled = false;

//        Action testDataProcessor = () =>
//        {
//            processorCalled = true;
//        };

//        // Act
//        WithOptionalArgsCode<TestDynamicDataSource, string>(dataSource, testDataProcessor, null);

//        // Assert
//        Assert.True(processorCalled);
//    }

//    [Theory]
//    [InlineData(ArgsCode.Instance)]
//    [InlineData(ArgsCode.Properties)]
//    public void WithOptionalArgsCode_Action_WithArgsCode_CreatesMementoAndCallsProcessor(ArgsCode argsCode)
//    {
//        // Arrange
//        var dataSource = new TestDynamicDataSource();
//        var processorCalled = false;

//        Action testDataProcessor = () =>
//        {
//            processorCalled = true;
//        };

//        // Act
//        WithOptionalArgsCode<TestDynamicDataSource, string>(dataSource, testDataProcessor, argsCode);

//        // Assert
//        Assert.True(processorCalled);
//        // Verify memento was created with correct parameters (would need proper mocking)
//    }

//    [Theory]
//    [InlineData(ArgsCode.Instance)]
//    [InlineData(ArgsCode.Properties)]
//    public void WithOptionalArgsCode_Func_DisposesMemento(ArgsCode argsCode)
//    {
//        // Arrange
//        var dataSource = new TestDynamicDataSource();
//        var mementoMock = new Mock<IDisposable>();

//        // This would require refactoring to inject the memento or use a factory
//        // For demonstration purposes, this shows what you'd want to test

//        // Act
//        // The method should dispose the memento after execution

//        // Assert
//        // Verify mementoMock.Dispose() was called once
//        // This would require refactoring the method to be more testable
//    }

//    [Theory]
//    [InlineData(ArgsCode.Instance)]
//    [InlineData(ArgsCode.Properties)]
//    public void WithOptionalArgsCode_Action_DisposesMemento(ArgsCode argsCode)
//    {
//        // Arrange
//        var dataSource = new TestDynamicDataSource();
//        var mementoMock = new Mock<IDisposable>();

//        // Similar to the Func version, would need refactoring for proper testing

//        // Act & Assert
//        // Verify memento is disposed
//    }

//    // Additional tests for edge cases
//    [Fact]
//    public void WithOptionalArgsCode_Func_ThrowsException_StillDisposesMemento()
//    {
//        // Arrange
//        var dataSource = new TestDynamicDataSource();
//        var argsCode = ArgsCode.Instance;
//        var mementoMock = new Mock<IDisposable>();

//        Func<string> testDataGenerator = () => throw new InvalidOperationException("Test exception");

//        // Act & Assert
//        Assert.Throws<InvalidOperationException>(() =>
//            WithOptionalArgsCode(dataSource, testDataGenerator, argsCode));

//        // Verify memento was disposed even when generator throws
//        // Would need refactoring to properly test this
//    }

//    [Fact]
//    public void WithOptionalArgsCode_Action_ThrowsException_StillDisposesMemento()
//    {
//        // Arrange
//        var dataSource = new TestDynamicDataSource();
//        var argsCode = ArgsCode.Properties;
//        var mementoMock = new Mock<IDisposable>();

//        Action testDataProcessor = () => throw new InvalidOperationException("Test exception");

//        // Act & Assert
//        Assert.Throws<InvalidOperationException>(() =>
//            WithOptionalArgsCode<TestDynamicDataSource, string>(dataSource, testDataProcessor, argsCode));

//        // Verify memento was disposed even when processor throws
//        // Would need refactoring to properly test this
//    }


////// Factory!
//[Fact]
//using System.Threading;

//public void WithOptionalArgsCode_UsesCorrectArgsCode()
//{
//    var ds = new TestDataSource();
//    ArgsCode? testCode = ArgsCode.Instance;
//    ArgsCode? usedCode = null;

//    var factory = new Func<DynamicDataSource, ArgsCode, IDisposable>((_, code) => {
//        usedCode = code;
//        return Mock.Of<IDisposable>();
//    });

//    WithOptionalArgsCode(ds, () => "test", testCode, factory);

//    Assert.Equal(testCode, usedCode);
//}

////////// Factory 2!
//public class Tests
//{
//    [Fact]
//    public void WithOptionalArgsCode_UsesFactoryCorrectly()
//    {
//        // Arrange
//        var mockDataSource = new Mock<DynamicDataSource>();
//        var mockDisposable = new Mock<IDisposable>();
//        var mockFactory = new Mock<IMementoFactory>();

//        mockFactory.Setup(f => f.Create(It.IsAny<DynamicDataSource>(), It.IsAny<ArgsCode>()))
//                  .Returns(mockDisposable.Object);

//        // Act
//        var result = WithOptionalArgsCode(
//            mockDataSource.Object,
//            () => "test",
//            ArgsCode.Instance,
//            mockFactory.Object);

//        // Assert
//        mockFactory.Verify(f => f.Create(mockDataSource.Object, ArgsCode.Instance), Times.Once);
//        mockDisposable.Verify(d => d.Dispose(), Times.Once);
//        Assert.Equal("test", result);
//    }
//}

////////// Final !
//[Fact]
//public void ReturnsGeneratorResult_WithArgsCode()
//{
//    var ds = new FakeDataSource();
//    var result = WithOptionalArgsCode(ds, () => 42, ArgsCode.Instance);
//    Assert.Equal(42, result);
//    // Verify side effects on ds if needed
//}
//}