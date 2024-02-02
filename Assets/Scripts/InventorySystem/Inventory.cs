using System;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    public class Inventory : MonoBehaviour
        {
            [SerializeField] private InventoryData inventoryData;
            [SerializeField] private bool saveItems = false;

            private ICollection<ItemInstance> _items;
            
            public void AddItem(ItemInstance itemToAdd)
            { 
                _items.Add(itemToAdd);
            }
            public void RemoveItem(ItemInstance itemToRemove)
            { 
                _items.Remove(itemToRemove);
            }

            private void Awake()
            {
                _items = saveItems ? new List<ItemInstance>() : inventoryData.bag;
            }
        }
}