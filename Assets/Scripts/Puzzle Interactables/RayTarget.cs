using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class RayTarget : MonoBehaviour, IRayController
{
    private ControlSwitch _switch;
    private readonly HashSet<LightRay> _rayHits = new();
    private bool _triggered;
    [SerializeField] private int requiredHits;
    [SerializeField] private UnityEvent onTrigger;

    public void OnRayHit(LightRay ray, Vector2 contactPoint, Vector2 direction)
    {
        if (_triggered) return;
        
        _rayHits.Add(ray);
        if (_rayHits.Count >= requiredHits)
            onTrigger.Invoke();
    }

    private void FixedUpdate()
    {
        _rayHits.Clear();
    }
}
