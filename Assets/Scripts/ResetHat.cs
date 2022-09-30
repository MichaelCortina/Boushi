using System.Timers;
using UnityEngine;

public class ResetHat : MonoBehaviour
{
    [SerializeField] private KeyCode resetKey;
    [SerializeField] private float resetTime; 
    [SerializeField] private GameObject player;

    private Vector2 _resetPosition;
    private bool _hasResetPoint;
    private InputHandler _inputHandler;
    
    private SceneManager _sceneManager;

    private void Update() => _inputHandler.HandleInput();
    
    private void FullReset() => _sceneManager.ResetAll();
    
    private void SoftReset()
    {
        if (_hasResetPoint)
            player.transform.position = _resetPosition;
        else
            _resetPosition = player.transform.position;
        _hasResetPoint = !_hasResetPoint;
    }

    private void Awake()
    {
        _sceneManager = FindObjectOfType<SceneManager>();
        _inputHandler = new InputHandler()
            .SetClickEvent(resetKey, SoftReset)
            .SetHoldEvent(resetKey, resetTime, FullReset);
    }
}