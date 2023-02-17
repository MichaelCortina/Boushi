using UnityEngine;

public static class BoundsExtensions
{
    public static Vector3[] EdgePoints(this Bounds bounds)
    {
        return new []
        {
            bounds.max,
            new(bounds.center.x + bounds.extents.x, bounds.center.y - bounds.extents.y),
            new(bounds.center.x - bounds.extents.x, bounds.center.y + bounds.extents.y),
            bounds.min
        };
    }
}