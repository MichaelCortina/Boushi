using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

[RequireComponent(typeof(IMovable), typeof(IResetable))]
public class ResetOnFall : MonoBehaviour
{
    private IMovable _movable;
    private IResetable _resetable;
    private MapManager _mapManager;
    [CanBeNull] private GrappleHat _grappleHat;

    private void CheckFall(GameObject o, Vector3 worldPosition)
    {
        var currentTileInfo = _mapManager.InfoAtPosition(worldPosition);
        if (!currentTileInfo.IsGround && _grappleHat is null)
            _resetable.ResetObject();
    }

    private void Awake()
    {
        _movable = GetComponent<IMovable>();
        _resetable = GetComponent<IResetable>();
        _mapManager = FindObjectOfType<MapManager>();
        _grappleHat = GetComponent<GrappleHat>();
        _movable.ObjectMoved += CheckFall;
    }
}