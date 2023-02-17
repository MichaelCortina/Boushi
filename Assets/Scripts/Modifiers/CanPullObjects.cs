using UnityEngine;

namespace Modifiers
{
    public class CanPullObjects : MonoBehaviour
    {
        [SerializeField] private KeyCode pullKey = KeyCode.LeftShift;
        private IMovable _currentMovable;
        private Collider2D _currentCollider;
    
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
            {
                _isPullingObject = true;
            
                //when pulling slow current object based on mass of object being pulled
                _currentMovable.ApplySpeedModifier(1/_beingPulled.mass);
            }

            if (Input.GetKeyUp(pullKey))
            {
                // when object is released revert current object to previous speed
                if (_isPullingObject)
                    _currentMovable.ApplySpeedModifier(_beingPulled.mass);
            
                _isPullingObject = false;
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
                _currentMovable.ApplySpeedModifier(_beingPulled.mass);
        
            _beingPulled = null;
            _isPullingObject = false;
        }

        /// if an object is being pulled, update its position to follow the
        /// player's movements
        private void FixedUpdate()
        {
            Vector2 currentPosition = _currentCollider.bounds.center;
        
            if (_isPullingObject)
            {
                Vector2 changeInPosition = currentPosition - _prevPosition;
                Vector2 prevClosestPoint = _beingPulled.ClosestPoint(_prevPosition);
                Vector2 currentClosestPoint = _beingPulled.ClosestPoint(currentPosition);

                // do not allow object to be pulled side to side
                if (Vector2.Distance(prevClosestPoint, currentClosestPoint) == 0)
                    _beingPulled.position += changeInPosition;
            }

            _prevPosition = currentPosition;
        }

        private void Awake()
        {
            _currentMovable = GetComponent<IMovable>();
            _currentCollider = GetComponent<Collider2D>();
        }
    }
}