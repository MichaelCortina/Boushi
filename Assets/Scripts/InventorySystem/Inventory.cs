using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    public class Inventory : ScriptableObject
        {
            public ItemData newItemType;
            public List<ItemInstance> items = new();
            void Start()
            {
                items.Add(new ItemInstance(newItemType));
            }
            
            public void AddItem(ItemInstance itemToAdd)
            {
                items.Add(itemToAdd);
            }
            public void RemoveItem(ItemInstance itemToRemove)
            {
                items.Remove(itemToRemove);
            }
        }
}