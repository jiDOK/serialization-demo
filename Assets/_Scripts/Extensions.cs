using System.Reflection;
using UnityEngine;

public static class Extensions
{

    public static T AddComponent<T>(this GameObject game, T duplicate) where T : Component
    {
        T target = game.AddComponent<T>();
        foreach (PropertyInfo x in typeof(T).GetProperties())
            if (x.CanWrite)
                x.SetValue(target, x.GetValue(duplicate));
        return target;
    }
}
