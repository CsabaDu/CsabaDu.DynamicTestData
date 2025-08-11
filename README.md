# CsabaDu.DynamicTestData

**`CsabaDu.DynamicTestData`** is a *robust*, *flexible*, and *extensible* .NET framework for *dynamic data-driven testing*. It offers *type-safe* and *thread-safe* support for MSTest, NUnit, xUnit, and xUnit.v3 — enabling developers to generate *portable data sources* with intuitive test cases at runtime with meaningful, *literal display names*.

[![Sponsor this project](https://img.shields.io/badge/Sponsor_on_GitHub-💖-ff69b4?style=flat-square)](https://github.com/sponsors/CsabaDu)  
[![Buy me a ko-fi](https://ko-fi.com/img/githubbutton_sm.svg)](https://ko-fi.com/Y8Y11HTQ0S)

---

⚡ **Generate** type-safe, thread-safe dynamic test data with customizable display names  
🧩 **Compatible** with MSTest, NUnit, xUnit, and xUnit.v3  
📐 **Extensible** abstractions and ready-to-use integrations  
💵 **Now seeking sponsors** to complete v2.0 – comprehensive testing, documentation, examples, and new features!

---

## Table of Contents

- [**Quick Start Guide**](#quick-start-guide)  
  - [**1. Install the NuGet Package**](#1-install-the-nuget-package) 
  - [**2. Create a Dynamic Data Source Class**](#2-create-a-dynamic-data-source-class) 
    - [Method Implementation](#method-implementation) 
    - [Row Structure](#row-structure) 
  - [**3. Declare the Data Source in Your Test Class**](#3-declare-the-data-source-in-your-test-class) 
  - [**4. Use the Appropriate Data-Driven Attribute**](#4-use-the-appropriate-data-driven-attribute) 
  - [**5. Define Test Method Parameters**](#5-define-test-method-parameters) 
- [**Project Ecosystem**](#project-ecosystem)  
- [**Architecture**](#architecture)  
  - [**Architectural Patterns**](#architectural-patterns)  
    - [1. Strategy Pattern](#1-strategy-pattern) 
    - [2. Composite Pattern](#2-composite-pattern) 
    - [3. Specialized Abstract Factory Pattern](#3-specialized-abstract-factory-pattern) 
    - [4. Memento Pattern](#4-memento-pattern) 
    - [5. Flyweight Pattern](#5-flyweight-pattern) 
  - [**Type Naming Conventions**](#type-naming-conventions)  
  - [**Four-Layer Test Data Architecture**](#four-layer-test-data-architecture)  
    - [1. Base Layer (Core)](#1-base-layer-core) 
    - [2. Vertical Inheritance (Depth)](#2-vertical-inheritance-depth) 
    - [3. Horizontal Specialization (Breadth)](#3-horizontal-specialization-breadth) 
    - [4. Specialization Markers (Pattern Matchable)](#4-specialization-markers-pattern-matchable) 
  - [**Self-Documenting Test Cases**](#self-documenting-test-cases)
  - [**Interface Structure Overview**](#interface-structure-overview)  
    - [Core Test Data Contracts](#core-test-data-contracts-testdatatypesinterfaces) 
    - [Test Data Rows](#test-data-rows-testdatarowsinterfaces) 
    - [Data Row Provisioning](#data-row-provisioning-datarowholdersinterfaces) 
    - [Data Strategy](#data-strategy-datastrategytypesinterfaces) 
    - [Design Highlights](#design-highlights) 
  - [**Namespace Dependency Overview**](#namespace-dependency-overview)  
    - [Key Highlights](#key-highlights) 
    - [Design Principles](#design-principles) 
  - [**Architectural Principles Realized**](#architectural-principles-realized) 
    - [SOLID Principles](#solid-principles) 
    - [Immutability & Thread Safety by Design](#immutability--thread-safety-by-design) 
    - [Type Safety & Null Safety](#type-safety--null-safety) 
    - [Framework Portability by Design](#framework-portability-by-design) 
    - [Separation of Concerns](#separation-of-concerns) 
    - [Fail Fast & Explicit Validation](#fail-fast--explicit-validation) 
    - [Performance Awareness](#performance-awareness) 
    - [Zero External Dependencies](#zero-external-dependencies) 
    - [High Maintainability Index](#high-maintainability-index) 
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
- [**Sample Codes**](#sample-codes)  
  - [**Sample Testable Class**](#sample-testable-class)
  - [**Usage**](#usage)
    - [General-purpose TestData Usage in MSTest with DynamicObjectArraySource](#general-purpose-testdata-usage-in-mstest-with-dynamicobjectarraysource)
    - [TestDataReturns Usage in NUnit with DynamicObjectArrayRowSource](#testdatareturns-usage-in-nunit-with-dynamicobjectarrayrowsource)
    - [TestDataThrows Usage in xUnit with DynamicExpectedObjectArrayRowSource](#testdatathrows-usage-in-xunit-with-dynamicexpectedobjectarrayrowsource)
  - [**Advanced Usage**](#advanced-usage)
    - [Temporary DataStrategy Overriding](#temporary-datastrategy-overriding)
    - [Generate Custom Display Name When Using Argscode.Properties](#generate-custom-display-name-when-using-argscodeproperties)
- [**Changelog**](#changelog)
- [**Contributing**](#contributing)
- [**License**](#license)
- [**Contact**](#contact)
- [**FAQ**](#faq)
- [**Troubleshooting**](#troubleshooting)

---

## Quick Start Guide

Integrate **CsabaDu.DynamicTestData** into your test project in five simple steps:

---

### **1️. Install the NuGet Package**

Run this command in the **NuGet Package Manager Console**:
```shell
Install-Package CsabaDu.DynamicTestData
```

---

### **2️. Create a Dynamic Data Source Class**

For each test class, define a corresponding data source class by extending one of the following:

| Base Class | Purpose |
|------------|---------|
| `DynamicObjectArraySource` | Supports generating `IEnumerable<object?[]>` using `yield return` |
| `DynamicObjectArrayRowSource` | Uses `IDataRowHolder<object?[], TTestData>` to manage rows |

#### Method Implementation

- **Using `DynamicObjectArraySource`**:
  - Use methods: `TestDataToParams`, `TestDataReturnsToParams`, `TestDataThrowsToParams`
  - Add rows with `yield return`

- **Using `DynamicObjectArrayRowSource`**:
  - Use methods: `Add`, `AddReturns`, `AddThrows`
  - After the last row added, return rows with `GetRows(null)` 

#### Row Structure

Each row must follow this sequence:
1. **`string definition`** – description of the test case scenario 
2. **`TExpected expected`** – *non-nullable* expected result:
   - `string` for general cases ( `Add`, `TestDataToParams`)
   - `ValueType` for return-based tests (`AddReturns`, `TestDataReturnsToParams`)
   - `Exception` for throw-based tests (`AddThrows`, `TestDataThrowsToParams`)  
3. **Test parameters** – any type, consistent order

---

### **3️. Declare the Data Source in Your Test Class**

- Create a static instance of your custom data source class  
- Initialize it with:
  - **First parameter** (choose based on display name needs):  
    - `ArgsCode.Instance` – for descriptive display names (without parameters)  
    - `ArgsCode.Properties` – to include parameter values in display names
  - **Second parameter** (considered just when using `ArgsCode.Properties`):  
    - `PropsCode.Expected` – excludes test case name (recommended for simplicity)  
    - `PropsCode.TestCaseName` – includes test case name as the first element, for descriptive display names with parameters   
- Expose test data via static `IEnumerable<object?[]>` properties or methods

>**Cleanup Requirement**  
> When using `DynamicObjectArrayRowSource`, implement cleanup to reset the internal data holder between test runs:  
> - **MSTest**: Use `[ClassCleanup(ClassCleanupBehavior.EndOfClass)]`  
> - **NUnit**: Use `[OneTimeTearDown]`  
> - **xUnit / xUnit.v3**: Implement `IDisposable` or `IAsyncLifetime`  
>
> In each case, call `ResetDataHolder()` on the data source instance to ensure a clean state.

---

### **4️. Use the Appropriate Data-Driven Attribute**

Apply the correct attribute based on your test framework:

| Framework | Attribute |
|----------|-----------|
| MSTest   | `DynamicData` |
| NUnit    | `TestCaseSource` |
| xUnit / xUnit.v3 | `MemberData` |

---

### **5️. Define Test Method Parameters**

- **With `ArgsCode.Instance`**:
  - Add a single strongly-typed `testData` parameter of type `ITestData`
  - Access values via properties like `Expected`, `Arg1`, `Arg2`, etc.

- **With `ArgsCode.Properties`**:
  - Add individual parameters in the same order as defined
  - Access them directly by name

---

Explore examples in the [*Usage*](#usage) and [*Advanced Usage*](#advanced-usage) sections, or dive into the [Sample Code Library](https://github.com/CsabaDu/CsabaDu.DynamicTestData.SampleCodes) for test framework specific implementations.

Happy Testing and Good Luck!

---

## Project Ecosystem

The `CsabaDu.DynamicTestData` framework extends across multiple specialized repositories, each tailored to integrate seamlessly with popular testing platforms. Below are the core and extension components: 

- [Core Framework](https://github.com/CsabaDu/CsabaDu.DynamicTestData)
- [NUnit Extension](https://github.com/CsabaDu/CsabaDu.DynamicTestData.NUnit)
- [xUnit Extension](https://github.com/CsabaDu/CsabaDu.DynamicTestData.xUnit)
- [xUnit.v3 Extension](https://github.com/CsabaDu/CsabaDu.DynamicTestData.xUnit.v3)

Practical examples demonstrating framework capabilities across different testing scenarios: 

- [Sample Code Library](https://github.com/CsabaDu/CsabaDu.DynamicTestData.SampleCodes)

*(These sample codes showcase the framework's versatility and ease of use, providing a solid foundation for dynamic test data generation across various test frameworks, with and without framework-specific extensions.)*

---

## Architecture

### **Architectural Patterns**  

This project leverages five core design patterns to enable flexible test data generation:  

#### 1. Strategy Pattern  
   - *Implementation*: `IDataStrategy` with `ArgsCode`/`PropsCode`  
   - *Purpose*: Decouples data processing rules (e.g., argument validation, property inclusion) from test generation logic and allows `DynamicDataSource` to control test data row generation as strategy provider 
   - *Benefit*: Lets flexible controll over data row generation via data source  

#### 2. Composite Pattern  
   - *Implementation*: `DynamicDataRowSource` + `IDataRowHolder<TRow>` hierarchy  
   - *Purpose*: Treats individual test cases (`ITestData`) and collections uniformly  
   - *Benefit*: Simplifies complex test scenario management  

#### 3. Specialized Abstract Factory Pattern  
   - *Implementation*: `ITestDataRowFactory<TRow, TTestData>` implementation in `DataRowHolder<TRow, TTestData>` derived classes 
   - *Purpose*: Creates consistent test data structures while hiding instantiation details  
   - *Benefit*: Enforces type safety across `DynamicDataSource` derived classes

#### 4. Memento Pattern  
   - *Implementation*: `DataStrategyMemento` in `DynamicDataSource`  
   - *Purpose*: Temporarily override strategies with automatic rollback  
   - *Benefit*: Ensures thread-safe, side-effect-free spot strategy customization  

#### 5. Flyweight Pattern  
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
| **`TTestData`** | `where TTestData : notnull, ITestData` | `ITestDataRow` and `IDataRowHolder` implementations, `DynamicDataRowSource` derivates | Concrete immutable implementations of `ITestData` |
| **`TRow`** | *(none)* | `ITestDataRow` and `IDataRowHolder` implementations, `DynamicDataRowSource` derivates  | Types convertible to executable test data rows |

**Key characteristics**:
- **`TStruct`** is exclusively used for value return type scenarios
- **`TException`** appears only in exception testing contexts
- **Consistent suffix rules**:
  - `Returns` → Always uses `TStruct`
  - `Throws` → Always uses `TException`
  - `DataRow` → Always uses `TRow`

> **Implementation Note**: In concrete implementations, `TTestData` is always paired with `TRow` as correlated generic type parameters, where `TTestData` represents the input test case and `TRow` represents its executable output form.

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

#### 1. Base Layer (Core)  
   Each concrete test data instance of all test data types can be accessed through the **base non-generic `ITestData` interface**.

#### 2. Vertical Inheritance (Depth)  
   Each type extends its predecessor with one additional type parameter.

![v2_TestDataTypes](https://raw.githubusercontent.com/CsabaDu/CsabaDu.DynamicTestData/refs/heads/master/_Images/CsabaDu_DynamicTestData_TestData_Depth.svg)

#### 3. Horizontal Specialization (Breadth)  
   Each concrete variant implements its corresponding generic `ITestData<TResult, T1, ..., T9>` interface.

![v2_TestDataTypes](https://raw.githubusercontent.com/CsabaDu/CsabaDu.DynamicTestData/refs/heads/master/_Images/CsabaDu_DynamicTestData_TestData_Breadth.svg)

#### 4. Specialization Markers (Pattern Matchable)  
   Only specialized test data types implement `IExpected` interface and a derived marker interface for specific test case expectations:
   - `ITestDataReturns` for test cases expecting a return value
   - `ITestDataThrows` for test cases expecting an exception to be thrown

![v2_TestDataTypes](https://raw.githubusercontent.com/CsabaDu/CsabaDu.DynamicTestData/refs/heads/master/_Images/CsabaDu_DynamicTestData_TestData_Markers.svg)

The specialized test data types can be accessed through the `IExpected` interface, and through the inherited corresponding `ITestDataReturns` and `ITestDataThrows` marker interfaces. This enables pattern matching.

Type Discrimination Flow: 

![v2_TestDataTypes](https://raw.githubusercontent.com/CsabaDu/CsabaDu.DynamicTestData/refs/heads/master/_Images/CsabaDu_DynamicTestData_TestData_Choice.svg)

This architecture enables type-safe test data composition while maintaining intuitive hierarchy, where each concrete test record can be accessed either through:
 - The non-generic `ITestData` base interface for **reflection or dynamic handling**, or
 - The strongly-typed `ITestData<TExpected, T1, ..., T9>` interface for **compile-time-safe** operations without purpose specialization, or
 - The specialization marker interfaces `IExpected`, `ITestDataReturns` and `ITestDataThrows` for **specific test case result** expectations, or
 - The actual concrete generic type for **type-safe** operations.

---

### **Self-Documenting Test Cases**

This project is designed to **automatically generate human-readable descriptive test name** for each test case by combining  
  1. decriptive test scenarios (`ITestData.Definition` property value), 
  2. selected test-data-type (`TestData<>`/`TestDataReturns<>`/`TestDataThrows<>`) specific result mode (e.g., *"returns"*, *"throws"*), and 
  3. primary test parameter (`ITestData<TResult>.Expected` property's string representation).

- **First-Class Concern**: Not just a utility feature, but a core design goal to make tests: 
  - Self-validating (names match intent) 
  - Equality comparable (names are unique and consistent across runs) 
  - Traceable (names survive test execution) 

- **Works across test frameworks**, ensuring consistent naming conventions:
  - The overriden `TestData.ToString()` method provides an intrinsic native naming feature
  - Several other sophisticated naming features operate through framework-specific extension points
  - No reflection hacks or fragile string parsing
  - 100% compatible with:
    - Parallel test execution
    - Test filters
    - Source-controlled data-driven tests

- **Supports generating test display names** by option for combining testmethod name with test case name.

- **Pre-adapted to support framework-specific display name customization** through each test framework’s native injection points (MSTest’s `DynamicDataAttribute`, NUnit’s `TestCaseData`, xUnit.v3’s `ITheoryDataRow`)

---

### **Interface Structure Overview**

#### Core Test Data Contracts (`TestDataTypes.Interfaces`) 

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

#### Test Data Rows (`TestDataRows.Interfaces`) 

**Row Conversion & Wrapping** 
- **`ITestDataRow`**: Wraps `ITestData` into framework-compatible rows (e.g., `object?[]`). 
  - **Generic variants**:
    - **`ITestDataRow<TRow>`**: Base for row type abstraction.
    - **`ITestDataRow<TRow, TTestData>`**: Binds rows to specific `ITestData` types.
- **`INamedTestDataRow<TRow>`**: Extends `ITestDataRow<TRow>` with named test case support.

#### Data Row Provisioning (`DataRowHolders.Interfaces`) 

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
- **`IRows<TRow>`**: Exposes rows as `IEnumerable<TRow>`.
- **`INamedRows<TRow>`**: Provides enumeration of named rows.

#### Data Strategy (`DataStrategyTypes.Interfaces`) 

- **`IDataStrategy`**: Configures data generation behavior (e.g., row members), implements `IEquatable<T>`. 

![InterfaceStructureOverview](https://raw.githubusercontent.com/CsabaDu/CsabaDu.DynamicTestData/refs/heads/master/_Images/ClassDiagrams_v2/v2_Interfaces_all.png) 

#### Design Highlights

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

#### Key Highlights 

- **Statics**: Core enums (`ArgsCode`, `PropsCode`) and extensions.
- **TestDataTypes**: Interfaces (`ITestData`, `ITestDataReturns`, `ITestDataThrows`) paired with immutable record implementations.
- **DataStrategyTypes**: Strategy pattern for data handling (`IDataStrategy`).
- **TestDataRows**: Types to act as wrappers and converters for `ITestData` instances.
- **DataRowHolders**: Abstract classes and factories to provide `ITestDataRow` instances for consumption by classes inherit `IDynamicDataRowSource`.
- **DynamicDataSources**: Abstract classes for dynamic test data generation, and  bridges DataRowHolders with test frameworks by supplying various types of test data and test data rows.

#### Design Principles 

- **Dependency Inversion** (interfaces drive dependencies)
- **Modularity** (clear separation between contracts and implementations)
- **Flexibility** (generic types and interfaces allow for diverse test data scenarios)
- **Extensibility** (abstract classes enable customization to support framework-specific adaptions)

---

### **Architectural Principles Realized**

This project is meticulously designed to adhere to and exemplify the following foundational architectural principles (with examples):

#### SOLID Principles
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

#### Immutability & Thread Safety by Design
- **Records**: `DataStrategy` and all `ITestData` implementations are immutable  
- **Thread Safety**: `AsyncLocal` ensures safe strategy overrides in async contexts  
- **Predictability**: No side effects during test execution  

#### Type Safety & Null Safety
- Generic constraints (`where TTestData : notnull, ITestData`)  
- Nullable reference types (`object?[]`)  
- Compile-time validation of test data structures  

#### Framework Portability by Design

  The dynamic data source classes and `ITestData` abstractions are designed to be **framework-agnostic**, enabling seamless reuse across MSTest, NUnit, and xUnit. This minimizes duplication and simplifies cross-framework test suite maintenance. When adapting to specific frameworks, only the **data strategy parameters** may require adjustment to meet display name or parameter formatting expectations.

#### Separation of Concerns
| Layer | Responsibility | Example Components |
|-------|----------------|-------------------|
| **Data Definition** | Test case modeling | `ITestData` |
| **Strategy** | Processing rules | `IDataStrategy`|
| **Transormation** | Data row conversion | `ITestDataRow` |
| **Composition** | Test data assembly | `IDataRowHolder` |
| **Execution** | Parameter generation | `DynamicObjectArrayRowSource` |

#### Fail Fast & Explicit Validation
- Guard clauses validate strategy codes immediately  
- Clear exceptions for invalid states (`GetInvalidEnumArgumentException`)  

#### Performance Awareness
- Minimal allocations in hot paths (e.g., `[.. args]` for array copies)  
- Flyweight pattern eliminates redundant allocations (`DataStrategy`)  
- Memento optimization (skips creation when strategies match)  

#### Zero External Dependencies  

The project maintains strict isolation by:  
- **Self-Contained Core**: All types (`TestData`, `DynamicDataSource`, etc.) require only .NET base class libraries  
- **No Third-Party Packages**: Avoids NuGet dependencies that could cause version conflicts  
- **Minimal BCL Surface**: Uses only fundamental System.* namespaces (`Collections.Generic`, `Threading`, `Diagnostics`)  

The only "dependency" is the .NET runtime itself – by design. This design choice ensures the library remains:  
- **Portable**: No dependency conflicts with test frameworks (xUnit/NUnit/MSTest), guaranteed to work in .NET 9+ environment   
- **Stable**: Not subject to breaking changes in external packages, enables safe embedding in larger projects
- **Transparent**: All behavior is traceable to the source code  

#### High Maintainability Index  

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
  - **`TestCaseName`**: Includes all properties of the `ITestData` instance in the test data object array, including the `TestCaseName` property. This is the most comprehensive inclusion option. *(Designed for using in MSTest framework, in combination with the `GetDisplayName` method of `DynamicDataAttribute`.)*
  - **`Expected`**: Includes all properties of the `ITestData` instance except the `TestCaseName` property. This is useful when the test case name isn't needed to be contained by the test data object array. *(Designed for using in xUnit in general, and in xUnit.v3, in combination with `ITheoryDataRow`.)*
  - **`Returns`**: Includes the `Expected` property only if the `ITestData` instance implements `ITestDataReturns`. Otherwise, the `Expected` property is excluded. *Designed for using in NUnit farmework where `TestCaseData` type supports simplified assertion of expected `ValueType` test case results.*
  - **`Throws`**: Includes the `Expected` property only if the `ITestData` instance implements `ITestDataThrows`. Otherwise, the `Expected` property is excluded.

**`Extensions` Static Class**
- **Purpose**: Provides extension methods for adding elements to object arrays and validating `ArgsCode` and `PropsCode` enum parameters.
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

![v2_DynamicDataSources](https://raw.githubusercontent.com/CsabaDu/CsabaDu.DynamicTestData/refs/heads/master/_Images/ClassDiagrams_v2/v2_DynamicDataSources_Horizontal.png)

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

## Sample Codes

Here are some basic examples of how to use `CsabaDu.DynamicTestData` in your project. These sample codes, together with much more test framework specific implementations can be found in the [Sample Code Library](https://github.com/CsabaDu/CsabaDu.DynamicTestData.SampleCodes). 

---

### **Sample Testable Class**

The following sample code demonstrates a simple testable class that demonstrates each type of test scenario supported by the framework. 

The class is a simple `BirthDay` class that has a name (`string`) and a date of birth (`DateOnly`). The class implements the `IComparable<BirthDay>` interface to allow comparison based on the date of birth. The class also has a static field for the current date, which is used to validate the date of birth.

```csharp
namespace CsabaDu.DynamicTestData.SampleCodes.Testables;

public class BirthDay : IComparable<BirthDay>
{
    #region Static Fields
    private static readonly DateOnly Today =
        DateOnly.FromDateTime(DateTime.Now);
    public const string GreaterThanTheCurrentDateMessage =
        "Date of birth cannot be greater than the current date.";
    #endregion

    #region Properties
    public string Name { get; init; }
    public DateOnly DateOfBirth { get; init; }
    #endregion

    #region Constructor
    // -----------
    // TEST CASES:
    // -----------
    // - GENERAL -
    // ('creates')
    // -----------
    // Valid name and dateOfBirth is equal with the current day => creates BirthDay instance
    // Valid name and dateOfBirth is greater than the current day => creates BirthDay instance
    // -----------
    // - THROWS -
    // -----------
    // name is null => throws ArgumentNullException
    // name is empty => throws ArgumentException
    // name is white space => throws ArgumentException
    // dateOfBirth is less than the current day => throws ArgumentOutOfRangeException
    public BirthDay(string name, DateOnly dateOfBirth)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(
            name,
            nameof(name));

        if (dateOfBirth > Today)
        {
            throw new ArgumentOutOfRangeException(
                nameof(dateOfBirth),
                GreaterThanTheCurrentDateMessage);
        }

        Name = name;
        DateOfBirth = dateOfBirth;
    }
    #endregion

    #region Methods
    // -----------
    // TEST CASES:
    // -----------
    // - RETURNS -
    // -----------
    // other is null => returns -1
    // this.DateOfBirth is less than other.DateOfBirth => returns -1
    // this.DateOfBirth is equal with other.DateOfBirth => returns 0
    // this.DateOfBirth is greater than other.DateOfBirth => returns 1
    public int CompareTo(BirthDay? other)
    => DateOfBirth.CompareTo(other?.DateOfBirth ?? DateOnly.MaxValue);
    #endregion
}
```

---

### Usage

This section provides basic examples of how to use each `ITestData` type in combination with various dynamic data source class extensions. Examples are shown for **MSTest**, **NUnit**, and **xUnit**, demonstrating how the framework integrates seamlessly across popular .NET test frameworks.

The demonstrated test cases and usage patterns for data source classes in this section are **consistent across all supported test frameworks**. As a result, the data sources themselves are **highly portable**, allowing reuse across MSTest, NUnit, and xUnit with minimal changes. (In cases where framework-specific conditions apply, only the data strategy parameters may need adjustment to fulfill those requirements.) The specific examples shown were selected arbitrarily and are intended to illustrate general usage rather than framework-specific behavior.

> To ensure **parameter order consistency** and enhance **readability**, it is recommended to define **local methods** within your data source methods. This helps encapsulate logic and maintain clarity when assembling test data rows.

---

#### General-purpose `TestData` Usage in *MSTest* with `DynamicObjectArraySource`

The following sample code demonstrates how to use:
- General-purpose `TestData<>` type
- in combination with the `DynamicObjectArraySource` class
- for testing in *MSTest*,
- using `ArgsCode.Instance`.

***DynamicObjectArraySource** child class*: 
```csharp
namespace CsabaDu.DynamicTestData.SampleCodes.DynamicDataSources;

public class BirthDayDynamicObjectArraySource(ArgsCode argsCode, PropsCode propsCode)
: DynamicObjectArraySource(argsCode, propsCode)
{
    private static readonly DateOnly Today =
        DateOnly.FromDateTime(DateTime.Now);

    // 'TestData<DateOnly>' type usage.
    // Valid 'string name' parameter should be declared and initialized within the test method.
    public IEnumerable<object?[]>? GetBirthDayConstructorValidArgs()
    {
        string expected = "creates BirthDay instance";
        string paramName = "dateOfBirth";

        // Valid name and dateOfBirth is equal with the current day => creates BirthDay instance
        string definition = $"Valid name and {paramName} is equal with the current day";
        DateOnly dateOfBirth = Today;
        yield return testDataToParams();

        // Valid name and dateOfBirth is less than the current day => creates BirthDay instance
        definition = $"Valid name and {paramName} is less than the current day";
        dateOfBirth = Today.AddDays(-1);
        yield return testDataToParams();

        #region Local Methods
        object?[] testDataToParams()
        => TestDataToParams(
            definition,
            expected,
            dateOfBirth))!;
        #endregion
    }
}
```

***MSTest** test class*: 
```csharp
namespace CsabaDu.DynamicTestData.SampleCodes.MSTest.UnitTests;

[TestClass]
public sealed class BirthDayTests_MSTest_ObyectArrays
{
    private static BirthDayDynamicObjectArraySource DataSource
    => new(ArgsCode.Instance, default);

    private static IEnumerable<object?[]>? BirthDayConstructorValidArgs
    => DataSource.GetBirthDayConstructorValidArgs();

    [TestMethod, DynamicData(nameof(BirthDayConstructorValidArgs))]
    public void Ctor_validArgs_createsInstance(TestData<DateOnly> testData)
    {
        // Arrange
        string name = "valid name";
        DateOnly dateOfBirth = testData.Arg1;

        // Act
        var actual = new BirthDay(name, dateOfBirth);
        
        // Assert
        Assert.IsNotNull(actual);
        Assert.AreEqual(name, actual.Name);
        Assert.AreEqual(dateOfBirth, actual.DateOfBirth);
    }
}
```

---

#### `TestDataReturns` Usage in *NUnit* with `DynamicObjectArrayRowSource`

The following sample code demonstrates how to use:
- `TestDataReturns<>` type
- in combination with the `DynamicObjectArrayRowSource` class
- for testing in *NUnit*,
- using `ArgsCode.Instance`.

***DynamicObjectArrayRowSource** child class*: 
```csharp
namespace CsabaDu.DynamicTestData.SampleCodes.DynamicDataSources;

public class BirthDayDynamicObjectArrayRowSource(ArgsCode argsCode, PropsCode propsCode)
: DynamicObjectArrayRowSource(argsCode, propsCode)
{
    private static readonly DateOnly Today =
        DateOnly.FromDateTime(DateTime.Now);

    // 'TestDataReturns<int, DateOnly, BirthDay>' type usage.
    // Valid 'string name' parameter should be declared and initialized within the test method.
    public IEnumerable<object?[]>? GetCompareToArgs()
    {
        string name = "valid name";
        DateOnly dateOfBirth = Today.AddDays(-1);

        // other is null => returns 1
        string definition = "other is null";
        int expected = -1;
        BirthDay? other = null;
        add();

        // this.DateOfBirth is greater than other.DateOfBirth => returns -1
        definition = "this.DateOfBirth is greater than other.DateOfBirth";
        other = new(name, dateOfBirth.AddDays(1));
        add();

        // this.DateOfBirth is equal with other.DateOfBirth => return 0
        definition = "this.DateOfBirth is equal with other.DateOfBirth";
        expected = 0;
        other = new(name, dateOfBirth);
        add();

        // this.DateOfBirth is less than other.DateOfBirth => returns 1
        definition = "this.DateOfBirth is less than other.DateOfBirth";
        expected = 1;
        other = new(name, dateOfBirth.AddDays(-1));
        add();

        return GetRows(null);

        #region Local Methods
        void add()
        => AddReturns(
            definition,
            expected,
            dateOfBirth,
            other);
        #endregion
    }
}
```

***NUnit** test class*: 
```csharp
namespace CsabaDu.DynamicTestData.SampleCodes.NUnit.UnitTests;

[TestFixture]
public class BirthdayTests_NUnit_ObjectArrayRows
{
    private static BirthDayDynamicObjectArrayRowSource DataSource
    => new(ArgsCode.Instance, default);

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        DataSource.ResetDataHolder();
    }

    public static IEnumerable<object?[]>? CompareToArgs
    => DataSource.GetCompareToArgs();

    [TestCaseSource(nameof(CompareToArgs))]
    public void CompareTo_validArgs_returnsExpected(
        TestDataReturns<int, DateOnly, BirthDay> testData)
    {
        // Arrange
        string name = "valid name";
        DateOnly dateOfBirth = testData.Arg1;
        BirthDay? other = testData.Arg2;
        BirthDay sut = new(name, dateOfBirth);

        // Act
        var actual = sut.CompareTo(other);

        // Assert
        Assert.That(actual, Is.EqualTo(testData.Expected));
    }
}
```

---

#### `TestDataThrows` Usage in *xUnit* with `DynamicExpectedObjectArrayRowSource`

The following sample code demonstrates how to use:
- `TestDataThrows<>` type
- in combination with the `DynamicExpectedObjectArrayRowSource` class
- for testing in *xUnit*,
- using `ArgsCode.Properties`.

***DynamicExpectedObjectArrayRowSource** child class*: 
```csharp
namespace CsabaDu.DynamicTestData.SampleCodes.DynamicDataSources;

public class BirthDayDynamicExpectedObjectArrayRowSource(ArgsCode argsCode)
: DynamicExpectedObjectArrayRowSource(argsCode)
{
    private static readonly DateOnly Today =
        DateOnly.FromDateTime(DateTime.Now);

    // 'TestDataThrows<ArgumentException, string>' type usage.
    // Invalid 'DateOnly dateOfBirth' parameter should be declared and initialized within the test method.
    public IEnumerable<object?[]>? GetBirthDayConstructorInvalidArgs()
    {
        string paramName = "name";

        // name is null => throws ArguemntNullException
        string definition = $"{paramName} is null";
        string name = null!;
        ArgumentException expected = new ArgumentNullException(paramName);
        add();

        // name is empty => throws ArgumentException
        definition = $"{paramName} is empty";
        name = string.Empty;
        string message = "The value cannot be an empty string " +
            "or composed entirely of whitespace.";
        expected = new ArgumentException(message, paramName);
        add();

        // name is white space => throws ArgumentException
        definition = $"{paramName} is white space";
        name = " ";
        add();

        paramName = "dateOfBirth";

        // dateOfBirth is greater than the current day => throws ArgumentOutOfRangeException
        definition = $"{paramName} is greater than the current day";
        name = "valid name";
        message = BirthDay.GreaterThanTheCurrentDateMessage;
        expected = new ArgumentOutOfRangeException(paramName, message);
        add();

        return GetRows(null);

        #region Local Methods
        void add()
        => AddThrows(
            definition,
            expected,
            name);
        #endregion
    }
}
```

***xUnit** test class*: 
```csharp
namespace CsabaDu.DynamicTestData.SampleCodes.xUnit.UnitTests;

public class BirthDayTests_xUnit_ExpectedObjectArrayRows : IDisposable
{
    private static BirthDayDynamicExpectedObjectArrayRowSource DataSource
    => new(ArgsCode.Properties);

    public void Dispose()
    {
        DataSource.ResetDataHolder();
        GC.SuppressFinalize(this);
    }

    public static IEnumerable<object?[]>? BirthDayConstructorInvalidArgs
    => DataSource.GetBirthDayConstructorInvalidArgs();

    [Theory, MemberTestData(nameof(BirthDayConstructorInvalidArgs))]
    public void Ctor_invalidArgs_throwsArgumentException(
        ArgumentException expected,
        string? name)
    {
        // Arrange
        DateOnly dateOfBirth = DateOnly.FromDateTime(DateTime.Now).AddDays(1);
        void attempt() => _ = new BirthDay(name!, dateOfBirth);

        // Act
        var actual = Record.Exception(attempt) as ArgumentException;

        // Assert
        Assert.IsType(expected.GetType(), actual);
        Assert.Equal(expected.Message, actual?.Message);
        Assert.Equal(expected.ParamName, actual?.ParamName);
    }
}
```

> ***Note for xUnit Users***  
> 
> To ensure that **Test Explorer displays the short method name** (rather than the full signature), add a `xunit.runner.json` configuration file to your test project with the following content:
 
```json
{
  "$schema": "https://xunit.net/schema/current/xunit.runner.schema.json",
  "methodDisplay": "method"
}
```
 
> Additionally, include the following item group in your `.csproj` file to ensure the configuration file is copied to the output directory:
 
```xml
<ItemGroup>
  <Content Include="xunit.runner.json" CopyToOutputDirectory="PreserveNewest" />
</ItemGroup>
```

---

### Advanced Usage

While *CsabaDu.DynamicTestData* offers intuitive, ready-to-use components for dynamic test data generation, its true strength lies in its **extensibility**.

This section presents native code examples that demonstrate advanced usage patterns—**without relying on any external dependencies** (besides the target test framework itself). These examples are designed to help you understand and apply the core concepts directly, using only the built-in capabilities of the framework. 

For test-framework-specific advanced implementations, refer to the [Sample Code Library](https://github.com/CsabaDu/CsabaDu.DynamicTestData.SampleCodes). You’ll find:
- **Ready-to-use extensions** for MSTest, NUnit, xUnit, and xUnit.v3
- **Intuitive sample implementations**
- **Flexible abstractions** that support custom types, reusable data holders, and framework-specific enhancements

In this section, we will focus on the following core advanced topics:
- Temporary `DataStrategy` Overriding  
- Generate Custom Display Name When Using `Argscode.Properties`

---

#### Temporary `DataStrategy` Overriding

By default, the **data strategy** — defined by `ArgsCode` and `PropsCode` — is provided by the dynamic data source classes and set during their initialization. These values determine the **type and content of each data row**, influencing how test arguments and expected results are structured.

Nevertheless, *CsabaDu.DynamicTestData* offers a **temporary overriding option** for these strategies, enabling fine-grained control over individual test cases.

There are two mechanisms for this:

- **When extending `DynamicObjectArraySource`**:  
  Use the base class method `WithOptionalDataStrategy<T>([NotNull] Func<T>, string, ArgsCode?, PropsCode?)` to override the strategy temporarily for a specific test data row.

- **When extending any derivative of `DynamicDataRowSource<TRow>`**:  
  Use the `IRow<TRow>.GetRow(ArgsCode?)` or `IRow<TRow>.GetRow(ArgsCode?, PropsCode?)` method to retrieve a test data row formatted according to the specified strategy.

These mechanisms allow developers to override the default behavior without modifying the global configuration of the data source.

---

The following sample code demonstrates how to use:
- `TestData<>` type
- in combination with the `DynamicObjectArraySource` class
- for testing in *NUnit*,
- overriding the default data stratiegy with the `WithOptionalDataStrategy` method.

***DynamicObjectArraySource** child class*: 
```csharp
namespace CsabaDu.DynamicTestData.SampleCodes.DynamicDataSources;

public class BirthDayDynamicObjectArraySource(ArgsCode argsCode, PropsCode propsCode)
: DynamicObjectArraySource(argsCode, propsCode)
{
    private static readonly DateOnly Today =
        DateOnly.FromDateTime(DateTime.Now);

    // Optional 'ArgsCode' and 'PropsCode' parameters can be used 
    // to override the default data strategy.
    public IEnumerable<object?[]>? GetCompareToArgs(
        ArgsCode? argsCode = null,
        PropsCode? propsCode = null)
    {
        string expected = "creates BirthDay instance";
        string paramName = "dateOfBirth";

        // Valid name and dateOfBirth is equal with the current day => creates BirthDay instance
        string definition = $"Valid name and {paramName} is equal with the current day";
        DateOnly dateOfBirth = Today;
        yield return testDataToParams();

        // Valid name and dateOfBirth is less than the current day => creates BirthDay instance
        definition = $"Valid name and {paramName} is less than the current day";
        dateOfBirth = Today.AddDays(-1);
        yield return testDataToParams();

        #region Local Methods
        // Temporarily override the data strategy using the 'WithOptionalDataStrategy' method.
        // If both 'argsCode' and 'propsCode' are null or match the default values,
        // the default strategy is retained; otherwise, the specified values are applied.
        object?[] testDataToParams()
        => WithOptionalDataStrategy(
            () => TestDataToParams(
                definition,
                expected,
                dateOfBirth),
            nameof(TestDataToParams),
            argsCode,
            propsCode)!;
        #endregion
    }
}
```

***NUnit** test class*: 
```csharp
namespace CsabaDu.DynamicTestData.SampleCodes.xUnit.UnitTests;

public class BirthDayTests_NUnit_ObjectArrayRows : IDisposable
{
   // Default data strategy setup.
    private static BirthDayDynamicObjectArraySource DataSource
    => new(ArgsCode.Instance, default);

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        DataSource.ResetDataHolder();
    }

    // Optional 'ArgsCode' and 'PropsCode' parameters override the default data strategy.
    public static IEnumerable<object?[]>? BirthDayConstructorValidArgs
    => DataSource.GetBirthDayConstructorValidArgs(
        ArgsCode.Properties,
        PropsCode.Expected);

    [TestCaseSource(nameof(BirthDayConstructorValidArgs))]
    public void Ctor_validArgs_createsInstance(DateOnly dateOfBirth)
    {
        // Arrange
        string name = "valid name";

        // Act
        var actual = new BirthDay(name, dateOfBirth);

        // Assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Name, Is.EqualTo(name));
            Assert.That(actual.DateOfBirth, Is.EqualTo(dateOfBirth));
        }
    }
}
```

---

The following sample code demonstrates how to use:
- `TestDataReturns<>` type
- in combination with the `DynamicObjectArrayRowSource` class
- for testing in *xUnit*,
- overriding the default data stratiegy with the `GetRow` method.

***DynamicObjectArrayRowSource** child class*: 
```csharp
public class BirthDayDynamicObjectArrayRowSource(ArgsCode argsCode, PropsCode propsCode)
: DynamicObjectArrayRowSource(argsCode, propsCode)
{
    private static readonly DateOnly Today =
        DateOnly.FromDateTime(DateTime.Now);

    // Optional 'ArgsCode' and 'PropsCode' parameters can be used 
    // to override the default data strategy.
    public IEnumerable<object?[]>? GetCompareToArgs(
        ArgsCode? argsCode = null,
        PropsCode? propsCode = null)
    {
        string name = "valid name";
        DateOnly dateOfBirth = Today.AddDays(-1);

        // other is null => returns 1
        string definition = "other is null";
        int expected = -1;
        BirthDay? other = null;
        add();

        // this.DateOfBirth is greater than other.DateOfBirth => returns -1
        definition = "this.DateOfBirth is greater than other.DateOfBirth";
        other = new(name, dateOfBirth.AddDays(1));
        add();

        // this.DateOfBirth is equal with other.DateOfBirth => return 0
        definition = "this.DateOfBirth is equal with other.DateOfBirth";
        expected = 0;
        other = new(name, dateOfBirth);
        add();

        // this.DateOfBirth is less than other.DateOfBirth => returns 1
        definition = "this.DateOfBirth is less than other.DateOfBirth";
        expected = 1;
        other = new(name, dateOfBirth.AddDays(-1));
        add();

        // Temporarily override the data strategy using the 'GetRows' method.
        // If both 'argsCode' and 'propsCode' are null or match the default values,
        // the default strategy is retained; otherwise, the specified values are applied.
        return GetRows(argsCode, propsCode);

        #region Local Methods
        void add()
        => AddReturns(
            definition,
            expected,
            dateOfBirth,
            other);
        #endregion
    }
}
```

***xUnit** test class*: 
```csharp
namespace CsabaDu.DynamicTestData.SampleCodes.NUnit.UnitTests;

[TestFixture]
public class BirthdayTests_xUnit_ObjectArrayRows
{
   // Default data strategy setup.
    private static BirthDayDynamicObjectArrayRowSource DataSource
    => new(ArgsCode.Instance, default);

    public void Dispose()
    {
        DataSource.ResetDataHolder();
        GC.SuppressFinalize(this);
    }

    // Optional 'ArgsCode' and 'PropsCode' parameters override the default data strategy.
    public static IEnumerable<object?[]>? CompareToArgs
    => DataSource.GetCompareToArgs(
        ArgsCode.Properties,
        PropsCode.Expected);

    [Theory, MemberTestData(nameof(CompareToArgs))]
    public void CompareTo_validArgs_returnsExpected(
        int expected,
        DateOnly dateOfBirth,
        BirthDay? other)
    {
        // Arrange
        string name = "valid name";
        BirthDay sut = new(name, dateOfBirth);

        // Act
        var actual = sut.CompareTo(other);

        // Assert
        Assert.Equal(expected, actual);
    }
}
```
---

#### Generate Custom Display Name When Using `Argscode.Properties`

*CsabaDu.DynamicTestData* provides intrinsic support for generating test display names when using `ArgsCode.Instance` in the data strategy. This is achieved through the `TestData.ToString()` method, which returns the dynamically generated display name for each test case.

Most test frameworks offer their own mechanisms for customizing test case display names, typically through their own test data types:
- **NUnit**: via `TestParameters.TestName`
- **xUnit.v3**: via `ITheoryDataRow.TestDisplayName`

You can find supportive implementations in the [Sample Code Library](https://github.com/CsabaDu/CsabaDu.DynamicTestData.SampleCodes) that demonstrate how to generate test display names using framework-specific test data types.

This section demonstrates how to generate test display names from object array rows in the notable exception **MSTest**, which supports custom display names natively when using object arrays as test data rows. You can see this in action using the method `TestDataFactory.GetDisplayName(string?, params object?[]?)`, which constructs display names from the test method name and the `TestData.TestCaseName` property value.

---

The following sample code demonstrates how to use:
- `TestDataThrows<>` type
- in combination with the `DynamicObjectArrayRowSource` class
- for testing in *MSTest*,
- generating custom display name when using `ArgsCode.Properties`.

***DynamicObjectArrayRowSource** child class*: 
```csharp
namespace CsabaDu.DynamicTestData.SampleCodes.DynamicDataSources;

public class BirthDayDynamicObjectArrayRowSource(ArgsCode argsCode, PropsCode propsCode)
: DynamicObjectArrayRowSource(argsCode, propsCode)
{
    private static readonly DateOnly Today =
        DateOnly.FromDateTime(DateTime.Now);

    // 'TestDataThrows<ArgumentException, string>' type usage.
    // Invalid 'DateOnly dateOfBirth' parameter should be declared and initialized within the test method.
    public IEnumerable<object?[]>? GetBirthDayConstructorInvalidArgs()
    {
        string paramName = "name";

        // name is null => throws ArguemntNullException
        string definition = $"{paramName} is null";
        string name = null!;
        ArgumentException expected = new ArgumentNullException(paramName);
        add();

        // name is empty => throws ArgumentException
        definition = $"{paramName} is empty";
        name = string.Empty;
        string message = "The value cannot be an empty string " +
            "or composed entirely of whitespace.";
        expected = new ArgumentException(message, paramName);
        add();

        // name is white space => throws ArgumentException
        definition = $"{paramName} is white space";
        name = " ";
        add();

        paramName = "dateOfBirth";

        // dateOfBirth is greater than the current day => throws ArgumentOutOfRangeException
        definition = $"{paramName} is greater than the current day";
        name = "valid name";
        message = BirthDay.GreaterThanTheCurrentDateMessage;
        expected = new ArgumentOutOfRangeException(paramName, message);
        add();

        return GetRows(null);

        #region Local Methods
        void add()
        => AddThrows(
            definition,
            expected,
            name);
        #endregion
    }
}
```

***MSTest** test class*: 
```csharp
namespace CsabaDu.DynamicTestData.SampleCodes.MSTest.UnitTests;

[TestClass]
public sealed class BirthDayTests_MSTest_ObyectArrayRowss
{
    // Uses 'PropsCode.TestCaseName' to embed the test case name
    // as first element into each generated object array row.
    private static BirthDayDynamicObjectArrayRowSource DataSource
    => new(ArgsCode.Properties, PropsCode.TestCaseName);

    [ClassCleanup]
    public static void Cleanup()
    {
        DataSource.ResetDataHolder();
    }

    // Constructs a custom display name by combining
    // the test method name with the test case name,
    // which is expected to be the first element in the object array row.
    // The method must be public and static with the exact signature
    // 'string? GetDisplayName(MethodInfo, object?[]?)'
    // to be recognized by MSTest framework. 
    public static string? GetDisplayName(MethodInfo testMethod, object?[] args)
    => TestDataFactory.GetDisplayName(testMethod.Name, args);

    private static IEnumerable<object?[]>? BirthDayConstructorInvalidArgs
    => DataSource.GetBirthDayConstructorInvalidArgs();

    [TestMethod]
    // Assigns the 'DynamicDataAttribute.DynamicDisplayName' property
    // to use the 'GetDisplayName' method for generating test case names.
    [DynamicData(nameof(BirthDayConstructorInvalidArgs),
        DynamicDataDisplayName = nameof(GetDisplayName))]
    public void Ctor_invalidArgs_throwsArgumentException(
        string ignored, // test case name, used for display name generation only
        ArgumentException expected,
        string? name)
    {
        // Arrange
        DateOnly dateOfBirth = DateOnly.FromDateTime(DateTime.Now).AddDays(1);
        void attempt() => _ = new BirthDay(name!, dateOfBirth);

        try
        {
            // Act
            attempt();
            Assert.Fail($"Expected {expected.GetType().Name} was not thrown.");
        }
        catch (ArgumentException actual)
        {
            // Assert
            Assert.IsInstanceOfType(actual, expected.GetType());
            Assert.AreEqual(expected.ParamName, actual.ParamName);
            Assert.AreEqual(expected.Message, actual.Message);
        }
        catch (Exception ex)
        {
            Assert.Fail($"Unexpected exception type: {ex.GetType().Name}");
        }
    }
}
```
---

## Changelog

### Version 2.0.0-beta (2025-08-11)
**Changed** 

**`TestDataTypes.Interfaces`**

| **Type**        | **Public Member**                             | **Change**                                                                 | **New**                                                                 |
|-----------------|-----------------------------------------------|-----------------------------------------------------------------------------|-------------------------------------------------------------------------|
| `ITestCaseName` | `string TestCase { get; }`                    | Shifted to `ITestData<TResult>` and renamed to `TestCaseName`              | `ITestData<TResult>.TestCaseName`                                      |
|                 | `string GetTestCaseName()`                    | New member to access the test case name of the derivates                   | `ITestCaseName.GetTestCaseName()`                                      |
| `ITestData`     | `string ExitMode { get; }`                    | Cancelled                                                                  | —                                                                       |
|                 | `string Result { get; }`                      | Cancelled                                                                  | —                                                                       |
|                 | `object?[] PropertiesToArgs(bool)`            | Cancelled                                                                  | —                                                                       |
|                 | `object?[] ToParams(ArgsCode, bool)`          | Signature changed: second `bool` replaced with `PropsCode`                 | `object?[] ToParams(ArgsCode, PropsCode)`                              |

**`DynamicDataSources`**

| **Type**             | **Public Member**                                         | **Change**                                                                 | **New**                                                                 |
|----------------------|-----------------------------------------------------------|-----------------------------------------------------------------------------|-------------------------------------------------------------------------|
| `ArgsCode`           | —                                                         | Shifted to namespace `Statics`                                             | `Statics.ArgsCode`                                                     |
| `DynamicDataSource`  | `static GetDisplayName(string?, params object?[]?)`       | Shifted to static class `TestDataFactory`                                  | `TestDataFactory.GetDisplayName(string?, params object?[]?)`           |
|                      | `static TestDataToParams(ITestData, ArgsCode, bool, out string)` | Shifted to `TestDataFactory` and signature changed: `bool` → `PropsCode` | `TestDataFactory.TestDataToParams(ITestData, ArgsCode, PropsCode, out string)` |

---

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

---

### **Version 1.4.0** (2025-05.16)

- **Added**:
  - `PropertiesToArgs` method added to the ITestData interface to generate an object array with the test parameters only.
- **Updated**:
  - README.md updated with the new feature.
  - README.md corrected the meaning of the behavior of `struct` constraint for the `TStruct` type parameter of `ITestDataReturns<TStruct>` instances.
- **Note**:
  - This update is backward-compatible with previous versions.

---

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

---

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

---

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

---

### **Version 1.0.0** (2025-02-09)

- Initial release of the `CsabaDu.DynamicTestData` framework.
- Includes the `ITestData` generic interface types, `TestData` record types, `DynamicDataSource` base class, and `ArgsCode` enum.
- Provides support for dynamic data-driven tests with multiple arguments, expected not null `ValueType' results, and exceptions.

---

## License

This project is licensed under the MIT License. See the [License](LICENSE.txt) file for details.

---

## Contact

For any questions or inquiries, please contact [CsabaDu](https://github.com/CsabaDu).

---

## FAQ

 - **Can I install `IXunitSerializable` or `IXunitSerializer` (xUnit.v3) interfaces to support using `TestData` types in xUnit tests?**
  No, you cannot install these interfaces because `TestData` types are open-generic ones, and don't have parameterless constructors. Although, you can generate object array of xUnit-serializable parameters to use them in `TheoryData` type data sources. Besides, if your tests don't have to comply with xUnit-serializability, you can use `TestData` types in xUnit tests well. 

- **Can I use the earlier implemented data source and test classes with version 1.1.0 ?**
  Yes, you can seamlessly use the already installed classes with the upgraded v1.1.0 of `CsabaDu.DynamicTestData` without the need of any change in your code. Besides, you can easily modify those to enjoy the benefits of the flexibility of this version.

---

## Troubleshooting

