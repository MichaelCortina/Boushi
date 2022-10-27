using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class TextInteraction : MonoBehaviour
{
    [SerializeField] private KeyCode interactKey = KeyCode.X;
    [SerializeField] private UnityEvent onInteract;
    private bool isInteracting = false;
    private InputHandler _inputHandler;
    private bool isPlayerInBounds;
    
    public static Action<IEnumerable<ConversationLine>> OnTextInteraction;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInBounds = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInBounds = false;
            isInteracting = false;
        }
    }
    
    private void StartInteract()
    {
        if (isPlayerInBounds && !isInteracting)
        {
            onInteract?.Invoke();
            isInteracting = true;
        }
    }

    private void Update() => _inputHandler.HandleInput();

    private void Awake()
    {
        _inputHandler = new InputHandler()
            .SetClickEvent(interactKey, StartInteract);
    }
}