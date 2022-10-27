using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class TextInteraction : MonoBehaviour, Interactable
{
    [SerializeField] private KeyCode interactKey = KeyCode.X;
    [SerializeField] private ConversationData conversation;
    [SerializeField] private UnityEvent onInteract;
    
    public event EventHandler<InteractionEventArgs> OnInteraction;
    public event EventHandler OnInteractionEnd;

    private bool _isInteracting;
    private bool _isPlayerInBounds;
    
    private InputHandler _inputHandler;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _isPlayerInBounds = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _isPlayerInBounds = false;
            if (_isInteracting)
                EndInteraction();
        }
    }
    
    public void StartInteraction()
    {
        if (_isPlayerInBounds && !_isInteracting)
        {
            var args = new InteractionEventArgs(conversation.Conversation);
            onInteract?.Invoke();
            OnInteraction?.Invoke(this, args);
            GlobalEventSystem.Instance.InvokeAnyInteraction(this, args);
            _isInteracting = true;
        }
    }

    public void EndInteraction()
    {
        _isInteracting = false;
        OnInteractionEnd?.Invoke(this, EventArgs.Empty);
        GlobalEventSystem.Instance.InvokeAnyInteractionEnd(this);
    }

    private void Update() => _inputHandler.HandleInput();

    private void Awake()
    {
        _inputHandler = new InputHandler()
            .SetClickEvent(interactKey, StartInteraction);
    }
}