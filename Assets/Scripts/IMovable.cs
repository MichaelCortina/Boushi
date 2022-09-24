using UnityEngine;

public interface IMovable
{
    public delegate void MoveHandler(GameObject sender, Vector3 worldPosition);
    public event MoveHandler ObjectMoved;

    public void MoveObject(Vector2 direction);
}