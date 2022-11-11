using System;
using UnityEngine;

[RequireComponent(typeof(IMovable))]
public class ResetToLastTile : MonoBehaviour, IResetable
{
    private IMovable _movable;
    private Collider2D _collider;
    private GrappleHat _grapple;
    private MapManager _map;
    
    private Vector3 _resetPosition;

    public void ResetObject()
    {
        //adjust reset to center on collider instead of sprite
        _resetPosition -= _collider.bounds.center;
        var position = transform.position;
        transform.position = new Vector3(position.x + _resetPosition.x, position.y + _resetPosition.y, position.z);
    }

    private void CacheResetPosition(object sender, ObjectMovedEventArgs args)
    {
        TileInfo currentTile = _map.InfoAtPosition(args.ColliderBounds.center);

        if (currentTile.IsGround && (_grapple == null || !_grapple.Retracting))
            _resetPosition = _map.NearestTileCenter(args.ColliderBounds.center);
    }

    private void OnEnable() => _movable.OnObjectMoved += CacheResetPosition;

    private void OnDisable() => _movable.OnObjectMoved -= CacheResetPosition;

    private void Awake()
    {
        _movable = GetComponent<IMovable>();
        _collider = GetComponent<Collider2D>();
        _grapple = GetComponent<GrappleHat>();
        _map = FindObjectOfType<MapManager>();
    }
}