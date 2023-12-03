using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class TileInfo : ScriptableObject
{
    [SerializeField] private TileBase[] tiles;
    [SerializeField] private bool ground;

    public TileBase[] Tiles => tiles;
    public bool IsGround => ground;
}