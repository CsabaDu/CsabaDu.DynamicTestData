// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

using CsabaDu.DynamicTestData.DynamicDataSources;

namespace CsabaDu.DynamicTestData.TestHelpers.TestDoubles;

public class DynamicDataSourceBaseChild(ArgsCode argsCode)
: DynamicDataSourceBase(argsCode)
{
    public override bool? WithExpected { get; init; } = null;

    public ArgsCode GetArgsCode()
    => ArgsCode;

    public static T TestWithOptionalArgsCode<TDataSource, T>(
        [NotNull] TDataSource dataSource,
        [NotNull] Func<T> testDataGenerator,
        ArgsCode? argsCode)
    where TDataSource : DynamicDataSourceBase
    where T : notnull
    => WithOptionalArgsCode(dataSource, testDataGenerator, argsCode);

    //public static void TestWithOptionalArgsCode<TDataSource>(
    //    [NotNull] TDataSource dataSource,
    //    [NotNull] Action testDataProcessor,
    //    ArgsCode? argsCode)
    //where TDataSource : DynamicDataSourceBase
    //=> WithOptionalArgsCode(dataSource, testDataProcessor, argsCode);
}
