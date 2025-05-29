// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.xUnit.TheoryTestDataTypes.Interfaces;

public interface IProperties : ITheoryTestData, IEquatable<Type[]>
{
    Type[] Types { get; }

    void Add(Type[] types, object?[] args);
}
