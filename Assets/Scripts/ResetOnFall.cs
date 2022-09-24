using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IMovable), typeof(IReset))]
public class ResetOnFall : MonoBehaviour
{
    private IMovable _movable;
    private IReset _reset;
    private MapManager _mapManager;

    private void CheckFall(GameObject o, Vector3 worldPosition)
    {
        var currentTileInfo = _mapManager.InfoAtPosition(worldPosition);
        
        if (!currentTileInfo.IsGround) 
            _reset.ResetObject();
    }

    private void Awake()
    {
        _movable = GetComponent<IMovable>();
        _reset = GetComponent<IReset>();
        _mapManager = FindObjectOfType<MapManager>();
        _movable.ObjectMoved += CheckFall;
    }
}