using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public sealed class InputHandler
{
    private readonly Dictionary<KeyCode, InputEvent> _inputEvents = new();

    //Should be called every frame
    public void HandleInput()
    {
        foreach (var (key, inputEvent) in _inputEvents)
        {
            bool hasHoldEvent = inputEvent.HoldEvent != null;

            if (hasHoldEvent && inputEvent.HoldEvent.ShouldInvoke)
            {
                inputEvent.HoldEvent.HoldAction.Invoke();
                inputEvent.HoldEvent.HoldTimer.Reset();
            }

            if (Input.GetKeyDown(key))
                if (hasHoldEvent) 
                    inputEvent.HoldEvent.HoldTimer.Start();
                else 
                    inputEvent.ClickEvent?.Invoke();
            else if (Input.GetKeyUp(key) 
                     && hasHoldEvent 
                     && inputEvent.HoldEvent.HoldTimer.IsRunning)
            {
                inputEvent.ClickEvent?.Invoke();
                inputEvent.HoldEvent.HoldTimer.Reset();
            }
        }
    }

    public InputHandler SetClickEvent(KeyCode key, Action clickEvent)
    {
        if (_inputEvents.ContainsKey(key))
            _inputEvents[key].ClickEvent = clickEvent;
        else
            _inputEvents.Add(key, new InputEvent {ClickEvent = clickEvent});
        return this;
    }

    public InputHandler SetHoldEvent(KeyCode key, float holdSeconds, Action holdEvent)
    {
        var hold = new HoldEvent
        {
            HoldSeconds = holdSeconds,
            HoldAction = holdEvent
        };

        if (_inputEvents.ContainsKey(key))
            _inputEvents[key].HoldEvent = hold;
        else
            _inputEvents.Add(key, new InputEvent { HoldEvent = hold });
        return this;
    }
    
    private sealed class InputEvent
    {
        public Action ClickEvent { get; set; }
        public HoldEvent HoldEvent { get; set; }
    }

    private sealed class HoldEvent
    {
        public float HoldSeconds { get; set; }
        public Action HoldAction  { get; set; }
        public readonly Stopwatch HoldTimer = new();

        public bool ShouldInvoke => HoldTimer.Elapsed.Seconds >= HoldSeconds;
    }
}