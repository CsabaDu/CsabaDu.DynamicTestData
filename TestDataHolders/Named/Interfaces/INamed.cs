// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

using CsabaDu.DynamicTestData.TestDataHolders.Interfaces;

namespace CsabaDu.DynamicTestData.TestDataHolders.Named.Interfaces
{
    //public interface INamed;

    public interface INamedTestDataRow<TRow>
    : ITestDataRow<TRow>
    {
        TRow Convert(string? testMethodName);
    }

    public interface INamedRows<TRow>
    {
        IEnumerable<TRow>? GetNamedRows(string? testMethodName);
        IEnumerable<TRow>? GetNamedRows(string? testMethodName, ArgsCode? argsCode);
    }

    public interface INamedDataRowHolder<TRow>
    : IDataRowHolder<TRow>, INamedRows<TRow>;

    //public interface INamedDataRowHolder<TTestData, TRow>
    //: INamedDataRowHolder<TRow>,
    //ICreateTestDataRow<TTestData, TRow>
    //where TTestData : notnull, ITestData;

    //public interface INamedDataRowHolder<TTestData, TRow>
    //: INamedDataRowHolder<TRow>,
    //ICreateTestDataRow<TTestData, TRow>
    //where TTestData : notnull, ITestData;

    //public interface INamedDataRowHolder<TRow>
    //: INamedDataRowHolder<TRow>
    //{
    //}

    //public interface ICreateNamedTestDataRow<TTestData, TRow>
    //where TTestData : notnull, ITestData
    //{
    //    INamedTestDataRow<TTestData, TRow> CreateTestDataRow(
    //        TTestData testData,
    //        IDataStrategy dataStrategy,
    //        string? testMethodName);
    //}
}
