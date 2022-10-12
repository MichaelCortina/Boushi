using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleHat : MonoBehaviour
{
    [SerializeField] private LayerMask grapplableMask;
    [SerializeField] private float maxDistance = 10f;
    [SerializeField] private float grappleSpeed = 10f;
    [SerializeField] private float grappleShootSpeed = 20f;
    
    private LineRenderer _line;

    private bool _isGrappling;
    private bool _retracting;
    private Vector2 _target;
    private Camera _mainCamera;

    private void Update()
    {
        if (Input.GetMouseButton(0) && !_isGrappling)
            StartGrapple();
    }

    private void FixedUpdate()
    {
        if (_retracting)
            Retract();
    }

    private void Retract()
    {
        Vector3 grapplePos = Vector2.Lerp(transform.position, _target, grappleSpeed * Time.deltaTime);
        transform.position = grapplePos;
        
        _line.SetPosition(0, grapplePos);

        if (Vector2.Distance(grapplePos, _target) < 0.5f)
            StopRetracting();
    }

    private void StopRetracting()
    {
        _retracting = false;
        _isGrappling = false;
        _line.enabled = false;
    }
    
    private void StartGrapple()
    {
        var position = transform.position;
        
        Vector2 direction = _mainCamera.ScreenToWorldPoint(Input.mousePosition) - position;
        RaycastHit2D hit = Physics2D.Raycast(position, direction, maxDistance, grapplableMask);

        if (hit.collider != null)
        {
            _isGrappling = true;
            _target = hit.point;
            _line.enabled = true;
            _line.positionCount = 2;

            StartCoroutine(GrappleCoroutine());
        }
    }

    private IEnumerator GrappleCoroutine()
    {
        float t = 0;
        float time = 10;
        var position = transform.position;
        
        _line.SetPosition(0, position);
        _line.SetPosition(1, position);

        for (; t < time; t += grappleShootSpeed * Time.deltaTime)
        {
            position = transform.position;
            var newPos = Vector2.Lerp(position, _target, t / time);
            
            _line.SetPosition(0, position);
            _line.SetPosition(1, newPos);
            yield return null;
        }
        _line.SetPosition(1, _target);
        _retracting = true;
    }

    private void Awake()
    {
        _line = GetComponent<LineRenderer>();
        _mainCamera = Camera.main;
    }
}
