using System.Collections.Generic;
using UnityEngine;

public class ColoredCubeManager : MonoBehaviour
{
    public SpawnMode spawnMode { get; private set; }
    public SaveMode saveMode { get; private set; }
    [SerializeField] int numberOfRandomCubes;
    string path;
    List<ColoredCubeData> datas = new List<ColoredCubeData>();

    public void SetSpawnMode(int mode)
    {
        spawnMode = (SpawnMode)mode;
    }

    public void SetSaveMode(int mode)
    {
        saveMode = (SaveMode)mode;
    }

    public void Spawn()
    {
        if (spawnMode == SpawnMode.Random)
        {
            datas = Utils.GetRandomDatas(numberOfRandomCubes);
        }
        else
        {
            datas = LoadColoredCubes();
        }

        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        var spawner = GetComponent<ColoredCubeSpawner>();
        spawner.SpawnCubes(datas);
    }

    public List<ColoredCubeData> LoadColoredCubes()
    {
        switch (spawnMode)
        {
            case SpawnMode.XML:
                return XMLManager.LoadDatabase().coloredCubeDatas;
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
                XMLManager.SaveDatabase();
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
