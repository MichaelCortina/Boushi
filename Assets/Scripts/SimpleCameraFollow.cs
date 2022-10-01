using System;
using UnityEngine;

public class SimpleCameraFollow : MonoBehaviour
{
    [SerializeField] private PolygonCollider2D cameraBounds;
    [SerializeField] private Transform player;

    private void Update()
    {
        var closestPoint = cameraBounds.ClosestPoint(player.position);
        transform.position = new Vector3(closestPoint.x, closestPoint.y, transform.position.z);
    }
}