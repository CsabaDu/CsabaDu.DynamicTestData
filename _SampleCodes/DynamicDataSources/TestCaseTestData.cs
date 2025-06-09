using CsabaDu.DynamicTestData.NUnit.Statics;
using CsabaDu.DynamicTestData.TestDataHolders;
using CsabaDu.DynamicTestData.TestDataHolders.Interfaces;
using NUnit.Framework;
using NUnit.Framework.Internal;
using static CsabaDu.DynamicTestData.DynamicDataSources.DynamicDataSourceBase;

namespace CsabaDu.DynamicTestData.SampleCodes.DynamicDataSources
{
    public abstract class TestCaseTestData : TestCaseData, ITestDataRow<TestCaseData>
    {
        private protected TestCaseTestData(
            ITestData testData,
        ArgsCode argsCode)
        : base(TestDataToParams(
            testData,
            argsCode,
            testData.IsTestDataReturns(
                out ITestDataReturns? testDataReturns),
            out string testCaseName))
        {
            TestCaseName = testCaseName;
            Properties.Set(PropertyNames.Description, TestCaseName);

            bool isReturns = testDataReturns != null;
            DataStrategy = new DataStrategy(argsCode, isReturns);

            if (isReturns)
            {
                ExpectedResult = testDataReturns!.GetExpected();
            }
        }

        public IDataStrategy DataStrategy { get; init; }

        public string TestCaseName { get; init; }

        public abstract TestCaseData Convert();

        public bool Equals(ITestCaseName? other)
        => other?.TestCaseName == TestCaseName;

        public override bool Equals(object? obj)
        => obj is ITestCaseName other
            && Equals(other);

        public override int GetHashCode()
        =>TestCaseName.GetHashCode();

        public string? GetDisplayName(string? testMethodName)
        => DynamicDataSourceBase.GetDisplayName(testMethodName, TestCaseName);
    }

    public sealed class TestCaseTestData<TTestData>
    : TestCaseTestData, ITestDataRow<TTestData, TestCaseData>
    where TTestData : notnull, ITestData
    {
        internal TestCaseTestData(
            TTestData testData,
            ArgsCode argsCode)
        : base(
            testData,
            argsCode)
        {
            TestData = testData;

            if (argsCode == ArgsCode.Properties)
            {
                Type[] genericTypes =
                    typeof(TTestData).GetGenericArguments();

                TypeArgs = HasExpectedResult ?
                    genericTypes[1..]
                    : genericTypes;
            }
        }

        internal TestCaseTestData(
            TTestData testData,
            ArgsCode argsCode,
            string? testMethodName)
        : this(
            testData,
            argsCode)
        => TestName = GetDisplayName(testMethodName);

        public TTestData TestData { get; init; }

        public override TestCaseData Convert()
        => this;

        public ITestDataRow<TTestData, TestCaseData> CreateTestDataRow(
            IDataStrategy dataStrategy,
            TTestData testData)
        => new TestCaseTestData<TTestData>(
            testData,
            dataStrategy.ArgsCode);
    }
}
