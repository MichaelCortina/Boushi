using UnityEngine;

class ResetToStartingPosition : MonoBehaviour, IResetable
{
    private Vector3 _startingPosition;

    public void ResetObject()
    {
        transform.position = _startingPosition;
    }

    private void Awake()
    {
        _startingPosition = transform.position;
    }
}