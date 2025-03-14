/* 
 * MIT License
 * 
 * Copyright (c) 2025. Csaba Dudas (CsabaDu)
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */
using CsabaDu.DynamicTestData.xUnit.DynamicDataSources;
using static CsabaDu.DynamicTestData.xUnit.Tests.TheoryDataSources.DynamicTheoryDataSourceTheoryData;

namespace CsabaDu.DynamicTestData.xUnit.Tests.UnitTests
{
    //public sealed class DynamicTheoryDataSourceTests : IDisposable
    //{
    //    public DynamicTheoryDataSourceTests()
    //    {
    //        _sutProperties = new(ArgsCode.Properties);
    //        _sutInstance = new(ArgsCode.Instance);
    //    }

    //    private DynamicTheoryDataSourceChild _sutProperties;
    //    private DynamicTheoryDataSourceChild _sutInstance;

    //    public void Dispose()
    //    {
    //        _sutProperties = null;
    //        _sutInstance = null;
    //    }


    //    [Theory, MemberData(nameof(AddTestDataToTheoryData1ArgsPropertiesTheoryData), MemberType = typeof(DynamicTheoryDataSourceTheoryData))]
    //    public void AddTestDataToTheoryData_Instance_AddsTestData(TheoryData<int> expected, int expectedCount)
    //    {
    //        // Arrange

    //        // Act
    //        _sutProperties.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1);
    //        var actual = _sutProperties.GetTheoryData();

    //        // Assert
    //        Assert.Equal(expected, actual);
    //        Assert.Equal(expectedCount, actual.Count);
    //    }

    //    [Fact]
    //    public void AddTestDataToTheoryData_Properties_AddsArgument()
    //    {
    //        // Arrange
    //        var dataSource = new DynamicTheoryDataSourceChild(ArgsCode.Properties);
    //        int arg1 = 42;

    //        // Act
    //        dataSource.AddTestDataToTheoryData("Test Definition", "Expected Result", arg1);
    //        var actual = dataSource.GetTheoryData();
    //        //var element = (actual as IEnumerable<int?>).First();

    //        // Assert
    //        Assert.NotNull(actual);
    //        Assert.IsType<TheoryData<int>>(actual);
    //        Assert.Single(actual);
    //        //Assert.Equal(arg1, element);
    //    }
    //}

    public class DynamicTheoryDataSourceTests1 : IDisposable
    {
        public void Dispose()
        {
            _sutInstance = new(ArgsCode.Instance);
            _sutProperties = new(ArgsCode.Properties);
        }

        private DynamicTheoryDataSourceChild _sutInstance = new(ArgsCode.Instance);
        private DynamicTheoryDataSourceChild _sutProperties = new(ArgsCode.Properties);

        #region Constructor tests
        [Theory, MemberData(nameof(ArgsCodesTheoryData), MemberType = typeof(DynamicTheoryDataSourceTheoryData))]
        public void Constructor_validArg_ArgsCode_createsInstance(ArgsCode argsCode)
        {
            // Arrange & Act
            var sut = new DynamicTheoryDataSourceChild(argsCode);

            // Assert
            Assert.NotNull(sut);
            Assert.IsType<DynamicTheoryDataSource>(sut, exactMatch: false);
        }

        [Fact]
        public void Constructor_invalidArg_ArgsCode_throwsInvalidEnumArgumentException()
        {
            // Arrange & Act
            static void attempt() => _ = new DynamicTheoryDataSourceChild(InvalidArgsCode);

            // Assert
            _ = Assert.Throws<InvalidEnumArgumentException>(attempt);
        }
        #endregion

        #region ResetTheoryData
        [Fact]
        public void ResetTheoryData_SetsTheoryDataToNull()
        {
            // Arrange
            _sutInstance.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1);

            // Act
            _sutInstance.ResetTheoryData();

            // Assert
            Assert.Null(_sutInstance.GetTheoryData());
        }
        #endregion

        #region GetArgumentsMismatchMessage
        [Fact]
        public void GetArgumentsMismatchMessage_ReturnsCorrectMessage()
        {
            // Arrange
            string actualTypeName = typeof(TheoryData<int>).Name;
            string expectedTypeName = typeof(TheoryData<TheoryData<TestData<int>>>).Name;
            _sutInstance.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1);
            string expectedSubString
                = $"Arguments are suitable for creating {actualTypeName} elements " +
                  $"and do not match with the initiated {expectedTypeName} instance's type parameters.";

            // Act
            var actualString = _sutInstance.GetArgumentsMismatchMessage<TheoryData<int>>();

            // Assert
            Assert.Contains(expectedSubString, actualString);
        }
        #endregion

        #region AddTestDataToTheoryData
        [Fact]
        public void AddTestDataToTheoryData_SingleArgument_Instance()
        {
            _sutInstance.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1);
            var theoryData = _sutInstance.GetTheoryData();
            Assert.IsType<TheoryData<TestData<int>>>(theoryData);
            Assert.Single(theoryData);
        }

        [Fact]
        public void AddTestDataToTheoryData_SingleArgument_Properties()
        {
            _sutProperties.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1);
            var theoryData = _sutProperties.GetTheoryData();
            Assert.IsType<TheoryData<int>>(theoryData);
            Assert.Single(theoryData);
        }

        [Fact]
        public void AddTestDataToTheoryData_MultipleArguments_Instance()
        {
            _sutInstance.AddTestDataToTheoryData("Test", "Expected", 1, "arg2", 3.14);
            var theoryData = _sutInstance.GetTheoryData();
            Assert.NotNull(theoryData);
            Assert.Single(theoryData);
        }

        [Fact]
        public void AddTestDataToTheoryData_MultipleArguments_Properties()
        {
            _sutProperties.AddTestDataToTheoryData("Test", "Expected", 1, "arg2", 3.14);
            var theoryData = _sutProperties.GetTheoryData();
            Assert.NotNull(theoryData);
            Assert.Single(theoryData);
        }

        [Fact]
        public void AddTestDataReturnsToTheoryData_SingleArgument_Instance()
        {
            _sutInstance.AddTestDataReturnsToTheoryData("Test", 42, 1);
            var theoryData = _sutInstance.GetTheoryData();
            Assert.NotNull(theoryData);
            Assert.Single(theoryData);
        }

        [Fact]
        public void AddTestDataReturnsToTheoryData_SingleArgument_Properties()
        {
            _sutProperties.AddTestDataReturnsToTheoryData("Test", 42, 1);
            var theoryData = _sutProperties.GetTheoryData();
            Assert.NotNull(theoryData);
            Assert.Single(theoryData);
        }

        [Fact]
        public void AddTestDataThrowsToTheoryData_SingleArgument_Instance()
        {
            _sutInstance.AddTestDataThrowsToTheoryData("Test", new ArgumentException(), 1);
            var theoryData = _sutInstance.GetTheoryData();
            Assert.NotNull(theoryData);
            Assert.Single(theoryData);
        }

        [Fact]
        public void AddTestDataThrowsToTheoryData_SingleArgument_Properties()
        {
            _sutProperties.AddTestDataThrowsToTheoryData("Test", new ArgumentException(), 1);
            var theoryData = _sutProperties.GetTheoryData();
            Assert.NotNull(theoryData);
            Assert.Single(theoryData);
        }

        [Fact]
        public void AddTestDataThrowsToTheoryData_MultipleArguments_Instance()
        {
            _sutInstance.AddTestDataThrowsToTheoryData("Test", new ArgumentException(), 1, "arg2", 3.14);
            var theoryData = _sutInstance.GetTheoryData();
            Assert.NotNull(theoryData);
            Assert.Single(theoryData);
        }

        [Fact]
        public void AddTestDataThrowsToTheoryData_MultipleArguments_Properties()
        {
            _sutProperties.AddTestDataThrowsToTheoryData("Test", new ArgumentException(), 1, "arg2", 3.14);
            var theoryData = _sutProperties.GetTheoryData();
            Assert.NotNull(theoryData);
            Assert.Single(theoryData);
        }
        #endregion
    }
}
