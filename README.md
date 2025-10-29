# CsabaDu.DynamicTestData

🎯 A robust, flexible, extensible, pure .NET framework to facilitate dynamic data-driven testing.

- ⚙️ Test data **conversion, management and provisioning**
- ⛑️ **Type-safe and thread-safe** support for *MSTest*, *NUnit*, *xUnit*, *xUnit.v3*
- 🧩 **Modular design**, abstractions and ready-to-use integrations
- 💼 **Portable** data sources
- 📋 Traceable **descriptive display names**
- 💵 **Now seeking sponsors** to complete v2.0 – comprehensive testing, documentation, examples, and new features!

---

[![Sponsor this project](https://img.shields.io/badge/Sponsor_on_GitHub-💖-ff69b4?style=flat-square)](https://github.com/sponsors/CsabaDu) 
[![Buy me a coffee](https://raw.githubusercontent.com/CsabaDu/CsabaDu.DynamicTestData/refs/heads/master/_Images/white-button_15.png)](https://buymeacoffee.com/csabadu) 
[![Support Me a Ko-fi](https://raw.githubusercontent.com/CsabaDu/CsabaDu.DynamicTestData/refs/heads/master/_Images/SupportMeOnKofi_20.png)](https://ko-fi.com/csabadu) 
[![OpenCollective](https://opencollective.com/static/images/opencollectivelogo-footer-n.svg)](https://opencollective.com/csabadudynamictestdata)  

---

## 📖 Documentation

This README contains the base info and the current version related notes.    
Visit the **[Wiki](https://github.com/CsabaDu/CsabaDu.DynamicTestData/wiki)** for full documentation, including  
- 📖 [**Introduction**](https://github.com/CsabaDu/CsabaDu.DynamicTestData/wiki/00-%F0%9F%93%96-Introduction)
- 🚀 [**Quick Start Guide**](https://github.com/CsabaDu/CsabaDu.DynamicTestData/wiki/01-%F0%9F%9A%80-Quick-Start-Guide)  
- 📐 [**Architecture**](https://github.com/CsabaDu/CsabaDu.DynamicTestData/wiki/02-%F0%9F%93%90-Architecture)  
- 🔍 [**Types**](https://github.com/CsabaDu/CsabaDu.DynamicTestData/wiki/03-%F0%9F%94%8D-Types)  
- 🌍 [**Project Ecosystem**](https://github.com/CsabaDu/CsabaDu.DynamicTestData/wiki/04-%F0%9F%8C%8D-Project-Ecosystem)  
- 📚 [**Sample Codes**](https://github.com/CsabaDu/CsabaDu.DynamicTestData/wiki/05-%F0%9F%93%9A-Sample-Codes)  

---

## 📘 Table of Contents

- [**CsabaDu.DynamicTestData — Modular Architecture**](#csabadudynamictestdata--modular-architecture))
- [**Version 2.0.0-beta Foreword**](#version-200-beta-foreword)
- [**Migration Guide (Under Construction)**](#migration-guide-under-construction)  
- [**Changelog**](#changelog)
- [**Contributing**](#contributing)
- [**License**](#license)
- [**Contact**](#contact)
- [**FAQ**](#faq)
- [**Troubleshooting**](#troubleshooting)

---

## CsabaDu.DynamicTestData — Modular Architecture
(Version 2.0.0-beta Foreword)

### **Overview**  

**CsabaDu.DynamicTestData** has been reorganized from a single monolithic package into a set of focused, aligned modules (NuGet packages) while keeping a clean, consistent namespace hierarchy under `CsabaDu.DynamicTestData.*`. Modules are deployable package boundaries; namespaces are logical organization inside those packages. The new layout reduces transitive dependencies, clarifies responsibilities, and makes it easier for developers to adopt only what they need.

See the Segregated Architecture Diagram for a visual overview of module and namespace boundaries and dependencies:

![CsabaDu_DynamicTestData_Segregated_Simplified](https://raw.githubusercontent.com/CsabaDu/CsabaDu.DynamicTestData/refs/heads/master/_Images/CsabaDu_DynamicTestData_Segregated_Simplified.svg)

---

### **Modules and contents**

#### Core Foundation Module  
  ***(package: `CsabaDu.DynamicTestData.Core`)***  

Foundation layer with essential contract surface, DTOs, stateless encoding helpers and strategy definitions.  
See [CsabaDu.DynamicTestData.Core README](https://github.com/CsabaDu/CsabaDu.DynamicTestData.Core/blob/master/README.md).

#### Lite Implementation Module  
  ***(package: `CsabaDu.DynamicTestData.Lite`)***  

Lightweight runtime helpers for manual-enumerable-style data sources - depends on Core.
See [CsabaDu.DynamicTestData.Lite README](https://github.com/CsabaDu/CsabaDu.DynamicTestData.Lite/blob/master/README.md).  

#### Full Implementation Module  
  ***(package: `CsabaDu.DynamicTestData`)***  

Complete runtime and convenience surface that provides all concrete implementations, builders, holders, rows, strategies, and adapters, composed on Core and Lite.

**Namespaces and highlights**:  

---
**`CsabaDu.DynamicTestData.DataStrategyTypes`**  

- *DataStrategy concrete implementation (flyweight pattern)*:  

  - **DataStrategy.cs**  

    - `DataStrategy`: sealed record  

---
**`CsabaDu.DynamicTestData.TestDataRows.Interfaces`**  

- *Data wrapper and converter row contracts (Composite component interfaces*:  

  - **ITestDataRow.cs**  

    - `ITestDataRow`: interface  
    - `ITestDataRow<TRow>`: interface  
    - `ITestDataRow<TRow, TTestData>`: interface  

  - **INamedTestDataRow.cs**  

    - `INamedTestDataRow`: interface  

---
**`CsabaDu.DynamicTestData.TestDataRows`**  

- *Test data row implementations (Composite leaves)*:  

  - **TestDataRow.cs**  

    - `TestDataRow<TRow>`: abstract class  
    - `TestDataRow<TRow, TTestData>`: abstract class

  - **NamedTestDataRow.cs**  

    - `NamedTestDataRow<TRow, TTestData>`: abstract class  

  - **ObjectArrayRow.cs**  

    - `ObjectArrayRow<TTestData>`: class  

---
**`CsabaDu.DynamicTestData.DataRowHolders.Interfaces`**  

- *Data row holder contracts (Composite interfaces)*:  

  - **IDataRowHolder.cs**  

    - `IDataRowHolder`: interface  
    - `IDataRowHolder<TRow>`: interface  
    - `IDataRowHolder<TRow, TTestData>`: interface  

  - **INamedDataRowHolder.cs**  

    - `INamedDataRowHolder<TRow, TTestData>`: interface  

- *Collection contracts*:  

  - **ITestDataRows.cs**  

    - `ITestDataRows`: interface  

  - **IRows.cs**  

    - `IRows`: interface  

  - **INamedRows.cs**  

    - `INamedRows`: interface  

- *Strongly typed addition contract*:  

  - **IAddTestData.cs**  

    - `IAddTestData<TTestData>`: interface  

- *Component factory method contract*:  

  - **ITestDataRowFactory.cs**  

    - `ITestDataRowFactory<TRow, TTestData>`: interface  

---
**`CsabaDu.DynamicTestData.DataRowHolders`**  

- *Data row holder implementations (Concrete composites)*:  

  - **DataRowHolder.cs**  

    - `DataRowHolder<TRow>`: abstract class  
    - `DataRowHolder<TRow, TTestData>`: abstract class  

  - **NamedDataRowHolder.cs**  

    - `NamedDataRowHolder<TRow, TTestData>`: abstract class  

  - **ObjectArrayRowHolder.cs**  

    - `ObjectArrayRowHolder<TTestData>`: class  

---

**`CsabaDu.DynamicTestData.DynamicDataRowSources`**  

- *Managed data row sources*:  

  - **DynamicDataSource.cs**  

    - `DynamicDataRowSource<TDataRowHolder, TRow>` : abstract class  
    - `DynamicDataRowSource<TRow>` : abstract class  

  - **DynamicNamedDataSource.cs**  

    - `DynamicNamedDataRowSource<TRow>` : abstract class  
  
  - **DynamicObjectArraySource.cs**  

    - `DynamicObjectArrayRowSource` : abstract class  

  - **DynamicExpectedObjectArraySource.cs**  

    - `DynamicExpectedObjectArrayRowSource` : abstract class  

---
**When to use**:  
- Holder-backed GetRows() semantics  
- Named-row support for display names and deduplication  
- Deterministic ordering and test case management  
- Ready-made framework adapters for xUnit, NUnit, MSTest 


**Dependencies**: `CsabaDu.DynamicTestData.Lite` (>= 2.1.0-beta)

---


## Version 2.0.0-beta Foreword


The `CsabaDu.DynamicTestData` framework has undergone a major transformation in version **2.0.0-beta**, introducing a wide range of enhancements while preserving its original foundation.

The core components from the 1.x.x series — particularly the `TestDataTypes.*` namespaces and the `DynamicDataSource` class — remain central to the framework. However, even these familiar types have received **small but breaking changes** to align with the new architecture.

This release introduces powerful new capabilities:
- **Test data conversion** to any type of test data row
- **Data row management** for structured and reusable test inputs
- **Flexible data provisioning** to test methods across frameworks

These features make the framework easier to use, more adaptable to diverse testing needs, and better suited for integration with MSTest, NUnit, xUnit, and beyond. The newly introduced interfaces and abstract classes are designed for **extensibility**, allowing developers to support custom types and framework-specific features while staying aligned with the `CsabaDu.DynamicTestData` ecosystem.

The architecture is **clean**, the codebase is **modular**, and many features have been **partially tested**. The documentation provides detailed insights into the design, types, and usage patterns. However, this version is still considered **beta** due to:
- Incomplete test coverage
- Missing documentation sections (e.g., migration guide from v1.x.x)

**Final Notes**  

This version is beta, meaning:
  - Features are **stable but may change**  
  - Some features are only **partially tested**  
  - Documentation is detailed, but **incomplete**  
  - Feedback and support is **highly appreciated**  

---

## Migration Guide (Under Construction)

### Migration from v2.0.x-beta to v2.1.0-beta

If you're upgrading from version `2.0.x-beta` to `2.1.0-beta`, please note the following breaking changes:

- All data source base classes with name end `...RowSource` (e.g., `DynamicDataRowSource<TRow>`, `DynamicObjectArrayRowSource`, etc.) have been moved from the `DynamicDataSources` namespace to the new `DynamicDataRowSources` namespace. Once you have inherited from any of these classes in your data source implementations, you need to update the `using` directives accordingly.

---

### Migration from v1.x.x to v2.0.0-beta

If you're upgrading from an earlier version of `CsabaDu.DynamicTestData`, please note:

> ⚠️ **Compatibility is broken**, even though the structure of your data source methods may remain similar to current requirements.

### What May Stay the Same
- The **structure** of your data source methods (e.g. method body, return types) may still align with the new framework.
- However, due to namespace, naming, and parameter changes, **existing implementations will not work without updates**.

### Required Changes
To ensure compatibility with the latest version (incomplete list):
- **Namespace updates**  
  - `ArgsCode` moved from `DynamicDataSources` → `Statics`
- **Renamed members**  
  - `TestData.TestCase` → `TestData.TestCaseName`  
  - `TestDataToArgs(...)` → `TestDataToParams(...)`
- **Signature changes**  
  - `DynamicDataSource` constructor now requires two parameters: `ArgsCode argsCode, PropsCode propsCode`
  - parameter where `bool? withExpected` was used → replace with `PropsCode propsCode`

### What to Do
- Update your test classes and data source references accordingly.
- Review the [Changelog](#changelog) for a complete list of changes.
- Explore the [Types](#types) section for detailed feature descriptions.

A full migration guide is on the way.  
In the meantime, feel free to reach out or open an issue if you need help.

---

## Changelog

### **Version 2.0.0-beta** (2025-10-29)

> This is a **beta release** introducing **breaking changes**, new features, and architectural enhancements to the `CsabaDu.DynamicTestData` library. These updates improve usability, flexibility, and extensibility across supported test frameworks.

---
#### **Removed**

- Namespaces moved with full contents to `CsabaDu.DynamicTestData.Core` package:  

  - `Statics`
  - `TestDataTypes.Interfaces`
  - `TestDataTypes`

- Namespaces moved with full contents to `CsabaDu.DynamicTestData.Lite` package:  

  - `DataStrategyTypes.Interfaces`  

- Namespaces moved with partial contents to `CsabaDu.DynamicTestData.Lite` package:  

  - `DynamicDataSources`  

    - DynamicDataSources.cs
    - DynamicObjectArraySource.cs
    - DynamicExpectedObjectArraySource.cs

---
#### **Added**

- New package dependency :  

  - `CsabaDu.DynamicTestData.Lite` (including `CsabaDu.DynamicTestData.Core` as transitive dependency)

---
#### **Changed**

- Classes muved from `DynamicDataSources` namespace to new `DynamicDataRowSources` namespace:  

  - `DynamicDataRowSource<TDataRowHolder, TRow>`  
  - `DynamicDataRowSource<TRow>`  
  - `DynamicNamedDataRowSource<TRow>`  
  - `DynamicObjectArrayRowSource`  
  - `DynamicExpectedObjectArrayRowSource`  

---
### **Version 2.0.0-beta** (2025-08-12)

> This is a **beta release** introducing **breaking changes**, new features, and architectural enhancements to the `CsabaDu.DynamicTestData` library. These updates improve usability, flexibility, and extensibility across supported test frameworks.

---

#### **Changed**  

> *This section summarizes changes to existing types introduced in this release. For details of the updated members and their current definitions, see the [Types](#types) section.*  

- **`Statics`**  

| **Type**       | **Modified Member**                                                                 | **Change** | **Current Member** |
|----------------|--------------------------------------------------------------------------------------|------------|---------------------|
| `Extensions`   | `static PropsCode Defined(this PropsCode, string)`                                  | New        | `Extensions.Defined(...)` |
|                | `static InvalidEnumArgumentException GetInvalidEnumArgumentException(this PropsCode, string)` | New        | `Extensions.GetInvalidEnumArgumentException(...)` |

- **`TestDataTypes.Interfaces`**

| **Type**       | **Modified Member**                                  | **Change**                                     | **Current Member** |
|----------------|------------------------------------------------------|------------------------------------------------|---------------------|
| `ITestCaseName`| `string TestCase { get; }`                           | Shifted to `ITestData<TResult>` and renamed    | `ITestData<TResult>.TestCaseName` |
|                | `string GetTestCaseName()`                           | New member                                     | `ITestCaseName.GetTestCaseName()` |
| `ITestData`    | `string ExitMode { get; }`, `string Result { get; }`, `object?[] PropertiesToArgs(bool)` | Cancelled | - |
|                | `object?[] ToParams(ArgsCode, bool)`                | Signature changed: `bool` → `PropsCode`        | `ToParams(ArgsCode, PropsCode)` |

- **`TestDataTypes`**

| **Type**    | **Modified Member**                                  | **Change**                                     | **Current Member** |
|-------------|------------------------------------------------------|------------------------------------------------|---------------------|
| `TestData`  | `string TestCase { get; }`                           | Renamed to `TestCaseName`                      | `TestData.TestCaseName` |
|             | `ExitMode`, `Result`, `PropertiesToArgs(bool)`       | Cancelled                                      | - |
|             | `ToParams(ArgsCode, bool)`                           | Signature changed: `bool` → `PropsCode`        | `ToParams(ArgsCode, PropsCode)` |

- **`DynamicDataSources`**  

| **Type**              | **Modified Member**                                                                 | **Change**                                     | **Current Member** |
|-----------------------|--------------------------------------------------------------------------------------|------------------------------------------------|---------------------|
| `ArgsCode`            | -                                                                                   | Shifted to namespace `Statics`                 | `Statics.ArgsCode` |
| `DynamicDataSource`   | `ArgsCode`, `PropsCode`                                                             | Refactored and exposed via `IDataStrategy`     | `IDataStrategy.ArgsCode`, `PropsCode` |
|                       | `DynamicDataSource(ArgsCode)` (constructor)                                         | Signature changed (`PropsCode` added)           | ` DynamicDataSource(ArgsCode, PropsCode` |
|                       | `GetDisplayName(...)`, `TestDataToParams(...)`                                      | Shifted to `TestDataFactory`, signature changed| `TestDataFactory.GetDisplayName(...)`, `TestDataToParams(...)` |
|                       | `OptionalToArgs(...)`, `WithOptionalArgsCode(...)`                                  | Cancelled / Refactored                         | - / `WithOptionalArgsCode<T>(...)` |
|                       | `TestDataToArgs<T...>`, `TestDataReturnsToArgs<T...>`, `TestDataThrowsToArgs<T...>` | Renamed, made `protected`, non-static          | `TestDataToParams<T...>`, `TestDataReturnsToParam<T...>`, `TestDataThrowsToParam<T...>` |

---

#### **Added**  

> This section lists newly introduced namespaces and types. For full details, see the [Types](#types) section.  
   
***New Types***  
    
- **`Statics`**
  - `enum PropsCode`  
    
- **`TestDataTypes`**
  - `static TestDataFactory`   
    
- **`DynamicDataSources`**
  
  *Base classes*  
  - `DynamicDataSource<TDataHolder>`  
  - `DynamicDataRowSource<TDataRowHolder, TRow>`  
  - `DynamicDataRowSource<TRow>`  
    
  *Specialized base classes*  
  - `DynamicObjectArraySource`  
  - `DynamicObjectArrayRowSource`  
  - `DynamicExpectedObjectArrayRowSource`
  - `DynamicNamedDataRowSource<TRow>`  
    
*- New namespaces -*  
    
- **`DataStrategyTypes.Interfaces`**
  - `IDataStrategy`  
    
- **`DataStrategyTypes`**
  - `sealed record DataStrategy`  
    
- **`TestDataRows.Interfaces`**
  - `ITestDataRow`, `ITestDataRow<TRow>`, `ITestDataRow<TRow, TTestData>`  
  - `INamedTestDataRow<TRow>`  
    
- **`TestDataRows`**  
    
  *Base classes*  
  - `TestDataRow<TRow>`  
  - `TestDataRow<TRow, TTestData>`  
    
  *Concrete implementation*  
  - `ObjectArrayRow<TTestData>`  
    
- **`DataRowHolders.Interfaces`**
  - `IDataRowHolder`, `IDataRowHolder<TRow>`, `IDataRowHolder<TRow, TTestData>`  
  - `ITestDataRowFactory<TRow, TTestData>`  
  - `IAddTestData<TTestData>`  
  - `ITestDataRows`
  - `IRows<TRow>`, `INamedRows<TRow>`  
  - `INamedDataRowHolder<TRow>`  
    
- **`DataRowHolders`**  
    
  *Base classes*  
  - `DataRowHolder<TRow>`  
  - `DataRowHolder<TRow, TTestData>`  
    
  *Specialized base class*  
  - `NamedDataRowHolder<TRow, TTestData>`  
    
  *Concrete implementation*  
  - `ObjectArrayRowHolder<TTestData>`  
  
---

#### **Version 2.0.6-beta** (2025-08-26)

- **Removed**:
  - `DataRowHolder<TRow>`: Constructors removed:
    - `private protected DataRowHolder(ITestData, IDataStrategy)`    
    - `private protected DataRowHolder(IDataRowHolder, IDataStrategy)`    
- **Changed**:
  - `DataRowHolder<TRow>`: Constructor `DataRowHolder(IDataStrategy)` made primary consructor.
  - `DataRowHolder<TRow, TTestData>`: constructors inherit from `DataRowHolder<TRow>` primary constructor.
- **Note**:
  - This update may break backward-compatibility with previous versions (low probability).

---

#### **Version 2.0.7-beta** (2025-09-02)

- **Removed**:
  - `DynamicDataSource<TDataHolder>`: Methods removed (shifted to `DynamicDataRowSource<TDataRowHolder>`):
    - `protected void Add<T1, T2, ..., T9>(string, string expected, T1?, T2?, ..., T9?)`,
    - `protected void AddReturns<TStruct, T1, T2, ..., T9>(string, string expected, T1?, T2?, ..., T9?)`,
    - `protected void AddThrows<TException, T1, T2, ..., T9>(string, string expected, T1?, T2?, ..., T9?)`,
    - `protected abstract void Add<TTestData>(TTestData)`,
    - `protected abstract void InitDataHolder<TTestData>(TTestData)`.
- **Added**:
  - `DynamicDataRowSource<TDataRowHolder>`: Methods added (shifted from `DynamicDataSource<TDataHolder>`):
    - `protected void Add<T1, T2, ..., T9>(string, string expected, T1?, T2?, ..., T9?)`,
    - `protected void AddReturns<TStruct, T1, T2, ..., T9>(string, string expected, T1?, T2?, ..., T9?)`,
    - `protected void AddThrows<TException, T1, T2, ..., T9>(string, string expected, T1?, T2?, ..., T9?)`,
    - `protected abstract void InitDataHolder<TTestData>(TTestData)`.
- **Changed**:
  - `DynamicDataRowSource<TDataRowHolder>`: :
    - `protected override void Add<TTestData>(TTestData)` made virtual.
- **Note**:
  - This update may break backward-compatibility with previous versions (low probability).

---

#### **Version 2.0.8-beta** (2025-09-04)

- **Added**:
  - `DynamicDataSource<TDataHolder>`:  
    - `protected abstract void Add<TTestData>(TTestData)`
- **Changed**:  
  - `DynamicDataRowSource<TDataRowHolder>`:  
    - `protected abstract void Add<TTestData>(TTestData)` made virtual.
- **Note**:
  - This update may break backward-compatibility with previous versions (low probability).

---

#### **Version 2.0.9-beta** (2025-09-18)

- **Added**:
  - `DynamicDataSources.DynamicExpectedObjectArraySource(ArgsCode argsCode) : DynamicObjectArraySource(argsCode, PropsCode.Expected)` abstract class added to simplify creating data sources without testcase name when using `ArgsCode.Properies`.  

---

#### **Version 2.0.10-beta** (2025-09-20)

- **Added**:
  - `TestDataRows.NamedTestDataRow<TRow, TTestData>` abstract class added.  

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
