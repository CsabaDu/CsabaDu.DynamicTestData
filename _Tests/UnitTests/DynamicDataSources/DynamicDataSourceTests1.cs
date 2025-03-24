//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace CsabaDu.DynamicTestData.Tests.UnitTests.DynamicDataSources;

//using Xunit;
//using System;

//public class DynamicDataSourceTests1
//{
//    // Assuming ArgsCode is an enum like this:

//    [Fact]
//    public void Constructor_SetsDefaultArgsCode()
//    {
//        ArgsCode expectedCode = default;
//        var dataSource = new DynamicDataSourceChild(expectedCode);

//        Assert.Equal(expectedCode, dataSource.GetArgsCode());
//    }

//    [Fact]
//    public void ArgsCode_ReturnsDefaultWhenNoOverrideSet()
//    {
//        ArgsCode defaultCode = default;
//        var dataSource = new DynamicDataSourceChild(defaultCode);

//        Assert.Equal(defaultCode, dataSource.GetArgsCode());
//    }

//    [Fact]
//    public void FlexibleTestDataToArgs_UsesDefaultArgsCodeWhenNoneProvided()
//    {
//        ArgsCode defaultCode = default;
//        var dataSource = new DynamicDataSourceChild(defaultCode);
//        var testData = new object[] { 1, "test" };

//        var result = dataSource.FlexibleTestDataToArgs(() => testData, null);

//        Assert.Equal(testData, result);
//        Assert.Equal(defaultCode, dataSource.ArgsCode);
//    }

//    [Fact]
//    public void FlexibleTestDataToArgs_TemporarilyUsesProvidedArgsCode()
//    {
//        var defaultCode = ArgsCode.Default;
//        var tempCode = ArgsCode.Temporary;
//        var dataSource = new DynamicDataSourceChild(defaultCode);
//        var testData = new object[] { 1, "test" };
//        bool wasInsideTest = false;

//        var result = dataSource.FlexibleTestDataToArgs(() =>
//        {
//            wasInsideTest = true;
//            Assert.Equal(tempCode, dataSource.ArgsCode);
//            return testData;
//        }, tempCode);

//        Assert.True(wasInsideTest);
//        Assert.Equal(testData, result);
//        Assert.Equal(defaultCode, dataSource.ArgsCode);
//    }

//    [Fact]
//    public void FlexibleTestDataToArgs_RestoresArgsCodeAfterException()
//    {
//        var defaultCode = ArgsCode.Default;
//        var tempCode = ArgsCode.Temporary;
//        var dataSource = new DynamicDataSourceChild(defaultCode);
//        var expectedException = new Exception("Test error");

//        var actualException = Assert.Throws<Exception>(() =>
//            dataSource.FlexibleTestDataToArgs(() => throw expectedException, tempCode));

//        Assert.Equal(expectedException.Message, actualException.Message);
//        Assert.Equal(defaultCode, dataSource.ArgsCode);
//    }

//    [Fact]
//    public void DisposableDataSourceMemento_SetsAndRestoresArgsCode()
//    {
//        var defaultCode = ArgsCode.Default;
//        var dataSource = new DynamicDataSourceChild(defaultCode);
//        var firstOverride = ArgsCode.Override1;
//        var secondOverride = ArgsCode.Override2;

//        // Set initial override
//        using (var m1 = new DynamicDataSource.DisposableDataSourceMemento(dataSource, firstOverride))
//        {
//            Assert.Equal(firstOverride, dataSource.ArgsCode);

//            // Nested override
//            using (var m2 = new DynamicDataSource.DisposableDataSourceMemento(dataSource, secondOverride))
//            {
//                Assert.Equal(secondOverride, dataSource.ArgsCode);
//            }

//            // Should return to first override after disposing m2
//            Assert.Equal(firstOverride, dataSource.ArgsCode);
//        }

//        // Should return to default after disposing m1
//        Assert.Equal(defaultCode, dataSource.ArgsCode);
//    }

//    [Fact]
//    public void DisposableDataSourceMemento_IsIdempotentOnMultipleDispose()
//    {
//        var defaultCode = ArgsCode.Default;
//        var dataSource = new DynamicDataSourceChild(defaultCode);
//        var overrideCode = ArgsCode.Override1;

//        // Get original value
//        var originalValue = dataSource.ArgsCode;

//        var memento = new DynamicDataSource.DisposableDataSourceMemento(dataSource, overrideCode);

//        Assert.Equal(overrideCode, dataSource.ArgsCode);

//        memento.Dispose();
//        Assert.Equal(originalValue, dataSource.ArgsCode);

//        // Second dispose should be harmless
//        memento.Dispose();
//        Assert.Equal(originalValue, dataSource.ArgsCode);
//    }
//}