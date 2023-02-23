using UnityEngine;
using UnityEngine.Tilemaps;

/// transforms a rectangular piece of tile from on to off whenever change states
/// is called starting at position, and extending upwards for height tiles as
/// well as extending to the right, length tiles.
public class BridgeController : MonoBehaviour
{
    [SerializeField] private bool isActivated = false;
    [SerializeField] private Tile on;
    [SerializeField] private Tile off;
    [SerializeField] private Tilemap map;
    
    [Header("Bridge Dimensions")]
    [SerializeField] private Vector3Int position;
    [SerializeField] private int length;
    [SerializeField] private int height;

    //transforms tiles in the range from on to off and vice versa
    public void ChangeStates() =>
        map.BoxFill(position, !(isActivated = !isActivated) ? off : on, 
            position.x, position.y, position.x + length, position.y + height);
}