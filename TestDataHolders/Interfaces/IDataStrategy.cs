// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.TestDataHolders.Interfaces;
public interface IDataStrategy : IArgsCode, IEquatable<IDataStrategy>
{
    ///// <summary>
    ///// Gets the code representing how to convert the 'TestData' records to arguments.
    ///// </summary>
    //ArgsCode ArgsCode { get; }

    /// <summary>
    /// Gets a value indicating whether the test parameters object array shall contain the expected result element.
    /// </summary>
    bool? WithExpected { get; }
}
