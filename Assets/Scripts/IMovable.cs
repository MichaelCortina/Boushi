using System;
using UnityEngine;

public interface IMovable
{
    event EventHandler<ObjectMovedEventArgs> OnObjectMoved;
    void MoveObject(Vector2 direction);
}

public class ObjectMovedEventArgs : EventArgs
{
    public Vector3 WorldPosition { get; }
    
    public ObjectMovedEventArgs(Vector3 worldPosition)
    {
        WorldPosition = worldPosition;
    }
}