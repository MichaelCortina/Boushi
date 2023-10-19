using System;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

namespace Modifiers
{
    public class CanPullObjects : MonoBehaviour
    {
        [SerializeField] private KeyCode pullKey = KeyCode.LeftShift;
        
        private IMovable _thisMovable;
        private Collider2D _thisCollider;
    
        [SerializeField] [CanBeNull] private Rigidbody2D _beingPulled;
        [SerializeField] Vector2 _pullDirection; // direction in which _beingPulled can move
        private Vector2 _prevPosition;
        [SerializeField] bool _isPullingObject;

        /// when in contact with an object that can be pulled, if the
        /// pullKey is pressed, begin pulling the object. When the key
        /// is released stop pulling the object
        private void Update()
        {
            if (_beingPulled is null) return;

            if (Input.GetKeyDown(pullKey))
            {
                _isPullingObject = true;
            
                //when pulling slow current object based on mass of object being pulled
                _thisMovable.ApplySpeedModifier(1/_beingPulled.mass);
            }

            if (Input.GetKeyUp(pullKey))
            {
                // when object is released revert current object to previous speed
                if (_isPullingObject)
                    _thisMovable.ApplySpeedModifier(_beingPulled.mass);
            
                _isPullingObject = false;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            // check if trigger entered was an object that can be pulled
            // (this is working under the assumption that the pull colliders are a child
            // of the object that can be pulled
            CanBePulled canBePulled = other.GetComponentInParent<CanBePulled>();

            // only track new object to pull if not pulling anything else already
            if (canBePulled != null && !_isPullingObject)
            {
                // get the direction in which canBePulled, can be pulled
                Vector2? direction = canBePulled.GetDirection(other);
                
                if (direction != null)
                {
                    _beingPulled = canBePulled.GetComponent<Rigidbody2D>();
                    _pullDirection = (Vector2) direction;
                }
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            // if this exits collider for _beingPulled remove _beingPulled
            Rigidbody2D otherRb = other.GetComponentInParent<Rigidbody2D>();
            
            if (otherRb != null && otherRb == _beingPulled)
            {
                if (_isPullingObject)
                    _thisMovable.ApplySpeedModifier(_beingPulled.mass);
                _beingPulled = null;
                _isPullingObject = false;
            }
        }

        /// if an object is being pulled, update its position to follow the
        /// player's movements
        private void FixedUpdate()
        {
            Vector2 currentPosition = _thisCollider.bounds.center;
            
            if (_isPullingObject)
            {
                // move _beingPulled by pullVector
                Vector2 pullVector = (currentPosition - _prevPosition) * _pullDirection;
                Vector2 beingPulledPosition = _beingPulled!.position;
                _beingPulled.MovePosition(beingPulledPosition + pullVector);
            }

            _prevPosition = currentPosition;
        }

        private void Awake()
        {
            _thisMovable = GetComponent<IMovable>();
            _thisCollider = GetComponent<Collider2D>();
            _prevPosition = _thisCollider.bounds.center;
        }
    }
}