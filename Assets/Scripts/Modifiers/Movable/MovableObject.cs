using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
class MovableObject : MonoBehaviour, IMovable
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float moveSpeedModifier = 1f;
    [SerializeField] private Boolean canMoveXAxis = true;
    [SerializeField] private Boolean canMoveYAxis = true;
    public event EventHandler<ObjectMovedEventArgs> OnObjectMoved;
    
    private Rigidbody2D _rb;
    private Collider2D _col;

    private Vector2 _moveDirection;
    private Vector3 _previousPosition;

    
    private float ModifiedSpeed => moveSpeed * moveSpeedModifier;

    public void ApplySpeedModifier(float speedPercentage) => moveSpeedModifier *= speedPercentage;
    
    public void MoveObject(Vector2 direction) => _moveDirection = direction;

    private void FixedUpdate()
    {
        
        if (canMoveXAxis && canMoveYAxis)
        {
            _rb.MovePosition(_rb.position + _moveDirection * (ModifiedSpeed * Time.fixedDeltaTime));
        }else if (canMoveXAxis)
        {
            Vector2 change = new Vector2(_rb.position.x + _moveDirection.x,_rb.position.y);
            _rb.MovePosition(change * (ModifiedSpeed * Time.fixedDeltaTime));
        }else if (canMoveYAxis)
        {
            Vector2 change = new Vector2(_rb.position.x,_rb.position.y + _moveDirection.y);
            _rb.MovePosition(change * (ModifiedSpeed * Time.fixedDeltaTime));
        }
        
        if (transform.position != _previousPosition)
            OnObjectMoved?.Invoke(this, new ObjectMovedEventArgs(_col.bounds));
        _previousPosition = transform.position;
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _col = GetComponent<Collider2D>();
    }
}