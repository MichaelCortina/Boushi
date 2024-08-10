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
    private void Update()
    {
        Vector2 movementDirection = rely_on.position - prevParentPos;
        
		if (movementDirection.x == 0){
		Debug.Log(movementDirection.x);
		Debug.Log("i am silly x");
			baby_guy.constraints = RigidbodyConstraints2D.FreezePositionX | ~RigidbodyConstraints2D.FreezePositionY;
		}
		if (movementDirection.y == 0){
		Debug.Log(movementDirection.y);
		Debug.Log("i am silly y");
			baby_guy.constraints = ~RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
		}
		baby_guy.constraints = ~RigidbodyConstraints2D.FreezePositionX | ~RigidbodyConstraints2D.FreezePositionY;
		Debug.Log("end of fixed update");
        /*baby_guy.constraints = RigidbodyConstraints2D.None;*/
        /*baby_guy.constraints = RigidbodyConstraints2D.FreezeRotation;*/
    }
}
