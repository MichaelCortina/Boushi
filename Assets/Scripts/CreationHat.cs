using System;
using UnityEngine;

public class CreationHat : MonoBehaviour
{
    [SerializeField] private KeyCode key;
    [SerializeField] private GameObject toCreate;
    [SerializeField] private float createRadius;

    private InputHandler _inputHandler;
    private Camera _mainCamera;

    private void Update() => _inputHandler.HandleInput();
    
    private void PlaceObject()
    { 
        Vector2 mouseWorldPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        var distance = Vector2.Distance(mouseWorldPosition, transform.position);
        
        if (distance > createRadius) return;

        toCreate.transform.position = mouseWorldPosition;
        toCreate.SetActive(true);
    }
    
    private void Awake()
    {
        _mainCamera = Camera.main;
        _inputHandler = new InputHandler()
            .SetClickEvent(key, PlaceObject);
    }
}