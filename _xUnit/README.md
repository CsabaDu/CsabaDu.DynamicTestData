# CsabaDu.DynamicTestData.NUnit

`CsabaDu.DynamicTestData.NUnit` is a lightweight, robust type-safe C# library designed to facilitate dynamic data-driven testing in NUnit framework, by providing a simple and intuitive way to generate `TheoryData` instances at runtime, based on `CsabaDu.DynamicTestData` features.

## Table of Contents

- [Description](#description)
- [Features](#features)
- [Quick Start](#quick-start)
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

## Quick Start

## Types

### Abstract `DynamicTheoryDataSource` Class

```csharp
namespace CsabaDu.DynamicTestData.xUnit.DynamicDataSources;

public abstract class DynamicTheoryDataSource(ArgsCode argsCode) : DynamicDataSource(argsCode)
{
    internal const string ArgumentsAreSuitableForCreating = "Arguments are suitable for creating ";
    internal const string ElementsAndDoNotMatchWithTheInitiated = " elements and do not match with the initiated ";
    internal const string InstancesTypeParameters = " instance's type parameters.";
    internal const string ArgsCodePropertyHasInvalidValue = "ArgsCode property has invalid value: ";

    private InvalidOperationException ArgsCodeProperyValueInvalidOperationException
    => new(ArgsCodePropertyHasInvalidValue + (int)ArgsCode);

    protected TheoryData? TheoryData { get; set; } = null;

    protected void ResetTheoryData() => TheoryData = null;

    internal string GetArgumentsMismatchMessage<TTheoryData>() where TTheoryData : TheoryData
    => ArgumentsAreSuitableForCreating
        + typeof(TTheoryData).Name + ElementsAndDoNotMatchWithTheInitiated
        + TheoryData?.GetType().Name + InstancesTypeParameters;

    private TTheoryData CheckedTheoryData<TTheoryData>(TTheoryData theoryData) where TTheoryData : TheoryData
    => (TheoryData ??= theoryData) is TTheoryData typedTheoryData ?
        typedTheoryData
        : throw new ArgumentException(GetArgumentsMismatchMessage<TTheoryData>());

    #region AddTestDataToTheoryData
    public void AddTestDataToTheoryData<T1>(string definition, string expected, T1? arg1)
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                CheckedTheoryData(initTestDataTheoryData()).Add(getTestData());
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(arg1);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
        }

        #region Local methods
        TestData<T1?> getTestData() => new(definition, expected, arg1);

        static TheoryData<TestData<T1?>> initTestDataTheoryData() => [];
        static TheoryData<T1?> initTheoryData() => [];
        #endregion
    }

    public void AddTestDataToTheoryData<T1, T2>(string definition, string expected, T1? arg1, T2? arg2)
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                CheckedTheoryData(initTestDataTheoryData()).Add(getTestData());
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(arg1, arg2);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
        }

        #region Local methods
        TestData<T1?, T2?> getTestData() => new(definition, expected, arg1, arg2);

        static TheoryData<TestData<T1?, T2?>> initTestDataTheoryData() => [];
        static TheoryData<T1?, T2?> initTheoryData() => [];
        #endregion
    }

    // AddTestDataToTheoryData<> overloads here...

    #endregion

    #region AddTestDataReturnsToTheoryData
    public void AddTestDataReturnsToTheoryData<TStruct, T1>(string definition, TStruct expected, T1? arg1)
    where TStruct : struct
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                CheckedTheoryData(initTestDataTheoryData()).Add(getTestData());
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(expected, arg1);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
        }

        #region Local methods
        TestDataReturns<TStruct, T1?> getTestData() => new(definition, expected, arg1);

        static TheoryData<TestDataReturns<TStruct, T1?>> initTestDataTheoryData() => [];
        static TheoryData<TStruct, T1?> initTheoryData() => [];
        #endregion
    }

    public void AddTestDataReturnsToTheoryData<TStruct, T1, T2>(string definition, TStruct expected, T1? arg1, T2? arg2)
    where TStruct : struct
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                CheckedTheoryData(initTestDataTheoryData()).Add(getTestData());
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(expected, arg1, arg2);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
        }

        #region Local methods
        TestDataReturns<TStruct, T1?, T2?> getTestData() => new(definition, expected, arg1, arg2);

        static TheoryData<TestDataReturns<TStruct, T1?, T2?>> initTestDataTheoryData() => [];
        static TheoryData<TStruct, T1?, T2?> initTheoryData() => [];
        #endregion
    }

    // AddTestDataReturnsToTheoryData<> overloads here...

    #endregion

    #region AddTestDataThrowsToTheoryData
    public void AddTestDataThrowsToTheoryData<TException, T1>(string definition, TException expected, T1? arg1)
    where TException : Exception
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                CheckedTheoryData(initTestDataTheoryData()).Add(getTestData());
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(expected, arg1);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
        }

        #region Local methods
        TestDataThrows<TException, T1?> getTestData() => new(definition, expected, arg1);

        static TheoryData<TestDataThrows<TException, T1?>> initTestDataTheoryData() => [];
        static TheoryData<TException, T1?> initTheoryData() => [];
        #endregion
    }

    public void AddTestDataThrowsToTheoryData<TException, T1, T2>(string definition, TException expected, T1? arg1, T2? arg2)
    where TException : Exception
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                CheckedTheoryData(initTestDataTheoryData()).Add(getTestData());
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(expected, arg1, arg2);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
        }

        #region Local methods
        TestDataThrows<TException, T1?, T2?> getTestData() => new(definition, expected, arg1, arg2);

        static TheoryData<TestDataThrows<TException, T1?, T2?>> initTestDataTheoryData() => [];
        static TheoryData<TException, T1?, T2?> initTheoryData() => [];
        #endregion
    }

    // AddTestDataThrowsToTheoryData<> overloads here...

    #endregion
}
```

## Usage

```csharp
using CsabaDu.DynamicTestData.xUnit.Attributes;
using CsabaDu.DynamicTestData.xUnit.DynamicDataSources;
using Xunit;

namespace CsabaDu.DynamicTestData.SampleCodes.DynamicDataSources;

class TestDataToTheoryDataSource(ArgsCode argsCode) : DynamicTheoryDataSource(argsCode)
{
    private readonly DateTime DateTimeNow = DateTime.Now;

    private DateTime _thisDate;
    private DateTime _otherDate;

    public TheoryData? IsOlderReturnsToTheoryData()
    {
        bool expected = true;
        string definition = "thisDate is greater than otherDate";      
        _thisDate = DateTimeNow;
        _otherDate = DateTimeNow.AddDays(-1);
        addTestDataToTheoryData();

        expected = false;
        definition = "thisDate equals otherDate";
        _otherDate = DateTimeNow;
        addTestDataToTheoryData();

        definition = "thisDate is less than otherDate";
        _thisDate = DateTimeNow.AddDays(-1);
        addTestDataToTheoryData();

        return TheoryData;

        #region Local methods
        void addTestDataToTheoryData()
        => AddTestDataReturnsToTheoryData(definition, expected, _thisDate, _otherDate);
        #endregion
    }

    public TheoryData? IsOlderThrowsToTheoryData()
    {
        string paramName = "otherDate";
        _thisDate = DateTimeNow;
        _otherDate = DateTimeNow.AddDays(1);
        addTestDataToTheoryData();

        paramName = "thisDate";
        _thisDate = DateTimeNow.AddDays(1);
        addTestDataToTheoryData();

        return TheoryData;

        #region Local methods
        void addTestDataToTheoryData()
        => AddTestDataThrowsToTheoryData(getDefinition(), getExpected(), _thisDate, _otherDate);

        string getDefinition()
        => $"{paramName} is greater than the current date";

        ArgumentOutOfRangeException getExpected()
        => new(paramName, DemoClass.GreaterThanCurrentDateTimeMessage);
        #endregion
    }
}
```

```csharp
using CsabaDu.DynamicTestData.xUnit.Attributes;
using Xunit;

namespace CsabaDu.DynamicTestData.SampleCodes.xUnitSamples.TheoryDataSamples;

public sealed class DemoClassTestsTestDataToTheoryDataInstance : IDisposable
{
    private readonly DemoClass _sut = new();
    private static readonly TestDataToTheoryDataSource DataSource = new(ArgsCode.Instance);

    public void Dispose() => DataSource.ResetTheoryData();

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
using CsabaDu.DynamicTestData.xUnit.Attributes;
using Xunit;

namespace CsabaDu.DynamicTestData.SampleCodes.xUnitSamples.TheoryDataSamples;

public sealed class DemoClassTestsTestDataToTheoryDataProperties : IDisposable
{
    private readonly DemoClass _sut = new();
    private static readonly TestDataToTheoryDataSource DataSource = new(ArgsCode.Properties);

    public void Dispose() => DataSource.ResetTheoryData();

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
