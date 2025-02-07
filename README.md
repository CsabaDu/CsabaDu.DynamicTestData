<a name="top"></a>

# CsabaDu.DynamicTestData

`CsabaDu.DynamicTestData` is a type-safe C# library designed to facilitate dynamic data-driven testing in MSTest, NUnit or xUnit framework.

## Table of Contents
- [Description](#description)
- [Features](#features)
- [Types](#types)
  - [ArgsCode Enum](#argscode-enum)
  - [Static Extensions Class](#static-extensions-class)
  - [ITestData Interfaces](#itestdata-interfaces)
    - [ITestData Properties](#itestdata-properties)
    - [ITestData Methods](#itestdata-methods)
  - [TestData Record Types](#testdata-record-types)
    - [Derived TestData Types](#derived-testdata-types)
      - [TestData](#testdata)
      - [TestDataReturns](#testdatareturns)
      - [TestDataThrows](#testdatathrows)
  - [Abstract DynamicDataSource Class](#abstract-dynamicdatasource-class)
    - [ArgsCode Property](#argscode-property)
    - [Object Array Generator Methods](#object-array-generator-methods)
      - [TestDataToArgs](#testdatatoargs)
      - [TestDataReturnsToArgs](#testdatareturnstoargs)
      - [TestDataThrowsToArgs](#testdatathrowstoargs))
    - [Static GetDisplayName Method](#static-getdisplayname-method)
- [Usage](#usage)
  - [Sample DemoClass](#sample-democlass)
  - [Test Framework Independent Dynamic Data Source](#test-framework-independent-dynamic-data-source)
  - [Usage in MSTest](#usage-in-mstest)
  - [Usage in xUnit](#usage-in-xunit)
- [Advanced Usage](#advanced-usage)
- [Contributing](#contributing)
- [License](#license)
- [Contact](#contact)
- [FAQ](#faq)
- [Troubleshooting](#troubleshooting)

## Description

`CsabaDu.DynamicTestData` provides strongly typed data types and easy-to-use methods to help creating general-purpose as well as specific test data dynamically, with literal test case descriptions to display in Visual Studio Test Explorer.

It consists of easy-to-use `record` types to initialize, store and proceed parameters of dynamic data-driven tests, 
and an extendable abstract `DynamicDataSource` base class with fully implemented methods to create specific object arrays of the data stored in `TestData` records. You get ready-to-use methods tó use as enumeration members of the derived dynamic data source classes.

<a href="#top" class="top-link">↑ Back to top</a>

## Features

- Comprehensive support for various types used in testing.
- Easy integration with your existing test frameworks.
- Utilities for generating test data records in two ways for dynamic data-driven tests.
- Extendable types to support further details or other modes of assertions.

<a href="#top" class="top-link">↑ Back to top</a>

## Types

### `ArgsCode` Enum

Every test frameworks accept object arrays as dynamic data-driven tests' data rows. The test parameters should be the object array elements. Other approach is that the object array contains a single object element, and the tests' parameters can be the properties of this object element. 

`CsabaDu.DynamicTestData` supports both approaches, you can generate object arrays with either content. The outcome of the object array generator methods is controlled with the dedicated `enum ArgsCode` type parameter having two self-explanatory values:

```csharp
namespace CsabaDu.DynamicTestData;

public enum ArgsCode
{
    Instance,
    Properties,
}
```

`ArgsCode` will be used as basic parameter of the object array generator methods.

<a href="#top" class="top-link">↑ Back to top</a>

### Static `Extensions` Class

Object array type is extended with a method to facilitate test data object arrays creation. Besides the object array which calls it, the method requires two parameters. In case of `Properties` value of the first `ArgsCode` argument the method increases the returning object array's elements with the new parameter as last one there, otherwise it returns the original object array: 

```csharp
namespace CsabaDu.DynamicTestData;

public static class Extensions
{
    public static object?[] Add<T>(this object?[] args, ArgsCode argsCode, T? parameter)
    => argsCode == ArgsCode.Properties ? [.. args, parameter] : args;
}

```

<a href="#top" class="top-link">↑ Back to top</a>

### `ITestData` Interfaces

`CsabaDu.DynamicTestData` provides three extendable base `record` types, and their concrete generic implementations with `T1` - `T9` types strongly typed parameters.

Each `TestData` type implements the following interfaces:

```csharp
namespace CsabaDu.DynamicTestData.TestDataTypes.Interfaces;

public interface ITestData
{
    string Definition { get; init; }
    string ExitMode { get; }
    string Result { get; }
    string TestCase { get; }

    object?[] ToArgs(ArgsCode argsCode);
}

public interface ITestData<out TResult> : ITestData where TResult : notnull
{
    TResult Expected { get; init;}
}
```

`ITestData` is the base interface of three inheritance lines. All derived types implement an abstract class each which implements a dedicated interface derived from the `ITestData<out TResult>` interface. Inherited types are `TestData`, `TestDataReturns<TStruct>` and `TestDataThrows<TException>`.

<a href="#top" class="top-link">↑ Back to top</a>

#### `ITestData` Properties

All types have five common properties.

Two properties are injected as first two parameters to each derived concrete types' constructors:
- `string Definition` to describe the test case parameters to be asserted.
- `TResult Expected`, a generic type property with `notnull` constraint.

 Additional properties are generated as follows:
- `string Result` property gets the appropriate string representation of the `Expected` property.
- `string ExitMode` property gets a constant string declared in the derived types. This implementation gets the following strings in the derived types:
  - `TestData`: `""` (virtual),
  - `TestDataReturns<TStruct>`: `"returns"` (sealed),
  - `TestDataThrows<TException>`: `"throws"` (sealed).
- `string TestCase` property gets the test case description. This text is created from the other properties in the following ways:
  - If `ExitMode` property gets null or an empty string: `{Description} => {Result}`,
  - Otherwise: `{Description} => {ExitMode} {Result}`.

<a href="#top" class="top-link">↑ Back to top</a>

#### `ITestData` Methods

`ITestData` interface defines the `object?[] ToArgs(ArgsCode argsCode)` method only.

Intended behavior of this method is to generate an object array from the data of the `ITestData` instance in two ways: The returning object array should contain either the properties of the `ITestData` instance or the `ITestData` instance itself.

<a href="#top" class="top-link">↑ Back to top</a>

### `TestData` Record Types

All concrete TestData types are inherited from the `abstract record TestData` type. Its primary constructor with the `object?[] ToArgs(ArgsCode argsCode)` method's virtual implementation looks like:

```csharp
namespace CsabaDu.DynamicTestData.TestDataTypes;

public abstract record TestData(string Definition) : ITestData
{
    public virtual object?[] ToArgs(ArgsCode argsCode) => argsCode switch
    {
        ArgsCode.Instance => [this],
        ArgsCode.Properties => [TestCase],
        _ => throw new InvalidEnumArgumentException(nameof(argsCode), (int)(object)argsCode, typeof(ArgsCode)),
    };
}
```
In the derived concrete `TestData` types the overriden `object?[] ToArgs(ArgsCode argsCode)` methods will increase the returning object array of the parent `record` with the recently added parameter in case of `ArgsCode.Properties` parameter, otherwise it will return an object array containing the given instance. Using the `object?[] Add<T>(this object?[] args, T? arg)` extension method, the overriden methods' implementations are uniform as you will see.

This type overrides and seals the `string ToString()` method with returning the `TestCase` property's value. When the instance is used as test method parameter, the test case display name will be the string representation of the instance. 

<a href="#top" class="top-link">↑ Back to top</a>

#### Derived `TestData` Types

All derived types of `TestData` base type implement the `ITestdata<out TResult> : ITestData` interface. `TestData` concrete types will inherit direcly from thie abstract `TestData` record, other types will inherit via intermediate abstract types. 

<a href="#top" class="top-link">↑ Back to top</a>

##### `TestData`

Implements the following interface:

```csharp
namespace CsabaDu.DynamicTestData.TestDataTypes.Interfaces;

public interface ITestData<string> : ITestData
```

- General purposes type `ITestData`.
- `Expected` property's type is `string`. The expected test case result should be written down literally.

Concrete `TestData` types primary constructors with the overriden `object?[] ToArgs(ArgsCode argsCode)` methods look like:

```csharp
namespace CsabaDu.DynamicTestData.TestDataTypes;

public record TestData<T1>(string Definition, string Expected, T1? Arg1)
: TestData(Definition), ITestData<string>
{
    public override object?[] ToArgs(ArgsCode argsCode)
    => base.ToArgs(argsCode).Add(argsCode, Arg1);
}

public record TestData<T1, T2>(string Definition, string Expected, T1? Arg1, T2? Arg2)
: TestData<T1>(Definition, Expected, Arg1)
{
    public override object?[] ToArgs(ArgsCode argsCode)
    => base.ToArgs(argsCode).Add(argsCode, Arg2);
}

// And similar extended inheritances till T9 type argument.
```

Test case displays in text explorer like:

`Test case definition => {Expected}`

<a href="#top" class="top-link">↑ Back to top</a>

##### `TestDataReturns`

Implements the following interface:

```csharp
namespace CsabaDu.DynamicTestData.TestDataTypes.Interfaces;

public interface ITestDataReturns<out TStruct> : ITestData<TStruct> where TStruct : struct;
```

- Designed to assert the comparison of numbers, booleans, enums, and other `struct` types' values.
- `Expected` property's type is `struct`.
  
The abstract `TestDataReturns<TStruct>` type and its concrete derived types' primary constructors with the overriden `object?[] ToArgs(ArgsCode argsCode)` methods look like:

```csharp
namespace CsabaDu.DynamicTestData.TestDataTypes;

public abstract record TestDataReturns<TStruct>(string Definition, TStruct Expected)
: TestData(Definition), ITestDataReturns<out TStruct>
where TStruct : struct
{
    public override object?[] ToArgs(ArgsCode argsCode)
    => base.ToArgs(argsCode).Add(argsCode, Expected);
}

public record TestDataReturns<TStruct, T1>(string Definition, TStruct Expected, T1? Arg1)
: TestDataReturns<TStruct>(Definition, Expected)
where TStruct : struct
{
    public override object?[] ToArgs(ArgsCode argsCode)
    => base.ToArgs(argsCode).Add(argsCode, Arg1);
}

public record TestDataReturns<TStruct, T1, T2>(string Definition, TStruct Expected, T1? Arg1, T2? Arg2)
: TestDataReturns<TStruct, T1>(Definition, Expected, Arg1)
where TStruct : struct
{
    public override object?[] ToArgs(ArgsCode argsCode)
    => base.ToArgs(argsCode).Add(argsCode, Arg2);
}

// And similar extended inheritances till T9 type argument.
```

Test case displays in text explorer like:

`Test case definition => returns {Expected.ToString() ?? string.Empty}`

<a href="#top" class="top-link">↑ Back to top</a>

##### `TestDataThrows`

Implements the following interface:
```csharp
namespace CsabaDu.DynamicTestData.TestDataTypes.Interfaces;

public interface ITestDataThrows<out TException> : ITestData<Exception> where TException : Exception
{
    string? ParamName { get; init; }
    string? Message { get; init; }
    Type ExceptionType { get; }
}
```
- Designed for test cases where the expected result to be asserted is a thrown `Exception`.
- `Expected` property's type is `Exception`.
- `Type ExceptionType` property is to get the type of `Expected` property.
- Additional two parameters are (expected) `string? ParamName` and (expected) `string? Message` to support the assertion of the similar properties of the thrown exception.

The abstract `TestDataThrows<TException>` type and its concrete derived types' primary constructors with the overriden `object?[] ToArgs(ArgsCode argsCode)` methods look like:

```csharp
namespace CsabaDu.DynamicTestData.TestDataTypes;

public abstract record TestDataThrows<TException>(string Definition, TException Expected, string? ParamName, string? Message)
: TestData(Definition), ITestDataThrows<out TException>
where TException : Exception
{
    public override object?[] ToArgs(ArgsCode argsCode)
    => argsCode == ArgsCode.Properties ?
        [.. base.ToArgs(argsCode), ParamName, Message, ExceptionType]
        : base.ToArgs(argsCode);
}

public record TestDataThrows<TException, T1>(string Definition, TException Expected, string? ParamName, string? Message, T1? Arg1)
: TestDataThrows<TException>(Definition, Expected, ParamName, Message)
where TException : Exception
{
    public override object?[] ToArgs(ArgsCode argsCode)
    => base.ToArgs(argsCode).Add(argsCode, Arg1);
}

public record TestDataThrows<TException, T1, T2>(string Definition, TException Expected, string? ParamName, string? Message, T1? Arg1, T2? Arg2)
: TestDataThrows<TException, T1>(Definition, Expected, ParamName, Message, Arg1)
where TException : Exception
{
    public override object?[] ToArgs(ArgsCode argsCode)
    => base.ToArgs(argsCode).Add(argsCode, Arg2);
}

// And similar extended inheritances till T9 type argument.
```

Test case displays in text explorer like:

`Test case definition => throws {ExceptionType.Name}`

<a href="#top" class="top-link">↑ Back to top</a>

### Abstract `DynamicDataSource` Class

This class contains the methods to create specific object arrays for dynamic data-driven tests' data row purposes from every `TestData` types. Once you call an object array generator method of the class, you create a new `TestData` child instance inside and call its `object?[] ToArgs(ArgsCode argsCode)` method to create the object array for dynamic test data record purposes.

However `DynamicDataSource` class implements all necessary methods for test data preparation, it is marked as `abstract`. Intended usage is to
- extend this class for each test class separately,
- implement the necessary specific methods in the derived class with `IEnumerable<object[]>` returning types, and
- declare a static instance of the derived class in the test class where it is going to be used.

You can implement its children as test framework independent portable dynamic data source types. Moreover, using a test framework in the derived classes, you can create specific types either like `TestCaseData` type data rows of NUnit, or generic `TheoryData<>` returning type methods of xUnit. You will find sample codes of these in the [Advanced Usage](#advanced-usage) section below.

<a href="#top" class="top-link">↑ Back to top</a>

#### `ArgsCode` Property

`ArgsCode ArgsCode` is the only property of `DynamicDataSource` class. This property is marked as `protected`. It should be initalized with the constructor parameter of the class. This property will be the parameter of the `ToArgs` methods called by the object array generator methods of the class

<a href="#top" class="top-link">↑ Back to top</a>

#### Object Array Generator Methods

`DynamicDataSource` class provides a dedicated object array generator each `TestData type`. The methods' parameters types and sequences are the same as the constructors' parameters of the related `TestData` types.

<a href="#top" class="top-link">↑ Back to top</a>

##### `TestDataToArgs`

- Signature:

`object?[] TestDataToArgs<T1...T9>(string definition, string expected, T1? arg1 ... T9? arg9)`.

- In case of `ArgsCode.Properties` parameter, the returning object array content is as follows:

`[TestCase, Arg1 ... Arg9]`.

<a href="#top" class="top-link">↑ Back to top</a>

##### `TestDataReturnsToArgs`

- Signature:

`object?[] TestDataReturnsToArgs<TStruct, T1...T9>(string definition, TStruct Expected, T1? arg1 ... T9? arg9)`.

- In case of `ArgsCode.Properties` parameter, the returning object array content is as follows:

`[TestCase, Expected, Arg1 ... Arg9]`.

<a href="#top" class="top-link">↑ Back to top</a>

##### `TestDataThrowsToArgs`

- Signature:

`object?[] TestDataThrowsToArgs<TException, T1...T9>(string definition, TException expected, string? paramName, string? message, T1? arg1 ... T9? arg9)`.

- In case of `ArgsCode.Properties` parameter, the returning object array content is as follows:

`[TestCase, ParamName, Message, ExceptionType, Arg1 ... Arg9]`.

<a href="#top" class="top-link">↑ Back to top</a>

#### Static `GetDisplayName` method

This method is prepared to facilitate displaying the tequired literal testcase description in MSTest and NUnit framewoks. You will find sample code for MSTest usage in the [Usage](#usage), for NUnit usage in the [Advanced Usage](#advanced-usage) sections below.

The method is implemented as it is defined to initialize the MSTest framework's `DynamicDataAttribute.DynamicDataDisplayName` property. Following the testmethod's name, the injected object array's first element will be used as string. This element in case of `ArgsCode.Properties` is the `TestCase` property of the instance, and the instance's string representation in case of `ArgsCode.Instance`. This is the `TestCase` property's value either as the `ToString()` method returns that.

```csharp
namespace CsabaDu.DynamicTestData;

public abstract class DynamicDataSource(ArgsCode argsCode)
{
    public static string GetDisplayName(MethodInfo testMethod, object?[] args)
    => $"{testMethod.Name}(testData: {args[0] as string})";

    // Other members here
}
```

<a href="#top" class="top-link">↑ Back to top</a>

## Usage

Here are some basic examples of how to use CsabaDu.DynamicTestData in your project.

### Sample `DemoClass`

The following `bool IsOlder(DateTime thisDate, DateTime otherDate)` method of the `DemoClass` is going to be the subject of the below sample dynamic data source and test method codes.

The method compares two `DateTime` type arguments and returns if the first is greater than the second one. The method throws an `ArgumentOutOfRangeException` if either argument is greater than the current date.

```csharp
namespace CsabaDu.DynamicTestData.SampleCodes;

public class DemoClass
{
    public const string GreaterThanCurrentDateTimeMessage
        = "The dateTime parameter cannot be greater than the current date and time.";

    public bool IsOlder(DateTime thisDate, DateTime otherDate)
    {
        throwIfDateTimeGreaterThanCurrent(thisDate, nameof(thisDate));
        throwIfDateTimeGreaterThanCurrent(otherDate, nameof(otherDate));

        return thisDate > otherDate;

        #region Local methods
        static void throwIfDateTimeGreaterThanCurrent(DateTime dateTime, string paramName)
        {
            if (dateTime <= DateTime.Now) return;

            throw new ArgumentOutOfRangeException(paramName, GreaterThanCurrentDateTimeMessage);
        }
        #endregion
    }
}
```

<a href="#top" class="top-link">↑ Back to top</a>

### Test Framework Independent Dynamic Data Source

You can easily implement test framework independent dynamic data source by extending the `DynamicDataSource` base class with `IEnumerable<object?[]>` type data source methods. You can use these directly in either test framework.

Also, you can use either ArgsCode.Instance and ArgsCode.Properties in any framework, however uning NUnit you will have the desired displayed text in the Test Explorer just with ArgsCode.Instance, otherwise the default display name only.

The 'native' dynamic data source class looks like:

```csharp
namespace CsabaDu.DynamicTestData.SampleCodes;

public class DemoClassTestsDataSource_Native(ArgsCode argsCode) : DynamicDataSource(argsCode)
{
    private readonly DateTime DateTimeNow = DateTime.Now;

    private DateTime _thisDate;
    private DateTime _otherDate;

    public IEnumerable<object?[]> IsOlderReturnsArgsToList()
    {
        bool expected = true;
        _thisDate = DateTimeNow;
        _otherDate = DateTimeNow.AddDays(-1);
        yield return testDataToArgs("thisDate is greater than otherDate");

        expected = false;
        _otherDate = DateTimeNow;
        yield return testDataToArgs("thisDate equals otherDate");

        _thisDate = DateTimeNow.AddDays(-1);
        yield return testDataToArgs("thisDate is less than otherDate");

        #region local methods
        object?[] testDataToArgs(string definition)
        => TestDataReturnsToArgs(definition, expected, _thisDate, _otherDate);
        #endregion
    }

    public IEnumerable<object?[]> IsOlderThrowsArgsToList()
    {
        ArgumentOutOfRangeException expected = new();
        string message = DemoClass.GreaterThanCurrentDateTimeMessage;

        string paramName = "otherDate";
        _thisDate = DateTimeNow;
        _otherDate = DateTimeNow.AddDays(1);
        yield return testDataToArgs();

        paramName = "thisDate";
        _thisDate = DateTimeNow.AddDays(1);
        yield return testDataToArgs();

        #region Local methods
        string getDefinition()
        => $"{paramName} is greater than the current date";

        object?[] testDataToArgs()
        => TestDataThrowsToArgs(getDefinition(), expected, paramName, message, _thisDate, _otherDate);
        #endregion
    }
}
```

<a href="#top" class="top-link">↑ Back to top</a>

### Usage in MSTest

You can assert the valid parameters in MSTest framework with the following method:

```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace CsabaDu.DynamicTestData.SampleCodes.MSTest;

[TestClass]
public sealed class DemoClassTests
{
    private readonly DemoClass _sut = new();
    private static DemoClassTestsDataSource_Native DataSource = new(ArgsCode.Properties);

    private static IEnumerable<object?[]> IsOlderReturnsArgsList
    => DataSource.IsOlderReturnsArgsToList();

    public static string GetDisplayName(MethodInfo testMethod, object?[] args)
    => DynamicDataSource.GetDisplayName(testMethod, args);

    [TestMethod, DynamicData(nameof(IsOlderReturnsArgsList), DynamicDataDisplayName = nameof(GetDisplayName))]
    public void IsOlder_validArgs_returnsExpected(string testCase, bool expected, DateTime thisDate, DateTime otherDate)
    {
        // Arrange & Act
        var actual = _sut.IsOlder(thisDate, otherDate);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
```

<a href="#top" class="top-link">↑ Back to top</a>

### Usage in xUnit

You can assert the invalid parameters in xUnit framework with the following method:

```csharp
using Xunit;

namespace CsabaDu.DynamicTestData.SampleCodes.xUnit;

public sealed class DemoClassTests
{
    private readonly DemoClass _sut = new();
    private static DemoClassTestsDataSource_Native DataSource = new(ArgsCode.Instance);

    public static IEnumerable<object?[]> IsOlderThrowsArgsList
    => DataSource.IsOlderThrowsArgsToList();

    [Theory, MemberData(nameof(IsOlderThrowsArgsList))]
    public void IsOlder_invalidArgs_throwsArgumentOutOfRangeException(TestDataThrows<ArgumentOutOfRangeException, DateTime, DateTime> testData)
    {
        // Arrange & Act
        void attempt() => _ = _sut.IsOlder(testData.Arg1, testData.Arg2);

        // Assert
        var actual = Assert.Throws<ArgumentOutOfRangeException>(attempt);
        Assert.Equal(testData.ParamName, actual.ParamName);
        Assert.StartsWith(testData.Message, actual.Message);
    }
}
```

To have the short name of the test method in Test Explorer add the follwong json file to the test project:


```json
{
  "$schema": "https://xunit.net/schema/current/xunit.runner.schema.json",
  "methodDisplay": "method"
}
```

furthermore you shall insert this item group in the xUnit project file too:

```xml
  <ItemGroup>
    <Content Include="xunit.runner.json" CopyToOutputDirectory="PreserveNewest" />
  </ItemGroup>
```

<a href="#top" class="top-link">↑ Back to top</a>

## Advanced Usage

Include more detailed examples and explanations here.

## Contributing

Contributions are welcome! Please submit a pull request or open an issue if you have any suggestions or bug reports.

## License

This project is licensed under the (...) License. See the LICENSE file for details.

## Contact

For any questions or inquiries, please contact [CsabaDu](https://github.com/CsabaDu).

## FAQ

- **How do I install the library?**
  You can install it via NuGet Package Manager using `Install-Package CsabaDu.DynamicTestData`.

- **Can I contribute to this project?**
  Yes, contributions are welcome! Please see the Contributing section.

## Troubleshooting

- **Issue 1: Cannot install the package**
  - Solution: Ensure you are using the correct package name `CsabaDu.DynamicTestData` and have a stable internet connection.

- **Issue 2: Test data not generating correctly**
  - Solution: Verify the input parameters for the `TestDataGenerator.Generate` method.
