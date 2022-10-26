using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
class MovableObject : MonoBehaviour, IMovable
{
    [SerializeField] private float moveSpeed;

    public event EventHandler<ObjectMovedEventArgs> OnObjectMoved;

    private Vector2 _moveDirection;
    private Rigidbody2D _rb;
    private Vector3 _previousPosition;

    public void MoveObject(Vector2 direction) => _moveDirection = direction;

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _moveDirection * (moveSpeed * Time.fixedDeltaTime));
        if (transform.position != _previousPosition)
            OnObjectMoved?.Invoke(this, new ObjectMovedEventArgs(transform.position));
        _previousPosition = transform.position;
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
}