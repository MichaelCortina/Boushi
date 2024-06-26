﻿using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
class MovableObject : MonoBehaviour, IMovable
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float moveSpeedModifier = 1f;
    [SerializeField] private bool canMoveXAxis = true;
    [SerializeField] private bool canMoveYAxis = true;
    
    [SerializeField] private int xModifier = 1;
    [SerializeField] private int yModifier = 1;
    public event EventHandler<ObjectMovedEventArgs> OnObjectMoved;
    
    private Rigidbody2D _rb;
    private Collider2D _col;

    private Vector2 _moveDirection;
    private Vector3 _previousPosition;

    
    private float ModifiedSpeed => moveSpeed * moveSpeedModifier;

    public void ApplySpeedModifier(float speedPercentage) => moveSpeedModifier *= speedPercentage;
    
    public void MoveObject(Vector2 direction) => 
        _moveDirection = new(
            direction.x * Convert.ToInt32(canMoveXAxis)*xModifier, 
            direction.y * Convert.ToInt32(canMoveYAxis)*yModifier);

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _moveDirection * (ModifiedSpeed * Time.fixedDeltaTime));

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