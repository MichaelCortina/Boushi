using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventPressurePlate : MonoBehaviour
{
    [SerializeField] private UnityEvent onPressed;
    [SerializeField] private UnityEvent onExit;
    [SerializeField] private UnityEvent onStay;

    private void OnTriggerEnter2D(Collider2D other) => onPressed?.Invoke();

    private void OnTriggerExit2D(Collider2D other) => onExit?.Invoke();

    private void OnTriggerStay(Collider other) => onStay?.Invoke();
}
