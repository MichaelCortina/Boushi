using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

public class CanPullObjects : MonoBehaviour
{
    [SerializeField] private KeyCode pullKey = KeyCode.LeftShift;
    private Rigidbody2D _beingPulled;

    private Vector2 _prevPosition;
    private bool _isPullingObject;
    
    private void Update()
    {
        if (_beingPulled is null) return;

        if (Input.GetKeyDown(pullKey))
            _isPullingObject = true;

        if (Input.GetKeyUp(pullKey))
            _isPullingObject = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var movable = collision.gameObject.GetComponent<IMovable>();

        if (movable is null || _beingPulled is not null) return;
        
        _beingPulled = collision.rigidbody;
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.rigidbody == _beingPulled)
        {
            _beingPulled = null;
            _isPullingObject = false;
        }
    }

    private void FixedUpdate()
    {
        Vector2 currentPosition = transform.position;
        
        if (_isPullingObject)
        {
            Vector2 changeInPosition = currentPosition - _prevPosition;
            
            _beingPulled.position += changeInPosition/2;
        }

        _prevPosition = currentPosition;
    }
}