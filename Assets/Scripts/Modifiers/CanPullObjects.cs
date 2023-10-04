using System;
using UnityEngine;

namespace Modifiers
{
    public class CanPullObjects : MonoBehaviour
    {
        [SerializeField] private KeyCode pullKey = KeyCode.LeftShift;
        private IMovable _thisMovable;
        private Collider2D _thisCollider;
    
        private Rigidbody2D _beingPulled;
        private Vector2 _pullDirection; // direction in which _beingPulled can move

        private Vector2 _prevPosition;
        private bool _isPullingObject;

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
            CanBePulled canBePulled = other.GetComponent<CanBePulled>();

            // only track new object to pull if not pulling anything else already
            if (canBePulled != null && !_isPullingObject)
            {
                // get the direction in which canBePulled, can be pulled
                Vector2? direction = canBePulled.GetDirection(_thisCollider);
                
                if (direction != null)
                {
                    _beingPulled = canBePulled.GetComponent<Rigidbody2D>();
                    _pullDirection = (Vector2) direction;
                }
            }
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
            if (_beingPulled is null || collision.rigidbody != _beingPulled) return;
        
            // when object is released revert current object to previous speed
            if (_isPullingObject)
                _thisMovable.ApplySpeedModifier(_beingPulled.mass);
        
            _beingPulled = null;
            _isPullingObject = false;
        }

        /// if an object is being pulled, update its position to follow the
        /// player's movements
        private void FixedUpdate()
        {
            Vector2 currentPosition = _thisCollider.bounds.center;
        
            if (_isPullingObject)
            {
                // calculate distance and direction traveled by player last frame
                Vector2 changeInPosition = currentPosition - _prevPosition;
                Vector2 prevClosestPoint = _beingPulled.ClosestPoint(_prevPosition);
                Vector2 currentClosestPoint = _beingPulled.ClosestPoint(currentPosition);

                // do not allow an object to be pulled side to side
                // otherwise move object in the same direction the player moved
                if (Vector2.Distance(prevClosestPoint, currentClosestPoint) == 0)
                    _beingPulled.position += changeInPosition;
            }

            _prevPosition = currentPosition;
        }

        private void Awake()
        {
            _thisMovable = GetComponent<IMovable>();
            _thisCollider = GetComponent<Collider2D>();
        }
    }
}