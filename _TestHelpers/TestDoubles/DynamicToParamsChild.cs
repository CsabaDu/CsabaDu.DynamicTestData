// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.TestHelpers.TestDoubles;

public sealed class DynamicToParamsChild(ArgsCode argsCode, bool? withExpected = null) : DynamicParams(argsCode)
{
    public override bool? WithExpected { get; init; } = withExpected;

    public T TestWithOptionalArgsCode<TDataSource, T>(
        [NotNull] TDataSource dataSource,
        [NotNull] Func<T> testDataGenerator,
        ArgsCode? argsCode)
    where TDataSource : DynamicDataSourceBase
    where T : notnull
    => WithOptionalArgsCode(dataSource, testDataGenerator, argsCode);
}