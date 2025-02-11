namespace CsabaDu.DynamicTestData.TestDataSerializers.Interfaces;

public interface ITestDataSerializer
{
    void Serialize(string fileName, TestData testData, FileFormatCode fileFormatCode);
    TestData Deserialize(string fileName);
    TestData? DeserializeContent(FileFormatCode fileFormatCode, string content);
}

