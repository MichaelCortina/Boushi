using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventPressurePlate : MonoBehaviour
{
    [SerializeField] private int timesCanBeActivated = 1;
    [SerializeField] private UnityEvent onPressed;
    [SerializeField] private UnityEvent onExit;
    [SerializeField] private UnityEvent onStay;
    

    private readonly List<Collider2D> _collidersOnThis = new();

    private void OnTriggerEnter2D(Collider2D other)
    {
        _collidersOnThis.Add(other);
        if (_collidersOnThis.Count <= timesCanBeActivated)
            onPressed?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _collidersOnThis.Remove(other);
        if (_collidersOnThis.Count < timesCanBeActivated)
            onExit?.Invoke();
    }

    private void OnTriggerStay(Collider other) => onStay?.Invoke();
}
