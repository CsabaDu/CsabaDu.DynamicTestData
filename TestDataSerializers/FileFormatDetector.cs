using System.Text.Json;
using System.Xml;

namespace CsabaDu.DynamicTestData.TestDataSerializers;

public static class FileFormatDetector
{
    public static FileFormatCode GetDetectedFileFormatCode(string fileName, out string content)
    {
        content = File.ReadAllText(fileName).Trim();

        if (IsJson(content))
        {
            return FileFormatCode.Json;
        }

        if (IsXml(content))
        {
            return FileFormatCode.Xml;
        }

        throw new InvalidDataException("Unsupported or invalid file format.");
    }

    private static bool IsJson(string content)
    {
        try
        {
            _ = JsonDocument.Parse(content);
            return true;
        }
        catch
        {
            return false;
        }
    }

    private static bool IsXml(string content)
    {
        try
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(content);
            return true;
        }
        catch
        {
            return false;
        }
    }
}

