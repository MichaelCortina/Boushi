using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IMovable))]
public class PlayerInput : MonoBehaviour
{
    private IMovable _movable;
    //private InventorySystem inventory;

    private void Update()
    {
        var input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _movable.MoveObject(input);
    }

    private void Awake()
    {
        _movable = GetComponent<IMovable>();
        //inventory = new InventorySystem();
    }
}