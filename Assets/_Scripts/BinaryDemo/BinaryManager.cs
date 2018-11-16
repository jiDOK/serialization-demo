using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class BinaryManager
{
    public static Database Database { get; } = new Database();
    static BinaryFormatter formatter = new BinaryFormatter();
    static string path = Application.dataPath + "/StreamingAssets/XML/coloredCubeData.sav";

    public static Database LoadDatabase()
    {
        if (File.Exists(path))
        {
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                return formatter.Deserialize(stream) as Database;
            }
        }
        else return null;
    }

    public static void SaveDatabase()
    {
        using (FileStream stream = new FileStream(path, FileMode.Create))
        {
            formatter.Serialize(stream, Database);
        }
    }
}
