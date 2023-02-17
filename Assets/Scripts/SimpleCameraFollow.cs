using System;
using UnityEngine;

public class SimpleCameraFollow : MonoBehaviour
{
    [SerializeField] private Collider2D mapCollider;
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 cameraVelocity;
    [SerializeField] private float smoothTime = 0.3f;

    private void FixedUpdate()
    {
        var cameraPosition = transform.position;
        var playerPosition = player.position;
        
        // move camera smoothly towards player
        cameraPosition = Vector3.SmoothDamp(cameraPosition, playerPosition, ref cameraVelocity, smoothTime);
        
        // clamp position within the map boundaries
        cameraPosition = mapCollider.bounds.ClosestPoint(cameraPosition);
        
        // set camera position while maintaining z axis
        transform.position = cameraPosition.Set(z: transform.position.z);
    }
}