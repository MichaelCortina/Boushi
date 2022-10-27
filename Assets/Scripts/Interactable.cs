using System;
using System.Collections.Generic;

public interface Interactable
{
    event EventHandler<InteractionEventArgs> OnInteraction;
    event EventHandler OnInteractionEnd;
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