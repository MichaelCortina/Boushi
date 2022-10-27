using System;
using UnityEngine;

public class GlobalEventSystem : MonoBehaviour
{
    public static GlobalEventSystem Instance { get; private set; }

    public event EventHandler<InteractionEventArgs> OnAnyInteraction;
    public event EventHandler OnAnyInteractionEnd;

    public void InvokeAnyInteraction(object sender, InteractionEventArgs args)
    {
        OnAnyInteraction?.Invoke(sender, args);
    }

    public void InvokeAnyInteractionEnd(object sender)
    {
        OnAnyInteractionEnd?.Invoke(sender, EventArgs.Empty);
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }
}