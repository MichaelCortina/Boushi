using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Utilities;

namespace Modifiers.Interactable
{
    public class TextInteraction : MonoBehaviour, Interactable
    {
        [SerializeField] private ConversationData conversation;
    
        [SerializeField] private UnityEvent onInteract;
        [SerializeField] private UnityEvent onInteractEnd;

        private bool _isInteracting;
        private bool _isPlayerInBounds;
    
        private InputHandler _inputHandler;

        public IEnumerable<ConversationLine> Lines => conversation.Conversation;

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
                _isInteracting = true;
                onInteract?.Invoke();
            }
        }

        public void EndInteraction()
        {
            _isInteracting = false;
            onInteractEnd?.Invoke();
        }

        private void Update() => _inputHandler.HandleInput();

        private void Awake()
        {
            _inputHandler = new InputHandler()
                .SetClickEvent(Keybindings.Instance.InteractKey, StartInteraction);
        }
    }
}