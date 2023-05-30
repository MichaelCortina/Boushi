using UnityEngine;
[CreateAssetMenu]
public class ItemData : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public GameObject model;
    [TextArea]
    public string description;
}