# CsabaDu.DynamicTestData

**`CsabaDu.DynamicTestData`** is a robust, flexible, and extensible .NET framework for dynamic data-driven testing. It offers type-safe and thread-safe support for MSTest, NUnit, xUnit, and xUnit.v3 — enabling developers to generate intuitive test cases at runtime with meaningful, literal display names.

[![Sponsor this project](https://img.shields.io/badge/Sponsor_on_GitHub-💖-ff69b4?style=flat-square)](https://github.com/sponsors/CsabaDu)  
[![Buy me a ko-fi](https://ko-fi.com/img/githubbutton_sm.svg)](https://ko-fi.com/Y8Y11HTQ0S)

---

⚡ **Generate** type-safe, thread-safe dynamic test data with customizable display names  
🧩 **Compatible** with MSTest, NUnit, xUnit, and xUnit.v3  
📐 **Extensible** abstractions and ready-to-use integrations  
💵 **Now seeking sponsors** to complete v2.0 – comprehensive testing, documentation, examples, and new features!

---

## Table of Contents

- [**Project Ecosystem**](#project-ecosystem)  
- [**Quick Start**](#quick-start)  
- [**Architecture**](#architecture)  
  - [**Architectural Patterns**](#architectural-patterns)  
  - [**Type Naming Conventions**](#type-naming-conventions)  
  - [**Four-Layer Test Data Architecture**](#four-layer-test-data-architecture)  
  - [**Self-Documenting Test Cases**](#self-documenting-test-cases)
  - [**Interface Structure Overview**](#interface-structure-overview)  
  - [**Namespace Dependency Overview**](#namespace-dependency-overview)  
  - [**Architectural Principles Realized**](#architectural-principles-realized)  
  - [**Extensibility & Ready-to-Use Implementations**](#extensibility--ready-to-use-implementations)  
- [**Types**](#types)  
  - [**Statics**](#statics)  
    - [Implementations](#statics-nammespace)
  - [**DataStrategyTypes**](#datastrategytypes)  
    - [Interfaces](#datastrategytypesinterfaces-namespace)
    - [Implementations](#datastrategytypes-namespace)
  - [**TestDataTypes**](#testdatatypes)  
    - [Interfaces](#testdatatypesinterfaces-namespace)
    - [Implementations](#testdatatypes-namespace)
  - [**TestDataRows**](#testdatarows)  
    - [Interfaces](#testdatarowsinterfaces-namespace)
    - [Implementations](#testdatarows-namespace)
  - [**DataRowHolders**](#datarowholders)  
    - [Interfaces](#datarowholdersinterfaces-namespace)
    - [Implementations](#datarowholders-namespace)
  - [**DynamicDataSources**](#dynamicdatasources)  
    - [Implementations](#dynamicdatasources-namespace)
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

---

## Project Ecosystem

- [Core Framework](https://github.com/CsabaDu/CsabaDu.DynamicTestData)
- [NUnit Extension](https://github.com/CsabaDu/CsabaDu.DynamicTestData.NUnit)
- [xUnit Extension](https://github.com/CsabaDu/CsabaDu.DynamicTestData.xUnit)
- [xUnit.v3 Extension](https://github.com/CsabaDu/CsabaDu.DynamicTestData.xUnit.v3)
- [Sample Code Library](https://github.com/CsabaDu/CsabaDu.DynamicTestData.SampleCodes)

## Quick Start

1. **Install the NuGet package**:  
   Run the following command in the NuGet Package Manager Console:  
   ```shell  
   Install-Package CsabaDu.DynamicTestData  
   ```  

2. **Create a derived dynamic test data source class**:
  - Create one class for each test class separately that extends one of the the `DynamicDataSource` base class derivates:
    - `DynamicObjectArrayRowSource` for using the managed ObjectArrayRowHolder<> row holder
    - `DynamicObjectArraySource` for object array generation with `IEnumerable<object?[]>` returning type methods
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

---

## Architecture

### **Architectural Patterns**  

This project leverages five core design patterns to enable flexible test data generation:  

1. **Strategy Pattern**  
   - *Implementation*: `IDataStrategy` with `ArgsCode`/`PropsCode`  
   - *Purpose*: Decouples data processing rules (e.g., argument validation, property inclusion) from test generation logic and allows `DynamicDataSource` to control test data row generation as strategy provider 
   - *Benefit*: Lets flexible controll over data row generation via data source  

2. **Composite Pattern**  
   - *Implementation*: `DynamicDataRowSource` + `IDataRowHolder<TRow>` hierarchy  
   - *Purpose*: Treats individual test cases (`ITestData`) and collections uniformly  
   - *Benefit*: Simplifies complex test scenario management  

3. **Specialized Abstract Factory Pattern**  
   - *Implementation*: `ITestDataRowFactory<TRow, TTestData>` implementation in `DataRowHolder<TRow, TTestData>` derived classes 
   - *Purpose*: Creates consistent test data structures while hiding instantiation details  
   - *Benefit*: Enforces type safety across `DynamicDataSource` derived classes

4. **Memento Pattern**  
   - *Implementation*: `DataStrategyMemento` in `DynamicDataSource`  
   - *Purpose*: Temporarily override strategies with automatic rollback  
   - *Benefit*: Ensures thread-safe, side-effect-free spot strategy customization  

5. **Flyweight Pattern**  
   - *Implementation*: Immutable `DataStrategy` record with static readonly default instances  
   - *Purpose*: Minimize memory usage by reusing shared strategy instances across test executions  
   - *Benefit*: Eliminates redundant allocations while maintaining thread safety through intrinsic immutability  

---

These patterns work together to:  
- **Isolate concerns** (Strategy)  
- **Manage complexity** (Composite)  
- **Ensure consistency** (Abstract Factory)  
- **Preserve state** (Memento)  
- **Optimize memory** (Flyweight)

---

### **Type Naming Conventions**

The project uses consistent generic type parameter names with specific semantic meaning:

| Type Parameter | Constraint | Usage Context | Purpose |
|---------------|------------|---------------|---------|
| **`TStruct`** | `where TStruct : struct` | Methods and types ending with `Returns` | Non-nullable `ValueType` expected as test return value |
| **`TException`** | `where TException : Exception` | Methods and types ending with `Throws` | Expected `Exception` type to be thrown |
| **`T1`-`T9`** | *(none)* | `ITestData` concrete implementations and test data generation | General purpose test parameters of any type |
| **`TTestData`** | `where TTestData : notnull, ITestData` | `ITestDataRow` and `IDataRowHolder` implementations | Concrete immutable implementations of `ITestData` |
| **`TRow`** | *(none)* | `ITestDataRow` and `IDataRowHolder` implementations  | Types convertible to executable test data rows |

**Key characteristics**:
- **`TStruct`** is exclusively used for value return type scenarios
- **`TException`** appears only in exception testing contexts
- **Consistent suffix rules**:
  - `Returns` → Always uses `TStruct`
  - `Throws` → Always uses `TException`
  - `DataRow` → Always uses `TRow`

**Implementation Note**: In concrete implementations, `TTestData` is always paired with `TRow` as correlated generic type parameters, where `TTestData` represents the input test case and `TRow` represents its executable output form.

**This convention ensures**:
- Immediate recognition of test intent through type names
- Compile-time safety for value/exception scenarios
- Consistent patterns across all test data generators
- Improved code readability and maintainability
- Intuitive framework usage through predictable type relationships
- Faster onboarding through consistent type naming

---

### **Four-Layer Test Data Architecture**

The test data types follow a four-layer inheritance structure:

**1. Base Layer** (Core, non-generic)  
   Each concrete test data instance of all test data types can be accessed through the **base non-generic `ITestData` interface**.

**2. Vertical Inheritance** (Depth)  
   Each type extends its predecessor with one additional type parameter.

![v2_TestDataTypes](https://raw.githubusercontent.com/CsabaDu/CsabaDu.DynamicTestData/refs/heads/master/_Images/CsabaDu_DynamicTestData_TestData_Depth.svg)

**3. Horizontal Specialization** (Breadth)  
   Each variant implements its corresponding generic `ITestData<TExpected, T1, ..., T9>` interface.

![v2_TestDataTypes](https://raw.githubusercontent.com/CsabaDu/CsabaDu.DynamicTestData/refs/heads/master/_Images/CsabaDu_DynamicTestData_TestData_Breadth.svg)

**4. Specialization Markers** (Pattern Matchable)  
   Only specialized test data types implement `IExpected` interface and a derived marker interface for specific test case expectations:
   - `ITestDataReturns` for test cases expecting a return value
   - `ITestDataThrows` for test cases expecting an exception to be thrown

![v2_TestDataTypes](https://raw.githubusercontent.com/CsabaDu/CsabaDu.DynamicTestData/refs/heads/master/_Images/CsabaDu_DynamicTestData_TestData_Markers.svg)

The specialized test data types can be accessed through the `IExpected` interface, and through the inherited corresponding `ITestDataReturns` and `ITestDataThrows` marker interfaces. This enables pattern matching.

Type Discrimination Flow:

![v2_TestDataTypes](https://raw.githubusercontent.com/CsabaDu/CsabaDu.DynamicTestData/refs/heads/master/_Images/CsabaDu_DynamicTestData_TestData_Choice.svg)

- **Key Characteristics**:

  - **Generic Progression**:  

   ```csharp
  public class TestData<T1, T2>
  : TestData<T1>,
  ITestData<string, T1, T2>
  {
    // Members
  }

  public class TestDataReturns<TStruct, T1, T2>
  : TestDataReturns<TStruct, T1>,
  ITestData<TStruct, T1, T2>
  where TStruct : struct
  {
    // Members
  }

  public class TestDataThrows<TException, T1, T2>
  : TestDataThrows<TException, T1>,
  ITestData<TException, T1, T2>
  where TException : Exception
  {
    // Members
  }
  ```

  - **Type Safety**: Each specialization preserves constraints:
    - `TestData`: `TExpected` defaults to `string` for descriptive scenarios
    - `TestDataReturns`: `TExpected` is `TStruct : struct`
    - `TestDataThrows`: `TExpected` is `TException : Exception`

This architecture enables type-safe test data composition while maintaining intuitive hierarchy, where each concrete test record can be accessed either through:
 - The non-generic `ITestData` base interface for reflection or dynamic handling, or
 - The strongly-typed `ITestData<TExpected, T1, ..., T9>` interface for compile-time-safe operations, or
 - The specialization marker interfaces `IExpected`, `ITestDataReturns` and `ITestDataThrows` for specific test case result expectations, or
 - The actual concrete generic type for type-safe operations.

---

### **Self-Documenting Test Cases**

This project is designed to **automatically generate human-readable descriptive test name** for each test case by combining 
  - selected test data type specific (`ITestData`/`ITestDataReturns`/`ITestDataThrows`) result mode (e.g., `Returns`, `Throws`)
  - decriptive test scenarios (`ITestData.Definition` property value) and
  - primary test parameter (`ITestData.Expected` property) string representation

- **First-Class Concern**: Not just a utility feature, but a core design goal to make tests:
  - Self-validating (names match intent)
  - Equality comparable (names are unique and consistent across runs)
  - Traceable (names survive test execution)

- **Works across test frameworks**, ensuring consistent naming conventions:
  - All naming features operate through framework-native extension points
  - No reflection hacks or fragile string parsing
  - 100% compatible with:
    - Parallel test execution
    - Test filters
    - Source-controlled data-driven tests

- **Supports generating test display names** by combining testmethod name with test case name.

- **Pre-adapted to support framework-specific display name customization** through each test framework’s native injection points (MSTest’s `DynamicDataAttribute`, NUnit’s `TestCaseData`, xUnit.v3’s `ITheoryDataRow`)

---

### **Interface Structure Overview**

#### **Core Test Data Contracts** (`TestDataTypes.Interfaces`) 

**Base Contracts**
- **`IExpected`**: Root interface marking types as test expectations (success/error).
- **`INamedTestCase`**: Extends IEquatable<T>, enabling named test case comparisons.

**Test Data Specialization**
- **`ITestData`**: Core interface for test data, inheriting `INamedTestCase`.
  - **Generic variants**:
    - **`ITestData<TResult, T1...T9>`**: support strongly-typed test inputs.
- **`ITestDataReturns` / `ITestDataThrows`**: Specialize `IExpected` for success/error cases:
  - **`ITestDataReturns<TStruct>`**: For non-nullable `ValueType` results.
  - **`ITestDataThrows<TException>`**: For expected `Exception` results.

#### **Test Data Rows** (`TestDataRows.Interfaces`) 

**Row Conversion & Wrapping** 
- **`ITestDataRow`**: Wraps `ITestData` into framework-compatible rows (e.g., `object?[]`). 
  - **Generic variants**:
    - **`ITestDataRow<TRow>`**: Base for row type abstraction.
    - **`ITestDataRow<TRow, TTestData>`**: Binds rows to specific `ITestData` types.
- **`INamedTestDataRow<TRow>`**: Extends `ITestDataRow<TRow>` with named test case support.

#### **Data Row Provisioning** (`DataRowHolders.Interfaces`) 

**Row Management & Factories**
- **`ITestDataRows`**: Root for row collection contracts.
- **`IDataRowHolder`**: Manages rows for dynamic data sources:
  - **Generic variants**
    - **`IDataRowHolder<TRow>`**: enforces type-safe row handling.
    - **`IDataRowHolder<TRow, TTestData>`**: enforces handling rows with strongly-typed `ITestData`.
- **`INamedDataRowHolder<TRow>`**: Extends `IDataRowHolder<TRow>` for named row scenarios.

**Factory & Composition** 
- **`ITestDataRowFactory<TRow, TTestData>`**: Creates rows from `ITestData`.
- **`IAddTestData<TTestData>`**: Fluent API for adding test data to holders.

**Collection Contracts**
-**`IRows<TRow>`**: Exposes rows as `IEnumerable<TRow>`.
-**`INamedRows<TRow>`**: Provides enumeration of named rows.

#### **Data Strategy** (`DataStrategyTypes.Interfaces`) 

- **`IDataStrategy`**: Configures data generation behavior (e.g., row members), implements `IEquatable<T>`. 

![InterfaceStructureOverview](https://raw.githubusercontent.com/CsabaDu/CsabaDu.DynamicTestData/refs/heads/master/_Images/ClassDiagrams_v2/v2_Interfaces_all.png)

#### **Design Highlights**

**Separation of Concerns** 
- **`TestDataTypes`** define what to test.
- **`TestDataRows`** handle conversion to testable formats.
- **`DataRowHolders`** manage provisioning to frameworks.

**Extensibility** 
- Generics (`ITestData<TResult>`, `ITestDataRow<TRow>`) enable **type-safe** extensions.
- Interfaces **segregate roles** (e.g., `IAddTestData` vs. `IRows`).

**Test Framework Agnosticism** 
- `ITestDataRow` abstracts framework-specific row formats.
- `IDataRowHolder` isolates framework integration.

**Patterns** 
- **Strategy** (`IDataStrategy`)
- **Composite** (`IRows`).
- **Specialized Abstract Factory** (`ITestDataRowFactory<TRow, TTestData>`)

**Usage Flow**
  1. Define test data → `ITestData`/`ITestDataReturns`/`ITestDataThrows`.
  2. Convert to rows → `ITestDataRow` via `ITestDataRowFactory`.
  3. Provision to tests → `IDataRowHolder` → DynamicDataSources (e.g. `DynamicDataRowSource`).

This structure ensures reusability (share `ITestData` across frameworks) and maintainability (clear interface segregation). 

---

### **Namespace Dependency Overview**

This diagram illustrates the namespace dependencies and architectural hierarchy. It showcases the layered structure, from foundational `Statics` (enums and utilities) to higher-level `DynamicDataSources`, with clear contracts (interfaces) and concrete implementations (records, classes). It is designed for seamless integration with MSTest, NUnit, xUnit, and xUnit.v3.

Arrows denote dependencies, emphasizing a clean separation of concerns and modular design for test data generation and management, enforcing modularity and test-framework-agnostic extensibility.

![NamespaceDependencyOverview](https://raw.githubusercontent.com/CsabaDu/CsabaDu.DynamicTestData/refs/heads/master/_Images/CsabaDu_DynamicTestData_NameSpacesDependencies.svg)

#### **Key Highlights**: 

- **Statics**: Core enums (`ArgsCode`, `PropsCode`) and extensions.
- **TestDataTypes**: Interfaces (`ITestData`, `ITestDataReturns`, `ITestDataThrows`) paired with immutable record implementations.
- **DataStrategyTypes**: Strategy pattern for data handling (`IDataStrategy`).
- **TestDataRows**: Types to act as wrappers and converters for `ITestData` instances.
- **DataRowHolders**: Abstract classes and factories to provide `ITestDataRow` instances for consumption by classes inherit `IDynamicDataRowSource`.
- **DynamicDataSources**: Abstract classes for dynamic test data generation, and  bridges DataRowHolders with test frameworks by supplying various types of test data and test data rows.

#### **Design Principles**: 

- **Dependency Inversion** (interfaces drive dependencies)
- **Modularity** (clear separation between contracts and implementations)
- **Flexibility** (generic types and interfaces allow for diverse test data scenarios)
- **Extensibility** (abstract classes enable customization to support framework-specific adaptions)

---

### **Architectural Principles Realized**

This project is meticulously designed to adhere to and exemplify the following foundational architectural principles:

**SOLID Principles**
- **Single Responsibility**  
  Each component has one clear purpose:  
  - `DynamicDataSource` → Strategy management  
  - `DynamicDataRowSource` → Typed row composition  
  - `DynamicObjectArraySource` → Parameter generation  

- **Open/Closed**  
  Extensible through interfaces (`ITestDataRow`, `IDataRowHolder`) without modifying core logic  

- **Liskov Substitution**  
  All test data implementations seamlessly substitute `ITestData` base contracts  

- **Interface Segregation**  
  Minimal, focused interfaces (`IRows<TRow>` for rows, `ITestDataRows` for enumeration)  

- **Dependency Inversion**  
  High-level modules depend on abstractions (`IDataStrategy`), not concrete implementations  

**Immutability by Design**
- **Records**: `DataStrategy` and all `ITestData` implementations are immutable  
- **Thread Safety**: `AsyncLocal` ensures safe strategy overrides in async contexts  
- **Predictability**: No side effects during test execution  

**Fail Fast & Explicit Validation**
- Guard clauses validate strategy codes immediately  
- Clear exceptions for invalid states (`GetInvalidEnumArgumentException`)  

**Separation of Concerns**
| Layer | Responsibility | Example Components |
|-------|----------------|-------------------|
| **Data Definition** | Test case modeling | `ITestData` records |
| **Strategy** | Processing rules | `IDataStrategy`, `ArgsCode`, `PropsCode` |
| **Composition** | Test data assembly | `DynamicDataRowSource` |
| **Execution** | Parameter generation | `DynamicObjectArraySource` |

**Type Safety & Null Safety**
- Generic constraints (`where T : IDataRowHolder<TRow>`)  
- Nullable reference types (`object?[]`)  
- Compile-time validation of test data structures  

**Thread Safety by Design**
- **Async-Safe State Management**:  
  Uses `AsyncLocal<T>` in `DynamicDataSource` to isolate strategy overrides per logical execution context  
- **Immutable Core Objects**:  
  All `IDataStrategy` and `ITestData` records are inherently thread-safe  
- **Concurrent Access Protection**:  
  Critical paths avoid shared mutable state (e.g., memento rollbacks are self-contained)  
- **Predictable Composition**:  
  Safe `DynamicDataRowSource` operations.

**Performance Awareness**
- Minimal allocations in hot paths (e.g., `[.. args]` for array copies)  
- Flyweight pattern eliminates redundant allocations (`DataStrategy`)  
- Memento optimization (skips creation when strategies match)  

**Zero External Dependencies**  
The project maintains strict isolation by:  
- **Self-Contained Core**: All types (`TestData`, `DynamicDataSource`, etc.) require only .NET base class libraries  
- **No Third-Party Packages**: Avoids NuGet dependencies that could cause version conflicts  
- **Minimal BCL Surface**: Uses only fundamental System.* namespaces (`Collections.Generic`, `Threading`, `Diagnostics`)  

The only "dependency" is the .NET runtime itself – by design. This design choice ensures the library remains:  
- **Portable**: No dependency conflicts with test frameworks (xUnit/NUnit/MSTest), guaranteed to work in .NET 9+ environment   
- **Stable**: Not subject to breaking changes in external packages, enables safe embedding in larger projects
- **Transparent**: All behavior is traceable to the source code  

**High Maintainability Index**
The architecture of this project is designed with a strong emphasis on **maintainability** and **clean separation of concerns**. It is engineered with a focus on **code quality**, **architectural clarity** and **extensibility**. Recent code metrics from Visual Studio reinforce the strength of its internal design:

![Code Metrics](https://raw.githubusercontent.com/CsabaDu/CsabaDu.DynamicTestData/refs/heads/master/_Images/Support/v2_CodeMetricsResults.png)

The high Maintainability Index (scores from **87 to 100**) reflects clean, readable code with low technical debt. Despite deep inheritance hierarchies in certain modules, the framework maintains a strong separation of concerns and manageable complexity. Abstract base classes and interfaces are specifically designed to support MSTest, NUnit, xUnit, and xUnit.v3 seamlessly across modular layers.

---

The architecture achieves these goals while remaining lightweight and focused on its core mission: **type-safe, thread-safe, flexible dynymic test data generation** that supports both simple and complex data-driven testing scenarios: 

- **Support dynamic test data generation** (with flexible row and strategy management)
- **Maintain thread safety** (through immutability and `AsyncLocal<T>`)
- **Provide a clear, test-framework-agnostic API** (with `IDataRowHolder` and `ITestDataRow`)
- **Facilitate easy integration** with various test frameworks (MSTest, NUnit, xUnit, xUnit.v3)
- **Enable extensibility** (through interfaces, abstract types and generics)
- **Allow for future extensions** (e.g., new data strategies, row types) without breaking existing functionality

---

### **Extensibility & Ready-to-Use Implementations**

The architecture enables framework-specific extensions by design. Production-ready implementations available:


| Target Framework | Source Code |  Purpose | Key Features with Namespaces |
|---------------|------------|---------------|---------|
| **NUnit** | [CsabaDu.DynamicTestData.NUnit](https://github.com/CsabaDu/CsabaDu.DynamicTestData.NUnit) | ✔ supports and extends `TestCaseData` | **TestDataTypes** <br> `TestCaseTestData<TTestData>` <br><br> **TestDataRows** <br> `TestCaseDataRow<TTestData>` <br> `TestCaseTestDataRow<TTestData>` <br><br> **DataRowHolders** <br> `TestCaseTestDataRowHolder<TTestData>` <br><br> **DynamicDataSources** <br> `DynamicTestCaseTestDataRowSource` |
| **xUnit** | [CsabaDu.DynamicTestData.xUnit](https://github.com/CsabaDu/CsabaDu.DynamicTestData.xUnit) | ✔ supports and extends `TheoryData` <br><br> ✔ extends `MemberDataAttributeBase` | **DataRowHolders.Interfaces** <br> `ITheoryTestData` <br><br> **DataRowHolders** `TheoryTestData<TTestData>` <br><br> **DynamicDataSources** `DynamicTheoryDataHolder` <br> `DynamicTheoryTestDataHolder` <br><br> **Attributes** <br> `MemberTestDataAttribute` |
| **xUnit.v3** | [CsabaDu.DynamicTestData.xUnit.v3](https://github.com/CsabaDu/CsabaDu.DynamicTestData.xUnit.v3) | ✔ supports `TheoryData` and `TheoryDataRow` <br><br> ✔ implements `ITheoryDataRow` <br><br> ✔ extends `TheoryDataBase` and `MemberDataAttributeBase` | **TestDataRows.Interfaces** <br> `ITheoryTestDataRow` <br><br> **TestDataRows** <br> `TheoryTestDataRow<TTestData>` <br><br> **DataRowHolders** <br> `TheoryTestData<TTestData>` <br><br> **DynamicDataSources** <br> `DynamicTheoryTestDataHolder` <br><br> **Attributes** <br> `MemberTestDataAttribute` |

These extensions prove the architecture's adaptability while providing turnkey solutions for major .NET test frameworks. These code bases may serve as reference implementations for custom adapters of custom test data / data row types, or for custom test data sources, available now or in the future.

See a wide range of practical usage of the native `CsabaDu.DynamicTestData` and the framework-specific extensions in the [Sample Code Library](https://github.com/CsabaDu/CsabaDu.DynamicTestData.SampleCodes).

---

## Types

### **Statics**

#### Statics Nammespace
(Implementations)  

##### **Source code**: 

[Statics namespace](https://github.com/CsabaDu/CsabaDu.DynamicTestData/tree/master/Statics)

##### **Class diagrams**: 

![v2_Statics](https://raw.githubusercontent.com/CsabaDu/CsabaDu.DynamicTestData/refs/heads/master/_Images/ClassDiagrams_v2/v2_Statics.png)

##### **Public Members**:

**`ArgsCode` Enum**:
- **Purpose**: Specifies whether the test data object array contains the `ITestData` instance itself or just its properties. This code determines how test data will be processed by the `IDataStrategy`.
- **Values**:
  - **`Instance`**: Indicates that the test data object array contains the complete `ITestData` instance. When this code is used, the `PropsCode` values are ignored.
  - **`Properties`**: Indicates that the test data object array contains only specific properties of the `ITestData` instance. Which properties are included is determined by the `PropsCode` value.

**`PropsCode` Enum**:
- **Purpose**: Specifies which properties of an `ITestData` instance should be included in the test data object array when `ArgsCode.Properties` is used. This works in conjunction with `IDataStrategy`.
- **Values**:
  - **`TestCaseName`**: Includes all properties of the `ITestData` instance in the test data object array, including the `TestCaseName` property. This is the most comprehensive inclusion option. *It most useful in MSTest framework, in combination with the `GetDisplayName` method of `DynamicDataAttribute`.*
  - **`Expected`**: Includes all properties of the `ITestData` instance except the `TestCaseName` property. This is useful when the test case name isn't needed to be contained by the test data object array. *It is most useful in xUnit framework where custom display name generation is supported just as the text representation of the test parameter(s) (`ITestData.ToString()`), and in xUnit.v3 framework where display name generation is supported via `ITheotyDataRow` implementations (when `IxunitSerializable` or `IxunitSerializer` interfaces implementation is not a possible or a preferred option).*
  - **`Returns`**: Includes the `Expected` property only if the `ITestData` instance implements `ITestDataReturns`. Otherwise, the `Expected` property is excluded. *It is most useful in NUnit farmework where `TestCaseData` type supports simplified assertion of expected `ValueType` test case results.*
  - **`Throws`**: Includes the `Expected` property only if the `ITestData` instance implements `ITestDataThrows`. Otherwise, the `Expected` property is excluded.

**`Extensions` Static Class**
- **Purpose**: Provides extension methods for adding elements to object arrays and validating `ArgsCode` enum and `PropsCode` parameters.
- **Methods**: 
- *`object?[]` extension* 
  - **`object?[] Add<T>(this object?[], ArgsCode, T?)`**: Conditionally adds a parameter to an arguments array based on the specified `ArgsCode`: 
    - For `ArgsCode.Instance`: Returns the original array reference without modification.
    - For `ArgsCode.Properties`: Creates and returns a new array instance, with the specified parameter added.
- *`ArgsCode` extensions* 
  - **`ArgsCode Defined(this ArgsCode, string)`**: Validates that the `ArgsCode` value is defined in the enumeration. This is typically used to ensure valid strategy configuration in `IDataStrategy`. 
  - **`InvalidEnumArgumentException GetInvalidEnumArgumentException(this ArgsCode, string)`**: Creates a standardized invalid enumeration exception for `ArgsCode` values. Used throughout the test data framework to maintain consistent error reporting. 
- *`PropsCode` extensions* 
  - **`PropsCode Defined(this PropsCode, string)`**: Validates that the `PropsCode` value is defined in the enumeration. This ensures proper property filtering behavior in `IDataStrategy` implementations. 
  - **`InvalidEnumArgumentException GetInvalidEnumArgumentException(this PropsCode, string)`**: Creates a standardized invalid enumeration exception for `PropsCode` values. Used throughout the test data framework to maintain consistent error reporting. 

---

### **DataStrategyTypes**

#### DataStrategyTypes.Interfaces Namespace
(Interfaces)

##### **Source code**:

[DataStrategyTypes.Interfaces namespace](https://github.com/CsabaDu/CsabaDu.DynamicTestData/tree/master/DataStrategyTypes/Interfaces)

##### **Class diagrams**: 

![v2_DataStrategyTypes_interfaces](https://raw.githubusercontent.com/CsabaDu/CsabaDu.DynamicTestData/refs/heads/master/_Images/ClassDiagrams_v2/v2_DataStrategyTypes_interfaces.png)

##### **Members**:  

**`IDataStrategy`**
 - **Purpose**: Represents a strategy for processing test data, defining how an `ITestData` instance should be turned into test data row.
 - **Properties**:
   - **`ArgsCode ArgsCode`**: Gets the `ITestData` instance processing strategy code.
   - **`PropsCode PropsCode`**: Gets the property inclusion strategy code.

---

#### DataStrategyTypes Namespace  
(Implementations)

##### **Source code:**

[DataStrategyTypes namespace](https://github.com/CsabaDu/CsabaDu.DynamicTestData/tree/master/DataStrategyTypes)

##### **Class diagrams**: 

![v2_DataStrategyTypes](https://raw.githubusercontent.com/CsabaDu/CsabaDu.DynamicTestData/refs/heads/master/_Images/CsabaDu_DynamicTestData_DataStrategyTypes.svg)

##### **Public Members**:

**`DataStrategy` Sealed Record**
 - **Purpose**: A sealed record implementation of `IDataStrategy` that strictly follows the Flyweight design pattern, providing a shared set of predefined, immutable strategy instances. 
 - **Constructors**:
   - **`private DataStrategy(ArgsCode, PropsCode)`** (Private visibility to enforce the Flyweight pattern, ensuring that instances are shared and reused rather than created anew.)
   - **`static DataStrategy()`** (Initializes the private static readonly collection of the `DataStrategy` instances for all `ArgsCode` and `PropsCode` combinations.)
 - **Properties**:
   - **`ArgsCode ArgsCode`**: Gets the `ITestData` instance processing strategy code.
   - **`PropsCode PropsCode`**: Gets the property inclusion strategy code.
 - **Methods**:
   - **`bool Equals(IDataStrategy?)`**: Determines whether the specified `DataStrategy` is equal to the current instance. 
   - **`override sealed int GetHashCode()`**: Serves as the default hash function, based on the combination of `ArgsCode` and `PropsCode`. 
   - **`static IDataStrategy GetStoredDataStrategy(ArgsCode, PropsCode)`**:  Retrieves a shared Flyweight instance based on explicit `ArgsCode` and `PropsCode`values. 
   - **`static IDataStrategy GetStoredDataStrategy(IDataStrategy)`**: Retrieves a shared Flyweight instance that matches the provided strategy.
   - **`static IDataStrategy GetStoredDataStrategy(ArgsCode?, IDataStrategy)`**: Retrieves a shared Flyweight instance based on the provided arguments, with optional `ArgsCode`.

---

### **TestDataTypes**

#### TestDataTypes.Interfaces Namespace
(Interfaces)

##### **Source code**:

[TestDataTypes.Interfaces namespace](https://github.com/CsabaDu/CsabaDu.DynamicTestData/tree/master/TestDataTypes/Interfaces)

##### **Class diagrams**: 

![v2_TestDataTypes_Interfaces](https://raw.githubusercontent.com/CsabaDu/CsabaDu.DynamicTestData/refs/heads/master/_Images/ClassDiagrams_v2/v2_TestDataTypes_Interfaces.png)

##### **Members**:

**`INamedTestCase`**
 - **Purpose**: Represents a test case that provides a display name for identification and reporting purposes. Combines the capability to provide a human-readable test case name with equality comparison functionality.
 - **Methods**:
   - **`string GetTestCaseName()`**: Generates a complete, descriptive name for the test case suitable for display in test runners.

**`ITestData`**
 - **Purpose**: Core interface representing test data with basic test case functionality.
 - **Property**:
   - **`string Definition`**: Gets the description of the test scenario being verified.
 - **Methods**:
   - **`object?[] ToArgs(ArgsCode)`**: Converts the test case to an array of arguments based on the specified `ArgsCode` parameter.
   - **`object?[] ToParams(ArgsCode, PropsCode)`**: Converts the test case to parameters with precise control over included elements.

**`ITestData<out TResult>`**
 - **Purpose**: Represents a generic test data interface that extends `ITestData` with the generic type of the expected non-nullable result of the test case.
 - **Properties**:
   - **`string TestCaseName`**: Gets the complete display name of the test case.
   - **`TResult Expected`**: Gets the expected result of the test case.

**`ITestData<out TResult, out T1, out T2, ..., out T9>`**
 - **Purpose**: Represent generic test data interfaces that extend `ITestData<TResult>` with 1-9 typed test parameters.
 - **Properties**:
   - **`T1? Arg1`, `T2? Arg2`, ..., `T9? Arg9`**: Get the respective typed arguments of the test case.
   
**`IExpected`**
 - **Purpose**: Represents a base interface for test data that has a primary test parameter for test case result.
 - **Methods**:
   - **`object GetExpected()`**: Returns the expected value of the test case.

**`ITestDataReturns`**
 - **Purpose**: Marker interface for test cases validating method return values. Inherits from `IExpected` and marks test data designed to return a value. 
 
**`ITestDataReturns<out TStruct>`**
 - **Purpose**: A generic interface that inherits from `ITestDataReturns`, for test cases expecting specific non-nullable value type returns.

**`ITestDataThrows`**
 - **Purpose**: Marker interface for test cases validating method return values. Inherits from `IExpected` and marks test data designed to throw an exception.
  
**`ITestDataThrows<out TException>`**
 - **Purpose**: A generic interface that inherits from `ITestDataThrows`, for test cases expecting specific `Exception`throws.

---

#### TestDataTypes Namespace
(Implementations)

##### **Source code**:

[TestDataTypes namespace](https://github.com/CsabaDu/CsabaDu.DynamicTestData/tree/master/TestDataTypes)

##### **Class diagrams**: 

![v2_TestDataTypes](https://raw.githubusercontent.com/CsabaDu/CsabaDu.DynamicTestData/refs/heads/master/_Images/CsabaDu_DynamicTestData_TestDataTypes.svg)

![v2_Statics](https://raw.githubusercontent.com/CsabaDu/CsabaDu.DynamicTestData/refs/heads/master/_Images/ClassDiagrams_v2/v2_TestDataTypes.png)

##### **Public Members**:

**`TestData` Abstract Record**
 - **Purpose**: Abstract base record representing test case data with core functionality for test argument generation. Implements `ITestData`.
 - **Constructor**:
   - **`TestData(string)`** (primary constructor). 
 - **Property**:
   - **`string Definition`**: Gets the description of the test scenario being verified.
 - **Methods**:
   - **`bool Equals(INamedTestCase?)`**: Determines equality with another `INamedTestCase` based on test case name comparison.
   - **`override int GetHashCode()`**: Generates a hash code derived from the return value of the `GetTestCaseName()` method.
   - **`virtual object?[] ToArgs(ArgsCode)`**: Converts the test data to an argument array based on the specified `ArgsCode` parameter.
   - **`object?[] ToParams(ArgsCode, PropsCode)`**: Converts the test data to a parameter array with precise control over included properties.
   - **`override sealed string ToString()`**: Overrides and seals the `ToString()` method to return the value of `GetTestCaseName()` method.
   - **`abstract string GetTestCaseName()`**: Gets the unique name identifying this test case..

**`TestData<T1>` Record**
 - **Purpose**: Represents a concrete record for general purpose test cases with one strongly-typed argument. Inherits from `TestData` and implements `ITestData<string, T1>`.
 - **Constructor**:
   - **`TestData<T1>(string, string, T1?)`** (primary constructor). 
 - **Properties**:
   - **`string Expected`**: Gets the literal description of the expected result of the test case.
   - **`string TestCaseName`**: Gets the complete formatted display name of the test case.
   - **`T1? Arg1`**: Gets first strongly-typed parameter of the test case.  
 - **Methods**:
   - **`override sealed string GetTestCaseName()`**: Returns the value of the `TestCaseName` property.
   - **`override object?[] ToArgs(ArgsCode)`**: Overrides the base method to add the respective arguments to the array.

**`TestData<T1, T2, T3, ..., T9>` Records**
 - **Purpose**: Represent concrete records for general purpose test cases with two to nine strongly-typed arguments.
 - **Constructor**:
   - **`TestData<T1, T2, T3, ..., T9>(string, string, T1?, T2?, T3?, ..., T9?)`** (primary constructor). 
 - **Properties**:
    - **`T2? Arg2`, `T3? Arg3`, ..., `T9? Arg9`**: Get the respective arguments of the test case.
 - **Method**:
   - **`override object?[] ToArgs(ArgsCode)`**: Overrides the base method to add the respective arguments to the array.

**`TestDataReturns<TStruct>` Abstract Record**
 - **Purpose**: Abstract base record for test data that expects a non-nullable `ValueType` return result.
 - **Constructor**:
   - **`TestDataReturns<TStruct>(string, TStruct)`** (primary constructor). 
 - **Properties**:
   - **`TStruct Expected`**: The primary test parameter.
   - **`string TestCaseName`**: Gets the complete formatted display name of the test case, including the expected return value.
 - **Methods**
   - **`override object?[] ToArgs(ArgsCode)`**: Adds the expected return value to the argument array when `ArgsCode.Properties` is specified.
   - **`object GetExpected()`**: Returns the value of the `Expected` property as `object`.
   - **`override sealed string GetTestCaseName()`**: Returns the value of the `TestCaseName` property.

**`TestDataReturns<TStruct, T1, T2, ..., T9>` Records**
 - **Purpose**: Represent concrete records for test data that returns a non-nullable `ValueType` with one to nine additional strongly-typed arguments.
 - **Constructor**:
   - `TestDataReturns<TStruct, T1, T2, ..., T9>(string, TStruct, T1?, T2?, ..., T9?)` (primary constructor). 
 - **Properties**:
   - **`T1? Arg1`, `T2? Arg2`, ..., `T9? Arg9`**: Get the respective arguments of the test case.
 - **Method**:
   - **`override object?[] ToArgs(ArgsCode)`**: Overrides the base method to add the respective arguments to the array.

**`TestDataThrows<TException>` Abstract Record**
 - **Purpose**: Represents an abstract base record for test data that expects `Exception` throwing behavior.
 - **Constructor**:
   - **`TestDataThrows<TException>(string, TException)`** (primary constructor). 
 - **Properties**:
   - **`TException Expected`**: The primary test parameter.
   - **`string TestCaseName`**: Gets the complete formatted display name of the test case, including the expected `Exception` name.
 - **Methods** (New v1.5.0):
   - **`object GetExpected()`**: Returns the value of the `Expected` property as `object`.
   - **`override sealed string GetTestCaseName()`**: Returns the value of the `TestCaseName` property.

**`TestDataThrows<TException, T1, T2, ..., T9>` Records**
 - **Purpose**: Represent concrete records for test data that throws `Exception` with one to nine additional arguments.
 - **Constructor**:
   - **`TestDataThrows<TException, T1, T2, ..., T9>(string, TException, T1?, T2?, ..., T9?)`** (primary constructor). 
 - **Properties**:
   - **`T1? Arg1`, `T2? Arg2`, ..., `T9? Arg9`**: Get the respective arguments of the test case.
 - **Method**:
   - **`override object?[] ToArgs(ArgsCode)`**: Overrides the base method to add the respective arguments to the array.

**`TestDataFactory` Static Class**
 - **Purpose**: Provides static methods to create `ITestData` instances.
 - **Methods**:
   - **`static TestData<T1, T2, ..., T9> CreateTestData<T1, T2, ..., T9>(string, string, T1?, T2?, ..., T9?)`**: Create general `TestData<>` instances with one to nine arguments.
   - **`static TestDataReturns<TStruct, T1, T2, ..., T9> CreateTestDataReturns<TStruct, T1, T2, ..., T9>(string, TStruct, T1?, T2?, ..., T9?)`**: Create `TestDataReturns<>` instances with one to nine arguments.
   - **`static TestDataThrows<TException, T1, T2, ..., T9> CreateTestDataThrows<TException, T1, T2, ..., T9>(string, TException, T1?, T2?, ..., T9?)`**: Creates `TestDataThrows<>` instances with one to nine arguments.

---

### **TestDataRows**

#### TestDataRows.Interfaces Namespace
(Interfaces)

##### **Source code**:

[TestDataRows.Interfaces namespace](https://github.com/CsabaDu/CsabaDu.DynamicTestData/tree/master/TestDataRows/Interfaces)

##### **Class diagrams**: 

![v2_TestDataRows_interfaces](https://raw.githubusercontent.com/CsabaDu/CsabaDu.DynamicTestData/refs/heads/master/_Images/ClassDiagrams_v2/v2_TestDataRows_interfaces.png)

##### **Members**: 

**`ITestDataRow`**
 - **Purpose**: Represents a single test case's data with parameter retrieval capabilities. Implements `INamedTestCase` to provide consistent test case identification.
 - **Methods**:
   - **`object?[] GetParams(IDataStrategy)`**: Retrieves test parameters formatted according to the specified `IDataStrategy` parameter.
   - **`ITestData GetTestData()`**: Provides access to the complete `ITestData` instance.`ITestData`.

**`ITestDataRow<TRow>`**
 - **Purpose**: Represents a test data row that can be converted to a specific type using the given strategy.
 - **Method**:
   - **`TRow Convert(IDataStrategy)`**: Converts this test data row to the specified type using the given `IDataStrategy`.

**`ITestDataRow<TRow, TTestData>`**
 - **Purpose**: Represents a test data row with associated strongly-typed `ITestData`.
 - **Property**:
   - **`TTestData TestData`**: Gets the strongly-typed `ITestData` instance associated with this row. 

**`INamedTestDataRow<TRow>`**
 - **Purpose**: Represents a named test data row that provides conversion capabilities with test method context. Extends `ITestDataRow<TRow>` to include test method naming support.
 - **Methods**: 
     - **`TRow Convert(IDataStrategy, string?)`**: Converts the test data row to the target type with additional naming context.

---

#### TestDataRows Namespace
(Implementations)

##### **Source code**:

[TestDataRows namespace](https://github.com/CsabaDu/CsabaDu.DynamicTestData/tree/master/TestDataRows)

##### **Class diagrams**: 

![v2_TestDataRows](https://raw.githubusercontent.com/CsabaDu/CsabaDu.DynamicTestData/refs/heads/master/_Images/ClassDiagrams_v2/v2_TestDataRows.png)

##### **Public Members**:

**`TestDataRow<TRow>` Abstract Class**
 - **Purpose**: Abstract base class for test data rows that can be converted to a target type. (`TRow`). Implements `ITestDataRow<TRow>`. 
 - **Constructor**: Default 
 - **Methods**:
   - **`bool Equals(INamedTestCase?)`**: Compares this instance with another `INamedTestCase` for name equality.
   - **`override sealed bool Equals(object?)`**: Compares this instance with another object for equality. Consistent with `INamedTestCase` equality semantics.
   - **`override sealed int GetHashCode()`**: Gets the hash code of the value returned by the `GetTestCaseName()` method.
   - **`object?[] GetParams(IDataStrategy)`**: Gets the parameter values for this test data row using the given `IDataStrategy` parameter.
   - **`string GetTestCaseName()`**: Gets the name of this test case, derived from the underlying `ITestData` value.
   - **`abstract TRow Convert(IDataStrategy)`**: Converts this test data row to the target TRow type using the given `IDataStrategy` parameter. 
   - **`abstract ITestData GetTestData()`**: Gets the underlying `ITestData` value for this row. 

**`TestDataRow<TRow, TTestData>` Abstract Class**
 - **Purpose**: Abstract base class for a strongly-typed test data row that associates a typed test data type (`TTestData`) with a target row type (`TRow`). Inherits from `TestDataRow<TRow>` and implements `ITestDataRow<TRow, TTestData>`.
 - **Constructor**:
   - **`TestDataRow<TRow, TTestData>(TTestData)`** (primary constructor). 
 - **Property**: 
   - **`TTestData TestData`**: Gets the strongly-typed `ITestData` instance associated with this row. Initialized through the primary constructor.
 - **Method**:
   - **`override sealed ITestData GetTestData()`**: Gets the test data associated with this row as an `ITestData`. This sealed implementation always returns the strongly-typed `TestData` property.

**`ObjectArrayRow<TTestData>` Class**
 - **Purpose**: A concrete implementation of `TestDataRow<TRow, TTestData>` that represents test data as an array of objects (`object?[]`).
 - **Constructor**:
   - **`ObjectArrayRow<object?[], TTestData>(TTestData)`** (primary constructor). 
 - **Method**:
   - **`override object?[] Convert(IDataStrategy)`**: Converts this test data row to the target row type using the given `IDataStrategy` parameter. This implementation simply returns the parameters generated by the`object?[] GetParams(IDataStrategy)` method.

---

### **DataRowHolders**

#### DataRowHolders.Interfaces Namespace
(Interfaces)

##### **Source code**:

[TestDataRows.Interfaces namespace](https://github.com/CsabaDu/CsabaDu.DynamicTestData/tree/master/DataRowHolders/Interfaces)

##### **Class diagrams**: 

![v2_DataRowHolders_interfaces](https://raw.githubusercontent.com/CsabaDu/CsabaDu.DynamicTestData/refs/heads/master/_Images/ClassDiagrams_v2/v2_DataRowHolders_interfaces.png)

##### **Members**: 

**`ITestDataRows`**
 - **Purpose**: Provides access to test data rows and their processing strategy. 
 - **Methods**: 
   - **`IEnumerable<ITestDataRow>? GetTestDataRows()`**: Gets an enumerable collection of `ITestDataRow` instances. 
   - **`IDataStrategy GetDataStrategy(ArgsCode?)`**: Gets the `IDataStrategy` value to be used for processing test data rows, potentially modified by an `ArgsCode`. 
   - **`IDataStrategy GetDataStrategy(ArgsCode?, PropsCode?)`**: Gets the `IDataStrategy` value to be used for processing test data rows, potentially modified by an `ArgsCode` and a `PropsCode`. 

**`IRows<TRow>`**
 - **Purpose**: Represents an access provider to the data rows. 
 - **Method**: 
   - **`IEnumerable<TRow>? GetRows(ArgsCode?)`**: Retrieves a sequence of typed data rows configured by the given nullable `ArgsCode` parameter.  
   - **`IEnumerable<TRow>? GetRows(ArgsCode?, PropsCode?)`**: Retrieves a sequence of typed data rows configured by the given nullable `ArgsCode` and `PropsCode` parameter.  

**`INamedRows<TRow>`**
 - **Purpose**: Represents an access provider to the data rows which support generating a test case display name using the test method name.  
 - **Method**: 
   - **`IEnumerable<TRow>? GetRows(string?, ArgsCode?)`**: Retrieves a sequence of  typed data rows configured by the given nullable `Args  Code` parameter, with display names of the test cases, which are to be generated with the given test method name.
   - **`IEnumerable<TRow>? GetRows(string?, ArgsCode?, PropsCode?)`**: Retrieves a sequence of  typed data rows configured by the given nullable `Args  Code` and `PropsCode` parameter, with display names of the test cases, which are to be generated with the given test method name.

**`IAddTestData<TTestData>`**
 - **Purpose**: Represents a fluent API for adding test data to a data row holder. This interface is used to add test data rows to a collection of test data rows.
 - **Method**:
   - **`void Add(TTestData)`**: Adds a new test data instance to the collection. The type of the added test data is determined by the generic type parameter `TTestData`.

**`ITestDataRowFactory<TRow, TTestData>`**
 - **Purpose**: Factory for creating typed test data rows..   
 - **Method**: 
   - **`ITestDataRow<TRow, TTestData> CreateTestDataRow(TTestData)`**: Creates a new strongly-typed test data row instance associated with the specified `ITestData` value. 

**`IDataRowHolder`**
 - **Purpose**: Represents a container that holds test data rows along with their associated `IDataStrategy`. Extends `ITestDataRows` to provide direct access to the data strategy.  
 - **Property**: 
   - **`IDataStrategy DataStrategy`**: Gets the configured processing strategy associated with the test data rows.  

**`IDataRowHolder<TRow>`**
 - **Purpose**: Represents a typed container for test data rows that combines row access, data strategy management, and type information. Extends the non-generic `IDataRowHolder` with type-specific operations.   
 - **Method**: 
   - `IDataRowHolder<TRow> GetDataRowHolder(IDataStrategy)`: Gets or creates a new instance of the data row holder with the specified data strategy. 

**`IDataRowHolder<TRow, TTestData>`**
 - **Purpose**: Represents a strongly typed container for test data rows that combines collection functionality, row access, and test data row creation capabilities. This interface combines multiple test data capabilities:
    - Collection functionality (via `IReadOnlyCollection<ITestDataRow}>`),
    - Data strategy management (via `IDataRowHolder<TRow>`),
    - Test data row creation (via `ITestDataRowFactory<TRow, TTestData>`).  
 - **Method**: 
   - **`void Add(ITestDataRow<TRow, TTestData>)`**: Adds a new strongly typed test data row to the collection. 

**`INamedDataRowHolder<TRow>`**
 - **Purpose**: Represents a typed container for named test data rows which combine data strategy management with named test case access capabilities. Combines the data strategy management of `IDataRowHolder<TRow>` with the named test case retrieval of `INamedRows<TRow>` without introducing additional members.  

---

#### DataRowHolders Namespace
(Implementations)

##### **Source code**:

[TestDataRows.Interfaces namespace](https://github.com/CsabaDu/CsabaDu.DynamicTestData/tree/master/DataRowHolders)

##### **Class diagrams**: 

![v2_DataRowHolders](https://raw.githubusercontent.com/CsabaDu/CsabaDu.DynamicTestData/refs/heads/master/_Images/ClassDiagrams_v2/v2_DataRowHolders.png)

##### **Public Members**:

**`DataRowHolder<TRow>` Abstract Class**
 - **Purpose**: Abstract base class for managing test data rows with a specific data strategy. 
 - **Constructors**:
   - **`DataRowHolder(IDataStrategy)`** (primary constructor)
   - **`private protected DataRowHolder(ITestData, IDataStrategy)`**,
   - **`private protected DataRowHolder(IDataRowHolder?, IDataStrategy)`**. 
 - **Property**: 
   - **`IDataStrategy DataStrategy`**: Gets the configured data processing strategy.  
 - **Methods**:
   - **`IDataStrategy GetDataStrategy(ArgsCode?)`**: Gets the processing `IDataStrategy` value to, potentially modified by an `ArgsCode`. 
   - **`IDataStrategy GetDataStrategy(ArgsCode?, PropsCode?)`**: Gets the processing `IDataStrategy` value with property control. 
   - **`IEnumerable<TRow>? GetRows(ArgsCode?)`**: Retrieves data rows, optionally converted by `ArgsCode` parameter.  
   - **`IEnumerable<TRow>? GetRows(ArgsCode?, PropsCode?)`**: Retrieves data rows, optionally converted by `ArgsCode` and `PropsCode` parameter.  
   - **`abstract IDataRowHolder<TRow> GetDataRowHolder(IDataStrategy)`**: Gets this instance, or creates a new one with the specified strategy. 
   - **`abstract IEnumerable<ITestDataRow>? GetTestDataRows()`**: Gets an enumerable collection of all managed `ITestDataRow` instances or null if none available. 

**`DataRowHolder<TRow, TTestData>` Abstract Class**
 - **Constructors**:
   - **`protected DataRowHolder(TTestData, IDataStrategy)`**,
   - **`protected DataRowHolder(IDataRowHolder, IDataStrategy)`**. 
 - **Purpose**: Abstract base class for managing strongly-typed test data rows. 
 - **Property**: 
   - **`int Count`**: Gets the number of test data rows in the `IReadOnlyCollection<ITestDataRow>` collection.  
 - **Methods**:
   - **`void Add(TTestData)`**: Adds a new strongly-typed `ITestData` instance to the collection by creating and storing a new row.
   - **`void Add(ITestDataRow<TRow, TTestData>)`**: Adds a pre-created test data row to the collection. 
   - **`override sealed IEnumerable<ITestDataRow>? GetTestDataRows()`**: Gets the stored collection of `ITestDataRow` instances without any transormation. 
   - **`IEnumerator<ITestDataRow> GetEnumerator()`**: Returns an enumerator that iterates through the `ITestDataRow` collection.  
   - **`abstract ITestDataRow<TRow, TTestData> CreateTestDataRow(TTestData)`**: Creates a new test data row from the specified test data. 

**`ObjectArrayRowHolder<TTestData>` Class**
 - **Purpose**: A concrete implementation of `DataRowHolder<TRow, TTestData>`. Specialized for test data that will be converted to parameter arrays for test execution. 
 - **Constructors**:
   - **`ObjectArrayRowHolder(TTestData, IDataStrategy)`**,
   - **`ObjectArrayRowHolder(IDataRowHolder<object?[], TTestData>?, IDataStrategy)`**. 
 - **Methods**:
   - **`override IDataRowHolder<object?[]> GetDataRowHolder(IDataStrategy)`**: Gets this or creates a new data row holder with the specified processing data strategy. 
   - **`override ITestDataRow<object?[], TTestData> CreateTestDataRow(TTestData)`**: Creates a new test data row of object array from the specified `ITestData` instance. 

---

### **DynamicDataSources**

This namespace provides the foundational *abstract* classes for defining custom data sources. Since the framework is designed for **one data source per test class**, most critical members are `protected` — allowing implementers to access or override key behaviors while encapsulating internal logic. The public interface remains minimal, adhering to the framework's contracts while granting flexibility in derived classes.  

#### DynamicDataSources Namespace
(Implementations)

##### **Source code**:

[DynamicDataSources namespace](https://github.com/CsabaDu/CsabaDu.DynamicTestData/tree/master/DynamicDataSources)

##### **Class diagrams**: 

![v2_DynamicDataSources](https://raw.githubusercontent.com/CsabaDu/CsabaDu.DynamicTestData/refs/heads/master/_Images/ClassDiagrams_v2/v2_DynamicDataSources.png)

##### **Public and Protected Members**:

*(Note: Focus here is on the protected/overridable members, as they define the primary extension points.)*  

**`DynamicDataSource` Abstract Class**
  - **Purpose**: Provides a thread-safe base for dynamic test data sources. Implements `IDataStrategy` and serves as strategy controller for test data generation, with temporary strategy override options.
  - **Constructor**:
    - **`protected DynamicDataSource(ArgsCode, PropsCode)`**
  - **Properties**:
    - **`ArgsCode ArgsCode`**: Gets the currently active `ArgsCode`, preferring any temporary override. 
    - **`PropsCode PropsCode`**: Gets the currently active `PropsCode`, preferring any temporary override. 
  - **Methods**:
    - **`bool Equals(INamedTestCase?)`**: Compares this instance with another `IDataStrategy` for name equality.
    - **`override bool Equals(object?)`**: Compares this instance with another object for equality. Consistent with `IDataStrategy` equality.
    - **`override int GetHashCode()`**: Serves as the default hash function, based on the combination of `ArgsCode` and `PropsCode`. 
  - *Protected method*
    - **`protected T WithOptionalDataStrategy<T>([NotNull] Func<T>, string, ArgsCode?, PropsCode?)`**: Executes a generator function with optional temporary strategy overrides, allowing dynamic data customization. Designed for use in derivatives of `DynamicObjectArraySource` and in other derivates of the non-generic `DynamicDataSource` classes. *(In `DynamicDataRowSource<TDataRowHolder, TRow>` derivates, all temporary value overrides are handled through the implementations of the `IRow<TRow>.GetRow(...)` methods.)*

**`DynamicObjectArraySource` Abstract Class**
  - **Purpose**: Abstract base class for dynamic test data sources that generate parameter arrays for test execution. Specializes the non-generic `DynamicDataSource` to provide an implementation for generating test data as `object?[]` arrays, without own data holder management. Uses the configured `DynamicDataSource.ArgsCode` and `DynamicDataSource.PropsCode` properties to control parameter generation. *(Derivates of this class are expected to provide their own data holder management, typically through `IEnumerable<object?[]>` members.)* 
  - **Constructor**:
    - **`DynamicObjectArraySource(ArgsCode, PropsCode)`** (primary constructor)
  - **Methods**:
  - *Protected methods*
    - **`protected object?[] TestDataToParams<T1, T2, ..., T9>(string, string expected, T1?, T2?, ..., T9?)`**: Generates a parameter array for a standard test case with `string` expected result (descriptive test scenario) and one to nine arguments.
    - **`protected object?[] TestDataReturnsToParams<TStruct, T1, T2, ..., T9>(string, string expected, T1?, T2?, ..., T9?)`**: Generates a parameter array for a test case expecting a non-nullable `ValueType` return with one to nine arguments.
    - **`protected object?[] TestDataThrowsToParams<TException, T1, T2, ..., T9>(string, string expected, T1?, T2?, ..., T9?)`**: Generates a parameter array for a test case expecting an `Exception` return with one to nine arguments.

**`DynamicDataSource<TDataHolder>` Abstract Class**
  - **Purpose**: Abstract base class for dynamic test data sources that contain and manage typed data holders. Inherits from the non-generic `DynamicDataSource`.
  - **Constructor**:
    - **`DynamicDataSource(ArgsCode, PropsCode)`** (primary constructor)
  - **Property** *(protected)*:
    - **`protected TDataHolder? DataHolder`**: Gets or sets the current data holder instance. 
  - **Methods**:
    - **`virtual void ResetDataHolder()`**: Resets the current data holder to its default state.
  - *Protected methods*
    - **`protected void Add<T1, T2, ..., T9>(string, string expected, T1?, T2?, ..., T9?)`**: Adds a standard test case to the data holder with `string` expected result (descriptive test scenario) and one to nine arguments.
    - **`protected void AddReturns<TStruct, T1, T2, ..., T9>(string, string expected, T1?, T2?, ..., T9?)`**: Adds a test case expecting a non-nullable `ValueType` return with one to nine arguments.
    - **`protected void AddThrows<TException, T1, T2, ..., T9>(string, string expected, T1?, T2?, ..., T9?)`**: Adds a test case expecting an `Exception` return with one to nine arguments.
    - **`protected abstract void Add<TTestData>(TTestData)`**: Adds a typed `ITestData` to the data holder.
    - **`protected abstract void InitDataHolder<TTestData>(TTestData)`**: Initializes the data holder with the first `ITestData` instance.

**`DynamicDataRowSource<TDataRowHolder, TRow>` Abstract Class**
  - **Purpose**: Abstract base class for dynamic test data sources that manage typed data rows through an `IDataRowHolder<TRow> DataHolder` propery. Inherits from the non-  generic `DynamicDataSource<TDataRowHolder>` and implements `ITestDataRows` and `IRows<TRow>` interfaces.
  - **Constructor**:
    - **`DynamicDataRowSource(ArgsCode, PropsCode)`** (primary constructor)
  - **Methods**:
    - **`IEnumerable<ITestDataRow>? GetTestDataRows()`**: Retrieves all managed test data rows. 
    - **`IDataStrategy GetDataStrategy(ArgsCode?)`**: Gets the data strategy with optional `ArgsCode` override. 
    - **`IDataStrategy GetDataStrategy(ArgsCode?, PropsCode?)`**: Gets the data strategy with optional `ArgsCode` and `PropsCode` overrides. 
    - **`IEnumerable<TRow>? GetRows(ArgsCode?)`**: Retrieves converted data rows with optional `ArgsCode` override.  
    - **`IEnumerable<TRow>? GetRows(ArgsCode?, PropsCode?)`**: Retrieves converted data rows with optional `ArgsCode` and `PropsCode` overrides.  
  - *Protected method*
    - **`protected override void Add<TTestData>(TTestData)`**: Adds a typed `ITestData` to the data holder, initailizing the data holder if necessary, and preveinting duplicate entries.

**`DynamicNamedDataRowSource<TRow>` Abstract Class**
  - **Purpose**: Abstract base class that provides named test data rows for parameterized testing scenarios. Specializes `DynamicDataRowSource<TDataRowHolder, TRow>` and implements `INamedRows<TRow>`.
  - **Constructor**:
    - **`DynamicNamedDataRowSource(ArgsCode, PropsCode)`** (primary constructor)
  - **Methods**:
    - **`IEnumerable<TRow>? GetRows(ArgsCode?)`**: Retrieves named, converted data rows with optional `ArgsCode` override.  
    - **`IEnumerable<TRow>? GetRows(ArgsCode?, PropsCode?)`**: Retrieves named, converted data rows with optional `ArgsCode` and `PropsCode` overrides.  

**`DynamicDataRowSource<TRow>` Abstract Class**
  - **Purpose**: Abstract base class for dynamic test data sources with simplified row holder management. Specializes `DynamicDataRowSource<TDataRowHolder, TRow>` using `IDataRowHolder<TRow>` as the default type of `DataHolder` propery, simplifying common use cases. Allows extensions with custom `TRow` types.
  - **Constructor**:
    - **`DynamicDataRowSource(ArgsCode, PropsCode)`** (primary constructor)

**`DynamicObjectArrayRowSource` Abstract Class**
  - **Purpose**: Abstract base class that provides test data in the form of object arrays. Specializes `DynamicDataRowSource<object?[]>`.
  - **Constructor**:
    - **`DynamicObjectArrayRowSource(ArgsCode, PropsCode)`** (primary constructor)
  - **Method**:
  - *Protected method*
    - **`protected override void InitDataHolder<TTestData>(TTestData)`**: Initializes the data holder with the specified `ITestData` instance. 

**`DynamicExpectedObjectArrayRowSource` Abstract Class**
  - **Purpose**: Abstract base class that provides test data in the form of object arrays, with pre-set `PropsCode.Expected` value of `DynamicDataSource.PropsCode` property. Specializes `DynamicObjectArrayRowSource`.
  - **Constructor**:
    - **`DynamicExpectedObjectArrayRowSource(ArgsCode)`** (primary constructor)

---  



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
    - [ITestData Methods](#itestdata-methods)]
  - [ITestCaseName Interface](#itestcasename-interface)
  - [IExpected Base interface](#iexpected-base-interface)
  - [ITestDataReturns and ITestDataThrows Marker Interfaces](#itestdatareturns-and-itestdatathrows-marker-interfaces)
  - [TestData Record Types](#testdata-record-types)
    - [TestData](#testdata)
    - [TestDataReturns](#testdatareturns)
    - [TestDataThrows](#testdatathrows)
  - [Abstract DynamicDataSource Class](#abstract-dynamicdatasource-class)
    - [ArgsCode Property](#argscode-property)
    - [Static GetDisplayName Method](#static-getdisplayname-method)
    - [Static TestDataToParams Method](#static-testdatatoparams-method)
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

    public static string? GetDisplayName(MethodInfo testMethod, object?[] args)
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

    public static string? GetDisplayName(MethodInfo testMethod, object?[] args)
    => DynamicDataSource.GetDisplayName(testMethod.Name, args);

    [TestMethod]
    [DynamicData(nameof(IsOlderReturnsArgsList), UnfoldingStrategy = Fold, DynamicDataDisplayName = DisplayName)]
    public void IsOlder_validArgs_returnsExpected(string testCaseName, bool expected, DateTime thisDate, DateTime otherDate)
    {
        // Arrange & Act
        var actual = _sut.IsOlder(thisDate, otherDate);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DynamicData(nameof(IsOlderThrowsArgsList), UnfoldingStrategy = Fold, DynamicDataDisplayName = DisplayName)]
    public void IsOlder_invalidArgs_throwsException(string testCaseName, ArgumentOutOfRangeException expected, DateTime thisDate, DateTime otherDate)
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
    public void IsOlder_validArgs_returnsExpected(string testCaseName, bool expected, DateTime thisDate, DateTime otherDate)
    {
        // Arrange & Act
        var actual = _sut.IsOlder(thisDate, otherDate);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(IsOlderThrowsArgsList))]
    public void IsOlder_invalidArgs_throwsException(string testCaseName, ArgumentOutOfRangeException expected, DateTime thisDate, DateTime otherDate)
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
    public void IsOlder_invalidArgs_throwsException(string testCaseName, ArgumentOutOfRangeException expected, DateTime thisDate, DateTime otherDate)
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
        string testCaseName = args[0]!.ToString()!;
        string displayName = GetDisplayName(testMethodName, testCaseName);
        TestCaseData? testCaseData = ArgsCode switch
        {
            ArgsCode.Instance => new(args),
            ArgsCode.Properties => new(args[1..]),
            _ => default,
        };

        return testCaseData!.SetDescription(testCaseName).SetName(displayName);
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

When using `TheoryData` as data source type in xUnit test class, the `MemberDataAttribute` detects the notated test method's arguments and the compiler generates error if the constructor parameters' types and the `TheoryData` type parameters are different. This ensures type safety in tests when using TheoryData. 

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
- **Changed**:
  - `private DynamicDataSource._tempArgsCode` to `protected DynamicDataSource.tempArgsCode`, to allow for easier extension of the DynamicDataSource class.
- **Updated**:
  - README.md and fixed navigation anchors.

### **Version 1.2.0** (2025-03-28)

- **Added**:
  - protected static generic `WithOptionalArgsCode<>` methods to the `DynamicDataSource` class to support the extension of using the optional `ArgsCode?` parameter in the derived data source classes. 
- **Changed**:
  - `OptionalToArgs` method to call a `WithOptionalArgsCode<>` method.
  - `protected DynamicDataSource.tempArgsCode` back to `private DynamicDataSource._tempArgsCode`.
- **Updated**:
  - README.md and fixed navigation anchors with simplification.
- **Note**: This update is backward-compatible with previous versions.

#### **Version 1.2.1** (2025-04-02)

- **Added**:
  - Internal test helper const string. 
- **Updated**:
  - README.md descriptoon of `WithOptionalArgsCode<>` methods in the How it Works section.
  - Small README.md corrections and visual refactorings.

#### **Version 1.2.2** (2025-04-10)

- **Changed**:
  - `TestData` refactored: `ExitMode` and `Result` properties are initialized in the constructor signature.
  - `TestDataReturns` and `TestDataThrows` follow this change.

#### **Version 1.2.3** (2025-04-10)

- **Updated**:
  - README.md Abstract`DynamicDataSource` Class section corrected.

### **Version 1.3.0** (2025-05-06)

- **Added**:
  - `ITestDataReturns` and `ITestDataThrows` base marker interfaces. 
- **Updated**:
  - README.md updated and Abstract`DynamicDataSource` Class section corrected.
- **Note**:
  - This update is backward-compatible with previous versions.

#### **Version 1.3.1** (2025-05-08)

- **Changed**:
  - `TestData` refactored.
- **Updated**:
  - README.md corrections and visual refactorings.

### **Version 1.4.0** (2025-05.16)

- **Added**:
  - `PropertiesToArgs` method added to the ITestData interface to generate an object array with the test parameters only.
- **Updated**:
  - README.md updated with the new feature.
  - README.md corrected the meaning of the behavior of `struct` constraint for the `TStruct` type parameter of `ITestDataReturns<TStruct>` instances.
- **Note**:
  - This update is backward-compatible with previous versions.

### **Version 1.5.0** (2025-05.17)

- **Added**:
  - `object?[] ToParams(ArgsCode argsCode, bool withExpected)` method added to the `ITestData` interface to simpplify converting the `TestData` instance to a test framework defined test data type.
  - New `IExpected` interface with `object GetExpected()` method, which is inherited by `ITestDataReturns` and `ITestDataThrows` interfaces to enhance extensibility with accessing the `Expected` property value of the derived generic `TestDataReturns<>` or `TestDataThrows<>` instances from the non-generic marker interface type.
- **Updated**:
  - README.md updated with the new features.
- **Note**:
  - This update is backward-compatible with previous versions.

#### **Version 1.5.1** (2025-05-17)

- **Updated**:
  - README.md corrections.

#### **Version 1.5.2** (2025-05-19)

- **Added**:
  - Parameter checking of `DynamicDataSource.GetDisplayName(string testMethodName, object?[] args)` extended to parameter `args`.
- **Updated**:
  - README.md update and corrections.

#### **Version 1.5.3** (2025-05-19)

- **Updated**:
  - `DynamicDataSource.GetDisplayName(string testMethodName, object?[] args)` method simplified.
  - README.md update and corrections.

### **Version 1.6.0** (2025-05-22)
- **Added**:
  - `ITestCase : IEquatable<ITestCase>` added to segregate the `string TestCase` property of the inherited `ITestData` interface, and to make the equality of two `ITestCase` instances comparable, based on their `TestCase` property.
  - `static object?[] TestDataToParams([NotNull] ITestData testData, ArgsCode argsCode, bool withExpected, out string testCaseName)` method added to the `DynamicDataSource` class to null-check the `ITestData testData` parameter and get the value of its `string TestCase` property as out-parameter.
- **Updated**:
  - README.md updated with the new features and other corrections.
- **Note**:
  - This update is backward-compatible with previous versions.

#### **Version 1.6.1** (2025-05-23)
- **Changed**:
  - Static `TestData.PropertiesToArgs(TestData?, bool)` refactored.
- **Updated**:
  - README.md updates and corrections.

#### **Version v1.6.2** (2025-05-30)
  - **Changed**
    - Former `ITestCase` interface renamed to `ITestCaseName` to avoid interference with interfaces of other frameworks having `ITestCase` named interface.
  - **Updated**
    - README.md updated.
  - **Note**
    - If you used `ITestCase` interface in your code yet, you should update these names for compatibility purposes.

---

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

