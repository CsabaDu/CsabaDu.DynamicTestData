using System.Text.Json;

namespace CsabaDu.DynamicTestData.TestDataSerializers;

public class TestDataSerializerJSon : ITestDataSerializer
{
    public void Serialize(string fileName, TestData testData, FileFormatCode fileFormatCode = FileFormatCode.Json)
    {
        if (fileFormatCode == FileFormatCode.Json)
        {
            string json = JsonSerializer.Serialize(testData);
            File.WriteAllText(fileName, json);
        }
        else
        {
            throw new InvalidDataException("Unsupported file format for JSON serializer.");
        }
    }

    public TestData Deserialize(string fileName)
    {
        var fileFormatCode = FileFormatDetector.GetDetectedFileFormatCode(fileName, out string content);

        if (fileFormatCode == FileFormatCode.Json)
        {
            return DeserializeContent(fileFormatCode, content) ?? throw new InvalidOperationException("JSON deserializing returned null");
        }

        throw new InvalidDataException("Unsupported file format for JSON deserializer.");
    }

    public TestData? DeserializeContent(FileFormatCode fileFormatCode, string content)
    {
        return fileFormatCode == FileFormatCode.Xml ? JsonSerializer.Deserialize<TestData>(content) : null;
    }
}
