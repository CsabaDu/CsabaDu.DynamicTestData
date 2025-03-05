# CsabaDu.DynamicTestData.NUnit

`CsabaDu.DynamicTestData.NUnit` is a lightweight, robust type-safe C# library designed to facilitate dynamic data-driven testing in NUnit framework, by providing a simple and intuitive way to generate `TestCaseData` instances at runtime, based on `CsabaDu.DynamicTestData` features.

## Table of Contents

- [Description](#description)
- [Features](#features)
- [Types](#types)
  - [Abstract DynamicTheoryDataSource Class](#abstract-dynamictheorydatasource-class)

- [Usage](#usage)
- [Contributing](#contributing)
- [License](#license)
- [Contact](#contact)
- [FAQ](#faq)
- [Troubleshooting](#troubleshooting)

## Description

## Features

## Types

### Abstract `DynamicTheoryDataSource` Class

```csharp
namespace CsabaDu.DynamicTestData.xUnit.DynamicDataSources;

public abstract class DynamicTheoryDataSource(ArgsCode argsCode) : DynamicDataSource(argsCode)
{
    protected TheoryData? TheoryData { get; set; }

    protected void ResetTheoryData() => TheoryData = default;

    internal ArgumentException ArgumentsMismatchException(Type expectedType)
    => new($"Arguments are suitable for creating {expectedType.Name} elements" +
        $" and do not match with the initiated {TheoryData!.GetType().Name} instance's type parameters.");

    private TTheoryData CheckedTheoryData<TTheoryData>(TTheoryData theoryData) where TTheoryData : TheoryData
    => (TheoryData ??= theoryData) is TTheoryData typedTheoryData ?
        typedTheoryData
        : throw ArgumentsMismatchException(typeof(TTheoryData));

    public void AddTestDataToTheoryData<T1>(string definition, string expected, T1? arg1)
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                TestData<T1?> testData = new(definition, expected, arg1);
                CheckedTheoryData(initTestDataTheoryData()).Add(testData);
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(arg1);
                break;
            default:
                break;
        }

        static TheoryData<TestData<T1?>> initTestDataTheoryData() => [];
        static TheoryData<T1?> initTheoryData() => [];
    }

    public void AddTestDataToTheoryData<T1, T2>(string definition, string expected, T1? arg1, T2? arg2)
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                TestData<T1?, T2?> testData = new(definition, expected, arg1, arg2);
                CheckedTheoryData(initTestDataTheoryData()).Add(testData);
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(arg1, arg2);
                break;
            default:
                break;
        }

        static TheoryData<TestData<T1?, T2?>> initTestDataTheoryData() => [];
        static TheoryData<T1?, T2?> initTheoryData() => [];
    }

    // AddTestDataToTheoryData<> overloads here...

    public void AddTestDataReturnsToTheoryData<TStruct, T1>(string definition, TStruct expected, T1? arg1)
    where TStruct : struct
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                TestDataReturns<TStruct, T1?> testData = new(definition, expected, arg1);
                CheckedTheoryData(initTestDataTheoryData()).Add(testData);
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(expected, arg1);
                break;
            default:
                break;
        }

        static TheoryData<TestDataReturns<TStruct, T1?>> initTestDataTheoryData() => [];
        static TheoryData<TStruct, T1?> initTheoryData() => [];
    }

    public void AddTestDataReturnsToTheoryData<TStruct, T1, T2>(string definition, TStruct expected, T1? arg1, T2? arg2)
    where TStruct : struct
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                TestDataReturns<TStruct, T1?, T2?> testData = new(definition, expected, arg1, arg2);
                CheckedTheoryData(initTestDataTheoryData()).Add(testData!);
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(expected, arg1, arg2);
                break;
            default:
                break;
        }

        // initTestDataTheoryData() and initTheoryData() methods here...

            public void AddTestDataThrowsToTheoryData<TException, T1>(string definition, TException expected, T1? arg1)
    where TException : Exception
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                TestDataThrows<TException, T1?> testData = new(definition, expected, arg1);
                CheckedTheoryData(initTestDataTheoryData()).Add(testData);
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(expected, arg1);
                break;
            default:
                break;
        }

        static TheoryData<TestDataThrows<TException, T1?>> initTestDataTheoryData() => [];
        static TheoryData<TException, T1?> initTheoryData() => [];
    }

    public void AddTestDataThrowsToTheoryData<TException, T1, T2>(string definition, TException expected, T1? arg1, T2? arg2)
    where TException : Exception
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                TestDataThrows<TException, T1?, T2?> testData = new(definition, expected, arg1, arg2);
                CheckedTheoryData(initTestDataTheoryData()).Add(testData);
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(expected, arg1, arg2);
                break;
            default:
                break;
        }

        static TheoryData<TestDataThrows<TException, T1?, T2?>> initTestDataTheoryData() => [];
        static TheoryData<TException, T1?, T2?> initTheoryData() => [];
    }

    // AddTestDataThrowsToTheoryData<> overloads here...
}
```

## Usage

```csharp
using CsabaDu.DynamicTestData.Statics;
using Xunit;

namespace CsabaDu.DynamicTestData.SampleCodes.DynamicDataSources;

public class TheoryDataSource(ArgsCode argsCode)
{
    protected ArgsCode ArgsCode { get; init; } = argsCode.Defined(nameof(argsCode));

    private readonly DateTime DateTimeNow = DateTime.Now;

    private DateTime _thisDate;
    private DateTime _otherDate;
    private ITestData? _testData;

    private void AddTestDataReturns(TheoryData theoryData, string definition, bool expected)
    {
        _testData = new TestDataReturns<bool, DateTime, DateTime>(definition, expected, _thisDate, _otherDate);
        AddTestData<bool>(theoryData);
    }

    private void AddTestDataThrows(TheoryData theoryData, string paramName)
    {
        _testData = new TestDataThrows<ArgumentOutOfRangeException, DateTime, DateTime>(getDefinition(), getExpected(), _thisDate, _otherDate);
        AddTestData<ArgumentOutOfRangeException>(theoryData);

        #region Local methods
        string getDefinition()
        => $"{paramName} is greater than the current date";

        ArgumentOutOfRangeException getExpected()
        => new(paramName, DemoClass.GreaterThanCurrentDateTimeMessage);
        #endregion
    }

    private void AddTestData<TResult>(TheoryData theoryData) where TResult : notnull
    {
        var testData = _testData as ITestData<TResult, DateTime, DateTime>;

        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                (theoryData as TheoryData<ITestData<TResult, DateTime, DateTime>>)!.Add(testData!);
                break;
            case ArgsCode.Properties:
                (theoryData as TheoryData<TResult, DateTime, DateTime>)!.Add(testData!.Expected, testData.Arg1, testData.Arg2);
                break;
            default:
                break;
        }
    }

    public TheoryData IsOlderReturnsToTheoryData()
    {
        TheoryData? theoryData = ArgsCode switch
        {
            ArgsCode.Instance => new TheoryData<ITestData<bool, DateTime, DateTime>>(),
            ArgsCode.Properties => new TheoryData<bool, DateTime, DateTime>(),
            _ => default,
        };

        bool expected = true;
        string definition = "thisDate is greater than otherDate";
        _thisDate = DateTimeNow;
        _otherDate = DateTimeNow.AddDays(-1);
        addTestData();

        expected = false;
        definition = "thisDate equals otherDate";
        _otherDate = DateTimeNow;
        addTestData();

        definition = "thisDate is less than otherDate";
        _thisDate = DateTimeNow.AddDays(-1);
        addTestData();

        return theoryData!;

        #region Local methods
        void addTestData()
        => AddTestDataReturns(theoryData!, definition, expected);
        #endregion
    }

    public TheoryData IsOlderThrowsToTheoryData()
    {
        TheoryData? theoryData = ArgsCode switch
        {
            ArgsCode.Instance => new TheoryData<ITestData<ArgumentOutOfRangeException, DateTime, DateTime>>(),
            ArgsCode.Properties => new TheoryData<ArgumentOutOfRangeException, DateTime, DateTime>(),
            _ => default,
        };

        string paramName = "otherDate";
        _thisDate = DateTimeNow;
        _otherDate = DateTimeNow.AddDays(1);
        addTestData();

        paramName = "thisDate";
        _thisDate = DateTimeNow.AddDays(1);
        addTestData();

        return theoryData!;

        #region Local methods
        void addTestData()
        => AddTestDataThrows(theoryData!, paramName);
        #endregion
    }
}
```

```csharp
using Xunit;

namespace CsabaDu.DynamicTestData.SampleCodes.xUnitSamples.TheoryDataSamples;

public sealed class DemoClassTestsTestDataToTheoryDataInstance
{
    private readonly DemoClass _sut = new();
    private static readonly TestDataToTheoryDataSource DataSource = new(ArgsCode.Instance);

    public static TheoryData<TestDataReturns<bool, DateTime, DateTime>>? IsOlderReturnsArgsTheoryData
    => DataSource.IsOlderReturnsToTheoryData() as TheoryData<TestDataReturns<bool, DateTime, DateTime>>;

    public static TheoryData<TestDataThrows<ArgumentOutOfRangeException, DateTime, DateTime>>? IsOlderThrowsArgsTheoryData
    => DataSource.IsOlderThrowsToTheoryData() as TheoryData<TestDataThrows<ArgumentOutOfRangeException, DateTime, DateTime>>;

    [Theory, MemberData(nameof(IsOlderReturnsArgsTheoryData))]
    public void IsOlder_validArgs_returnsExpected(TestDataReturns<bool, DateTime, DateTime> testData)
    {
        // Arrange & Act
        var actual = _sut.IsOlder(testData.Arg1, testData.Arg2);

        // Assert
        Assert.Equal(testData.Expected, actual);
    }

    [Theory, MemberData(nameof(IsOlderThrowsArgsTheoryData))]
    public void IsOlder_invalidArgs_throwsException(TestDataThrows<ArgumentOutOfRangeException, DateTime, DateTime> testData)
    {
        // Arrange & Act
        void attempt() => _ = _sut.IsOlder(testData.Arg1, testData.Arg2);

        // Assert
        var actual = Assert.Throws<ArgumentOutOfRangeException>(attempt);
        Assert.Equal(testData.Expected.ParamName, actual.ParamName);
        Assert.Equal(testData.Expected.Message, actual.Message);
    }
}
```

```csharp
using Xunit;

namespace CsabaDu.DynamicTestData.SampleCodes.xUnitSamples.TheoryDataSamples;

public sealed class DemoClassTestsTestDataToTheoryDataProperties
{
    private readonly DemoClass _sut = new();
    private static readonly TestDataToTheoryDataSource DataSource = new(ArgsCode.Properties);

    public static TheoryData<bool, DateTime, DateTime>? IsOlderReturnsArgsTheoryData
    => DataSource.IsOlderReturnsToTheoryData() as TheoryData<bool, DateTime, DateTime>;

    public static TheoryData<ArgumentOutOfRangeException, DateTime, DateTime>? IsOlderThrowsArgsTheoryData
    => DataSource.IsOlderThrowsToTheoryData() as TheoryData<ArgumentOutOfRangeException, DateTime, DateTime>;

    [Theory, MemberData(nameof(IsOlderReturnsArgsTheoryData))]
    public void IsOlder_validArgs_returnsExpected(bool expected, DateTime thisDate, DateTime otherDate)
    {
        // Arrange & Act
        var actual = _sut.IsOlder(thisDate, otherDate);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(IsOlderThrowsArgsTheoryData))]
    public void IsOlder_invalidArgs_throwsException(ArgumentOutOfRangeException expected, DateTime thisDate, DateTime otherDate)
    {
        // Arrange & Act
        void attempt() => _ = _sut.IsOlder(thisDate, otherDate);

        // Assert
        var actual = Assert.Throws<ArgumentOutOfRangeException>(attempt);
        Assert.Equal(expected.ParamName, actual.ParamName);
        Assert.Equal(expected.Message, actual.Message);
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
