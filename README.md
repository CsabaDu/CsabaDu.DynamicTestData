# CsabaDu.DynamicTestData

`CsabaDu.DynamicTestData` is a lightweight, robust, flexible and extensible, type- and thread-safe C# framework, designed to facilitate dynamic data-driven testing in MSTest, NUnit or xUnit frameworks, by providing simple and intuitive ways to generate test cases at runtime with literal names.

## Table of Contents

- [**Description**](#description)
- [**What's New?**](#whats-new)
- [**Features**](#features)
- [**Quick Start**](#quick-start)
- [**Types**](#types)
- [**How it Works**](#how-it-works)
  - [ArgsCode Enum](#argscode-enum)
  - [Static Extensions Class](#static-extensions-class)
    - [object?[] Extension Methods](#object-extension-methods)
    - [ArgsCode Extension Methods](#argscode-extension-methods)
  - [ITestData Base Interfaces](#itestdata-base-interfaces)
    - [ITestData Properties](#itestdata-properties)
    - [ITestData Methods](#itestdata-methods)
  - [TestData Record Types](#testdata-record-types)
    - [TestData](#testdata)
    - [TestDataReturns](#testdatareturns)
    - [TestDataThrows](#testdatathrows)
  - [Abstract DynamicDataSource Class](#abstract-dynamicdatasource-class)
    - [ArgsCode Property](#argscode-property)
    - [Static GetDisplayName Method](#static-getdisplayname-method)
    - [Object Array Generator Methods](#object-array-generator-methods)
    - [Embedded Private DisposableMemento Class](#embedded-private-disposablememento-class)
    - [OptionalToArgs Method](#optionaltoargs-method)
- [**Usage**](#usage)
  - [Sample DemoClass](#sample-democlass)
  - [Test Framework Independent Dynamic Data Source](#test-framework-independent-dynamic-data-source)
  - [Usage in MSTest](#usage-in-mstest)
  - [Usage in NUnit](#usage-in-nunit)
  - [Usage in xUnit](#usage-in-xunit)
  - [Usage of the Optional ArgsCode Parameter of the Data Source Methods](#usage-of-the-optional-argscode-parameter-of-the-data-source-methods)
- [**Advanced Usage**](#advanced-usage)
  - [Using TestCaseData type of NUnit](#using-testcasedata-type-of-nunit)
  - [Using TheoryData type of xUnit](#using-theorydata-type-of-xunit)
- [**Changelog**](#changelog)
- [**Contributing**](#contributing)
- [**License**](#license)
- [**Contact**](#contact)
- [**FAQ**](#faq)
- [**Troubleshooting**](#troubleshooting)

## Description

`CsabaDu.DynamicTestData` framework is particularly useful in a unit testing context, where it can help streamline the creation of test cases and ensure that tests are both comprehensive and easy to maintain. It is designed to be highly flexible and extensible, allowing developers to create and manage test data for a wide variety of scenarios and literal test case descriptions displaying in Visual Studio Test Explorer.

This framework consists of immutable `TestData` record types to initialize, store and proceed parameters of dynamic data-driven tests in runtime. It supports tests with multiple arguments, expected not null `ValueType' results and exceptions. It contains a `DynamicDataSource` base class with fully implemented methods to create specific object arrays of the data stored in the `record` instances. You get ready-to-use methods to create enumeration members of the derived dynamic data source classes. The use of generics and records ensures type safety and immutability, while the `ArgsCode` enum provides a clear way to specify how arguments should be handled.

It is a lightweight but robust framework. It does not have outer dependencies so it is portable, you can use with any test framework in Visual Studio. However consider the limitations of its usage and extensibility mentioned where applicable.

## What's New?

### **Version 1.4.0**

- **New Feature**: `object?[] PropertiesToArgs(bool withExpected)` method added to the `ITestData` interface, which allows you to get the test parameters of the `TestData` instance only as an array of objects, with or without the `Expected` property value. This method is useful for passing the selected properties of the `TestData` instance to a test framework defined test data type.

- **Compatibility**: This update is fully backward-compatible with previous versions. Existing solutions will continue to work without any changes.

## Features
(Updated v1.4.0)

**Generic `TestData` Types**:
- The `TestData` record and its derived types (`TestDataReturns`, `TestDataThrows`) are generic and support up to nine arguments (`T1` to `T9`).
- This allows for flexible test data creation for methods with varying numbers of parameters.

**`ValueType` Support** (Updated v1.4.0):
- The `TestDataReturns` record with `struct` constraint is designed for test cases that expect returning a not null `ValueType`.
- It ensures that the expected result is a not null `ValueType` and provides methods to convert the test data into arguments.

**`Exception` Support**:
- The `TestDataThrows` record is specifically designed for test cases that expect exceptions to be thrown.
- It includes the expected `Exception` type and any arguments required for the test.

**`DynamicDataSource` Abstract Class** (Updated v1.1.0):
- The `DynamicDataSource` class provides methods (`TestDataToArgs`, `TestDataReturnsToArgs`, `TestDataThrowsToArgs`) to convert test data into arguments for test methods.
- These methods use the `ArgsCode` to determine how to convert the test data.
- The `OptionalToArgs` method makes possible the thread-safe temporary overriding of the original (default) `ArgsCode` property value. (New v1.1.0)

**`ArgsCode` Enum**:
- The `ArgsCode` enum specifies the strategy how test data should be converted into arguments. For example:
- `ArgsCode.Instance`: Uses the test data instance itself as an argument.
- `ArgsCode.Properties`: Uses the properties of the test data as arguments.

**Dynamic Data Generation**:
- Designed to easily generate test data dynamically at runtime.

**Type Safety**:
- Ensures type safety for generated test data with using `TestData` generic types for test parameter set creation.

**Thread Safety**
- The generated `TestData` record types' immutability ensures thread safety.

**Readability**:
- The `TestCase` property of the TestData types is designed to create a literal test description to display in Visual Studio Test Explorer.

**Portability**:
- The framework does not have outer dependencies.
- Easy to integrate with your existing test frameworks.

**Enhanced Flexibility** (New v1.1.0):
- You can generate exceptionally different type object array lists in the same test method with optional `ArgsCode?` parameter.

**Extensibility**: (Updated v1.4.0)
- The framework is highly extensible. You can add new dynamic data source classes or test data types to suit your needs. You can extend the recent implementations or create new ones with implementing `ITestData` derived interfaces.
- Using exceptionally different optional `ArgsCode?` is extensible, either with functionts and processes. (New v1.2.0)
- `PropertiesToArgs` method of `ITestData` interface is useful for passing the selected properties of the `TestData` instance to a test framework defined test data type.

## Quick Start
(Updated v1.1.0)

1. **Install the NuGet package**:
  - You can install the `CsabaDu.DynamicTestData` NuGet package from the NuGet Package Manager Console by running the following command:
     ```shell
     Install-Package CsabaDu.DynamicTestData
     ```
2. **Create a derived dynamic test data source class**:
  - Create one class for each test class separately that extends the `DynamicDataSource` base class.
  - Implement `IEnumerable<object?[]>` returning type methods to generate test data.
  - Use the `TestDataToArgs`, `TestDataReturnsToArgs`, and `TestDataThrowsToArgs` methods to create test data rows within the methods.
  - Use the `OptionalToArgs` method along with the object array generating methods. (New v1.1.0)
  - (See the [Test Framework Independent Dynamic Data Source](#test-framework-independent-dynamic-data-source) section for a sample code.)

3. **Insert the dynamic test data source in the test class**:
  - Declare a static instance of the derived dynamic data source class in the test class and initialize it with either `ArgsCode.Instance` or `ArgsCode.Properties` parameter.
  - Declare static `IEnumerable<object?[]>` properties or methods to call the test data generated by the dynamic data source class.
  - Override the default `ArgsCode` value of any data source method by adding `ArgsCode`parameter to the called method. (New v1.1.0)

4. **Use dynamic test data source members in the test methods**:
  - Use the `DynamicData` attribute in MSTest, `TestCaseSource` attribute in NUnit, or `MemberData` attribute in xUnit to pass the test data to the test methods.
  - Initialize the attribute with the belonging dynamic data source member name.
  - (See the [Usage in MSTest](#usage-in-mstest), [Usage in NUnit](#usage-in-nunit) or [Usage in xUnit](#usage-in-xunit) sections for sample codes. For `TestCaseData` type usage of NUnit  or `TheoryData` type usage of xUnit, see [Advanced Usage](#advanced-usage) section. See sample usage of the optional `ArgsCode?` parameter in the [Using of the optional ArgsCode Parameter of the Data Source Methods)](#using-optional-argscode-parameter-of-the-data-source-methods) section.)

## Types
(Updated v1.4.0)

**`ArgsCode` Enum**
 - **Purpose**: Specifies the strategy of different ways to generate test data to an array of arguments.
 - **Values**:
   - `Instance`: Represents an instance ArgsCode.
   - `Properties`: Represents a properties ArgsCode.

**`Extensions` Static Class**
 - **Purpose**: Provides extension methods for adding elements to object arrays and validating `ArgsCode` enum parameters.
 - **Methods**:
   - `Add<T>(this object?[] args, ArgsCode argsCode, T? parameter)`: Adds a parameter to the array of arguments based on the specified `ArgsCode`.
   - `Defined(this ArgsCode argsCode, string paramName)`: Validates whether the specified `ArgsCode` is defined in the enumeration.
   - `GetInvalidEnumArgumentException(this ArgsCode argsCode, string paramName)`: Creates a new `InvalidEnumArgumentException` for the specified `ArgsCode` value.

**`ITestData` Interface** (Updated v1.4.0)
 - **Purpose**: Represents a test data interface with properties for test case and result, and a method to convert arguments.
 - **Properties**:
   - `Definition`: Gets the definition of the test case.
   - `ExitMode`: Gets the expected exit mode of the test.
   - `Result`: Gets the name of the expected result of the test case.
   - `TestCase`: Gets the test case description.
 - **Methods** (Updated v1.4.0):
   - `ToArgs(ArgsCode argsCode)`: Converts the `ITestData` instance to an array of arguments based on the specified `ArgsCode`.
   - `PropertiesToArgs(bool withExpected)`: Converts the selected properties of the `ITestData` instance to an array of objects, with or without the `Expected` property value as defined by the `bool withExpected` parameter. (New v1.4.0)

**`ITestData<TResult>` Interface**
 - **Purpose**: Represents a generic test data interface that extends `ITestData`.
 - **Property**:
   - `Expected`: Gets the expected result of the test case.

**`ITestDataReturns` interface** (New v1.3.0)
 - **Purpose**: Represents a base marker interface for test data that returns a value. 

**`ITestDataReturns<TStruct>` Interface**
 - **Purpose**: Represents an interface for test data that returns a value of type `TStruct`, which must be a not null `ValueType'.

**`ITestDataThrows` interface** (New v1.3.0)
 - **Purpose**: Represents a base marker interface for test data that throws an exception.

**`ITestDataThrows<TException>` Interface**
 - **Purpose**: Represents an interface for test data that throws exceptions of type `TException`.

**`ITestData<TResult, T1, T2, ..., T9>` Interfaces**
 - **Purpose**: Represent generic test data interfaces that extend `ITestData<TResult>` with additional arguments.
 - **Properties**:
   - `Arg1`, `Arg2`, ..., `Arg9`: Get the respective arguments of the test case.

**`TestData` Abstract Record** (Updated v1.4.0)
 - **Purpose**: Represents an abstract record for test data.
 - **Properties**:
   - `Definition`: The definition of the test data.
   - `ExitMode`: The expected exit mode of the test case.
   - `Result`: The result name of the test case.
   - `TestCase`: The test case string representation.
 - **Methods** (Updated v1.4.0):
   - `ToArgs(ArgsCode argsCode)`: Converts the test data to an array of arguments based on the specified `ArgsCode`.
   - `PropertiesToArgs(bool withExpected)`: Abstract method to be implemented in derived classes. (New v1.4.0)
   - `ToString`: Overrides and seals the `ToString` method to return the value of `TestCase` property. (Updated v1.4.0)

**`TestData<T1, T2, ..., T9>` Records** (Updated v1.4.0)
 - **Purpose**: Represent concrete records for test data with one to nine arguments.
 - **Method**:
   - `ToArgs(ArgsCode argsCode)`: Overrides the base method to add the respective arguments to the array.
   - `PropertiesToArgs(bool withExpected)`: Overrides and seals the abstract method in the `TestData<T1>` type with the behavior defined in the `ITestData` secction. (In the generic `TestData` instances this method always return the properties without the `Expected` property value.) (New v1.4.0)

**cTestDataReturns<TStruct, T1, T2, ..., T9>` Records** (Updated v1.4.0)
 - **Purpose**: Represent records for test data that returns a not null `ValueType' with one to nine additional arguments.
 - **Method**:
   - `ToArgs(ArgsCode argsCode)`: Overrides the base method to add the respective arguments to the array.
   - `PropertiesToArgs(bool withExpected)`: Overrides and seals the abstract method in the `TestDataReturns<TStruct, T1>` type with the behavior defined in the `ITestData` secction. (New v1.4.0)

**`TestDataThrows<TException, T1, T2, ..., T9>` Records** (Updated v1.4.0)
 - **Purpose**: Represent records for test data that throws exceptions with one to nine additional arguments.
 - **Method**:
   - `ToArgs(ArgsCode argsCode)`: Overrides the base method to add the respective arguments to the array.
   - `PropertiesToArgs(bool withExpected)`: Overrides and seals the abstract method in the `TestDataThrowss<TException, T1>` type with the behavior defined in the `ITestData` secction. (New v1.4.0)

**`DynamicDataSource` Abstract Class**
(Updated v1.1.0)
 - **Purpose**: Represents an abstract base class for dynamic data source classes and provides features to facilitate generating test data.
 - **Properties**:
   - `ArgsCode`: Gets the current `ArgsCode` value used for argument conversion, which is either the temporary override value or the default value. (Updated v1.1.0)
 - **Methods**:
   - `GetDisplayName(string? testMethodName, params object?[]? args)`: Gets the display name of the test method and the test case description.
   - `TestDataToArgs<T1, T2, ..., T9>(...)`: Converts test data to an array of arguments for tests with one to nine arguments.
   - `TestDataReturnsToArgs<TStruct, T1, T2, ..., T9>(...)`: Converts test data to an array of arguments for tests that expect a not null `ValueType' to assert.
   - `TestDataThrowsToArgs<TException, T1, T2, ..., T9>(...)`: Converts test data to an array of arguments for tests that throw exceptions.
   - `OptionalToArgs([NotNull] Func<object?[]> testDataToArgs, ArgsCode? argsCode)`: Executes the provided test data function with an optional temporary ArgsCode override. (New v1.1.0)

## How it Works
(Updated v1.4.0)

### **`ArgsCode` Enum**

Every test frameworks accept object arrays as dynamic data-driven tests' data rows. The test parameters should be the object array elements. Other approach is that the object array contains a single object element, and the tests' parameters can be the properties of this object element. 

`CsabaDu.DynamicTestData` supports both approaches, you can generate object arrays with either content. The outcome of the object array generator methods is controlled with the dedicated `enum ArgsCode` type parameter having two self-explanatory values:

```csharp
namespace CsabaDu.DynamicTestData.DynamicDataSources;

public enum ArgsCode
{
    Instance,
    Properties,
}
```

`ArgsCode` will be used as basic parameter of the object array generator methods.

### **Static `Extensions` Class**

```csharp
namespace CsabaDu.DynamicTestData.Statics;

public static class Extensions
{
    public static object?[] Add<T>(this object?[] args, ArgsCode argsCode, T? parameter)
    => argsCode switch
    {
        ArgsCode.Instance => args,
        ArgsCode.Properties => [.. args, parameter],
        _ => throw argsCode.GetInvalidEnumArgumentException(nameof(argsCode)),
    };

    public static ArgsCode Defined(this ArgsCode argsCode, string paramName)
    => Enum.IsDefined(argsCode) ? argsCode : throw argsCode.GetInvalidEnumArgumentException(paramName);

    public static InvalidEnumArgumentException GetInvalidEnumArgumentException(this ArgsCode argsCode, string paramName)
    => new(paramName, (int)(object)argsCode, typeof(ArgsCode));
}
```

#### **object?[] Extension Methods**

`object?[]` type is extended with a method to facilitate test data object arrays creation. Besides the object array which calls it, the method requires two parameters. In case of `Properties` value of the first `ArgsCode` argument the method increases the returning object array's elements with the new parameter as last one there, in case of `Instance` value it returns the original object array, otherwise it throws an `InvalidEnumArgumentException`.

#### **ArgsCode Extension Methods**

`ArgsCode` type is extended with guarding methods to validate the value of the `ArgsCode` type parameter:

- `Defined` method returns the `ArgsCode` parameter if valid, otherwise throws an `InvalidEnumArgumentException`.

- `GetInvalidEnumArgumentException` just returns an `InvalidEnumArgumentException` instance with the pre-set parameters.

### **`ITestData` Base Interfaces**
(Updated v1.4.0)

`CsabaDu.DynamicTestData` provides three extendable base `record` types, and their concrete generic implementations of strongly typed parameters with `T1` - `T9` open generic types.

Each `TestData` type implements the following interfaces:

```csharp
namespace CsabaDu.DynamicTestData.TestDataTypes.Interfaces;

public interface ITestData
{
    string Definition { get; }
    string? ExitMode { get; }
    string Result { get; }
    string TestCase { get; }

    object?[] ToArgs(ArgsCode argsCode);

    #region New feature v1.4.0
    object?[] PropertiesToArgs(bool withExpected);
    #endregion New feature v1.4.0
}

public interface ITestData<out TResult>
: ITestData
where TResult : notnull
{
    TResult Expected { get; }
}
```

`ITestData` is the base interface of three inheritance lines. All derived types implement an abstract class each which implements a dedicated interface derived from the `ITestData<out TResult>` interface. Inherited types are `TestData`, `TestDataReturns<TStruct>` and `TestDataThrows<TException>`.

The other inheritance line of the `ITestData<out TResult>` interface remains abstract and each concrete type inherits one. You can approach the different specified types having same test parameter types by calling these Interfaces:

```csharp
namespace CsabaDu.DynamicTestData.TestDataTypes.Interfaces;

public interface ITestData<out TResult, out T1>
: ITestData<TResult>
where TResult : notnull
{
    T1? Arg1 { get; }
}

public interface ITestData<out TResult, out T1, out T2>
: ITestData<TResult, T1>
where TResult : notnull
{
    T2? Arg2 { get; }
}

// And similar extended inheritances till T9 type argument.
```

#### **ITestData Properties**
(Updated v1.2.2)

All types have five common properties.

Two properties are injected as first two parameters to each derived concrete types' constructors:
- `string Definition` to describe the test case parameters to be asserted.
- `TResult Expected`, a generic type property with `notnull` constraint.

Additional properties are generated as follows:
- `string ExitMode` property gets a constant string declared in the derived types. This implementation gets the following strings in the derived types:
  - `TestData`: `null`,
  - `TestDataReturns<TStruct>`: `"returns"`,
  - `TestDataThrows<TException>`: `"throws"`.
- `string Result` property gets the appropriate string representation of the `Expected` property.
- `string TestCase` property gets the test case description. This text is created from the other properties in the following ways:
  - If `ExitMode` property gets null or an empty string: `$"{Definition} => {Result}"`,
  - Otherwise: `$"{Definition} => {ExitMode} {Result}`.

#### **ITestData Methods**
(Updated v1.4.0)

`ITestData` interface defines two methods:
- `object?[] ToArgs(ArgsCode argsCode)` method's intended behavior is to generate an object array from the `ITestData` instance in two ways: The returning object array should contain
  - either the selected properties of the `ITestData` instance
  - or the `ITestData` instance itself.
- `PropertiesToArgs(bool withExpected)`: method's intended behavior is to generate an object array from `ITestData` instance which - unlike the object array returned in `ToArgs(ArgsCode.Properties)` case - contains the test parameters only,
  - without the `TestCase` property value,
  - and with or without the `Expected` property value where it is applicable, as defined by the `bool withExpected` parameter. (New v1.4.0)

### **`ITestDataReturns` and `ITestDataThrows` Base Interfaces**
(New v1.3.0)

These non-generic base marker interfaces were added to call derived types. Purpose of these interfaces is to enhance extensibility.  

See the whole `ITestData` interface inheritance structure on the below picture:
(Updated v1.4.0)

![TestDataInterfaces](https://raw.githubusercontent.com/CsabaDu/CsabaDu.DynamicTestData/refs/heads/master/Images/ITestDataInheritance_v1_4_0.svg)

### **`TestData` Record Types**
(Updated v1.3.2)

All concrete TestData types are inherited from the `abstract record TestData` type. Its primary constructor with the `object?[] ToArgs(ArgsCode argsCode)` method's virtual implementation looks like:

```csharp
namespace CsabaDu.DynamicTestData.TestDataTypes;

public abstract record TestData(string Definition, string? ExitMode, string Result) 
: ITestData
{
    internal const string Returns = "returns";
    internal const string Throws = "throws";

    #region Code adjustments v1.3.1
    private readonly string definitionOrName = GetValueOrSubstitute(Definition, nameof(Definition));
    private readonly string resultOrName = GetValueOrSubstitute(Result, nameof(Result));
    private readonly string exitModeOrEmpty = GetValueOrSubstitute(ExitMode, string.Empty);

    public string TestCase
    => $"{definitionOrName} => {exitModeOrEmpty}{resultOrName}";

    private static string GetValueOrSubstitute(string? value, string substitute)
    => string.IsNullOrEmpty(value) ?
        substitute
        : substitute == string.Empty ?
            value + " "
            : value;
    #endregion Code adjustments v1.3.1

    public virtual object?[] ToArgs(ArgsCode argsCode) => argsCode switch
    {
        ArgsCode.Instance => [this],
        ArgsCode.Properties => [TestCase],
        _ => throw argsCode.GetInvalidEnumArgumentException(nameof(argsCode)),
    };

    public override sealed string ToString() => TestCase;

    #region New feature v1.4.0
    public abstract object?[] PropertiesToArgs(bool withExpected);

    // This method is called by the override 'PropertiesToArgs' methods
    // in the derived generic concrete 'TestData' instances.
    protected static object?[] PropertiesToArgs(
        TestData? testData,
        bool withExpected)
    {
        int count = propertiesToArgs()?.Length ?? 0;

        if (withExpected && count > 1)
        {
            return propertiesToArgs()![1..];
        }

        if (count > 2)
        {
            return propertiesToArgs()![2..];
        }

        throw new InvalidOperationException(
            "The test data properties count is " +
            "not enough for the current instance.");

        #region Local methods
        object?[]? propertiesToArgs()
        => testData?.ToArgs(ArgsCode.Properties);
        #endregion
    }
}
```

In the derived concrete `TestData` types the overriden `object?[] ToArgs(ArgsCode argsCode)` methods will increase the returning object array of the parent `record` with the recently added parameter in case of `ArgsCode.Properties` parameter, otherwise it will return an object array containing the given instance. Using the `object?[] Add<T>(this object?[] args, T? arg)` extension method, the overriden methods' implementations are uniform as you will see.

This type overrides and seals the `string ToString()` method with returning the `TestCase` property's value. When the instance is used as test method parameter, the test case display name will be the string representation of the instance. 

All derived types of `TestData` base type implement the `ITestdata<out TResult> : ITestData` interface. `TestData` concrete types will inherit direcly from the abstract `TestData` record, other types will inherit via `TestDataReturns<TStruct>` and `TestDataThrows<TException>` intermediate abstract types. 

#### **TestData**
(Updated v1.4.0)

Implements the following interface:

```csharp
namespace CsabaDu.DynamicTestData.TestDataTypes.Interfaces;

public interface ITestData<string>
: ITestData
```

- General purposes type `ITestData`.
- `Expected` property's type is `string`. The expected test case result should be written down literally.

Concrete `TestData` types primary constructors with the overriden `object?[] ToArgs(ArgsCode argsCode)` methods look like:

```csharp
namespace CsabaDu.DynamicTestData.TestDataTypes;

public record TestData<T1>(
    string Definition,
    string Expected,
    T1? Arg1)
: TestData(
    Definition,
    null,
    string.IsNullOrEmpty(Expected) ? nameof(Expected) : Expected),
    ITestData<string, T1>
{
    public override object?[] ToArgs(ArgsCode argsCode)
    => base.ToArgs(argsCode).Add(argsCode, Arg1);

    #region New feature v1.4.0
    public override sealed object?[] PropertiesToArgs(bool withExpected)
    => PropertiesToArgs(this, true);
    #endregion New feature v1.4.0
}

public record TestData<T1, T2>(
    string Definition,
    string Expected,
    T1? Arg1, T2? Arg2)
: TestData<T1>(
    Definition,
    Expected,
    Arg1),
    ITestData<string, T1, T2>
{
    public override object?[] ToArgs(ArgsCode argsCode)
    => base.ToArgs(argsCode).Add(argsCode, Arg2);
}

// And similar extended inheritances till T9 type argument.
```

`TestCase` displays in text explorer like:

`$"{Definition} => {string.IsNullOrEmpty(Expected) ? nameof(Expected) : Expected}`

Note that the `PropertiesToArgs` method in the generic `TestData` instances always return the properties without the `Expected` property value. This is because the `Expected` property is a literal description of the expected result, not a test parameter.

#### **TestDataReturns**
(Updated v1.4.0)

Implements the following interface:

```csharp
namespace CsabaDu.DynamicTestData.TestDataTypes.Interfaces;

public interface ITestDataReturns<out TStruct>
: ITestDataReturns, ITestData<TStruct>
where TStruct : struct;
```

- Designed to assert the comparison of numbers, booleans, enums, and other not null `ValueType` values.
- `Expected` property's type is not null `ValueType` (as this is the actual type definition of the `struct` constraint).
  
The abstract `TestDataReturns<TStruct>` type and its concrete derived types' primary constructors with the overriden `object?[] ToArgs(ArgsCode argsCode)` methods look like:

```csharp
namespace CsabaDu.DynamicTestData.TestDataTypes;

public abstract record TestDataReturns<TStruct>(
    string Definition,
    TStruct Expected)
: TestData(
    Definition,
    Returns,
    Expected.ToString() ?? nameof(Expected)),
    ITestDataReturns<TStruct>
where TStruct : struct
{
    public override object?[] ToArgs(ArgsCode argsCode)
    => base.ToArgs(argsCode).Add(argsCode, Expected);
}

public record TestDataReturns<TStruct, T1>(
    string Definition,
    TStruct Expected,
    T1? Arg1)
: TestDataReturns<TStruct>(
    Definition,
    Expected),
    ITestData<TStruct, T1>
where TStruct : struct
{
    public override object?[] ToArgs(ArgsCode argsCode)
    => base.ToArgs(argsCode).Add(argsCode, Arg1);

    #region New feature v1.4.0
    public override sealed object?[] PropertiesToArgs(bool withExpected)
    => PropertiesToArgs(this, withExpected);
    #endregion New feature v1.4.0
}

public record TestDataReturns<TStruct, T1, T2>(
    string Definition,
    TStruct Expected,
    T1? Arg1, T2? Arg2)
: TestDataReturns<TStruct, T1>(
    Definition,
    Expected,
    Arg1),
    ITestData<TStruct, T1, T2>
where TStruct : struct
{
    public override object?[] ToArgs(ArgsCode argsCode)
    => base.ToArgs(argsCode).Add(argsCode, Arg2);
}

// And similar extended inheritances till T9 type argument.
```

`TestCase` displays in text explorer like:

`$"{Definition} => returns {Expected.ToString() ?? nameof(Expected)}"`

#### **TestDataThrows**
(Updated v1.3.2)

Implements the following interface:

```csharp
namespace CsabaDu.DynamicTestData.TestDataTypes.Interfaces;

public interface ITestDataThrows<out TException>
: ITestDataThrows, ITestData<TException>
where TException : Exception;
```

- Designed for test cases where the expected result to be asserted is a thrown `Exception`.
- `Expected` property's type is `Exception`.

The abstract `TestDataThrows<TException>` type and its concrete derived types' primary constructors with the overriden `object?[] ToArgs(ArgsCode argsCode)` methods look like:

```csharp
namespace CsabaDu.DynamicTestData.TestDataTypes;

public abstract record TestDataThrows<TException>(
    string Definition,
    TException Expected)
: TestData(
    Definition,
    Throws,
    typeof(TException).Name),
    ITestDataThrows<TException>
where TException : Exception
{
    public override object?[] ToArgs(ArgsCode argsCode)
    => base.ToArgs(argsCode).Add(argsCode, Expected);
}

public record TestDataThrows<TException, T1>(
    string Definition,
    TException Expected,
    T1? Arg1)
: TestDataThrows<TException>(
    Definition,
    Expected),
    ITestData<TException, T1>
where TException : Exception
{
    public override object?[] ToArgs(ArgsCode argsCode)
    => base.ToArgs(argsCode).Add(argsCode, Arg1);

    #region New feature v1.4.0
    public override sealed object?[] PropertiesToArgs(bool withExpected)
    => PropertiesToArgs(this, withExpected);
    #endregion New feature v1.4.0
}

public record TestDataThrows<TException, T1, T2>(
    string Definition,
    TException Expected,
    T1? Arg1, T2? Arg2)
: TestDataThrows<TException, T1>(
    Definition,
    Expected,
    Arg1),
    ITestData<TException, T1, T2>
where TException : Exception
{
    public override object?[] ToArgs(ArgsCode argsCode)
    => base.ToArgs(argsCode).Add(argsCode, Arg2);
}

// And similar extended inheritances till T9 type argument.
```

`TestCase` displays in text explorer like:

`$"{Definition} => throws {typeof(TException).Name}"`

### **Abstract `DynamicDataSource` Class**
(Updated v1.2.3)

This class contains the methods to create specific object arrays for dynamic data-driven tests' data row purposes from every `TestData` types. Once you call an object array generator method of the class, you create a new `TestData` child instance inside and call its `object?[] ToArgs(ArgsCode argsCode)` method to create the object array for dynamic test data record purposes.

However `DynamicDataSource` class implements all necessary methods for test data preparation, it is marked as `abstract`. Intended usage is to
- extend this class for each test class separately,
- implement the necessary specific methods in the derived class with `IEnumerable<object[]>` returning types, and
- declare a static instance of the derived class in the test class where it is going to be used.

You can implement its children as test framework independent portable dynamic data source types. Moreover, using a test framework in the derived classes, you can create specific types either like `TestCaseData` type data rows of NUnit. You will find sample codes of these in the [Advanced Usage](#advanced-usage) section below.

```csharp
namespace CsabaDu.DynamicTestData.DynamicDataSources;

public abstract class DynamicDataSource
{
    #region Code adjustments v1.1.0
    // New: Fields to store default ArgsCode value
    // and to ensure thread-safe temporary overriding it.
    private readonly ArgsCode _argsCode; // Default ArgsCode value
    private readonly AsyncLocal<ArgsCode?> _tempArgsCode = new(); // Temporary override ArgsCode value holder

    // Adjusted: Gets the current ArgsCode value,
    // which is either the temporary override value or the default value.
    protected ArgsCode ArgsCode => _tempArgsCode.Value ?? _argsCode;

    // Adjusted: Protected constructor initializing new fields.
    protected DynamicDataSource(ArgsCode argsCode)
    {
        _argsCode = argsCode.Defined(nameof(argsCode));
        _tempArgsCode.Value = null;
    }

    // New: A disposable class that manages thread-safe temporary ArgsCode overrides
    // and restores the previous value when disposed.
    private sealed class DisposableMemento : IDisposable
    {
        [NotNull]
        private readonly DynamicDataSource _dataSource;
        private readonly ArgsCode? _tempArgsCodeValue;
        private bool _disposed = false;

        internal DisposableMemento(DynamicDataSource dataSource, ArgsCode argsCode)
        {
            _dataSource = dataSource ?? throw new ArgumentNullException(nameof(dataSource));
            _tempArgsCodeValue = _dataSource._tempArgsCode.Value;
            _dataSource._tempArgsCode.Value = argsCode.Defined(nameof(argsCode));
        }

        public void Dispose()
        {
            if (_disposed) return;

            _dataSource._tempArgsCode.Value = _tempArgsCodeValue;
            _disposed = true;
        }
    }

    #region Code adjustments v1.2.0
    // Refactored: Calls a WithOptionalArgsCode method
    // with an optional temporary ArgsCode override.
    public object?[] OptionalToArgs(Func<object?[]> testDataToArgs, ArgsCode? argsCode)
    {
        ArgumentNullException.ThrowIfNull(testDataToArgs, nameof(testDataToArgs));
        return WithOptionalArgsCode(this, testDataToArgs, argsCode);
    }

    // New: Executes the provided test data function with an optional temporary ArgsCode override.
    // This method is called by the OptionalToArgs method and prepared to use in the derived data source classes either.
    protected static T WithOptionalArgsCode<TDataSource, T>([NotNull] TDataSource dataSource, [NotNull] Func<T> testDataGenerator, ArgsCode? argsCode)
    where TDataSource : DynamicDataSource
    where T : notnull
    {
        if (!argsCode.HasValue)
        {
            return testDataGenerator();
        }

        using (new DisposableMemento(dataSource, argsCode.Value))
        {
            return testDataGenerator();
        }
    }

    // New: Executes the provided test data processor with an optional temporary ArgsCode override.
    // This method is prepared to use in the derived data source classes.
    protected static void WithOptionalArgsCode<TDataSource>([NotNull] TDataSource dataSource,[NotNull] Action testDataProcessor, ArgsCode? argsCode)
    where TDataSource : DynamicDataSource
    {
        if (!argsCode.HasValue)
        {
            testDataProcessor();
        }
        else
        {
            using (new DisposableMemento(dataSource, argsCode.Value))
            {
                testDataProcessor();
            }
        }
    }
    #endregion Code adjustments v1.2.0
    #endregion Code adjustments v1.1.0

    public static string GetDisplayName(string? testMethodName, params object?[]? args)
    => $"{testMethodName}({args?[0]})";

    #region TestDataToArgs
    public object?[] TestDataToArgs<T1>(string definition, string expected, T1? arg1)
    => new TestData<T1>(definition, expected, arg1).ToArgs(ArgsCode);

    public object?[] TestDataToArgs<T1, T2>(string definition, string expected, T1? arg1, T2? arg2)
    => new TestData<T1, T2>(definition, expected, arg1, arg2).ToArgs(ArgsCode);

    // TestDataToArgs<> overloads here

    #endregion

    #region TestDataReturnsToArgs
    public object?[] TestDataReturnsToArgs<TStruct, T1>(string definition, TStruct expected, T1? arg1)
    where TStruct : struct
    => new TestDataReturns<TStruct, T1>(definition, expected, arg1).ToArgs(ArgsCode);

    public object?[] TestDataReturnsToArgs<TStruct, T1, T2>(string definition, TStruct expected, T1? arg1, T2? arg2)
    where TStruct : struct
    => new TestDataReturns<TStruct, T1, T2>(definition, expected, arg1, arg2).ToArgs(ArgsCode);

    // TestDataReturnsToArgs<> overloads here

    #endregion

    #region TestDataThrowsToArgs
    public object?[] TestDataThrowsToArgs<TException, T1>(string definition, TException expected, T1? arg1)
    where TException : Exception
    => new TestDataThrows<TException, T1>(definition, expected, arg1).ToArgs(ArgsCode);

    public object?[] TestDataThrowsToArgs<TException, T1, T2>(string definition, TException expected, T1? arg1, T2? arg2)
    where TException : Exception
    => new TestDataThrows<TException, T1, T2>(definition, expected, arg1, arg2).ToArgs(ArgsCode);

    // TestDataThrowsToArgs<> overloads here

    #endregion
}
```

#### **Protected `ArgsCode` Property**
(Updated v1.1.0)

`ArgsCode ArgsCode` is the only property of `DynamicDataSource` class. This property is marked as `protected`. It should be initalized with the constructor parameter of the class. This property will be the parameter of the `ToArgs` methods called by the object array generator methods of the class

#### **Static `GetDisplayName` Method**

This method is prepared to facilitate displaying the required literal testcase description in MSTest and NUnit framewoks. You will find sample code for MSTest usage in the [Usage](#usage), for NUnit usage in the [Advanced Usage](#advanced-usage) sections below.

The method is implemented to support initializing the MSTest framework's `DynamicDataAttribute.DynamicDataDisplayName` property. Following the testmethod's name, the injected object array's first element will be used as string. This element in case of `ArgsCode.Properties` is the `TestCase` property of the instance, and the instance's string representation in case of `ArgsCode.Instance`. This is the `TestCase` property's value either as the `ToString()` method returns that.

#### **Object Array Generator Methods**

`DynamicDataSource` class provides a dedicated object array generator each `TestData type`. The methods' parameters types and sequences are the same as the constructors' parameters of the related `TestData` types.

##### **TestDataToArgs**

- Parameters:

`string definition, string expected, T1? arg1 ... T9? arg9`.

- In case of `ArgsCode.Properties` parameter, the returning object array content is as follows:

`[TestCase, Arg1 ... Arg9]`.

##### **TestDataReturnsToArgs**

- Parameters:

`string definition, TStruct expected, T1? arg1 ... T9? arg9`.

- In case of `ArgsCode.Properties` parameter, the returning object array content is as follows:

`[TestCase, Expected, Arg1 ... Arg9]`.

##### **TestDataThrowsToArgs**

- Parameters:

`string definition, TException expected, T1? arg1 ... T9? arg9`.

- In case of `ArgsCode.Properties` parameter, the returning object array content is as follows:

`[TestCase, Expected, Arg1 ... Arg9]`.

#### **Embedded Private `DisposableMemento` Class**
(New v1.1.0)

This embedded class follows the thread-safe Memento design pattern. Its function is to make possible the thread-safe temporary overriding of the `ArgsCode` property value by storing and ensuring to restore the original value. Its constructor's first parameter should be an instance of the eclosing `DynamicDataSource` class, and the second one is an `ArgsCode` enum to override its default `ArgsCode` property value. The class implements the `IDIsposable` interface, and its `Dispose` method sets the `ArgsCode` property with the original (default) value.

#### **`OptionalToArgs` Method**
(Updated v1.2.0)

The function of this method is to invoke the object array generator `TestDataToArgs`, `TestDataReturnsToArgs` or `TestDataThrowsToArgs` method given as `Func<object[]>` parameter to its signature. If the second optional `ArgsCode?` parameter is not null, the ArgsCode value of the initialized `DynamicDataSource` child instance will be overriden temporarily in a using block of the `DisposableMemento` class. Note that overriding the default `ArgsCode` is expensive so apply for it just occasionally. However, using this method with null value `ArgsCode?` parameter does not have significant impact on the performance yet.

#### **Protected Static Generic `WithOptionalArgsCode` Methods**
(Updated v1.2.1)

These two method overrides are to proceed the test data generation with optional `ArgsCode?` parameter. The first one is for the `Func<T>` type test data generator methods, the second one is for the `Action` type test data processor methods. Both methods have the same signature with the `OptionalToArgs` method, but the first one returns the result of the test data generator method, the second one is void. The methods are protected and prepared to use in the derived data source classes either.

## Usage
(Updated v1.2.0)

Here are some basic examples of how to use `CsabaDu.DynamicTestData` in your project.

### **Sample `DemoClass`**

The following `bool IsOlder(DateTime thisDate, DateTime otherDate)` method of the `DemoClass` is going to be the subject of the below sample dynamic data source and test method codes.

The method compares two `DateTime` type arguments and returns `true` if the first is greater than the second one, otherwise `false`. The method throws an `ArgumentOutOfRangeException` if either argument is greater than the current date.

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

### **Test Framework Independent Dynamic Data Source**
(Updated v1.2.0)

You can easily implement test framework independent dynamic data source by extending the `DynamicDataSource` base class with `IEnumerable<object?[]>` type data source methods. You can use these directly in either test framework. You can easily adjust your already existing data source methods you used with version 1.0.x yet to have the benefits of the new feature (see comments in the sample code):

1. Add an optional `ArgsCode?` parameter to the data source methods signature.
2. Add `optionalToArgs` local method to the enclosing data source methods and call `OptionalToArgs` method with the `testDataToArgs` and `argsCode` parameters.
3. Call `optionalToArgs` local method to generate object arrays with data-driven test arguments .

However, note that this version is fully compatible backward, you can use the data source test classes and methods with the current version without any necessary change. The first data source method of the sample code remained unchanged as simpler but less flexible implememtation.

See the updated (flexible) test method implementation in the [Usage of the Optional ArgsCode Parameter of the Data Source Methods)](#usage-of-the-optional-argscode-parameter-of-the-data-source-methods) section.

The 'native' dynamic data source class with the new feature looks like:

```csharp
namespace CsabaDu.DynamicTestData.SampleCodes.DynamicDataSources;

public class NativeTestDataSource(ArgsCode argsCode) : DynamicDataSource(argsCode)
{
    private readonly DateTime DateTimeNow = DateTime.Now;

    private DateTime _thisDate;
    private DateTime _otherDate;

    public IEnumerable<object?[]> IsOlderReturnsArgsToList()
    {
        bool expected = true;
        string definition = "thisDate is greater than otherDate";
        _thisDate = DateTimeNow;
        _otherDate = DateTimeNow.AddDays(-1);
        yield return testDataToArgs();

        expected = false;
        definition = "thisDate equals otherDate";
        _otherDate = DateTimeNow;
        yield return testDataToArgs();

        definition = "thisDate is less than otherDate";
        _thisDate = DateTimeNow.AddDays(-1);
        yield return testDataToArgs();

        #region Local methods

        object?[] testDataToArgs()
        => TestDataReturnsToArgs(definition, expected, _thisDate, _otherDate);
        #endregion
    }

    // 1. Add an optional 'ArgsCode?' parameter to the method signature.
    public IEnumerable<object?[]> IsOlderThrowsArgsToList(ArgsCode? argsCode = null)
    {
        string paramName = "otherDate";
        _thisDate = DateTimeNow;
        _otherDate = DateTimeNow.AddDays(1);
        // 3. Call 'optionalToArgs' method.
        yield return optionalToArgs();

        paramName = "thisDate";
        _thisDate = DateTimeNow.AddDays(1);
        // 3. Call 'optionalToArgs' method.
        yield return optionalToArgs();

        #region Local methods
        // 2. Add 'optionalToArgs' local method to the enclosing method
        // and call 'OptionalToArgs' method with the testDataToArgs and argsCode parameters.
        object?[] optionalToArgs()
        => OptionalToArgs(testDataToArgs, argsCode);

        object?[] testDataToArgs()
        => TestDataThrowsToArgs(getDefinition(), getExpected(), _thisDate, _otherDate);

        string getDefinition()
        => $"{paramName} is greater than the current date";

        ArgumentOutOfRangeException getExpected()
        => new(paramName, DemoClass.GreaterThanCurrentDateTimeMessage);
        #endregion
    }
}
```

You can use this dynamic data source class initialized either with `ArgsCode.Instance` or `ArgsCode.Properties` in any test framework. You will find examples of both option for each yet. However, note that NUnit will display the test case as desired just with `ArgsCode.Instance` injection.

### **Usage in MSTest**

Find MSTest sample codes for using `TestData` instance as test method parameter:  

```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CsabaDu.DynamicTestData.SampleCodes.MSTestSamples;

[TestClass]
public sealed class DemoClassTestsInstance
{
    private readonly DemoClass _sut = new();
    private static readonly NativeTestDataSource DataSource = new(ArgsCode.Instance);
    private const string DisplayName = nameof(GetDisplayName);

    private static IEnumerable<object?[]> IsOlderReturnsArgsList
    => DataSource.IsOlderReturnsArgsToList();

    private static IEnumerable<object?[]> IsOlderThrowsArgsList
    => DataSource.IsOlderThrowsArgsToList();

    public static string GetDisplayName(MethodInfo testMethod, object?[] args)
    => DynamicDataSource.GetDisplayName(testMethod.Name, args);

    [TestMethod]
    [DynamicData(nameof(IsOlderReturnsArgsList), DynamicDataDisplayName = DisplayName)]
    public void IsOlder_validArgs_returnsExpected(TestDataReturns<bool, DateTime, DateTime> testData)
    {
        // Arrange & Act
        var actual = _sut.IsOlder(testData.Arg1, testData.Arg2);

        // Assert
        Assert.AreEqual(testData.Expected, actual);
    }

    [TestMethod]
    [DynamicData(nameof(IsOlderThrowsArgsList), DynamicDataDisplayName = DisplayName)]
    public void IsOlder_invalidArgs_throwsException(TestDataThrows<ArgumentOutOfRangeException, DateTime, DateTime> testData)
    {
        // Arrange & Act
        void attempt() => _ = _sut.IsOlder(testData.Arg1, testData.Arg2);

        // Assert
        var actual = Assert.ThrowsException<ArgumentOutOfRangeException>(attempt);
        Assert.AreEqual(testData.Expected.ParamName, actual.ParamName);
        Assert.AreEqual(testData.Expected.Message, actual.Message);
    }
}
```

Results in the Test Explorer:

![MSTest_DemoClassTestsInstance_returns](https://raw.githubusercontent.com/CsabaDu/CsabaDu.DynamicTestData/master/Images/MSTest_DemoClassTestsInstance_returns.png)

![MSTest_DemoClassTestsInstance_throws](https://raw.githubusercontent.com/CsabaDu/CsabaDu.DynamicTestData/master/Images/MSTest_DemoClassTestsInstance_throws.png)

Find MSTest sample codes for using `TestData` properties' object array members  as test method parameters.

```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CsabaDu.DynamicTestData.SampleCodes.MSTestSamples;

[TestClass]
public sealed class DemoClassTestsProperties
{
    private readonly DemoClass _sut = new();
    private static readonly NativeTestDataSource DataSource = new(ArgsCode.Properties);
    private const string DisplayName = nameof(GetDisplayName);
    private const TestDataSourceUnfoldingStrategy Fold = TestDataSourceUnfoldingStrategy.Fold;

    private static IEnumerable<object?[]> IsOlderReturnsArgsList
    => DataSource.IsOlderReturnsArgsToList();

    private static IEnumerable<object?[]> IsOlderThrowsArgsList
    => DataSource.IsOlderThrowsArgsToList();

    public static string GetDisplayName(MethodInfo testMethod, object?[] args)
    => DynamicDataSource.GetDisplayName(testMethod.Name, args);

    [TestMethod]
    [DynamicData(nameof(IsOlderReturnsArgsList), UnfoldingStrategy = Fold, DynamicDataDisplayName = DisplayName)]
    public void IsOlder_validArgs_returnsExpected(string testCase, bool expected, DateTime thisDate, DateTime otherDate)
    {
        // Arrange & Act
        var actual = _sut.IsOlder(thisDate, otherDate);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DynamicData(nameof(IsOlderThrowsArgsList), UnfoldingStrategy = Fold, DynamicDataDisplayName = DisplayName)]
    public void IsOlder_invalidArgs_throwsException(string testCase, ArgumentOutOfRangeException expected, DateTime thisDate, DateTime otherDate)
    {
        // Arrange & Act
        void attempt() => _ = _sut.IsOlder(thisDate, otherDate);

        // Assert
        var actual = Assert.ThrowsException<ArgumentOutOfRangeException>(attempt);
        Assert.AreEqual(expected.ParamName, actual.ParamName);
        Assert.AreEqual(expected.Message, actual.Message);
    }
}
```

Results in the Test Explorer:

![MSTest_DemoClassTestsProperties_returns](https://raw.githubusercontent.com/CsabaDu/CsabaDu.DynamicTestData/master/Images/MSTest_DemoClassTestsProperties_returns.png)

![MSTest_DemoClassTestsProperties_throws](https://raw.githubusercontent.com/CsabaDu/CsabaDu.DynamicTestData/master/Images/MSTest_DemoClassTestsProperties_throws.png)

### **Usage in NUnit**

Find NUnit sample codes for using `TestData` instance as test method parameter:  

```csharp
using NUnit.Framework;

namespace CsabaDu.DynamicTestData.SampleCodes.NUnitSamples;

[TestFixture]
public sealed class DemoClassTestsInstance
{
    private readonly DemoClass _sut = new();
    private static readonly NativeTestDataSource DataSource = new(ArgsCode.Instance);

    private static IEnumerable<object?[]> IsOlderReturnsArgsToList()
    => DataSource.IsOlderReturnsArgsToList();

    private static IEnumerable<object?[]> IsOlderThrowsArgsToList()
    => DataSource.IsOlderThrowsArgsToList();

    [TestCaseSource(nameof(IsOlderReturnsArgsToList))]
    public void IsOlder_validArgs_returnsExpected(TestDataReturns<bool, DateTime, DateTime> testData)
    {
        // Arrange & Act
        var actual = _sut.IsOlder(testData.Arg1, testData.Arg2);

        // Assert
        Assert.That(actual, Is.EqualTo(testData.Expected));
    }

    [TestCaseSource(nameof(IsOlderThrowsArgsToList))]
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

Results in the Test Explorer:

![NUnit_DemoClassTestsInstance](https://raw.githubusercontent.com/CsabaDu/CsabaDu.DynamicTestData/master/Images/NUnit_DemoClassTestsInstance.png)

### **Usage in xUnit**

However `CsabaDu.DynamicTestData` works well with xUnit, note that you cannot implement `IXunitSerializable` or `IXunitSerializer` (xUnit.v3) interfaces any way, since `TestData` types are open-generic ones. Secondary reason is that `TestData` types intentionally don't have parameterless constructors. Anyway you can still use these types as dynamic test parameters or you can use the methods to generate object arrays of `IXunitSerializable` elements. Ultimately you can generate xUnit-serializable data-driven test parameters as object arrays of xUnit-serializable-by-default (p.e. intristic) elements.

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

Find xUnit sample codes for using `TestData` instance as test method parameter:  

```csharp
using Xunit;

namespace CsabaDu.DynamicTestData.SampleCodes.xUnitSamples;

public sealed class DemoClassTestsInstance
{
    private readonly DemoClass _sut = new();
    private static readonly NativeTestDataSource DataSource = new(ArgsCode.Instance);

    public static IEnumerable<object?[]> IsOlderReturnsArgsList
    => DataSource.IsOlderReturnsArgsToList();

    public static IEnumerable<object?[]> IsOlderThrowsArgsList
    => DataSource.IsOlderThrowsArgsToList();

    [Theory, MemberData(nameof(IsOlderReturnsArgsList))]
    public void IsOlder_validArgs_returnsExpected(TestDataReturns<bool, DateTime, DateTime> testData)
    {
        // Arrange & Act
        var actual = _sut.IsOlder(testData.Arg1, testData.Arg2);

        // Assert
        Assert.Equal(testData.Expected, actual);
    }

    [Theory, MemberData(nameof(IsOlderThrowsArgsList))]
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

![xUnit_DemoClassTestsInstance_returns](https://raw.githubusercontent.com/CsabaDu/CsabaDu.DynamicTestData/master/Images/xUnit_DemoClassTestsInstance_returns.png)

![xUnit_DemoClassTestsInstance_throws](https://raw.githubusercontent.com/CsabaDu/CsabaDu.DynamicTestData/master/Images/xUnit_DemoClassTestsInstance_throws.png)

Find xUnit sample codes for using `TestData` properties' object array members as test method parameters.

```csharp
using Xunit;

namespace CsabaDu.DynamicTestData.SampleCodes.xUnitSamples;

public sealed class DemoClassTestsProperties
{
    private readonly DemoClass _sut = new();
    private static readonly NativeTestDataSource DataSource = new(ArgsCode.Properties);

    public static IEnumerable<object?[]> IsOlderReturnsArgsList
    => DataSource.IsOlderReturnsArgsToList();

    public static IEnumerable<object?[]> IsOlderThrowsArgsList
    => DataSource.IsOlderThrowsArgsToList();

    [Theory, MemberData(nameof(IsOlderReturnsArgsList))]
    public void IsOlder_validArgs_returnsExpected(string testCase, bool expected, DateTime thisDate, DateTime otherDate)
    {
        // Arrange & Act
        var actual = _sut.IsOlder(thisDate, otherDate);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(IsOlderThrowsArgsList))]
    public void IsOlder_invalidArgs_throwsException(string testCase, ArgumentOutOfRangeException expected, DateTime thisDate, DateTime otherDate)
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

![xUnit_DemoClassTestsProperties](https://raw.githubusercontent.com/CsabaDu/CsabaDu.DynamicTestData/master/Images/xUnit_DemoClassTestsProperties.png)

### **Usage of the Optional ArgsCode Parameter of the Data Source Methods**
(Updated v1.2.0)

If you updated or prepared the data source methods using the `OptionalToArgs` method as described in the [Test Framework Independent Dynamic Data Source)](#test-framework-independent-dynamic-data-source) section, see how to override the default `ArgsCode` value of the initialized static data source instance of the test class. Take care with the parapeters of the respective test method(s)!

Find sample codes in xUnit for using the optional `ArgsCode` parameter in one of the data source methods:

```csharp
using Xunit;

namespace CsabaDu.DynamicTestData.SampleCodes.xUnitSamples;

public sealed class DemoClassTestsInstance
{
    private readonly DemoClass _sut = new();
    private static readonly NativeTestDataSource DataSource = new(ArgsCode.Instance); // Default ArgsCode

    public static IEnumerable<object?[]> IsOlderReturnsArgsList
    => DataSource.IsOlderReturnsArgsToList();

    // ArgsCode Overriden
    public static IEnumerable<object?[]> IsOlderThrowsArgsList
    => DataSource.IsOlderThrowsArgsToList(ArgsCode.Properties);

    [Theory, MemberData(nameof(IsOlderReturnsArgsList))]
    public void IsOlder_validArgs_returnsExpected(TestDataReturns<bool, DateTime, DateTime> testData)
    {
        // Arrange & Act
        var actual = _sut.IsOlder(testData.Arg1, testData.Arg2);

        // Assert
        Assert.Equal(testData.Expected, actual);
    }

    // Signature of the thest method adjusted to comply with the overriden ArgsCode.
    [Theory, MemberData(nameof(IsOlderThrowsArgsList))]
    public void IsOlder_invalidArgs_throwsException(string testCase, ArgumentOutOfRangeException expected, DateTime thisDate, DateTime otherDate)
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

Result of the unchanged method in the Test Explorer:

![xUnit_DemoClassTestsProperties](https://raw.githubusercontent.com/CsabaDu/CsabaDu.DynamicTestData/master/Images/xUnit_DemoClassTestInstance_overridenArgsCode_returns.png)

Result of the method with overriden `ArgsCode` in the Test Explorer:

![xUnit_DemoClassTestsProperties](https://raw.githubusercontent.com/CsabaDu/CsabaDu.DynamicTestData/master/Images/xUnit_DemoClassTestInstance_overridenArgsCode_throws.png)

## Advanced Usage

Besides generating object array lists for dynamic data-driven tests, you can use `CsabaDu.DynamicTestData` to support own type creation of the selected test framework.

### **Using `TestCaseData` type of NUnit**

You can generate `TestCaseData` type of NUnit from `TestData`, since its constructor's parameter should be an object array. `TestCaseData` instances grant other features supporting meta data completion, and methods like `SetName` to set display name of the test case.

```csharp
using NUnit.Framework;

namespace CsabaDu.DynamicTestData.SampleCodes.DynamicDataSources;

public class TestCaseDataSource(ArgsCode argsCode) : DynamicDataSource(argsCode)
{
    private readonly DateTime DateTimeNow = DateTime.Now;

    private DateTime _thisDate;
    private DateTime _otherDate;

    private TestCaseData TestDataToTestCaseData<TResult>(Func<object?[]> testDataToArgs, string testMethodName) where TResult : notnull
    {
        object?[] args = testDataToArgs();
        string testCase = args[0]!.ToString()!;
        string displayName = GetDisplayName(testMethodName, testCase);
        TestCaseData? testCaseData = ArgsCode switch
        {
            ArgsCode.Instance => new(args),
            ArgsCode.Properties => new(args[1..]),
            _ => default,
        };

        return testCaseData!.SetDescription(testCase).SetName(displayName);
    }

    public IEnumerable<TestCaseData> IsOlderReturnsTestCaseDataToList(string testMethodName)
    {
        bool expected = true;
        string definition = "thisDate is greater than otherDate";
        _thisDate = DateTimeNow;
        _otherDate = DateTimeNow.AddDays(-1);
        yield return testDataToTestCaseData();

        expected = false;
        definition = "thisDate equals otherDate";
        _otherDate = DateTimeNow;
        yield return testDataToTestCaseData();

        definition = "thisDate is less than otherDate";
        _thisDate = DateTimeNow.AddDays(-1);
        yield return testDataToTestCaseData();

        #region Local methods
        TestCaseData testDataToTestCaseData()
        => TestDataToTestCaseData<bool>(testDataToArgs, testMethodName).Returns(expected);

        object?[] testDataToArgs()
        => TestDataReturnsToArgs(definition, expected, _thisDate, _otherDate);
        #endregion
    }

    public IEnumerable<TestCaseData> IsOlderThrowsTestCaseDataToList(string testMethodName)
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
        => TestDataToTestCaseData<ArgumentOutOfRangeException>(testDataToArgs, testMethodName);

        object?[] testDataToArgs()
        => TestDataThrowsToArgs(getDefinition(), getExpected(), _thisDate, _otherDate);

        string getDefinition()
        => $"{paramName} is greater than the current date";

        ArgumentOutOfRangeException getExpected()
        => new(paramName, DemoClass.GreaterThanCurrentDateTimeMessage);
        #endregion
    }
}
```

Find NUnit sample codes for using `TestData` instance's array as `TesCaseData` parameter:  

```csharp
using NUnit.Framework;

namespace CsabaDu.DynamicTestData.SampleCodes.NUnitSamples;

[TestFixture]
public sealed class DemoClassTestsInstanceWithTestCaseData
{
    private readonly DemoClass _sut = new();
    private static readonly TestCaseDataSource DataSource = new(ArgsCode.Instance);

    private static IEnumerable<TestCaseData> IsOlderReturnsTestCaseDataToList()
    => DataSource.IsOlderReturnsTestCaseDataToList(nameof(IsOlder_validArgs_returnsExpected));

    private static IEnumerable<TestCaseData> IsOlderThrowsTestCaseDataToList()
    => DataSource.IsOlderThrowsTestCaseDataToList(nameof(IsOlder_invalidArgs_throwsException));

    [TestCaseSource(nameof(IsOlderReturnsTestCaseDataToList))]
    public bool IsOlder_validArgs_returnsExpected(TestDataReturns<bool, DateTime, DateTime> testData)
    {
        // Arrange & Act & Assert
        return _sut.IsOlder(testData.Arg1, testData.Arg2);
    }

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

Results in the Test Explorer:

![NUnit_DemoClassTestsInstance_TestCaseData](https://raw.githubusercontent.com/CsabaDu/CsabaDu.DynamicTestData/master/Images/NUnit_DemoClassTestsInstance_TestCaseData.png)

Find NUnit sample codes for using `TestData` properties' array as `TesCaseData` parameter:  

```csharp
using NUnit.Framework;

namespace CsabaDu.DynamicTestData.SampleCodes.NUnitSamples;

[TestFixture]
public sealed class DemoClassTestsPropertiesWithTestCaseData
{
    private readonly DemoClass _sut = new();
    private static readonly TestCaseDataSource DataSource = new(ArgsCode.Properties);

    private static IEnumerable<TestCaseData> IsOlderReturnsTestCaseDataToList()
    => DataSource.IsOlderReturnsTestCaseDataToList(nameof(IsOlder_validArgs_returnsExpected));

    private static IEnumerable<TestCaseData> IsOlderThrowsTestCaseDataToList()
    => DataSource.IsOlderThrowsTestCaseDataToList(nameof(IsOlder_invalidArgs_throwsException));

    [TestCaseSource(nameof(IsOlderReturnsTestCaseDataToList))]
    public bool IsOlder_validArgs_returnsExpected(bool expected, DateTime thisDate, DateTime otherDate)
    {
        // Arrange & Act & Assert
        return _sut.IsOlder(thisDate, otherDate);
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

Results in the Test Explorer:

![NUnit_DemoClassTestsProperties_TestCaseData](https://raw.githubusercontent.com/CsabaDu/CsabaDu.DynamicTestData/master/Images/NUnit_DemoClassTestsProperties_TestCaseData.png)

### **Using `TheoryData` type of xUnit**

`TheoryData` is a generic type safe data source type of xUnit which implements the generic `IEnumerable` interface. You can use `TestData` types as `TheoryData` type parameter as well as its elements. In order to simplify the implementation, you may better use the interface `ITestData` generic interface types.

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

When using `TheoryData` as data source type in xUnit test class, the `MemberDataAttribute` detects the notated test method's arguments and the compiler generates error if the constructor parameters' types and the `TheoryData` type parameters are different. This means that using `TheoryData` makes our tests type safe indeed. 

Find xUnit sample codes for using `TestData` instance as `TheoryData` element:  

```csharp
using Xunit;

namespace CsabaDu.DynamicTestData.SampleCodes.xUnitSamples;

public sealed class DemoClassTestsInstanceWithTheoryData
{
    private readonly DemoClass _sut = new();
    private static readonly TheoryDataSource DataSource = new(ArgsCode.Instance);

    public static TheoryData<ITestData<bool, DateTime, DateTime>> IsOlderReturnsArgsTheoryData
    => (DataSource.IsOlderReturnsToTheoryData() as TheoryData<ITestData<bool, DateTime, DateTime>>)!;

    public static TheoryData<ITestData<ArgumentOutOfRangeException, DateTime, DateTime>> IsOlderThrowsArgsTheoryData
    => (DataSource.IsOlderThrowsToTheoryData() as TheoryData<ITestData<ArgumentOutOfRangeException, DateTime, DateTime>>)!;

    [Theory, MemberData(nameof(IsOlderReturnsArgsTheoryData))]
    public void IsOlder_validArgs_returnsExpected(ITestData<bool, DateTime, DateTime> testData)
    {
        // Arrange & Act
        var actual = _sut.IsOlder(testData.Arg1, testData.Arg2);

        // Assert
        Assert.Equal(testData.Expected, actual);
    }

    [Theory, MemberData(nameof(IsOlderThrowsArgsTheoryData))]
    public void IsOlder_invalidArgs_throwsException(ITestData<ArgumentOutOfRangeException, DateTime, DateTime> testData)
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

![xUnit_DemoClassTestsInstance_TheoryData_returns](https://raw.githubusercontent.com/CsabaDu/CsabaDu.DynamicTestData/master/Images/xUnit_DemoClassTestsInstance_TheoryData_returns.png)

![xUnit_DemoClassTestsInstance_TheoryData_throws](https://raw.githubusercontent.com/CsabaDu/CsabaDu.DynamicTestData/master/Images/xUnit_DemoClassTestsInstance_TheoryData_throws.png)

The limitations mentioned in the [Usage in xUnit](#usage-in-xunit) section are applicable here. Besides, you will detect that when `TheoryData` elements are intristics only, the Test Explorer will display each test case like individual test methods yet.

Find xUnit sample codes for using `TestData` properties as `TheoryData` elements:  

```csharp
using Xunit;

namespace CsabaDu.DynamicTestData.SampleCodes.xUnitSamples;

public sealed class DemoClassTestsPropertiesWithTheoryData
{
    private readonly DemoClass _sut = new();
    private static readonly TheoryDataSource DataSource = new(ArgsCode.Properties);

    public static TheoryData<bool, DateTime, DateTime> IsOlderReturnsArgsTheoryData
    => (DataSource.IsOlderReturnsToTheoryData() as TheoryData<bool, DateTime, DateTime>)!;

    public static TheoryData<ArgumentOutOfRangeException, DateTime, DateTime> IsOlderThrowsArgsTheoryData
    => (DataSource.IsOlderThrowsToTheoryData() as TheoryData<ArgumentOutOfRangeException, DateTime, DateTime>)!;

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

![xUnit_DemoClassTestsProperties_TheoryData_returns](https://raw.githubusercontent.com/CsabaDu/CsabaDu.DynamicTestData/master/Images/xUnit_DemoClassTestsProperties_TheoryData_returns.png)

![xUnit_DemoClassTestsProperties_TheoryData_throws](https://raw.githubusercontent.com/CsabaDu/CsabaDu.DynamicTestData/master/Images/xUnit_DemoClassTestsProperties_TheoryData_throws.png)

## Changelog

### **Version 1.0.0** (2025-02-09)

- Initial release of the `CsabaDu.DynamicTestData` framework.
- Includes the `ITestData` generic interface types, `TestData` record types, `DynamicDataSource` base class, and `ArgsCode` enum.
- Provides support for dynamic data-driven tests with multiple arguments, expected not null `ValueType' results, and exceptions.

### **Version 1.1.0** (2025-03-27)

- **Added**:
  - `OptionalToArgs` method added to the `DynamicDataSource` class.
  - `DisposableMemento` private class added to the `DynamicDataSource` class.
  - `ArgsCode` property behavior of the `DynamicDataSource` class changed.
- **Note**: This update is backward-compatible with previous versions.

#### **Version 1.1.1** (2025-03-27)
- **Changed**: `private DynamicDataSource._tempArgsCode` to `protected DynamicDataSource.tempArgsCode`, to allow for easier extension of the DynamicDataSource class.
- **Updated**: README.md and fixed navigation anchors.

### **Version 1.2.0** (2025-03-28)

- **Added**: protected static generic `WithOptionalArgsCode<>` methods to the `DynamicDataSource` class to support the extension of using the optional `ArgsCode?` parameter in the derived data source classes. 
- **Changed**:
  - `OptionalToArgs` method to call a `WithOptionalArgsCode<>` method.
  - `protected DynamicDataSource.tempArgsCode` back to `private DynamicDataSource._tempArgsCode`.
- **Updated**: README.md and fixed navigation anchors with simplification.
- **Note**: This update is backward-compatible with previous versions.

#### **Version 1.2.1** (2025-04-02)
- **Added**: Internal test helper const string. 
- **Updated**:
  - README.md descriptoon of `WithOptionalArgsCode<>` methods in the How it Works section.
  - Small README.md corrections and visual refactorings.

#### **Version 1.2.2** (2025-04-10)
- **Changed**:
  - `TestData` refactored: `ExitMode` and `Result` properties are initialized in the constructor signature.
  - `TestDataReturns` and `TestDataThrows` follow this change.

#### **Version 1.2.3** (2025-04-10)
- **Updated**: README.md Abstract`DynamicDataSource` Class section corrected.

### **Version 1.3.0** (2025-05-06)

- **Added**: `ITestDataReturns` and `ITestDataThrows` base marker interfaces. 
- **Updated**: README.md updated and Abstract`DynamicDataSource` Class section corrected.
- **Note**: This update is backward-compatible with previous versions.

#### **Version 1.3.1** (2025-05-08)
- **Changed**:
  - `TestData` refactored.
- **Updated**:
  - README.md corrections and visual refactorings.

### **Version 1.4.0** (2025-05.16)

- **Added**: `PropertiesToArgs` method added to the ITestData interface to generate an object array with the test parameters only.
- **Updated**:
  - README.md updated with the new feature.
  - README.md corrected the meaning of the behavior of `struct` constraint for the `TStruct` type parameter of `ITestDataReturns<TStruct>` instances.

## Contributing

Contributions are welcome! Please submit a pull request or open an issue if you have any suggestions or bug reports.

## License

This project is licensed under the MIT License. See the [License](LICENSE.txt) file for details.

## Contact

For any questions or inquiries, please contact [CsabaDu](https://github.com/CsabaDu).

## FAQ

- **How do I install the library?**
  You can install it via NuGet Package Manager using `Install-Package CsabaDu.DynamicTestData`.

 - **Can I install `IXunitSerializable` or `IXunitSerializer` (xUnit.v3) interfaces to support using `TestData` types in xUnit tests?**
  No, you cannot install these interfaces because `TestData` types are open-generic ones, and don't have parameterless constructors. Although, you can generate object array of xUnit-serializable parameters to use them in `TheoryData` type data sources. Besides, if your tests don't have to comply with xUnit-serializability, you can use `TestData` types in xUnit tests well. 

- **Can I use the earlier implemented data source and test classes with version 1.1.0 ?**
  Yes, you can seamlessly use the already installed classes with the upgraded v1.1.0 of `CsabaDu.DynamicTestData` without the need of any change in your code. Besides, you can easily modify those to enjoy the benefits of the flexibility of this version.

## Troubleshooting
