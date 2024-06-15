using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IMovable))]
public class PlayerInput : MonoBehaviour
{
    private IMovable _movable;
    //private InventorySystem inventory;
    private Animator animator;

    private void Update()
    {
        var input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _movable.MoveObject(input);
        
        animator.SetFloat("x_move",Input.GetAxis("Horizontal"));
        animator.SetFloat("y_move",Input.GetAxis("Vertical"));
        animator.SetFloat("speed",Mathf.Abs(Input.GetAxis("Vertical")+Input.GetAxis("Horizontal")));
        //this is not actually the speed i but it accomplishes what I need it to do.
    }

    private void Awake()
    {
        _movable = GetComponent<IMovable>();
        //inventory = new InventorySystem();
        animator = GetComponent<Animator>();
    }
    
}