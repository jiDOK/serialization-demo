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
        Color = new ColorData(color.r, color.g, color.b, color.a);
        Position = new Vector3Data(position.x, position.y, position.z);
        Scale = new Vector3Data(scale.x, scale.y, scale.z);
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

    public ColorData(float r, float g, float b, float a) : this()
    {
        R = r;
        G = g;
        B = b;
        A = a;
    }

    public Color ToColor()
    {
        return new Color(R, G, B, A);
    }
}

[System.Serializable]
public struct Vector3Data
{
    public Vector3Data(float x, float y, float z) : this()
    {
        X = x;
        Y = y;
        Z = z;
    }

    public float X { get; set; }
    public float Y { get; set; }
    public float Z { get; set; }

    public Vector3 ToVector3()
    {
        return new Vector3(X, Y, Z);
    }
}