namespace CsabaDu.DynamicTestData.xUnit.v3.Attributes;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public sealed class DynamicTestDisplayNameAttribute(string dataSourceMemberName) : DataAttribute
{
    private readonly string _dataSourceMemberName = dataSourceMemberName;

    internal const string TestMethodHasNoDeclaringTypeMessage = "Test method has no declaring type";

    internal static string GetDataSourceNullOrInvalidTypeMessage(object? data)
    => $"Data source must return IEnumerable<TheoryTestDataRow>. " +
        $"Actual type: {data?.GetType().Name ?? "null"}";

    internal string GetDataSourceMemberNotFoundMesssage(Type declaringType)
    => $"Data source member '{_dataSourceMemberName}' not found in type {declaringType.Name}. " +
        $"Expected a static method or property.";

    public override bool SupportsDiscoveryEnumeration() => true;

    public override ValueTask<IReadOnlyCollection<ITheoryDataRow>> GetData(MethodInfo testMethod, DisposalTracker disposalTracker)
    {
        Type? declaringType = testMethod.DeclaringType
            ?? throw new InvalidOperationException(TestMethodHasNoDeclaringTypeMessage);
        MethodInfo? getDataSourceMethod = FindDataSourceMethod(declaringType)
            ?? throw new ArgumentException(GetDataSourceMemberNotFoundMesssage(declaringType));
        object? data = getDataSourceMethod.Invoke(null, null);
        var dataRowList = GetTheoryTestDataRowList(data, testMethod);

        return new ValueTask<IReadOnlyCollection<ITheoryDataRow>>(dataRowList);
    }

    private MethodInfo? FindDataSourceMethod(Type declaringType)
    {
        const BindingFlags flags
            = BindingFlags.Static
            | BindingFlags.Public
            | BindingFlags.NonPublic;

        return declaringType.GetMethod(_dataSourceMemberName, flags)
            ?? declaringType.GetProperty(_dataSourceMemberName, flags)?.GetMethod;
    }

    private static List<TheoryTestDataRow> GetTheoryTestDataRowList(object? data, MethodInfo testMethod)
    {
        if (data is not IEnumerable<TheoryTestDataRow> rowList)
        {
            throw new ArgumentException(GetDataSourceNullOrInvalidTypeMessage(data));
        }

        var dataRowList = new List<TheoryTestDataRow>();

        foreach (var row in rowList)
        {
            var testData = row.TestData;
            string displayName = GetDisplayName(testMethod.Name, testData.TestCase);
            var dataRow = new TheoryTestDataRow(testData, row.ArgsCode)
            {
                TestDisplayName = displayName,
            };

            dataRowList.Add(dataRow);
        }

        return dataRowList;
    }
}
