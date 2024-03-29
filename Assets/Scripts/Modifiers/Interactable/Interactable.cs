using System;
using System.Collections.Generic;

namespace Modifiers.Interactable
{
    public interface Interactable
    {
        void StartInteraction();
        void EndInteraction();
    }

    public class InteractionEventArgs : EventArgs
    {
        public IEnumerable<ConversationLine> Conversation { get; }
    
        public InteractionEventArgs(IEnumerable<ConversationLine> conversation)
        {
            Conversation = conversation;
        }
    }
}