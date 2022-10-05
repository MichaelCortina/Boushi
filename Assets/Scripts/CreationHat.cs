using Unity.VisualScripting;
using UnityEngine;

public class CreationHat : MonoBehaviour
{
    [SerializeField] private KeyCode key;
    [SerializeField] private GameObject toCreate;
    [SerializeField] private float createRadius;

    private InputHandler _inputHandler;
    private Camera _mainCamera;
    private SpriteRenderer _renderer; // for testing purposes
    private Color _startingColor; // for testing

    private void Update() => _inputHandler.HandleInput();
    
    private void PlaceObject()
    {
        _renderer.color = _startingColor; // for testing
        Vector2 mouseWorldPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        var distance = Vector2.Distance(mouseWorldPosition, transform.position);
        // calculate distance between mouse and player, if this is further than
        // the create radius exit the method
        if (distance > createRadius) return;

        toCreate.transform.position = mouseWorldPosition;
        toCreate.SetActive(true);
    }
    
    private void ShowCreationRadius()
    {
        _renderer.color = Color.magenta; // for testing
    }

    private void Awake()
    {
        _mainCamera = Camera.main;
        _renderer = GetComponent<SpriteRenderer>(); // for testing
        _startingColor = _renderer.color;
        _inputHandler = new InputHandler()
            .SetClickEvent(key, PlaceObject)
            .SetStartHoldEvent(key, 1f, ShowCreationRadius);
    }
}