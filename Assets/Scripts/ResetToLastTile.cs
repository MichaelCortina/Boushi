using System;
using UnityEngine;

[RequireComponent(typeof(IMovable))]
public class ResetToLastTile : MonoBehaviour, IResetable
{
    private IMovable _movable;
    private GrappleHat _grapple;
    private MapManager _map;
    
    private Vector3 _resetPosition;

    public void ResetObject() => transform.position = _resetPosition;

    private void CacheResetPosition(object sender, ObjectMovedEventArgs args)
    {
        TileInfo currentTile = _map.InfoAtPosition(args.WorldPosition);

        if (currentTile.IsGround && (_grapple == null || !_grapple.Retracting))
            _resetPosition = _map.NearestTileCenter(args.WorldPosition);
    }

    private void OnEnable() => _movable.OnObjectMoved += CacheResetPosition;

    private void OnDisable() => _movable.OnObjectMoved -= CacheResetPosition;

    private void Awake()
    {
        _movable = GetComponent<IMovable>();
        _grapple = GetComponent<GrappleHat>();
        _map = FindObjectOfType<MapManager>();
    }
}