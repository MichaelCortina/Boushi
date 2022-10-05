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
            bool hasBeginHoldEvent = inputEvent.StartHoldEvent != null;
            
            if (hasHoldEvent && inputEvent.HasHoldTimeElapsed)
            {
                inputEvent.HoldEvent.HoldAction.Invoke();
                inputEvent.HoldTimer.Reset();
            }

            if (inputEvent.StartHoldEvent is { HasActivated: false }
                && inputEvent.HasDelayElapsed)
            {
                inputEvent.StartHoldEvent.BeginHoldAction.Invoke();
                inputEvent.StartHoldEvent.HasActivated = true;
            }

            if (Input.GetKeyDown(key)
                && (hasHoldEvent || hasBeginHoldEvent))
                inputEvent.HoldTimer.Start();
            else if (Input.GetKeyUp(key))
            {
                inputEvent.ClickEvent?.Invoke();
                inputEvent.HoldTimer.Reset();
                if (hasBeginHoldEvent)
                    inputEvent.StartHoldEvent.HasActivated = false;
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

    public InputHandler SetStartHoldEvent(KeyCode key, float delay, Action beginHoldEvent)
    {
        var beginHold = new StartHoldEvent
        {
            Delay = delay,
            BeginHoldAction = beginHoldEvent,
        };

        if (_inputEvents.ContainsKey(key))
            _inputEvents[key].StartHoldEvent = beginHold;
        else 
            _inputEvents.Add(key, new InputEvent { StartHoldEvent = beginHold });
        return this;
    }
    
    private sealed class InputEvent
    {
        public Action ClickEvent { get; set; }
        public HoldEvent HoldEvent { get; set; }
        public StartHoldEvent StartHoldEvent { get; set; }

        public readonly Stopwatch HoldTimer = new();
        
        public bool HasHoldTimeElapsed => HoldTimer.Elapsed.Seconds >= HoldEvent.HoldSeconds;
        public bool HasDelayElapsed => HoldTimer.Elapsed.Milliseconds >= StartHoldEvent.Delay;
    }

    private sealed class HoldEvent
    {
        public float HoldSeconds { get; set; }
        public Action HoldAction  { get; set; }
    }

    private sealed class StartHoldEvent
    {
        public float Delay { get; set; }
        public bool HasActivated { get; set; }
        public Action BeginHoldAction { get; set; }

    }
}