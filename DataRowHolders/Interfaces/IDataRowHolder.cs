// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.DataRowHolders.Interfaces;

/// <summary>
/// Represents a holder for data rows, providing access to the associated data strategy.
/// </summary>
/// <remarks>This interface extends <see cref="ITestDataRows"/> and provides a mechanism to retrieve the <see
/// cref="IDataStrategy"/> used for managing or interacting with the data rows.</remarks>
public interface IDataRowHolder
: ITestDataRows
{
    IDataStrategy DataStrategy { get; }
}

/// <summary>
/// Represents a holder for data rows of a specific type, providing functionality to retrieve and manage rows using a
/// specified data strategy.
/// </summary>
/// <typeparam name="TRow">The type of the data rows managed by this holder.</typeparam>
public interface IDataRowHolder<TRow>
: IDataRowHolder,
ITestDataType,
IRows<TRow>
{
    IDataRowHolder<TRow> GetDataRowHolder(IDataStrategy dataStrategy);
}

/// <summary>
/// Represents a collection of test data rows, providing functionality to manage and access rows of type <typeparamref
/// name="TRow"/> associated with test data of type <typeparamref name="TTestData"/>.
/// </summary>
/// <remarks>This interface extends <see cref="IReadOnlyCollection{T}"/> to provide read-only access to the
/// collection of test data rows, and also includes methods for adding new rows and accessing strongly-typed test data
/// rows.</remarks>
/// <typeparam name="TRow">The type of the data row contained in the collection.</typeparam>
/// <typeparam name="TTestData">The type of the test data associated with each data row. Must implement <see cref="ITestData"/> and cannot be null.</typeparam>
public interface IDataRowHolder<TRow, TTestData>
: IReadOnlyCollection<ITestDataRow>,
IDataRowHolder<TRow>,
ITypedTestDataRow<TRow, TTestData>
where TTestData : notnull, ITestData
{
    void Add(ITestDataRow<TRow, TTestData> testDataRow);
}
