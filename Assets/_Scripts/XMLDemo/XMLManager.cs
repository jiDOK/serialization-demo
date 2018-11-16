using System.IO;
using System.Text;
using System.Xml.Serialization;
using UnityEngine;

public static class XMLManager
{
    public static Database Database { get; } = new Database();
    static XmlSerializer serializer = new XmlSerializer(typeof(Database));
    static string path = Application.dataPath + "/StreamingAssets/XML/coloredCubeData.xml";

    public static Database LoadDatabase()
    {
        if (File.Exists(path))
        {
            using (StreamReader stream = new StreamReader(path))
            {
                return serializer.Deserialize(stream) as Database;
            }
        }
        else return null;
    }

    public static void SaveDatabase()
    {
        using (StreamWriter stream = new StreamWriter(path, false, Encoding.UTF8))
        {
            serializer.Serialize(stream, Database);
        }
    }
}
