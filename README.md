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

It provides strongly typed data types and methods to help create, test data dynamically, with literal test case descriptions to populate in Visual Studio Test Explorer.

## Features

- Comprehensive support for various data types used in testing.
- Easy integration with your existing test frameworks.
- Utilities for generating and validating test data.

## Installation

You can install `CsabaDu.DynamicTestData` via NuGet Package Manager:

```bash
Install-Package CsabaDu.DynamicTestData
```

## Usage

Here is a basic example of how to use CsabaDu.DynamicTestData in your project:

```csharp
using CsabaDu.DynamicTestData;

// ArgsCode type parameter defines if the dynamic data source should consist of
// indifidual parameters or instances of the used TestData type.
public class DynamicTestDataSourceExample(ArgsCode argsCode) : DynamicDataSource(argsCode)
{
    public IEnumerable<object[]> ExampleTestDataList()
    {
        // Initialize parameters.
        string definition = "Same numbers";
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
