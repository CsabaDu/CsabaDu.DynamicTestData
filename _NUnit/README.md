# CsabaDu.DynamicTestData.NUnit

`CsabaDu.DynamicTestData.NUnit` is a lightweight, robust type-safe C# library designed to facilitate dynamic data-driven testing in NUnit framework, by providing a simple and intuitive way to generate `TestCaseData` instances at runtime, based on `CsabaDu.DynamicTestData` features.

## Table of Contents

- [Description](#description)
- [Features](#features)
- [Types](#types)
  - [Static Extensions Class](#static-extensions-class)
  - [Abstract DynamicTestCaseDataSource Class](#abstract-dynamictestcasedatasource-class)

- [Usage](#usage)
- [Contributing](#contributing)
- [License](#license)
- [Contact](#contact)
- [FAQ](#faq)
- [Troubleshooting](#troubleshooting)

## Description

## Features

## Types

### Static `Extensions` Class

```csharp
using static CsabaDu.DynamicTestData.DynamicDataSources.DynamicDataSource;

namespace CsabaDu.DynamicTestData.NUnit.Statics;

public static class Extensions
{
    public static TestCaseData ToTestCaseData(this TestData testData, ArgsCode argsCode, string? testMethodName = null)
    => testData.ToTestCaseData(argsCode, 1).SetDescriptionAndName(testData.TestCase, testMethodName);

    public static TestCaseData ToTestCaseData<TStruct>(this TestDataReturns<TStruct> testData, ArgsCode argsCode, string? testMethodName = null)
    where TStruct : struct
    => testData.ToTestCaseData(argsCode, 2).SetDescriptionAndName(testData.TestCase, testMethodName).Returns(testData.Expected);

    private static TestCaseData ToTestCaseData(this TestData testData, ArgsCode argsCode, int index)
    => argsCode switch
    {
        ArgsCode.Instance => new(testData),
        ArgsCode.Properties => new(testData.ToArgs(argsCode)[index..]),
        _ => throw argsCode.GetInvalidEnumArgumentException(nameof(argsCode)),
    };

    private static TestCaseData SetDescriptionAndName(this TestCaseData testCaseData, string description, string? testMethodName)
    => string.IsNullOrEmpty(testMethodName) ?
        testCaseData.SetDescription(description)
        : testCaseData.SetDescription(description).SetName(GetDisplayName(testMethodName, description));
}
```

### Abstract `DynamicTestCaseDataSource` Class

```csharp
namespace CsabaDu.DynamicTestData.NUnit.DynamicDataSources;

public abstract class DynamicTestCaseDataSource(ArgsCode argsCode) : DynamicDataSource(argsCode)
{
    #region TestDataToTestCaseData
    public TestCaseData TestDataToTestCaseData<T1>(string definition, string expected, T1? arg1, string? testMethodName = null)
    => new TestData<T1>(definition, expected, arg1).ToTestCaseData(ArgsCode, testMethodName);

    public TestCaseData TestDataToTestCaseData<T1, T2>(string definition, string expected, T1? arg1, T2? arg2, string? testMethodName = null)
    => new TestData<T1, T2>(definition, expected, arg1, arg2).ToTestCaseData(ArgsCode, testMethodName);

    // TestDataToTestCaseData<> overloads here

    #endregion

    #region TestDataReturnsToTestCaseData
    public TestCaseData TestDataReturnsToTestCaseData<TStruct, T1>(string definition, TStruct expected, T1? arg1, string? testMethodName = null)
    where TStruct : struct
    => new TestDataReturns<TStruct, T1>(definition, expected, arg1).ToTestCaseData(ArgsCode, testMethodName);

    public TestCaseData TestDataReturnsToTestCaseData<TStruct, T1, T2>(string definition, TStruct expected, T1? arg1, T2? arg2, string? testMethodName = null)
    where TStruct : struct
    => new TestDataReturns<TStruct, T1, T2>(definition, expected, arg1, arg2)
        .ToTestCaseData(ArgsCode, testMethodName);

    // TestDataReturnsToTestCaseData<> overloads here

    #endregion

    #region TestDataThrowsToTestCaseData
    public TestCaseData TestDataThrowsToTestCaseData<TException, T1>(string definition, TException expected, T1? arg1, string? testMethodName = null)
    where TException : Exception
    => new TestDataThrows<TException, T1>(definition, expected, arg1).ToTestCaseData(ArgsCode, testMethodName);

    public TestCaseData TestDataThrowsToTestCaseData<TException, T1, T2>(string definition, TException expected, T1? arg1, T2? arg2, string? testMethodName = null)
    where TException : Exception
    => new TestDataThrows<TException, T1, T2>(definition, expected, arg1, arg2)
        .ToTestCaseData(ArgsCode, testMethodName);

    // TestDataThrowsToTestCaseData<> overloads here

    #endregion
    }
```

## Usage

```csharp
using CsabaDu.DynamicTestData.NUnit.DynamicDataSources;
using NUnit.Framework;

namespace CsabaDu.DynamicTestData.SampleCodes.DynamicDataSources;

public class TestDataToTestCaseDataSource(ArgsCode argsCode) : DynamicTestCaseDataSource(argsCode)
{
    private readonly DateTime DateTimeNow = DateTime.Now;

    private DateTime _thisDate;
    private DateTime _otherDate;

    public IEnumerable<TestCaseData> IsOlderReturnsTestCaseDataToList(string? testMethodName = null)
    {
        bool expected = true;
        _thisDate = DateTimeNow;
        _otherDate = DateTimeNow.AddDays(-1);
        string definition = "thisDate is greater than otherDate";
        yield return testDataToTestCaseData();

        expected = false;
        _otherDate = DateTimeNow;
        definition = "thisDate equals otherDate";
        yield return testDataToTestCaseData();

        _thisDate = DateTimeNow.AddDays(-1);
        definition = "thisDate is less than otherDate";
        yield return testDataToTestCaseData();

        #region Local methods
        TestCaseData testDataToTestCaseData()
        => TestDataReturnsToTestCaseData(definition, expected, _thisDate, _otherDate, testMethodName);
        #endregion
    }

    public IEnumerable<TestCaseData> IsOlderThrowsTestCaseDataToList(string? testMethodName = null)
    {
        string paramName = "otherDate";
        _thisDate = DateTimeNow;
        _otherDate = DateTimeNow.AddDays(1);
        yield return testDataToTestCaseData();

        paramName = "thisDate";
        _thisDate = DateTimeNow.AddDays(1);
        yield return testDataToTestCaseData();

        #region Local methods
        TestCaseData testDataToTestCaseData()
        => TestDataThrowsToTestCaseData(getDefinition(), getExpected(), _thisDate, _otherDate, testMethodName);

        string getDefinition()
        => $"{paramName} is greater than the current date";

        ArgumentOutOfRangeException getExpected()
        => new(paramName, DemoClass.GreaterThanCurrentDateTimeMessage);
        #endregion
    }
}
```

```csharp
using NUnit.Framework;

namespace CsabaDu.DynamicTestData.SampleCodes.NUnitSamples.TestCaseDataSamples;

[TestFixture]
public sealed class DemoClassTestsTestDataToTestCaseDataInstance
{
    private readonly DemoClass _sut = new();
    private static readonly TestDataToTestCaseDataSource DataSource = new(ArgsCode.Instance);

    private static IEnumerable<TestCaseData> IsOlderReturnsTestCaseDataToList()
    => DataSource.IsOlderReturnsTestCaseDataToList();

    private static IEnumerable<TestCaseData> IsOlderThrowsTestCaseDataToList()
    => DataSource.IsOlderThrowsTestCaseDataToList();

    [TestCaseSource(nameof(IsOlderReturnsTestCaseDataToList))]
    public bool IsOlder_validArgs_returnsExpected(TestDataReturns<bool, DateTime, DateTime> testData)
    {
        // Arrange & Act & Assert
        return _sut.IsOlder(testData.Arg1, testData.Arg2);
    }

    [TestCaseSource(nameof(IsOlderThrowsTestCaseDataToList))]
    public void IsOlder_invalidArgs_throwsException(TestDataThrows<ArgumentOutOfRangeException, DateTime, DateTime> testData)
    {
        // Arrange & Act
        void attempt() => _ = _sut.IsOlder(testData.Arg1, testData.Arg2);

        // Assert
        Assert.Multiple(() =>
        {
            var actual = Assert.Throws<ArgumentOutOfRangeException>(attempt);
            Assert.That(actual?.ParamName, Is.EqualTo(testData.Expected.ParamName));
            Assert.That(actual?.Message, Is.EqualTo(testData.Expected.Message));
        });
    }
}
```

```csharp
using NUnit.Framework;

namespace CsabaDu.DynamicTestData.SampleCodes.NUnitSamples.TestCaseDataSamples;

class DemoClassTestsTestDataToTestCaseDataProperties
{
    public sealed class DemoClassTestsPropertiesWithTestCaseData
    {
        private readonly DemoClass _sut = new();
        private static readonly TestDataToTestCaseDataSource DataSource = new(ArgsCode.Properties);

        private static IEnumerable<TestCaseData> IsOlderReturnsTestCaseDataToList()
        => DataSource.IsOlderReturnsTestCaseDataToList(nameof(IsOlder_validArgs_returnsExpected));

        private static IEnumerable<TestCaseData> IsOlderThrowsTestCaseDataToList()
        => DataSource.IsOlderThrowsTestCaseDataToList(nameof(IsOlder_invalidArgs_throwsException));

        [TestCaseSource(nameof(IsOlderReturnsTestCaseDataToList))]
        public bool IsOlder_validArgs_returnsExpected(DateTime thisDate, DateTime otherDate)
        {
            // Arrange & Act & Assert
            return _sut.IsOlder(thisDate, otherDate);
        }

        [TestCaseSource(nameof(IsOlderThrowsTestCaseDataToList))]
        public void IsOlder_invalidArgs_throwsException(ArgumentOutOfRangeException expected, DateTime thisDate, DateTime otherDate)
        {
            // Arrange & Act
            void attempt() => _ = _sut.IsOlder(thisDate, otherDate);

            // Assert
            Assert.Multiple(() =>
            {
                var actual = Assert.Throws<ArgumentOutOfRangeException>(attempt);
                Assert.That(actual?.ParamName, Is.EqualTo(expected.ParamName));
                Assert.That(actual?.Message, Is.EqualTo(expected.Message));
            });
        }
    }
}
```

## Contributing

Contributions are welcome! Please submit a pull request or open an issue if you have any suggestions or bug reports.

## License

This project is licensed under the MIT License. See the [License](LICENSE.txt) file for details.

## Contact

For any questions or inquiries, please contact [CsabaDu](https://github.com/CsabaDu).

## FAQ

## Troubleshooting

# **ÚJ**

# Dynamic Test Data for NUnit

This project provides a set of utilities for dynamically generating and managing test data in NUnit. It simplifies the process of creating parameterized tests by offering a flexible and extensible way to define test cases with various arguments, expected results, and exceptions.

## Features

- **Dynamic Test Data Generation**: Easily create test data for parameterized tests with support for up to nine arguments.
- **Support for Expected Results**: Define test cases with expected return values (for structs) or expected exceptions.
- **Flexible Argument Handling**: Use `ArgsCode` to control how arguments are passed to the test method (e.g., as properties or instances).
- **Integration with NUnit**: Seamlessly convert test data into NUnit's `TestCaseData` for use in parameterized tests.

## Installation

To use this library in your NUnit test project, add the following NuGet package:

```bash
dotnet add package CsabaDu.DynamicTestData.NUnit
```

## Usage

### 1. **Defining Test Data**

The `DynamicTestCaseDataSource` class provides methods to create test data for parameterized tests. You can define test cases with up to nine arguments, expected results, or expected exceptions.

#### Example: Creating Test Data

```csharp
var dataSource = new DynamicTestCaseDataSource(ArgsCode.Instance);

// Create a test case with one argument
var testCase = dataSource.TestDataToTestCaseData("Test case description", "Expected result", 42);

// Create a test case with multiple arguments
var multiArgTestCase = dataSource.TestDataToTestCaseData("Multi-argument test", "Expected result", 1, "arg2", 3.14);
```

### 2. **Using Test Data in NUnit Tests**

Once you have created the test data, you can use it in your NUnit tests by converting it to `TestCaseData`.

#### Example: Using Test Data in a Parameterized Test

```csharp
[TestFixture]
public class MyTests
{
    [Test, TestCaseSource(nameof(GetTestCases))]
    public void MyParameterizedTest(TestCaseData testCaseData)
    {
        // Extract arguments from the test case data
        var args = testCaseData.Arguments;

        // Perform the test
        var result = MyMethod(args[0], args[1], args[2]);

        // Assert the result
        Assert.AreEqual(testCaseData.ExpectedResult, result);
    }

    public static IEnumerable<TestCaseData> GetTestCases()
    {
        var dataSource = new DynamicTestCaseDataSource(ArgsCode.Instance);

        yield return dataSource.TestDataToTestCaseData("Test case 1", "Expected result 1", 1, "arg2", 3.14);
        yield return dataSource.TestDataToTestCaseData("Test case 2", "Expected result 2", 2, "arg2", 6.28);
    }
}
```

### 3. **Handling Expected Results and Exceptions**

You can define test cases with expected results (for structs) or expected exceptions.

#### Example: Test Case with Expected Result

```csharp
var dataSource = new DynamicTestCaseDataSource(ArgsCode.Instance);

// Create a test case with an expected result
var testCase = dataSource.TestDataReturnsToTestCaseData("Test case with expected result", 42, 1);
```

#### Example: Test Case with Expected Exception

```csharp
var dataSource = new DynamicTestCaseDataSource(ArgsCode.Instance);

// Create a test case with an expected exception
var exceptionTestCase = dataSource.TestDataThrowsToTestCaseData("Test case with expected exception", new ArgumentException(), 1);
```

### 4. **Customizing Test Case Names**

You can optionally provide a test method name to customize the display name of the test case.

#### Example: Custom Test Case Name

```csharp
var dataSource = new DynamicTestCaseDataSource(ArgsCode.Instance);

// Create a test case with a custom name
var testCase = dataSource.TestDataToTestCaseData("Test case description", "Expected result", 42, "MyTestMethod");
```

## API Reference

### `DynamicTestCaseDataSource`

- **Constructor**: `DynamicTestCaseDataSource(ArgsCode argsCode)`
  - Initializes a new instance of the `DynamicTestCaseDataSource` class with the specified `ArgsCode`.

#### Methods

- **TestDataToTestCaseData**: Converts test data to `TestCaseData` for tests with up to nine arguments.
  - Overloads for 1 to 9 arguments.
  - Example: `TestDataToTestCaseData<T1>(string definition, string expected, T1? arg1, string? testMethodName = null)`

- **TestDataReturnsToTestCaseData**: Converts test data to `TestCaseData` for tests with expected return values (for structs).
  - Overloads for 1 to 9 arguments.
  - Example: `TestDataReturnsToTestCaseData<TStruct, T1>(string definition, TStruct expected, T1? arg1, string? testMethodName = null)`

- **TestDataThrowsToTestCaseData**: Converts test data to `TestCaseData` for tests with expected exceptions.
  - Overloads for 1 to 9 arguments.
  - Example: `TestDataThrowsToTestCaseData<TException, T1>(string definition, TException expected, T1? arg1, string? testMethodName = null)`

### `Extensions`

- **ToTestCaseData**: Extension methods for converting `TestData`, `TestDataReturns`, and `TestDataThrows` to `TestCaseData`.
  - Example: `ToTestCaseData(this TestData testData, ArgsCode argsCode, string? testMethodName = null)`

## Contributing

Contributions are welcome! Please open an issue or submit a pull request for any improvements or bug fixes.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

---

This README provides an overview of the project and its usage. For more detailed examples and advanced usage, refer to the source code and unit tests.