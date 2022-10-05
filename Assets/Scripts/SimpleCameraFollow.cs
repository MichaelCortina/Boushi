using System;
using UnityEngine;

public class SimpleCameraFollow : MonoBehaviour
{
    [SerializeField] private Collider2D cameraCollider;
    [SerializeField] private Collider2D mapCollider;
    [SerializeField] private Transform player;
    [SerializeField] private float cameraSpeed;
    [SerializeField] private KeyCode centerCamera;

    private InputHandler _inputHandler;
    private bool _centeringCamera;

    private void Update() => _inputHandler.HandleInput();
    
    private void FixedUpdate()
    {
                
        var cameraPosition = transform.position;
        var playerPosition = player.position;
        
        if (_centeringCamera)
            cameraPosition = Vector3.MoveTowards(cameraPosition, playerPosition, cameraSpeed);
        
        else if (!cameraCollider.bounds.Contains(new Vector3(playerPosition.x, playerPosition.y,
                         cameraCollider.transform.position.z)))
            cameraPosition = Vector3.MoveTowards(
                cameraPosition,
                playerPosition,
                Vector2.Distance(
                    playerPosition,
                    cameraCollider.ClosestPoint(playerPosition)));

        cameraPosition = mapCollider.bounds.ClosestPoint(cameraPosition);
        transform.position = new Vector3(cameraPosition.x, cameraPosition.y, transform.position.z);
        
        if (_centeringCamera)
            _centeringCamera = Math.Abs(cameraPosition.x - playerPosition.x) > 0.1 || Math.Abs(cameraPosition.y - playerPosition.y) > 0.1;
    }

    private void Awake() =>
        _inputHandler = new InputHandler()
            .SetClickEvent(centerCamera, CenterCamera);

    private void CenterCamera() => _centeringCamera = true;
}