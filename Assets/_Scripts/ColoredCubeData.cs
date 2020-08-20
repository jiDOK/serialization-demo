using UnityEngine;

[System.Serializable]
public class ColoredCubeData
{
    public ColorData Color;
    public Vector3Data Position;
    public Vector3Data Scale;
    public string Name;

    public ColoredCubeData(Color color, Vector3 position, Vector3 scale, string name)
    {
        Color = new ColorData(color);
        Position = new Vector3Data(position);
        Scale = new Vector3Data(scale);
        Name = name;
    }

    public ColoredCubeData() { }
}

[System.Serializable]
public struct ColorData
{
    public float R { get; set; }
    public float G { get; set; }
    public float B { get; set; }
    public float A { get; set; }

    public ColorData(Color color)
    {
        R = color.r;
        G = color.g;
        B = color.b;
        A = color.a;
    }

    public Color ToColor()
    {
        return new Color(R, G, B, A);
    }
}

[System.Serializable]
public struct Vector3Data
{
    public Vector3Data(Vector3 vector3)
    {
        X = vector3.x;
        Y = vector3.y;
        Z = vector3.z;
    }

    public float X { get; set; }
    public float Y { get; set; }
    public float Z { get; set; }

    public Vector3 ToVector3()
    {
        return new Vector3(X, Y, Z);
    }
}