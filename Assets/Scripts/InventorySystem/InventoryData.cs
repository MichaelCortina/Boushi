using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    [CreateAssetMenu]
    internal class InventoryData : ScriptableObject
    {
        // public Bag<ItemInstance> bag;
        public List<ItemInstance> bag; // so that it displays in Unity
    }
}