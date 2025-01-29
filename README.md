# CsabaDu.DynamicTestData

Data types for dynamic data driven tests.

## Description

`CsabaDu.DynamicTestData` is a C# library designed to facilitate dynamic data-driven testing. It provides various data types and utilities to help create, manage, and manipulate test data dynamically.

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
using CsabaDu.DynamicTestData;

```bash
public class TestExample
{
    public void ExampleTest()
    {
        // Example usage of the library
        var testData = TestDataGenerator.Generate();
        Console.WriteLine(testData);
    }
}
```
## Contributing

Contributions are welcome! Please submit a pull request or open an issue if you have any suggestions or bug reports.

## Licence

This project is licensed under the (...) License. See the LICENSE file for details.

## Contact

For any questions or inquiries, please contact [CsabaDu](https://github.com/CsabaDu).

Feel free to modify and expand upon this template to better suit the specifics of your repository.
