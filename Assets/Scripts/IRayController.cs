using System;
using UnityEngine;

public interface IRayController
{
    void OnRayHit(LightRay ray, Vector2 contactPoint, Vector2 direction);
}