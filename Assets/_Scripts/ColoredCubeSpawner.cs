using System.Collections.Generic;
using UnityEngine;

public class ColoredCubeSpawner : MonoBehaviour
{
    ColoredCubeManager manager;

    void Awake()
    {
        manager = GetComponent<ColoredCubeManager>();
    }

    public void SpawnCubes(List<ColoredCubeData> datas)
    {
        for (int i = 0; i < datas.Count; i++)
        {
            GameObject cubeGO = GameObject.CreatePrimitive(PrimitiveType.Cube);
            var coloredCube = cubeGO.AddComponent<ColoredCube>();
            coloredCube.transform.parent = transform;
            coloredCube.Data = datas[i];
            coloredCube.Init();
        }
    }

}

