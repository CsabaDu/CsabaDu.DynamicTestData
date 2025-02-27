# CsabaDu.DynamicTestData.NUnit

`CsabaDu.DynamicTestData.NUnit` is a lightweight, robust type-safe C# library designed to facilitate dynamic data-driven testing in NUnit framework, by providing a simple and intuitive way to generate `TestCaseData` instances at runtime.

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
    public TestCaseData TestDataToTestCaseData<T1>(string definition, string expected, T1? arg1, string? testMethodName = null)
    => new TestData<T1>(definition, expected, arg1).ToTestCaseData(ArgsCode, testMethodName);

    // TestDataToTestCaseData<> overloads here

    public TestCaseData TestDataReturnsToTestCaseData<TStruct, T1>(string definition, TStruct expected, T1? arg1, string? testMethodName = null)
    where TStruct : struct
    => new TestDataReturns<TStruct, T1>(definition, expected, arg1).ToTestCaseData(ArgsCode, testMethodName);

    // TestDataReturnsToTestCaseData<> overloads here

    public TestCaseData TestDataThrowsToTestCaseData<TException, T1>(string definition, TException expected, T1? arg1, string? testMethodName = null)
    where TException : Exception
    => new TestDataThrows<TException, T1>(definition, expected, arg1).ToTestCaseData(ArgsCode, testMethodName);

    // TestDataThrowsToTestCaseData<> overloads here
}
```

## Usage

## Contributing

Contributions are welcome! Please submit a pull request or open an issue if you have any suggestions or bug reports.

## License

This project is licensed under the MIT License. See the [License](LICENSE.txt) file for details.

## Contact

For any questions or inquiries, please contact [CsabaDu](https://github.com/CsabaDu).

## FAQ

## Troubleshooting
