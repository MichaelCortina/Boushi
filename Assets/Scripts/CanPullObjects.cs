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
    
    /// when in contact with an object that can be pulled, if the
    /// pullKey is pressed, begin pulling the object. When the key
    /// is released stop pulling the object
    private void Update()
    {
        if (_beingPulled is null) return;

        if (Input.GetKeyDown(pullKey))
            _isPullingObject = true;

        if (Input.GetKeyUp(pullKey))
            _isPullingObject = false;
    }

    /// when the current object comes in contact with another object that can
    /// be pulled, store a reference to the object unless another has already
    /// been stored.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var movable = collision.gameObject.GetComponent<IMovable>();

        if (movable is null || _beingPulled is not null) return;
        
        _beingPulled = collision.rigidbody;
    }
    
    /// when the current object loses contact with the object being pulled,
    /// stop pulling it.
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.rigidbody == _beingPulled)
        {
            _beingPulled = null;
            _isPullingObject = false;
        }
    }

    /// if an object is being pulled, update its position to follow the
    /// player's movements
    private void FixedUpdate()
    {
        Vector2 currentPosition = transform.position;
        
        if (_isPullingObject)
        {
            Vector2 changeInPosition = currentPosition - _prevPosition;
            
            _beingPulled.position += changeInPosition;
        }

        _prevPosition = currentPosition;
    }
}