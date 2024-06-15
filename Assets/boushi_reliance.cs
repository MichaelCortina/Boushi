using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boushi_reliance : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rely_on;
    [SerializeField] private Rigidbody2D baby_guy;

    private Vector2 prevParentPos;

    private void Start()
    {
        rely_on = GetComponent<Rigidbody2D>();
        baby_guy = GetComponent<Rigidbody2D>();
        prevParentPos = rely_on.position;
    }
    private void FixedUpdate()
    {
        Vector2 currParentPos = rely_on.position;
        Vector2 movementDirection = currParentPos - prevParentPos;
        
        if (movementDirection.x < 1)
        {
            baby_guy.constraints = RigidbodyConstraints2D.FreezePositionX;
        }
        if (movementDirection.y < 1)
        {
            baby_guy.constraints = RigidbodyConstraints2D.FreezePositionY;
        }
        baby_guy.constraints = RigidbodyConstraints2D.None;
        baby_guy.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
