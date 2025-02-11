namespace CsabaDu.DynamicTestData.TestDataSerializers;

public class TestDataSerializerXml : ITestDataSerializer
{
    public void Serialize(string fileName, TestData testData, FileFormatCode fileFormatCode = FileFormatCode.Xml)
    {
        if (fileFormatCode == FileFormatCode.Xml)
        {
            XmlSerializer serializer = new(typeof(TestData));
            using TextWriter writer = new StreamWriter(fileName);
            serializer.Serialize(writer, testData);
        }
        else
        {
            throw new InvalidDataException("Unsupported file format for XML serializer.");
        }
    }

    public TestData Deserialize(string fileName)
    {
        var fileFormatCode = FileFormatDetector.GetDetectedFileFormatCode(fileName, out string content);

        if (fileFormatCode == FileFormatCode.Xml)
        {
            return DeserializeContent(fileFormatCode, content)!;
        }

        throw new InvalidDataException("Unsupported file format for XML deserializer.");
    }

    public TestData? DeserializeContent(FileFormatCode fileFormatCode, string content)
    {
        return fileFormatCode == FileFormatCode.Xml ? deserialize() : null;

        TestData deserialize()
        {
            XmlSerializer serializer = new(typeof(TestData));
            using TextReader reader = new StringReader(content);
            return (TestData)serializer.Deserialize(reader)!;

        }
    }
}
