using System.Collections.Generic;
using System.Text;
using UnityEngine;

public static class Utils
{
    public static List<ColoredCubeData> GetRandomDatas(int count)
    {
        var cubeDataList = new List<ColoredCubeData>(count);
        for (int i = 0; i < count; i++)
        {
            cubeDataList.Add(new ColoredCubeData(GetRandomColor(), GetRandomVector3(3f, false), GetRandomVector3(1.5f, true), GetRandomString(5)));
        }
        return cubeDataList;
    }

    public static Color GetRandomColor()
    {
        return Random.ColorHSV(0f, 1f, 0.7f, 1f, 0.75f, 0.9f);
    }

    public static Vector3 GetRandomVector3(float range, bool onlyPositive)
    {
        if (onlyPositive)
        {
            return ((Random.insideUnitSphere / 2) + Vector3.one) * range;
        }
        else
        {
            return Random.insideUnitSphere * range;
        }
    }

    public static string GetRandomString(int length)
    {
        const string pool = "abcdefghijklmnopqrstuvwxyz";
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < length; i++)
        {
            char c = pool[Random.Range(0, pool.Length)];
            sb.Append(c);
        }
        return sb.ToString();
    }
}
