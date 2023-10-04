using System.Collections.Generic;
using UnityEngine;

namespace Modifiers
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class CanBePulled : MonoBehaviour
    {
        [SerializeField] private List<Vector2> pullDirections;
        [SerializeField] private List<Collider2D> pullColliders;

        public Vector2? GetDirection(Collider2D canPull)
        {
            for (int i = 0; i < pullColliders.Count; i++)
                if (pullColliders[i].IsTouching(canPull))
                    return pullDirections[i];
            return Vector2.zero;
        }
    }
}