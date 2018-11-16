using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

[System.Serializable]
public class Database
{
    [XmlArray(ElementName = "Data_of_Colored_Cubes")]
    public List<ColoredCubeData> coloredCubeDatas = new List<ColoredCubeData>();
}
