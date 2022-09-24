using System;
using UnityEngine;

class ResetToStartingPostion : MonoBehaviour, IReset
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