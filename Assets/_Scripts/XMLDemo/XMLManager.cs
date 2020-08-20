using System.IO;
using System.Text;
using System.Xml.Serialization;
using UnityEngine;

public static class XMLManager
{
    public static Database Database { get; } = new Database();
    static XmlSerializer serializer = new XmlSerializer(typeof(Database));
    static string path = Application.dataPath + "/StreamingAssets/XML/";
    static string defaultFileName = "coloredCubeData";
    static string fileExtension = ".xml";

    public static Database LoadDatabase(string fileName)
    {
        fileName = fileName.Length > 0 ? fileName : defaultFileName;
        string fullPath = path + fileName + fileExtension;
        if (File.Exists(fullPath))
        {
            using (StreamReader stream = new StreamReader(fullPath))
            {
                return serializer.Deserialize(stream) as Database;
            }
        }
        else return null;
    }

    public static void SaveDatabase(string fileName)
    {
        fileName = fileName.Length > 0 ? fileName : defaultFileName;
        string fullPath = path + fileName + fileExtension;
        using (StreamWriter stream = new StreamWriter(fullPath, false, Encoding.UTF8))
        {
            serializer.Serialize(stream, Database);
        }
    }
}
