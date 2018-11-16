using UnityEngine;

public class ColoredCube : MonoBehaviour
{
    public ColoredCubeData Data;

    public void Init()
    {
        GetComponent<Renderer>().material.color = Data.Color.ToColor();
        transform.localPosition = Data.Position.ToVector3();
        transform.localScale = Data.Scale.ToVector3();
        gameObject.name = Data.Name;
    }
}
