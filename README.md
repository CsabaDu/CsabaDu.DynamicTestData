# CsabaDu.DynamicTestData

## Description

`CsabaDu.DynamicTestData` is a C# library designed to facilitate dynamic data-driven testing in MSTest, NUnit or xUnit framework.

It provides strongly typed data types and easy-to-use methods to help creating test data dynamically, with literal test case descriptions to populate in Visual Studio Test Explorer.

It consists of easy-to-use `record` types to store and proceed parameters to suit for dynamic data-driven tests as enumerable data sources, 
and an extendable abstract `DynamicDataSource` base class with fully implemented methods to create enumerations of specific object arrays.

## Table of Contents
- [Description](#description)
- [Features](#features)
- [Types](#types)
  - [TestData Record Types](#testdata-record-types)
    - [Properties](#properties)
    - [Methods](#methods)
    - [Derived Types](#derived-types)
      - [TestData](#testdata)
      - [TestDataReturns](#testdatareturns)
      - [TestDataThrows](testdatathrows)
  - [DynamicDataSource class](#dynamicdatasource-class)
    - [Properties](#properties)
    - [Methods](#methods)
      - [GetDisplayName](#getdisplayname)
      - [TestDataToArgs](#testdatatoargs)
      - [TestDataReturnsToArgs](#testdatareturnstoargs)
      - [TestDataThrowsToArgs](#testdatathrowstoargs)
- [Usage](#usage)
- [Advanced Usage](#advanced-usage)
- [Contributing](#contributing)
- [License](#license)
- [Contact](#contact)
- [FAQ](#faq)
- [Troubleshooting](#troubleshooting)

## Features

- Comprehensive support for various types used in testing.
- Easy integration with your existing test frameworks.
- Utilities for generating test data records in two ways for dynamic data-driven tests.
- Extendable to support further details or other modes of assertions.

## Types

### `TestData` Record Types

`CsabaDu.DynamicTestData` provides three extendable base `record` types, and their concrete implementations with `T1` - `T9` types strongly typed parameters.

Each type implements the following interfaces:

```csharp
namespace CsabaDu.DynamicTestData.TestDataTypes.Interfaces;

public interface ITestData
{
    string Definition { get; }
    string ExitMode { get; }
    string Result { get; }
    string TestCase { get; }

    object?[] ToArgs(ArgsCode argsCode);
}

public interface ITestData<out TResult> : ITestData where TResult : notnull
{
    TResult Expected { get; }
}
```

`ITestData` is the base interface of three inheritance lines. All derived types implement an abstract class each which implements a dedicated interface derived from the `ITestData<out TResult>` interface. Inherited types are `TestData`, `TestDataReturns<TStruct>` and `TestDataThrows<TException>`.

#### Properties

All types have five common properties.

Two properties are injected as first two parameters to each derived types' constructors:
- `string Definition` to describe the test case parameters to be asserted.
- `TResult Expected`, a generic type property with `notnull` constraint.

 Additional properties are generated as follows:
- `string Result` property gets the appropriate string representation of the `Expected` property.
- `string ExitMode` property gets a constant string declared in the derived types. This implementation gets the following strings in the derived types:
  - `TestData`: `""` (overridable),
  - `TestDataReturns<TStruct>`: `"returns"` (sealed),
  - `TestDataThrows<TException>`: `"throws"` (sealed).
- `string TestCase` property gets the test case description. This text is created from the other properties in the following ways:
  - If `ExitMode` property gets null or an empty string: `{Description} => {Result}`,
  - Otherwise: `{Description} => {ExitMode} {Result}`.

#### Methods

`ITestData` interface defines the `object?[] ToString(ArgsCode argsCode)` method only.

Intended behavior of this method is to generate an object array of the the data of the `ITestData` instance in two ways: The returning object array should contain either the properties of the `ITestData` instance or the `ITestData` instance itself.

The method's parameter is an `enum` type having two values:

```csharp
namespace CsabaDu.DynamicTestData;

public enum ArgsCode
{
    Instance,
    Properties,
}
```

#### Derived Types

All derived types are inherited from the `TestData<TResult> : ITestdata<TResult> where TResult : notnull` abstract `record` type.

This type overrides and seals the `string ToString()` method with returning the `TestCase` property's value. 

##### `TestData`

Implements the following interface:

```csharp
namespace CsabaDu.DynamicTestData.TestDataTypes.Interfaces;

public interface ITestData<string> : ITestData
```

- General purposes type `ITestData`.
- `Expected` property's type is `string`, it should be added literally.
- Test case populates in text explorer:

`Test case definition => {Expected}`

##### `TestDataReturns`

Implements the following interface:

```csharp
namespace CsabaDu.DynamicTestData.TestDataTypes.Interfaces;

public interface ITestDataReturns<out TStruct> : ITestData<TStruct> where TStruct : struct;
```

- Designed to assert the comparison of numbers, booleans, enums, and other `struct` types' values.
- `Expected` property's type is `struct`.
- Test case populates in text explorer:

`Test case definition => returns {Expected.ToString() ?? string.Empty}`

##### `TestDataThrows`

Implements the following interface:
```csharp
namespace CsabaDu.DynamicTestData.TestDataTypes.Interfaces;

public interface ITestDataThrows<out TException> : ITestData<Exception> where TException : Exception
{
    string ParamName { get; }
    string Message { get; }
}
```
- Designed for test cases where the expected result to be asserted is a thrown `Exception`.
- `Expected` property's type is `Exception`.
- Additional two parameters are (expected) `string? ParamName` and (expected) `string? Message` to support the assertion of the similar properties of the thrown exception.
- Test case populates in text explorer:

`Test case definition => throws {Expected.Name}`

### `DynamicDataSource` class

This class contains the methods to create specific object arrays for data records of dynamic data-driven tests of each `TestData` types. The methods' parameters types and sequences are the same as the constructors' parameters of the related `TestData` types.

However `DynamicDataSource` class implements all necessary methods for test data preparation, it is marked as `abstract`. Intended usage is to
- extend this class for each test class separately,
- implement the necessary specific methods in the derived class with `IEnumerable<object[]>` returning types, and
- declare a static instance of the derived class in the test class where it is going to be used.

#### Properties

`ArgsCode ArgsCode` is the only property of `DynamicDataSource` class. This property is marked as `protected`. It should be initalized with the constructor parameter of the class. Purpose of this member is to control the content of the returning object arrays via the way of creating these.

#### Methods

##### `GetDisplayName`

##### `TestDataToArgs`

##### `TestDataReturnsToArgs`

##### `TestDataThrowsToArgs`

## Usage

Here are some basic examples of how to use CsabaDu.DynamicTestData in your project.

Note that test parameters can be Initialized dinamically.

```csharp
using CsabaDu.DynamicTestData;

// ArgsCode type parameter defines if the dynamic data source should consist of
// individual parameters or instances of the used TestData type.
public class DynamicDataSourceExample(ArgsCode argsCode) : DynamicDataSource(argsCode)
{
    public IEnumerable<object[]> AreEqualTestDataList()
    {
        // Create literal test case definition.
        string definition = "Same numbers";
        // Initialize parameters.
        bool expected = true;
        int a = 2;
        int b = a;
        // Create an object array of the parameters as defined by the 'argsCode' parameter.
        yield return TestDataReturns(definition, expected, a, b);

        definition = "Different numbers"
        expected = false;
        b++;
        yield return TestDataReturns(definition, expected, a, b);
    }

    public IEnumerable<object[]> ThrowsExceptionTestDataList()
    {
        string definition = "First parameter is negative";
        Exception expected = new ArgumentOutOfRangeException();
        string paramName = "a";
        string message = $"Specified argument was out of the range of valid values. Parameter name: {paramName}"
        int a = -1;
        int b = 0;
        yield return TestDataThrows(definition, expected, paramName, message, a, b);

        definition = "Second parameter is negative"
        paramName = "b";
        a++;
        b--;
        yield return TestDataThrows(definition, expected, paramName, message, a, b);
    }
}
```

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
