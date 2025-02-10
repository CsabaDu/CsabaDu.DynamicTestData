using Xunit.Abstractions;

namespace CsabaDu.DynamicTestData.SampleCodes.xUnitSamples;

public abstract record TestDataXunitSerializable : IXunitSerializable
{
    public TestDataXunitSerializable()
    {
    }
        
    public void Serialize(IXunitSerializationInfo info)
    {
        var properties = GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach (var property in properties)
        {
            var value = property.GetValue(this);
            info.AddValue(property.Name, value);
        }
    }

    public void Deserialize(IXunitSerializationInfo info)
    {
        var properties = GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach (var property in properties)
        {
            var value = info.GetValue(property.Name, property.PropertyType);
            property.SetValue(this, value);
        }
    }
}
