using UnityEngine;

public class Mirror : MonoBehaviour, IRayController
{
    [SerializeField] [Range(0f, 360f)] private float angle;

    public void OnRayHit(LightRay ray, Vector2 contactPoint, Vector2 direction)
    {
        // multiply the direction of the ray by the rotation matrix with theta = angle in radians
        float radians = (angle * Mathf.PI) / 180;
        float x = direction.x * Mathf.Cos(radians) - direction.y * Mathf.Sin(radians);
        float y = direction.x * Mathf.Sin(radians) + direction.y * Mathf.Cos(radians);

        // then change the direction to the new rotated direction and cast the ray again
        direction = new Vector2(x, y);

        ray.CastRay(contactPoint, direction);
    }
}