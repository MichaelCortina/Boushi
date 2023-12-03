using UnityEngine;

namespace InventorySystem
{
    [CreateAssetMenu]
    internal class InventoryData : ScriptableObject
    {
        public Bag<ItemInstance> Bag;
    }
}