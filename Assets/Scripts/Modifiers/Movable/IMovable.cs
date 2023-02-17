using System;
using UnityEngine;

public interface IMovable
{
    event EventHandler<ObjectMovedEventArgs> OnObjectMoved;
    void MoveObject(Vector2 direction);
    void ApplySpeedModifier(float speedPercentage);
}

public class ObjectMovedEventArgs : EventArgs
{
    public Bounds ColliderBounds { get; }

    public ObjectMovedEventArgs(Bounds colliderBounds)
    {
        ColliderBounds = colliderBounds;
    }
}