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
    
    public bool Retracting { get; private set; }
    
    private LineRenderer _line;

    private bool _isGrappling;
    private Vector2 _target;
    private Camera _mainCamera;

    private void Update()
    {
        if (Input.GetMouseButton(0) && !_isGrappling)
            StartGrapple();
    }

    private void FixedUpdate()
    {
        if (Retracting)
            Retract();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (Retracting) 
            StopRetracting();
    }

    private void Retract()
    {
        var position = transform.position;
        Vector3 grapplePos = 
            Vector2.MoveTowards(position, _target, grappleSpeed * Time.deltaTime)
            .Extend(position.z);
        
        transform.position = grapplePos;

        _line.SetPosition(0, grapplePos);

        if (Vector2.Distance(grapplePos, _target) < 0.5f)
            StopRetracting();
    }

    private void StopRetracting()
    {
        Retracting = false;
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
        Vector2 newPos = transform.position;

        while(Vector2.Distance(newPos, _target) >= 0.0001f)
        {
            newPos = Vector2.MoveTowards(newPos, _target, grappleShootSpeed * Time.deltaTime);
            
            _line.SetPosition(0, transform.position);
            _line.SetPosition(1, newPos);
            yield return null;
        }
        _line.SetPosition(1, _target);
        Retracting = true;
    }

    private void Awake()
    {
        _line = GetComponent<LineRenderer>();
        _mainCamera = Camera.main;
    }
}
