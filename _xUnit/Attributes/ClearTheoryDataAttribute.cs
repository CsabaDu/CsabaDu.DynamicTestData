using System.Reflection;
using Xunit.Sdk;

namespace CsabaDu.DynamicTestData.xUnit.Attributes;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public class ClearTheoryDataAttribute : BeforeAfterTestAttribute
{
    public override void Before(MethodInfo methodUnderTest)
    {
        var theoryDataProperty = methodUnderTest?.DeclaringType?.GetProperty("TheoryData");

        if (theoryDataProperty != null && theoryDataProperty.CanWrite)
        {
            theoryDataProperty.SetValue(null, null);
        }
    }
}