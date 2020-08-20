using System.Collections.Generic;
using UnityEngine;

public class ColoredCubeManager : MonoBehaviour
{
    public SpawnMode spawnMode { get; private set; }
    public SaveMode saveMode { get; private set; }
    [SerializeField] int numberOfRandomCubes;
    public string fileName;
    List<ColoredCubeData> datas = new List<ColoredCubeData>();

    public void SetSpawnMode(int mode)
    {
        spawnMode = (SpawnMode)mode;
    }

    public void SetSaveMode(int mode)
    {
        saveMode = (SaveMode)mode;
    }

    public void SetFilename(string fileName)
    {
        this.fileName = fileName;
    }

    public void Spawn()
    {
        if (spawnMode == SpawnMode.Random)
        {
            datas = Utils.GetRandomDatas(numberOfRandomCubes);
        }
        else
        {
            datas = LoadColoredCubes(fileName);
        }

        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < datas.Count; i++)
        {
            GameObject cubeGO = GameObject.CreatePrimitive(PrimitiveType.Cube);
            var coloredCube = cubeGO.AddComponent<ColoredCube>();
            coloredCube.transform.parent = transform;
            coloredCube.Data = datas[i];
            coloredCube.Init();
        }
    }

    public List<ColoredCubeData> LoadColoredCubes(string fileName)
    {
        switch (spawnMode)
        {
            case SpawnMode.XML:
                return XMLManager.LoadDatabase(fileName).coloredCubeDatas;

            case SpawnMode.Binary:
                return BinaryManager.LoadDatabase().coloredCubeDatas;
            default:
                return null;
        }
    }

    public void SaveColoredCubes()
    {
        datas.Clear();
        foreach (Transform child in transform)
        {
            datas.Add(child.GetComponent<ColoredCube>().Data);
        }
        switch (saveMode)
        {
            case SaveMode.XML:
                XMLManager.Database.coloredCubeDatas = datas;
                XMLManager.SaveDatabase(fileName);
                break;
            case SaveMode.Binary:
                BinaryManager.Database.coloredCubeDatas = datas;
                BinaryManager.SaveDatabase();
                break;
            default:
                break;
        }
    }
}
