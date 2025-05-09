# CsabaDu.DynamicTestData.NUnit

`CsabaDu.DynamicTestData.NUnit` is a lightweight, robust type-safe C# framework designed to facilitate dynamic data-driven testing particularly in NUnit framework, by providing a simple and intuitive way to generate `TestCaseData` instances or object arrays at runtime, based on `CsabaDu.DynamicTestData` features.

## Table of Contents

- [**Description**](#description)
- [**What's New?**](#whats-new)
- [**Features**](#features)
- [**Quick Start**](#quick-start)
- [**Types**](#types)
- [**How it Works**](#how-it-works)
  - [Extensions Static Class](#extensions-static-class)
  - [DynamicTestCaseDataSource Abstract Class](#dynamictestcasedatasource-abstract-class)
- [**Usage**](#usage)
  - [Sample DemoClass](#sample-democlass)
  - [Sample DynamicTestCaseDataSource Child Class](#sample-dynamictestcasedatasource-child-class)
  - [Sample Test Classes with TestCaseData Lists](#sample-test-classes-with-testcasedata-lists)
- [**Changelog**](#changelog) 
- [**Contributing**](#contributing)
- [**License**](#license)
- [**Contact**](#contact)
- [**FAQ**](#faq)
- [**Troubleshooting**](#troubleshooting)

## Description

`CsabaDu.DynamicTestData.NUnit` framework provides a set of utilities for dynamically generating and managing test data, particularly in NUnit. It simplifies the process of creating parameterized tests by offering a flexible and extensible way to define test cases with various arguments, expected results, and exceptions, based on `CsabaDu.DynamicTestData`features and the `TestCaseData` type of NUnit.

## What's New?

### **Version 1.1.0**

- **New Feature**: Enhanced flexibility in generating exceptionally different `TestCaseData` instances with optional `ArgsCode?` parameter.

- **Compatibility**: This update is fully backward-compatible with previous versions. Existing solutions will continue to work without any changes.

## Features
(Updated v1.1.0)

**Inherited `CsabaDu.DynamicTestData` Features**:
- Complete functionality of the `CsabaDu.DynamicTestData` framework is available as dependency.

**`TestCaseData` Type Support**:
- The generic `TestData` record of `CsabaDu.DynamicTestData` framework and its derived types (`TestDataReturns`, `TestDataThrows`) which support up to nine arguments (`T1` to `T9`) are used for `TestCaseData` instances creation at runtime.

**`TestCaseData` Features Support**:
- `TestCaseData` properties which are supported in particular:
  - `Description`,
  - `TestName` (optional),
  - `ExpectedResult` (if `struct` type).

**`Struct` Support**:
- The `TestDataReturnsToTestCaseData` methods are designed for creating test cases that expect returning a struct (value type). It ensures that the expected result is a struct and sets the `ExpectedResult` property of the `TestCaseData` instances.

**`Exception` Support**:
- The `TestDataThrows` type which is specifically designed for test cases that expect exceptions to be thrown can either be used to create `TestCaseData` instances.
- It includes the expected exception type and any arguments required for the test.

**`DynamicTestCaseDataSource` Abstract Class** (Updated v1.1.0):
- Provides methods (`TestDataToTestCaseData`, `TestDataReturnsToTestCaseData`, `TestDataThrowsToTestCaseData`) to convert test data into `TestCaseData` of NUnit for data-driven test methods.
- Sets the `Description` and can set the `TestName` properties of the generated `TestCaseData` instances with the respective `TestData` property values, and the optionally injected test method name.
- These methods use the `ArgsCode` enum of `CsabaDu.DynamicTestData` to determine if `TestcaseData` instances shall consist of `TestData` record instances or their properties.
- The `OptionalToTestCaseData` method makes possible the thread-safe temporary overriding of the original (default) `ArgsCode` property value. (New v1.1.0)

**Dynamic Data Generation**:
- Designed to easily generate `TestCaseData` instances dynamically.

**Type Safety**:
- Ensures type safety for generated test data with using `TestData` generic types for `TestCaseData` instances creation.

**Thread Safety**:
- The generated `TestData` record types' immutability ensures thread safety of tests with `TestCaseData`types too.

**Readability**:
- The `TestName` property of the `TestCaseData` type can be set with a literal test description to display in Visual Studio Test Explorer.

**NUnit Integration**:
- Easy to integrate with NUnit framework.
- Seamlessly convert test data into NUnit's `TestCaseData` for use in parameterized tests.

**Portability**:
- Besides NUnit support and dependency, easy to integrate with other test frameworks as well.

**Enhanced Flexibility** (New v1.1.0):
- You can generate exceptionally different `TestCaseData` lists in the same test method with optional `ArgsCode?` parameter.

## Quick Start
(Updated v1.1.0)

1. **Install the NuGet package**:
  - You can install the `CsabaDu.DynamicTestData.NUnit` NuGet package from the NuGet Package Manager Console by running the following command:
     ```shell
     Install-Package CsabaDu.DynamicTestData.NUnit
     ```
 2. **Create a derived dynamic `TestCaseData` source class**:
  - Create one class for each test class separately that extends the `DynamicTestCaseDataSource` base class.
  - Implement `IEnumerable<TestCaseData>` returning type methods to generate test data.
  - Use the `TestDataToTestCaseData`, `TestDataReturnsToTestCaseData`, and `TestDataThrowsToTestCaseData` methods to create 'TestCaseData' instances within the methods.
  - Use the `OptionalToArgs` method along with the `TestCaseData` generating methods. (New v1.1.0)
  - (See the [Sample DynamicTestCaseDataSource  Child Class](#sample-dynamictestcasedatasource-child-class) section for a sample code.)

 3. **Insert the dynamic `TestCaseData` source instance in the test class**:
  - Declare a static instance of the derived `DynamicTestCaseDataSource` child class in the test class and initiate it with either `ArgsCode.Instance` or `ArgsCode.Properties` parameter.
  - Declare static `IEnumerable<TestCaseData>` methods to call the test data generated by the dynamic data source class.
  - Add the test method name as an optional parameter to the data source method to generate literal display name in Test Explorer.
  - Override the default `ArgsCode` value of any data source method by adding `ArgsCode`parameter to the called method. (New v1.1.0)

 4. **Use dynamic `TestCaseData` source members in the test methods**:
  - Use the `TestCaseSource` attribute in NUnit to pass the test data to the test methods.
  - Initialize the attribute with the belonging dynamic data source member name.
  - (See the [Sample Test Classes with TestCaseData Lists](#sample-test-classes-with-testcasedata-lists) or section for sample codes.)

## Types
(Updated v1.1.0)

### **`Extensions` Static Class**
 - **Purpose**: Provides extension methods for converting `TestData` instances of `CsabaDu.DynamicTestData` framework to `TestCaseData` instances of NUnit framework.
 - **Methods**:
   - `ToTestCaseData(this TestData testData, ArgsCode argsCode, string? testMethodName = null)`: Converts an instance of `TestData` to `TestCaseData`.
   - `ToTestCaseData<TStruct>(this TestDataReturns<TStruct> testData, ArgsCode argsCode, string? testMethodName = null)`: Converts an instance of `TestDataReturns<TStruct>` to `TestCaseData`.

### **`DynamicTestCaseDataSource` Abstract Class**
 - **Purpose**: Represents an abstract base class for dynamic `TestCaseData` sources.
 - **Methods**:
   - `OptionalToTestCaseData(Func<TestCaseData> testDataToTestCaseData, ArgsCode? argsCode)`: Executes the provided `TestCaseData` function with an optional temporary ArgsCode override. (New v1.1.0) 
   - `TestDataToTestCaseData<T1, T2, ..., T9>(...)`: Converts test data to `TestCaseData` instance with one to nine arguments.
   - `TestDataReturnsToTestCaseData<TStruct, T1, T2, ..., T9>(...)`: Converts test data to `TestCaseData` instance for tests that expect a struct to assert.
   - `TestDataThrowsToTestCaseData<TException, T1, T2, ..., T9>(...)`: Converts test data to `TestCaseData` instance for tests that throw exceptions.

## How it Works
(Updated v1.1.0)

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
(Updated v1.1.0)

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
    #region Code adjustments v1.1.0
    public TestCaseData OptionalToTestCaseData(Func<TestCaseData> testDataToTestCaseData, ArgsCode? argsCode)
    {
        ArgumentNullException.ThrowIfNull(testDataToTestCaseData, nameof(testDataToTestCaseData));
        return WithOptionalArgsCode(this, testDataToTestCaseData, argsCode);
    }
    #endregion

    #endregion

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

#### **`OptionalToTestCaseData` Method**
(New v1.1.0)

The function of this method is to invoke the `TestCaseData` generator `TestDataToTestCaseData`, `TestDataReturnsToTestCaseData` or `TestDataThrowsToTestCaseData` method given as `Func<TestCaseData>` parameter to its signature. If the second optional `ArgsCode?` parameter is not null, the ArgsCode value of the initialized `DynamicTestCaseDataSource` child instance will be overriden temporarily in a using block of the DisposableMemento class. Note that overriding the default `ArgsCode` is expensive so apply for it just occasionally. However, using this method with null value `ArgsCode?` parameter does not have significant impact on the performance yet.

## Usage
(Updated v1.1.0)

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
(Updated v1.1.0)

You can easily implement a dynamic `TestCaseData` source class by extending the `DynamicTestCaseDataSource` base class with `IEnumerable<TestCaseData>` type data source methods. You can use these just in NUnit test framework. You can easily adjust your already existing data source methods you used with version 1.0.x yet to have the benefits of the new feature (see comments in the sample code):

1. Add an optional `ArgsCode?` parameter to the data source methods signature.
2. Add `optionalToTestCaseData` local method to the enclosing data source methods and call `OptionalToTestCaseData` method with the `testDataToTestCaseData` and `argsCode` parameters.
3. Call `optionalToTestCaseData` local method to generate `TestCaseData` instances with data-driven test arguments .

However, note that this version is fully compatible backward, you can use the data source test classes and methods with the current version without any necessary change. The second data source method of the sample code remained unchanged as simpler but less flexible implememtation.

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

    // 1. Add an optional 'ArgsCode?' parameter to the method signature.
    public IEnumerable<TestCaseData> IsOlderReturnsTestCaseDataToList(string? testMethodName = null, ArgsCode? argsCode = null)
    {
        bool expected = true;
        string definition = "thisDate is greater than otherDate";
        _thisDate = DateTimeNow;
        _otherDate = DateTimeNow.AddDays(-1);
        // 3. Call 'optionalToTestCaseData' method.
        yield return optionalToTestCaseData();

        expected = false;
        definition = "thisDate equals otherDate";
        _otherDate = DateTimeNow;
        // 3. Call 'optionalToTestCaseData' method.
        yield return optionalToTestCaseData();

        definition = "thisDate is less than otherDate";
        _thisDate = DateTimeNow.AddDays(-1);
        // 3. Call 'optionalToTestCaseData' method.
        yield return optionalToTestCaseData();

        #region Local methods
        // 2. Add 'optionalToTestCaseData' local method to the enclosing method
        // and call 'OptionalToTestCaseData' method with the testDataToTestCaseData and argsCode parameters.
        TestCaseData optionalToTestCaseData()
        => OptionalToTestCaseData(testDataToTestCaseData, argsCode);

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
(Updated v1.1.0)

Find test class sample codes for using `TestData` instance's array as `TesCaseData` parameter:  

```csharp
using NUnit.Framework;

namespace CsabaDu.DynamicTestData.SampleCodes.NUnitSamples.TestCaseDataSamples;

[TestFixture]
public sealed class DemoClassTestsTestDataToTestCaseDataInstance
{
    private readonly DemoClass _sut = new();
    private static readonly TestDataToTestCaseDataSource DataSource = new(ArgsCode.Instance);

    // ArgsCode Overriden
    private static IEnumerable<TestCaseData> IsOlderReturnsTestCaseDataToList()
    => DataSource.IsOlderReturnsTestCaseDataToList(nameof(IsOlder_validArgs_returnsExpected), ArgsCode.Properties);

    private static IEnumerable<TestCaseData> IsOlderThrowsTestCaseDataToList()
    => DataSource.IsOlderThrowsTestCaseDataToList();

    [TestCaseSource(nameof(IsOlderReturnsTestCaseDataToList))]
    public bool IsOlder_validArgs_returnsExpected(DateTime thisDate, DateTime otherDate)
    {
        // Arrange & Act & Assert
        return _sut.IsOlder(thisDate, otherDate);
    }

    // Signature of the thest method adjusted to comply with the overriden ArgsCode.
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
public sealed class DemoClassTestsTestDataToTestCaseDataProperties
{
    private readonly DemoClass _sut = new();
    private static readonly TestDataToTestCaseDataSource DataSource = new(ArgsCode.Properties);

    // ArgsCode Overriden
    private static IEnumerable<TestCaseData> IsOlderReturnsTestCaseDataToList()
    => DataSource.IsOlderReturnsTestCaseDataToList(null, ArgsCode.Instance);

    private static IEnumerable<TestCaseData> IsOlderThrowsTestCaseDataToList()
    => DataSource.IsOlderThrowsTestCaseDataToList(nameof(IsOlder_invalidArgs_throwsException));

    // Signature of the thest method adjusted to comply with the overriden ArgsCode.
    [TestCaseSource(nameof(IsOlderReturnsTestCaseDataToList))]
    public bool IsOlder_validArgs_returnsExpected(TestDataReturns<bool, DateTime, DateTime> testData)
    {
        // Arrange & Act & Assert
        return _sut.IsOlder(testData.Arg1, testData.Arg2);
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

Results oof both test class run in the Test Explorer:

![DemoClassTestsTestDataToTestCaseDataProperties](https://raw.githubusercontent.com/CsabaDu/CsabaDu.DynamicTestData/master/Images/NUnit_OptionalToTestCaseData.png)

## Changelog

### **Version 1.0.0** (2025-03-13)

- Initial release of the `CsabaDu.DynamicTestData.NUnit` framework, which is a child of `CsabaDu.DynamicTestData` framework.
- Includes the `DynamicTestCaseDataSource` base class.
- Provides support for dynamic data-driven tests with `TestCaseData` arguments having different data, expected struct results, and exceptions, on top of the inherited `CsabaDu.DynamicTestData` features.

### **Version 1.1.0** (2025-03-30)

- **Added**: `OptionalToTestCaseData` method added to the `DynamicTestCaseDataSource` class.
- **Note**: This 

#### **Version 1.1.1** (2025-03-31)
- **Updated**: README.md Sample codes corrected.

#### **Version 1.1.2** (2025-04-02)
- **Updated**:
  - README.md Sample Test Classes with `TestCaseData` Lists' section Sample codes corrected.
  - Small README.md corrections and visual refactorings.
  
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
