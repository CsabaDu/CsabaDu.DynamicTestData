# CsabaDu.DynamicTestDataitHub Copilot generated doc, under construction)

Data types for dynamic data driven tests in MSTest, NUnit or xUnit framework.

## Table of Contents
- [Description](#description)
- [Features](#features)
- [Installation](#installation)
- [Usage](#usage)
- [Advanced Usage](#advanced-usage)
- [Contributing](#contributing)
- [License](#license)
- [Contact](#contact)
- [FAQ](#faq)
- [Troubleshooting](#troubleshooting)

## Description

`CsabaDu.DynamicTestData` is a C# library designed to facilitate dynamic data-driven testing in MSTest, NUnit or xUnit framework.

It provides strongly typed data types and easy-to-use methods to help creating test data dynamically, with literal test case descriptions to populate in Visual Studio Test Explorer.

## Features

- Comprehensive support for various data types used in testing.
- Easy integration with your existing test frameworks.
- Utilities for generating and validating test data.
- Extendable to support further details or other modes of assertions.

### Data Types

`CsabaDu.DynamicTestData` provides three extendable base record types, and their concrete implelentations with `T1` - `T9` types strongly typed parameters.

Each type implements the following interfaces:

```csharp
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

All types' constructors have two common parameters (properties):
- `string Definition` to describe the test case parameters to be asserted.
- `<TResult> Expected`, a generic type and property parameter with `notnull` constraint.

#### `TestData`

Implements the following interface:

```csharp
public interface ITestData<string>
```

- General purposes type.
- `Expected` property's type is `string`, it should be added literally.
- Test case populates in text explorer:

`Test case definition => {Expected}`

#### `TestDataReturns`

Implements the following interface:

```csharp
public interface ITestDataReturns<out TStruct> : ITestData<TStruct> where TStruct : struct;
```

- Type for test cases where the expected result to be asserted is a `struct`.
- `Expected` property's type is `struct`.
- Test case populates in text explorer:

`Test case definition => returns {Expected.ToString() ?? string.Empty}`

#### `TestDataThrows`

Implements the following interface:
```csharp
public interface ITestDataThrows<out TException> : ITestData<Exception> where TException : Exception
{
    string ParamName { get; }
    string Message { get; }
}
```
- Type for test cases where the expected result to be asserted is a thrown `Exception`.
- `Expected` property's type is `Exception`.
- Additional two parameters are (expected) `string ParamName` and (expected) `string Message` to support the aassertion of these properties of the thrown exception.
- Test case populates in text explorer:

`Test case definition => throws {Expected.Name}`

## Installation

You can install `CsabaDu.DynamicTestData` via NuGet Package Manager:

```bash
Install-Package CsabaDu.DynamicTestData
```

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
