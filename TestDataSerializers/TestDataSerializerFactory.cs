namespace CsabaDu.DynamicTestData.TestDataSerializers;

public class TestDataSerializerFactory
{
    public ITestDataSerializer GetSerializer(FileFormatCode fileFormatCode)
    {
        return fileFormatCode switch
        {
            FileFormatCode.Json => new TestDataSerializerJSon(),
            FileFormatCode.Xml => new TestDataSerializerXml(),
            _ => throw new InvalidEnumArgumentException(nameof(fileFormatCode), (int)(object)fileFormatCode, typeof(FileFormatCode))
        };
    }
}

