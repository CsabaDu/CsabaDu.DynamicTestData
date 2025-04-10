# CsabaDu.DynamicTestData.xUnit

`CsabaDu.DynamicTestData.xUnit` is a lightweight, robust type-safe C# library designed to facilitate dynamic data-driven testing in xUnit framework, by providing a simple and intuitive way to generate `TheoryData` instances at runtime, based on `CsabaDu.DynamicTestData` features.

## Table of Contents

- [**Description**](#description)
- [**What's New?**](#whats-new)
- [**Features**](#features)
- [**Quick Start**](#quick-start)
- [**Types**](#types)
- [**How it Works**](#how-it-works)
  - [Abstract DynamicTheoryDataSource Class](#abstract-dynamictheorydatasource-class)
- [**Usage**](#usage)
  - [Sample DemoClass](#sample-democlass)
  - [Sample TestDataToTheoryDataSource Class](#sample-testdatatotheorydatasource-class)
  - [Sample Test Classes with TheoryData source](#sample-test-classes-with-theorydata-source)
- [**Changelog**](#changelog) 
- [**Contributing**](#contributing)
- [**License**](#license)
- [**Contact**](#contact)
- [**FAQ**](#faq)
- [**Troubleshooting**](#troubleshooting)

## Description

`CsabaDu.DynamicTestData.xUnit` framework provides a set of utilities for dynamically generating and managing test data, particularly in xUnit. It simplifies the process of creating parameterized tests by offering a flexible and extensible way to define test cases with various arguments, expected results, and exceptions, based on `CsabaDu.DynamicTestData`features and the `TheoryData` type of xUnit.

## What's New?

### **Version 1.1.0**

- **New Feature**: Enhanced flexibility in generating exceptionally different `TheoryData` instances with optional `ArgsCode?` parameter.

- **Compatibility**: This update is fully backward-compatible with previous versions. Existing solutions will continue to work without any changes.

## Features
(Updated v1.1.0)

**Inherited `CsabaDu.DynamicTestData` Features**:
- Complete functionality of the `CsabaDu.DynamicTestData` framework is available as dependency.

**`TheoryData` Type Support**:
- The generic `TestData` record of `CsabaDu.DynamicTestData` framework and its derived types (`TestDataReturns`, `TestDataThrows`) which support up to nine arguments (`T1` to `T9`) are used for `TheoryData` instances creation at runtime.

**`Struct` Support**:
- The `AddTestDataReturnsToTheoryData` methods are designed for creating test cases that expect returning a struct (value type).

**`Exception` Support**:
- The `TestDataThrows` type which is specifically designed for test cases that expect exceptions to be thrown can either be used to create `TheoryData` instances with the `AddTestDataThrowsToTheoryData`.
- It includes the expected exception type and any arguments required for the test.

**`DynamicTheoryDataSource` Abstract Class**:
- Provides methods (`AddTestDataToTheoryData`, `AddTestDataReturnsToTheoryData`, `AddTestDataThrowsToTheoryData`) to create `TheoryData` of xUnit instances and add the converted test data to it for data-driven test methods.
- These methods use the `ArgsCode` enum of `CsabaDu.DynamicTestData` to determine if `TheoryData` instances shall consist of `TestData` record instances or their properties.
- The `AddOptionalToTheoryData` method makes possible the thread-safe temporary overriding of the original (default) `ArgsCode` property value. (New v1.1.0)

**Dynamic Data Generation**:
- Designed to easily generate `TheoryData` instances dynamically.

**Type Safety**:
- Ensures type safety for generated test data with using `TestData` generic types for `TheoryData` instances creation.

**Thread Safety**:
- The generated `TestData` record types' immutability ensures thread safety of tests with `TheoryData`types too.

**Readability**:
- The `TestCase` property of the TestData types is designed to create a literal test description to display in Visual Studio Test Explorer when using as `TheoryData` element.

**xUnit Integration**:
- Easy to integrate with xUnit framework.
- Seamlessly create `TheoryData` instances and add the converted test data to it for use in parameterized tests.

**Portability**:
- Besides xUnit support and dependency, easy to integrate with other test frameworks as well.

**Enhanced Flexibility** (New v1.1.0):
- You can generate exceptionally different `TheoryData` instances in the same test method with optional `ArgsCode?` parameter.

## Quick Start
(Updated v1.1.0)

1. **Install the NuGet package**:
  - You can install the `CsabaDu.DynamicTestData.xUnit` NuGet package from the NuGet Package Manager Console by running the following command:
     ```shell
     Install-Package CsabaDu.DynamicTestData.xUnit
     ```
 2. **Create a derived dynamic `TheoryData` source class**:
  - Create one class for each test class separately that extends the `DynamicTheoryDataSource` base class.
  - Implement `TheoryData` returning (base) type methods to generate test data.
  - Use the `AddTestDataToTheoryData`, `AddTestDataReturnsToTheoryData`, and `AddTestDataThrowsToTheoryData` methods to add the test data which were dynamically created within the methods to the `TheoryData TheoryData` property.
  - Use the `OptionalToArgs` method along with the `TheoryData` generating methods. (New v1.1.0)
  - (See the [Sample DynamicTheoryDataSource  Child Class](#sample-dynamictheorydatasource-child-class) section for a sample code.)

 3. **Insert the `TheoryData` source instance in the test class**:
  - Declare a static instance of the derived `DynamicTheoryDataSource` child class in the test class and initiate it with either `ArgsCode.Instance` or `ArgsCode.Properties` parameter.
  - Declare static `TheoryData<>` properties or methods with exact type parameters to call the test data generated by the dynamic data source class.
  - Cast the called `TheoryData` instances to the exact types of `TheoryData<>` to use it in the test methods.
  - Override the default `ArgsCode` value of any data source method by adding `ArgsCode`parameter to the called method. (New v1.1.0)

 4. **Use dynamic `TheoryData` source members in the test methods**:
  - Use the `MemberData` attribute in xUnit to pass the test data to the test methods.
  - Initialize the attribute with the belonging dynamic data source member name.
  - (See the [Sample Test Classes with TheoryData source](#sample-test-classes-with-theorydata-source) or section for sample codes.)

## Types

### **`DynamicTheoryDataSource` Abstract Class**
 - **Purpose**: Represents an abstract base class for dynamic `TheoryData` sources.
 - **Property**:
   - `TheoryData`: Gets or sets the `TheoryData` used for parameterized tests.
 - **Methods**:
    - `AddTestDataToTheoryData<T1, T2, ..., T9>(...)`: Adds test data to the `TheoryData` instance with one to nine arguments.
    - `AddTestDataReturnsToTheoryData<TStruct, T1, T2, ..., T9>(...)`: Adds test data to `TheoryData` instance for tests that expect a struct to assert.
    - `AddTestDataThrowsToTheoryData<TException, T1, T2, ..., T9>(...)`: Adds test data to `TheoryData` instance for tests that throw exceptions.
    - `AddOptionalToTheoryData(Action addTestDataToTheoryData, ArgsCode? argsCode)`: Executes the provided action with an optional temporary ArgsCode override. (New v1.1.0) 
    - `ResetTheoryData()`: Sets the `TheoryData` property with null value.

## How it Works
(Updated v1.1.1)

This framework is the extension of [CsabaDu.DynamicTestData](https://github.com/CsabaDu/CsabaDu.DynamicTestData#csabadudynamictestdata) framework. If you are not familiar with that framework yet, learn more about it, especially about the [ArgsCode Enum](https://github.com/CsabaDu/CsabaDu.DynamicTestData#argscode-enum), the [ITestData Base Interfaces](https://github.com/CsabaDu/CsabaDu.DynamicTestData#itestdata-base-interfaces) and [TestData Record Types](https://github.com/CsabaDu/CsabaDu.DynamicTestData#testdata-record-types) of that.

### Abstract `DynamicTheoryDataSource` Class
(Updated v1.1.1)

This class extends the abstract `DynamicDataSource` class of `CsabaDu.DynamicTestData` framework. (To learn more about the base class, see [Abstract DynamicDataSource Class](https://github.com/CsabaDu/CsabaDu.DynamicTestData/?tab=readme-ov-file#abstract-dynamicdatasource-class).)

This class contains the `AddTestDataToTheoryData`, `AddTestDataReturnsToTheoryData` and `AddTestDataThrowsToTheoryData` methods to add `TestData` instances of `CsabaDu.DynamicTestData` framework or its propertes to an initiated `TheoryData` instance. (To learn more about the `TestData` types of `CsabaDu.DynamicTestData`, see [ITestData Base Interfaces](https://github.com/CsabaDu/CsabaDu.DynamicTestData/#itestdata-base-interfaces) and [TestData Record Types](https://github.com/CsabaDu/CsabaDu.DynamicTestData/#testdata-record-types).) Once you call an `AddTestData...` method of the class, initialize a new `TheoryData` instance inside if the `TheoryData` property is null, and adds the test data to it.

Parameters of the methods are the same as the object array generator methods of the parent `DynamicDataSource` class, as well as the intended usage of it:

- extend this class for each test class separately,
- implement the necessary specific methods in the derived class with the `TheoryData` returning type, and
- declare a static instance of the derived class in the test class with the exact generic `TheoryData<>` type where it is going to be used.

You should do two more specific steps:

- Cast the called `TheoryData` returning type method to the exact generic `TheoryData<>` type.
- Implement the `IDisposable` interface and call the `ResetTheoryData()` method of the data source class with the `Dispose()` method call.

These methods contain two static methods each to initialize the `TheoryData` property with the appropriate type instance. The methods use the generic `CheckedTheoryData` private method which
- checks if `TheoryData` property is null so it should be initialize,
- Checks if its `TheoryData` instance parameter is of the same type with the `TheoryData`, and
- Adds the `TheoryData` instance to the `TheoryData` property.

```csharp
namespace CsabaDu.DynamicTestData.xUnit.DynamicDataSources;

public abstract class DynamicTheoryDataSource(ArgsCode argsCode) : DynamicDataSource(argsCode)
{
    internal const string ArgumentsAreSuitableForCreating = "Arguments are suitable for creating ";
    internal const string ArgsCodePropertyHasInvalidValue = "ArgsCode property has invalid value: ";

    internal string ArgumentsMismatchMessageEnd => " elements and do not match with the initiated "
        + TheoryData?.GetType().Name + " instance's type parameters.";

    private InvalidOperationException ArgsCodeProperyValueInvalidOperationException
    => new(ArgsCodePropertyHasInvalidValue + (int)ArgsCode);

    protected TheoryData? TheoryData { get; set; } = null;

    public void ResetTheoryData() => TheoryData = null;

    internal string GetArgumentsMismatchMessage<TTheoryData>() where TTheoryData : TheoryData
    => ArgumentsAreSuitableForCreating + typeof(TTheoryData).Name
        + ArgumentsMismatchMessageEnd;

    private TTheoryData CheckedTheoryData<TTheoryData>(TTheoryData theoryData) where TTheoryData : TheoryData
    => (TheoryData ??= theoryData) is TTheoryData typedTheoryData ?
        typedTheoryData
        : throw new ArgumentException(GetArgumentsMismatchMessage<TTheoryData>());

    #region Code adjustments v1.1.0
    public void AddOptionalToTheoryData(Action addTestDataToTheoryData, ArgsCode? argsCode)
    {
        ArgumentNullException.ThrowIfNull(addTestDataToTheoryData, nameof(addTestDataToTheoryData));
        WithOptionalArgsCode(this, addTestDataToTheoryData, argsCode);
    }
    #endregion

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

#### **Protected `TheoryData` Property**
(Updated v1.1.1)

Since `TheoryData` type is an IEnumerable itself, to follow the pattern of `CsabaDu.DynamicTestData`, the test data rows are stored and got by this property.

Don't forget to install `IDisposable` interface in the test methods which use these `TheoryData` sources and call `ResetTheoryData` to reset this property value after each test method run.

#### **`ResetTheoryData` Method**
(Updated v1.1.1)

This method resets the `TheoryData` property value. The purpose of this method is to call by the `Dispose` method in the test classes which implement the `IDisposable` interface.

#### **`AddOptionalToTheoryData` Method**
(New v1.1.0)

The function of this method is to invoke the `TheoryData` generator `AddTestDataToTheoryData`, `AddTestDataReturnsToTheoryData` or `AddTestDataThrowsToTheoryData` method given as `Action` parameter to its signature. If the second optional `ArgsCode?` parameter is not null, the ArgsCode value of the initialized `DynamicTheoryDataSource` child instance will be overriden temporarily in a using block of the DisposableMemento class. Note that overriding the default `ArgsCode` is expensive so apply for it just occasionally. However, using this method with null value `ArgsCode?` parameter does not have significant impact on the performance yet.

## Usage

Here are some basic examples of how to use `CsabaDu.DynamicTestData.xUnit` in your project.

### **Sample `DemoClass`**
(Updated v1.1.0)

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

### **Sample `TestDataToTheoryDataSource` Class**
(Updated v1.1.0)

You can easily implement a dynamic `TheoryData` source class by extending the `DynamicTheoryDataSource` base class with `TheoryData` type data source methods. You can use these just in xUnit test framework. You can easily adjust your already existing data source methods you used with version 1.0.x yet to have the benefits of the new feature (see comments in the sample code):

1. Add an optional `ArgsCode?` parameter to the data source methods signature.
2. Add `addOptionalToTheoryData` local method to the enclosing data source methods and call `AddOptionalToTheoryData` method with the `addTestDataToTheoryData` and `argsCode` parameters.
3. Call `addOptionalToTheoryData` local method to generate `TheoryData` instances with data-driven test arguments .

However, note that this version is fully compatible backward, you can use the data source test classes and methods with the current version without any necessary change. The second data source method of the sample code remained unchanged as simpler but less flexible implememtation.


The derived dynamic `TheoryData` source class looks quite similar to the sample [Test Framework Independent Dynamic Data Source](https://github.com/CsabaDu/CsabaDu.DynamicTestData/tree/master?tab=readme-ov-file#test-framework-independent-dynamic-data-source) of `CsabaDu.DynamicTestData`:

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

    // 1. Add an optional 'ArgsCode?' parameter to the method signature.
    public TheoryData? IsOlderReturnsToTheoryData(ArgsCode? argsCode = null)
    {
        bool expected = true;
        string definition = "thisDate is greater than otherDate";      
        _thisDate = DateTimeNow;
        _otherDate = DateTimeNow.AddDays(-1);
        // 3. Call 'addOptionalToTheoryData' method.
        addOptionalToTheoryData();

        expected = false;
        definition = "thisDate equals otherDate";
        _otherDate = DateTimeNow;
        // 3. Call 'addOptionalToTheoryData' method.
        addOptionalToTheoryData();

        definition = "thisDate is less than otherDate";
        _thisDate = DateTimeNow.AddDays(-1);
        // 3. Call 'addOptionalToTheoryData' method.
        addOptionalToTheoryData();

        return TheoryData;

        #region Local methods
        // 2. Add 'addOptionalToTheoryData' local method to the enclosing method
        // and call 'AddOptionalToTheoryData' method with the 'addtestDataToTheoryeData' and argsCode parameters.
        void addOptionalToTheoryData()
        => AddOptionalToTheoryData(addTestDataToTheoryData, argsCode);

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

### **Sample Test Classes with `TheoryData` source**

Note that you cannot implement `IXunitSerializable` or `IXunitSerializer` (xUnit.v3) interfaces any way, since `TestData` types are open-generic ones. Secondary reason is that `TestData` types intentionally don't have parameterless constructors. Anyway you can still use these types as dynamic test parameters or you can use the methods to generate object arrays of `IXunitSerializable` elements. Ultimately you can generate xUnit-serializable data-driven test parameters as object arrays of xUnit-serializable-by-default (p.e. intristic) elements.

The individual test cases will be displayed in Test Explorer on the Test Details screen as multiple result outcomes. To have the short name of the test method in Test Explorer add the following `xunit.runner.json` file to the test project:

```json
{
  "$schema": "https://xunit.net/schema/current/xunit.runner.schema.json",
  "methodDisplay": "method"
}
```

Furthermore, you should insert this item group in the xUnit project file too to have the desired result:

```xml
  <ItemGroup>
    <Content Include="xunit.runner.json" CopyToOutputDirectory="PreserveNewest" />
  </ItemGroup>
```

Besides, note that you can have the desired test case display name in the Test Explorer just when you use the `TestData` instance as the element of the generated object array, otherwise Test Explorer will display the test parameters in the default format.

Don't forget to implement the `IDisposable` interface and call the `ResetTheoryData()` method of the data source class with the `Dispose()` method call. Also don't forget to cast the called `TheoryData` returning type method to the exact generic `TheoryData<>` type.

Find xUnit sample codes for using `TestData` instance as test method parameter:  

```csharp
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

Results in the Test Explorer:

![xUnit_TheoryData_Intance_returns](https://raw.githubusercontent.com/CsabaDu/CsabaDu.DynamicTestData/master/Images/xUnit_TheoryData_Intance_returns.png)

![xUnit_TheoryData_Intance_throws](https://raw.githubusercontent.com/CsabaDu/CsabaDu.DynamicTestData/master/Images/xUnit_TheoryData_Intance_throws.png)

Find xUnit sample codes for using `TestData` properties' object array members as test method parameters.

```csharp
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

Results in the Test Explorer:

![xUnit_TheoryData_Properties_returns](https://raw.githubusercontent.com/CsabaDu/CsabaDu.DynamicTestData/master/Images/xUnit_TheoryData_Properties_returns.png)

![xUnit_TheoryData_Properties_throws](https://raw.githubusercontent.com/CsabaDu/CsabaDu.DynamicTestData/master/Images/xUnit_TheoryData_Properties_throws.png)

See how you can use the exceptionally overriden `ArgsCode`:

```csharp
using Xunit;

namespace CsabaDu.DynamicTestData.SampleCodes.xUnitSamples.TheoryDataSamples;

public sealed class DemoClassTestsTestDataToTheoryDataInstance : IDisposable
{
    private readonly DemoClass _sut = new();
    private static readonly TestDataToTheoryDataSource DataSource = new(ArgsCode.Instance);

    public void Dispose() => DataSource.ResetTheoryData();

    // ArgsCode Overriden
    public static TheoryData<bool, DateTime, DateTime>? IsOlderReturnsArgsTheoryData
    => DataSource.IsOlderReturnsToTheoryData(ArgsCode.Properties) as TheoryData<bool, DateTime, DateTime>;

    public static TheoryData<TestDataThrows<ArgumentOutOfRangeException, DateTime, DateTime>>? IsOlderThrowsArgsTheoryData
    => DataSource.IsOlderThrowsToTheoryData() as TheoryData<TestDataThrows<ArgumentOutOfRangeException, DateTime, DateTime>>;

    // Signature of the thest method adjusted to comply with the overriden ArgsCode.
    [Theory, MemberData(nameof(IsOlderReturnsArgsTheoryData))]
    public void IsOlder_validArgs_returnsExpected(bool expected, DateTime thisDate, DateTime otherDate)
    {
        // Arrange & Act
        var actual = _sut.IsOlder(thisDate, otherDate);

        // Assert
        Assert.Equal(expected, actual);
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
Results in the Test Explorer:

![xUnit_TheoryData_Properties_returns](https://raw.githubusercontent.com/CsabaDu/CsabaDu.DynamicTestData/master/Images/xUnit_TheoryData_OptionalArgsCode.png)

## Changelog

### **Version 1.0.0** (2025-03-20)

- Initial release of the `CsabaDu.DynamicTestData.xUnit` framework, which is a child of `CsabaDu.DynamicTestData` framework.
- Includes the `DynamicTheoryDataSource` base class.
- Provides support for dynamic data-driven tests with `TheoryData` arguments having different data, expected struct results, and exceptions, on top of the inherited `CsabaDu.DynamicTestData` features.

### **Version 1.1.0** (2025-04-01)

- **Added**: `AddOptionalToTheoryData` method added to the `DynamicTheoryDataSource` class.
- **Note**: This update is backward-compatible with previous versions.

#### **Version 1.1.1** (2025-04-02)
- **Updated**:
  - README.md How it Works - Abstract `DynamicTheoryDataSource` Class section updated with `CheckedTheoryData` method explanation.
  - README.md Added explanation how `TheoryData` property and `ResetTheoryData` method work.
  - Small README.md corrections and visual refactorings.  

## Contributing

Contributions are welcome! Please submit a pull request or open an issue if you have any suggestions or bug reports.

## License

This project is licensed under the MIT License. See the [License](LICENSE.txt) file for details.

## Contact

For any questions or inquiries, please contact [CsabaDu](https://github.com/CsabaDu).

## FAQ

## Troubleshooting
