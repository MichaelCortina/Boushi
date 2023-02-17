using UnityEngine;

public static class VectorExtensions
{
    public static Vector3 Extend(this Vector2 vec, float z) => new(vec.x, vec.y, z);

    public static Vector2 Set(this Vector2 vec, float x = float.NaN, float y = float.NaN)
    {
        vec.x = float.IsNaN(x) ? vec.x : x;
        vec.y = float.IsNaN(y) ? vec.y : y;
        return vec;
    }
    
    public static Vector3 Set(this Vector3 vec, float x = float.NaN, float y = float.NaN, float z = float.NaN)
    {
        vec.x = float.IsNaN(x) ? vec.x : x;
        vec.y = float.IsNaN(y) ? vec.y : y;
        vec.z = float.IsNaN(z) ? vec.z : z;
        return vec;
    }
    
    

    public static void Deconstruct(this Vector3 vec, out float x, out float y, out float z) =>
        (x, y, z) = (vec.x, vec.y, vec.z);
    
    public static void Deconstruct(this Vector2 vec, out float x, out float y) =>
        (x, y) = (vec.x, vec.y);
}