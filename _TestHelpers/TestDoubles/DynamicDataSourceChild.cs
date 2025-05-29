// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.TestHelpers.TestDoubles;

public class DynamicDataSourceChild(ArgsCode argsCode)
: DynamicDataSource(argsCode)
{
    public ArgsCode GetArgsCode()
    => ArgsCode;

    public static T TestWithOptionalArgsCode<TDataSource, T>(
        [NotNull] TDataSource dataSource,
        [NotNull] Func<T> testDataGenerator,
        ArgsCode? argsCode)
    where TDataSource : DynamicDataSource
    where T : notnull
    => WithOptionalArgsCode(dataSource, testDataGenerator, argsCode);

    public static void TestWithOptionalArgsCode<TDataSource>(
        [NotNull] TDataSource dataSource,
        [NotNull] Action testDataProcessor,
        ArgsCode? argsCode)
    where TDataSource : DynamicDataSource
    => WithOptionalArgsCode(dataSource, testDataProcessor, argsCode);
}