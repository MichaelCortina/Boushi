using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Modifiers
{
    /// <summary>
    /// Allows for this object to be pulled by the player in specific directions specified
    /// by the list of pullColliders. This class works under the assumption that the pullColliders
    /// are attached to an empty GameObject that is a child of this GameObject
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D))]
    public class CanBePulled : MonoBehaviour
    {
        [SerializeField] private List<PullCollider> pullColliders;

        public Vector2? GetDirection(Collider2D canPull)
        {
            foreach (var pullCollider in pullColliders)
                if (pullCollider.Collider == canPull)
                    return pullCollider.Direction;
            return Vector2.zero;
        }
    }

    [Serializable]
    struct PullCollider
    {
        [SerializeField] private Vector2 direction;
        [SerializeField] private Collider2D collider;
        public Vector2 Direction => direction;
        public Collider2D Collider => collider;
    }
}