using System.Timers;
using UnityEngine;

public class ResetHat : MonoBehaviour
{
    [SerializeField] private KeyCode resetKey;
    //time user must hold resetKey before fully resetting scene
    [SerializeField] private float resetTime; 
    [SerializeField] private GameObject player;

    private Vector2 _resetPosition;
    private Timer _resetTimer;
    private bool _hasResetPoint;
    private bool _shouldFullReset;
    
    private SceneManager _sceneManager;

    private void Update()
    {
        HandleInput();
        
        if (_shouldFullReset)
        {
            FullReset();
            _shouldFullReset = false;
        }
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(resetKey))
        {
            _resetTimer.Start();
        }

        if (Input.GetKeyUp(resetKey) && _resetTimer.Enabled)
        {
            SoftReset();
            _resetTimer.Stop();
        }
    }

    private void SoftReset()
    {
        if (_hasResetPoint)
            player.transform.position = _resetPosition;
        else
            _resetPosition = player.transform.position;
        _hasResetPoint = !_hasResetPoint;
    }
    
    private void FullReset() => _sceneManager.ResetAll();

    private void Awake()
    {
        _sceneManager = FindObjectOfType<SceneManager>();
        
        _resetTimer = new Timer(resetTime * 1000);
        _resetTimer.Elapsed += (_, _) => _shouldFullReset = true;
    }
}