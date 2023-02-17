using System.Timers;
using UnityEngine;

public class ResetHat : MonoBehaviour
{
    [SerializeField] private KeyCode resetKey;
    [SerializeField] private float resetTime;
    [SerializeField] private SpriteRenderer afterImage;

    private Vector3 _resetPosition;
    private bool _hasResetPoint;
    private InputHandler _inputHandler;
    
    private SceneManager _sceneManager;

    private void Update() => _inputHandler.HandleInput();
    
    private void FullReset() => _sceneManager.ResetAll();
    
    private void SoftReset()
    {
        if (_hasResetPoint)
        {
            transform.position = _resetPosition;
            afterImage.enabled = false;
        }
        else
        {
            _resetPosition = transform.position;
            afterImage.transform.position = _resetPosition;
            afterImage.enabled = true;
        }
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