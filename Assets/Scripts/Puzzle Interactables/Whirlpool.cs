using System;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

namespace Puzzle_Interactables
{
    public class Whirlpool : MonoBehaviour
    {
        [SerializeField] private Vector2 center;
        [SerializeField] private float strength;
        [SerializeField] private Vector2 directionVector; //for debugging purposes

        private void OnTriggerStay2D(Collider2D col)
        {
            directionVector = center - (Vector2) col.transform.position;
            col.attachedRigidbody.AddRelativeForce(directionVector * strength, ForceMode2D.Force);
        }
    }
}