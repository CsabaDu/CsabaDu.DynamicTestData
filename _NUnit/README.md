# CsabaDu.DynamicTestData.NUnit

`CsabaDu.DynamicTestData.NUnit` is a lightweight, robust type-safe C# framework designed to facilitate dynamic data-driven testing in NUnit framework, by providing a simple and intuitive way to generate `TestCaseData` instances or object arrays at runtime, based on `CsabaDu.DynamicTestData` features.

## Table of Contents

- [CsabaDu.DynamicTestData.NUnit](#csabadudynamictestdatanunit)
  - [Table of Contents](#table-of-contents)
  - [Description](#description)
  - [Features](#features)
  - [Quick Start](#quick-start)
  - [Types](#types)
    - [Extensions Static Class](#extensions-static-class)
    - [DynamicTestCaseDataSource Abstract Class](#dynamictestcasedatasource-abstract-class)
  - [How it Works](#how-it-works)
    - [Static Extensions Class](#static-extensions-class)
    - [Abstract DynamicTestCaseDataSource Class](#abstract-dynamictestcasedatasource-class)
  - [Usage](#usage)
    - [Sample DemoClass](#sample-democlass)
    - [Sample DynamicTestCaseDataSource Child Class](#sample-dynamictestcasedatasource-child-class)
    - [Sample Test Classes with TestCaseData Lists](#sample-test-classes-with-testcasedata-lists)
  - [Contributing](#contributing)
  - [License](#license)
  - [Contact](#contact)
  - [FAQ](#faq)
  - [Troubleshooting](#troubleshooting)

## Description

`CsabaDu.DynamicTestData.NUnit` framework provides a set of utilities for dynamically generating and managing test data, particularly in NUnit. It simplifies the process of creating parameterized tests by offering a flexible and extensible way to define test cases with various arguments, expected results, and exceptions, based on `CsabaDu.DynamicTestData`features and the `TestCaseData` type of NUnit.

## Features

1. **Inherited `CsabaDu.DynamicTestData` Features**:
  - Complete functionality of the `CsabaDu.DynamicTestData` framework is available as dependency.

2. **`TestCaseData` Type Support**:
  - The generic `TestData` record of `CsabaDu.DynamicTestData` framework and its derived types (`TestDataReturns`, `TestDataThrows`) which support up to nine arguments (`T1` to `T9`) are used for `TestCaseData` instances creation at runtime.

3. **`TestCaseData` Features Support**:
  - `TestCaseData` properties which are supported in particular:
    - `Description`,
    - `TestName` (optional),
    - `ExpectedResult` (if `struct` type).

4. **`Struct` Support**:
  - The `TestDataReturnsToTestCaseData` methods are designed for creating test cases that expect returning a struct (value type). It ensures that the expected result is a struct and sets the `ExpectedResult` property of the `TestCaseData` instances.

5. **`Exception` Support**:
  - The `TestDataThrows` type which is specifically designed for test cases that expect exceptions to be thrown can either be used to create `TestCaseData` instances.
  - It includes the expected exception type and any arguments required for the test.

6. **`DynamicTestCaseDataSource` Abstract Class**:
  - Provides methods (`TestDataToTestCaseData`, `TestDataReturnsToTestCaseData`, `TestDataThrowsToTestCaseData`) to convert test data into `TestCaseData` of NUnit for data-driven test methods.
  - Sets the `Description` and can set the `TestName` properties of the generated `TestCaseData` instances with the respective `TestData` property values, and the optionally injected test method name.
  - These methods use the `ArgsCode` enum of `CsabaDu.DynamicTestData` to determine if `TestcaseData` instances shall consist of `TestData` record instances or their properties.

7. **Dynamic Data Generation**:
  - Designed to easily generate `TestCaseData` instances dynamically.

8. **Type Safety**:
  - Ensures type safety for generated test data with using `TestData` generic types for `TestCaseData` instances creation.

9. **Thread Safety**:
  - The generated `TestData` record types' immutability ensures thread safety of tests with `TestCaseData`types too.

10. **Readability**:
  - The `TestName` property of the `TestCaseData` type can be set with a literal test description to display in Visual Studio Test Explorer.

11. **NUnit Integration**:
  - Easy to integrate with NUnit framework.
  - Seamlessly convert test data into NUnit's `TestCaseData` for use in parameterized tests.

12. **Portability**:
  - Besides NUnit support and dependency, easy to integrate with other test frameworks as well.

## Quick Start

1. **Install the NuGet package**:
  - You can install the `CsabaDu.DynamicTestData.NUnit` NuGet package from the NuGet Package Manager Console by running the following command:
     ```shell
     Install-Package CsabaDu.DynamicTestData.NUnit
     ```
 2. **Create a derived dynamic `TestCaseData` source class**:
  - Create one class for each test class separately that extends the `DynamicTestCaseDataSource` base class.
  - Implement `IEnumerable<TestCaseData>` returning type methods to generate test data.
  - Use the `TestDataToTestCaseData`, `TestDataReturnsToTestCaseData`, and `TestDataThrowsToTestCaseData` methods to create 'TestCaseData' instances within the methods.
  - (See the [Sample DynamicTestCaseDataSource  Child Class](#sample-dynamictestcasedatasource-child-class) section for a sample code.)

 3. **Insert the dynamic `TestCaseData` source instance in the test class**:
  - Declare a static instance of the derived `DynamicTestCaseDataSource` child class in the test class and initiate it with either `ArgsCode.Instance` or `ArgsCode.Properties` parameter.
  - Declare static `IEnumerable<TestCaseData>` methods to call the test data generated by the dynamic data source class.
  - Add the test method name as an optional parameter to the data source method to generate literal display name in Test Explorer.
  
 4. **Use dynamic `TestCaseData` source members in the test methods**:
  - Use the `TestCaseSource` attribute in NUnit to pass the test data to the test methods.
  - Initialize the attribute with the belonging dynamic data source member name.
  - (See the [Sample Test Classes with TestCaseData Lists](#sample-test-classes-with-testcasedata-lists) or section for sample codes.)

## Types

### **`Extensions` Static Class**
 - **Purpose**: Provides extension methods for converting `TestData` instances of `CsabaDu.DynamicTestData` framework to `TestCaseData` instances of NUnit framework.
 - **Methods**:
   - `ToTestCaseData(this TestData testData, ArgsCode argsCode, string? testMethodName = null)`: Converts an instance of `TestData` to `TestCaseData`.
   - `ToTestCaseData<TStruct>(this TestDataReturns<TStruct> testData, ArgsCode argsCode, string? testMethodName = null)`: Converts an instance of `TestDataReturns<TStruct>` to `TestCaseData`.
   
### **`DynamicTestCaseDataSource` Abstract Class**
 - **Purpose**: Represents an abstract base class for dynamic `TestCaseData` sources.
 - **Methods**:
   - `TestDataToTestCaseData<T1, T2, ..., T9>(...)`: Converts test data to `TestCaseData` instance with one to nine arguments.
   - `TestDataReturnsToTestCaseData<TStruct, T1, T2, ..., T9>(...)`: Converts test data to `TestCaseData` instance for tests that expect a struct to assert.
   - `TestDataThrowsToTestCaseData<TException, T1, T2, ..., T9>(...)`: Converts test data to `TestCaseData` instance for tests that throw exceptions.

## How it Works

This framework is the extension of [CsabaDu.DynamicTestData](https://github.com/CsabaDu/CsabaDu.DynamicTestData#csabadudynamictestdata) framework. If you are not familiar with that framework yet, learn more about it, especially about the [ArgsCode Enum](https://github.com/CsabaDu/CsabaDu.DynamicTestData#argscode-enum), the [ITestData Base Interfaces](https://github.com/CsabaDu/CsabaDu.DynamicTestData#itestdata-base-interfaces) and [TestData Record Types](https://github.com/CsabaDu/CsabaDu.DynamicTestData#testdata-record-types) of that.

### **Static `Extensions` Class**

`TestData` and `TestDataReturns<TStruct>` types are extended with two public methods to facilitate `TestCaseData` instances creation.

```csharp
using static CsabaDu.DynamicTestData.DynamicDataSources.DynamicDataSource;

namespace CsabaDu.DynamicTestData.NUnit.Statics;

public static class Extensions
{
    public static TestCaseData ToTestCaseData(this TestData testData, ArgsCode argsCode, string? testMethodName = null)
    => testData.ToTestCaseData(argsCode, 1).SetDescriptionAndTestName(testData.TestCase, testMethodName);

    public static TestCaseData ToTestCaseData<TStruct>(this TestDataReturns<TStruct> testData, ArgsCode argsCode, string? testMethodName = null)
    where TStruct : struct
    => testData.ToTestCaseData(argsCode, 2).SetDescriptionAndTestName(testData.TestCase, testMethodName).Returns(testData.Expected);

    #region Private methods
    private static TestCaseData ToTestCaseData(this TestData testData, ArgsCode argsCode, int index)
    => argsCode switch
    {
        ArgsCode.Instance => new(testData),
        ArgsCode.Properties => new(testData.ToArgs(argsCode)[index..]),
        _ => throw argsCode.GetInvalidEnumArgumentException(nameof(argsCode)),
    };

    private static TestCaseData SetDescriptionAndTestName(this TestCaseData testCaseData, string testCase, string? testMethodName)
    => testCaseData.SetDescription(testCase).SetName(GetDisplayNameOrNull(testMethodName, testCase));

    private static string? GetDisplayNameOrNull(string? testMethodName, string testCase)
    => string.IsNullOrEmpty(testMethodName) ? null : GetDisplayName(testMethodName, testCase);
    #endregion
}
```

Besides the `TestData`-child instances which call these, the methods require two parameters: `ArgsCode argsCode`, and an optional `string? testMethodName = null`.

In case of `Properties` value of the first `ArgsCode` argument, the methods create a `TestCaseData` instance of properties of the `TestData` instance, in case of `Instance` value they create a `TestCaseData` of the `TestData`-derived instance itself, otherwise it throws an `InvalidEnumArgumentException`.

The methods set the `Description` property with the value of the `TestCase` property of the `TestData` instance, and in case of `ArgsCode.Properties` value of the first argument, the test data of the `TestCaseData` instance excludes the first element of the `TestDataToTestCaseData`-method generated object array (`TestCase`).

Second parameter is `string` type and is optional. Adding this parameter with notnull and not-empty-string value triggers the setting of the `TestName` property of the `TestCaseData` returning instance, using the `DynamicDataSource.GetDisplayName` method, otherwise remains default. The value of the `TestName` propery will be displayed in Visual Studio Test Explorer if set.

The extension method of `TestDataReturns<TStruct>` type sets the `ExpectedResult` property of the returning `TestCaseData` instance with the value of the `Expected` property of the `TestDataReturns<TStruct>` instance, and in case of `ArgsCode.Properties` value of the first argument, the test data of the `TestCaseData` instance excludes the first two elements of the `TestDataReturnsToTestCaseData`-method generated object array (`TestCase` and `Expected`).

### **Abstract `DynamicTestCaseDataSource` Class**

This class extends the abstract `DynamicDataSource` class of `CsabaDu.DynamicTestData` framework. (To learn more about the base class, see [Abstract DynamicDataSource Class](https://github.com/CsabaDu/CsabaDu.DynamicTestData/?tab=readme-ov-file#abstract-dynamicdatasource-class).)

This class contains the methods to create `TestCaseData` instances from the `TestData` types of `CsabaDu.DynamicTestData` framework. (To learn more about the `TestData` types of `CsabaDu.DynamicTestData`, see [ITestData Base Interfaces](https://github.com/CsabaDu/CsabaDu.DynamicTestData/#itestdata-base-interfaces) and [TestData Record Types](https://github.com/CsabaDu/CsabaDu.DynamicTestData/#testdata-record-types).) Once you call a `TestCaseData` generator method of the class, you create a new `TestData` child instance inside and call its `ToTestCaseData(ArgsCode argsCode, string? testMethod = null)` extension method.

Pattern of the methods is the same as the object array generator methods of the parent `DynamicDataSource` class, as well as the intended usage of it:

- extend this class for each test class separately,
- implement the necessary specific methods in the derived class with `IEnumerable<TestCaseData>` returning types, and
- declare a static instance of the derived class in the test class where it is going to be used.

Last argument of the methods of this class is `string? testMethodName = null` optional parameter. This will be passed to the `ToTestCaseData` method inside the `TestCaseData` generator methods.

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
    => new TestDataReturns<TStruct, T1, T2>(definition, expected, arg1, arg2).ToTestCaseData(ArgsCode, testMethodName);

    // TestDataReturnsToTestCaseData<> overloads here

    #endregion

    #region TestDataThrowsToTestCaseData
    public TestCaseData TestDataThrowsToTestCaseData<TException, T1>(string definition, TException expected, T1? arg1, string? testMethodName = null)
    where TException : Exception
    => new TestDataThrows<TException, T1>(definition, expected, arg1).ToTestCaseData(ArgsCode, testMethodName);

    public TestCaseData TestDataThrowsToTestCaseData<TException, T1, T2>(string definition, TException expected, T1? arg1, T2? arg2, string? testMethodName = null)
    where TException : Exception
    => new TestDataThrows<TException, T1, T2>(definition, expected, arg1, arg2).ToTestCaseData(ArgsCode, testMethodName);

    // TestDataThrowsToTestCaseData<> overloads here

    #endregion
}
```

## Usage

Here are some basic examples of how to use `CsabaDu.DynamicTestData.NUnit` in your project.

### **Sample `DemoClass`**

The following `bool IsOlder(DateTime thisDate, DateTime otherDate)` method of the `DemoClass` is going to be the subject of the below sample dynamic data source and test method codes.

The method compares two `DateTime` type arguments and returns `true` if the first is greater than the second one, otherwise `false`. The method throws an `ArgumentOutOfRangeException` if either argument is greater than the current date.

This demo class is the same as used in the [Sample DemoClass](https://github.com/CsabaDu/CsabaDu.DynamicTestData/tree/master#sample-democlass) `CsabaDu.DynamicTestData` sample codes, to help you compare the implementations of the dynamic data sources and test classes of the different `CsabaDu.DynamicTestData` frameworks with each other

```csharp
namespace CsabaDu.DynamicTestData.SampleCodes;

public class DemoClass
{
    public const string GreaterThanCurrentDateTimeMessage
        = "The DateTime parameter cannot be greater than the current date and time.";

    public bool IsOlder(DateTime thisDate, DateTime otherDate)
    {
        if (thisDate <= DateTime.Now && otherDate <= DateTime.Now)
        {
            return thisDate > otherDate;
        }

        throw new ArgumentOutOfRangeException(getParamName(), GreaterThanCurrentDateTimeMessage);

        #region Local methods
        string getParamName()
        => thisDate > DateTime.Now ? nameof(thisDate) : nameof(otherDate);
        #endregion
    }
}
```

### **Sample `DynamicTestCaseDataSource` Child Class**

You can easily implement a dynamic `TestCaseData` source class by extending the `DynamicTestCaseDataSource` base class with `IEnumerable<TestCaseData>` type data source methods. You can use these just in NUnit test framework.

The derived dynamic `TestCaseData` source class looks quite similar to the sample [Test Framework Independent Dynamic Data Source](https://github.com/CsabaDu/CsabaDu.DynamicTestData/tree/master?tab=readme-ov-file#test-framework-independent-dynamic-data-source) of `CsabaDu.DynamicTestData`:

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
### **Sample Test Classes with `TestCaseData` Lists**

Find test class sample codes for using `TestData` instance's array as `TesCaseData` parameter:  

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

Find test class sample codes for using `TestData` properties' array as `TesCaseData` parameter:  

```csharp
using NUnit.Framework;

namespace CsabaDu.DynamicTestData.SampleCodes.NUnitSamples.TestCaseDataSamples;

[TestFixture]
class DemoClassTestsTestDataToTestCaseDataProperties
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
```

## Contributing

Contributions are welcome! Please submit a pull request or open an issue if you have any suggestions or bug reports.

## License

This project is licensed under the MIT License. See the [License](LICENSE.txt) file for details.

## Contact

For any questions or inquiries, please contact [CsabaDu](https://github.com/CsabaDu).

## FAQ

- **How do I install the framework?**
  You can install it via NuGet Package Manager using `Install-Package CsabaDu.DynamicTestData.NUnit`.

 - **Does the framework support strongly typed generic `TestCaseData` types?**
  No, `CsabaDu.DynamicTestData.NUnit` does not support those types because of incompatibility of the type parameter counts: While `TestData` supports 9 type paramemters (on top of `struct` and `Exception` types of the special derived types), `TestCaseData` supports max. 5 type parameters only. Besides, note that the used generic `TestData` types are strongly typed ones themselves and that can ensure test parameters' type safety yet.

## Troubleshooting
