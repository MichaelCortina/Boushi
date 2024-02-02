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
        //If already event activated return
        if (_triggered)
            return;
        
        //Else add new rays to set
        _rayHits.Add(ray);
        print("Hit" + _rayHits.Count);

        //Once required hits is met activate event
        if (_rayHits.Count >= requiredHits)
        {
            //mark as triggered
            _triggered = true;
            onTrigger.Invoke();
        }
    }

    private void FixedUpdate()
    {
        if (!_triggered)
        {
            _rayHits.Clear();
        }
    }
}
