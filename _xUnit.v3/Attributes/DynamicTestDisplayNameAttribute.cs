/*
 * MIT License
 * 
 * Copyright (c) 2025. Csaba Dudas (CsabaDu)
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */
namespace CsabaDu.DynamicTestData.xUnit.v3.Attributes;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public sealed class DynamicTestDisplayNameAttribute(string dataSourceMemberName) : DataAttribute
{
    private readonly string _dataSourceMemberName = dataSourceMemberName;

    internal const string TestMethodHasNoDeclaringTypeMessage
        = "Test method has no declaring type";

    internal static string GetDataSourceNullOrInvalidTypeMessage(object? data)
    => $"Data source must return IEnumerable<TheoryTestDataRow>. " +
        $"Actual type: {data?.GetType().Name ?? "null"}";

    internal string GetDataSourceMemberNotFoundMesssage(Type declaringType)
    => $"Data source member '{_dataSourceMemberName}' not found " +
        $"in type {declaringType.Name}. " +
        $"Expected a static method or property.";

    public override bool SupportsDiscoveryEnumeration() => true;

    public override ValueTask<IReadOnlyCollection<ITheoryDataRow>> GetData(
        MethodInfo testMethod,
        DisposalTracker disposalTracker)
    {
        Type? declaringType = testMethod.DeclaringType
            ?? throw new InvalidOperationException(TestMethodHasNoDeclaringTypeMessage);
        MethodInfo? getDataSourceMethod = FindDataSourceMethod(declaringType)
            ?? throw new ArgumentException(GetDataSourceMemberNotFoundMesssage(declaringType));
        object? data = getDataSourceMethod.Invoke(null, null);
        var namedDataRowList = GetNamedDataRowList(data, testMethod);

        return new ValueTask<IReadOnlyCollection<ITheoryDataRow>>(namedDataRowList);
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

    private static List<TheoryTestDataRow> GetNamedDataRowList(object? data, MethodInfo testMethod)
    {
        if (data is not IEnumerable<TheoryTestDataRow> dataRowList)
        {
            throw new ArgumentException(GetDataSourceNullOrInvalidTypeMessage(data));
        }

        var namedDataRowList = new List<TheoryTestDataRow>();

        foreach (TheoryTestDataRow? item in dataRowList)
        {
            var testData = item.TestData;
            string displayName = GetDisplayName(testMethod.Name, testData.TestCase);
            var namedDataRow = new TheoryTestDataRow(testData, item.ArgsCode)
            {
                TestDisplayName = displayName,
            };

            namedDataRowList.Add(namedDataRow);
        }

        return namedDataRowList;
    }
}
