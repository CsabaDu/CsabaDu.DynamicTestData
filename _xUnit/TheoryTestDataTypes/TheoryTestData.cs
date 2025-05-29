// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

using System.Diagnostics.CodeAnalysis;

namespace CsabaDu.DynamicTestData.xUnit.TheoryTestDataTypes
{
    public class TheoryTestData : TheoryData, IProperties
    {
        public TheoryTestData(Type[] types, object?[] args)
        {
            Types = types
                ?? throw new ArgumentNullException(nameof(types));
            AddRow(args);
        }

        public void Add(Type[] types, object?[] args)
        {
            if (Equals(types))
            {
                AddRow(args);
                return;
            }

            throw new ArgumentException(
                "Types do not match.", nameof(types));
        }

        public Type[] Types { get; init; }

        public bool Equals(Type[]? other)
        => other?.SequenceEqual(Types) == true;
    }

    public class TheoryTestData<TTestData>
    : TheoryData, IInstance
    where TTestData : ITestData
    {
        public TheoryTestData(TTestData testData)
        => AddTestData(testData);

        public void AddTestData(ITestData testData)
        {
            if (testData is TTestData typedTestData)
            {
                AddRow(typedTestData);
                return;
            }

            throw new ArgumentException(
                "Type does not match.", nameof(testData));
        }

        //public Type Type => typeof(TTestData);

        //public bool Equals(Type? other)
        //=> other == Type;
    }
}

