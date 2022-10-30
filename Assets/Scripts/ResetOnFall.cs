using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(IMovable), typeof(IResetable))]
public class ResetOnFall : MonoBehaviour
{
    private IMovable _movable;
    private IResetable _resetable;
    private MapManager _mapManager;
    [CanBeNull] private GrappleHat _grappleHat;

    private void CheckFall(object o, ObjectMovedEventArgs e)
    {
        bool onGround = e.ColliderBounds
            .EdgePoints()
            .Select(edgePoint => _mapManager.InfoAtPosition(edgePoint))
            .All(tile => tile.IsGround);
        
        if (!onGround && (_grappleHat is null || !_grappleHat.Retracting))
            _resetable.ResetObject();
    }

    private void OnEnable() => _movable.OnObjectMoved += CheckFall;

    private void OnDisable() => _movable.OnObjectMoved -= CheckFall;

    private void Awake()
    {
        _movable = GetComponent<IMovable>();
        _resetable = GetComponent<IResetable>();
        _mapManager = FindObjectOfType<MapManager>();
        _grappleHat = GetComponent<GrappleHat>();
    }
}