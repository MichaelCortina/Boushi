using UnityEngine;

namespace InventorySystem
{
    [CreateAssetMenu]
    public class FixedInventoryItem : ScriptableObject
    {
        public bool hasItem;
        public string itemName;
        public Sprite icon;
        [TextArea]
        public string description;
    }
}