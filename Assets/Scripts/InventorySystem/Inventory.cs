using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    public class Inventory : MonoBehaviour
        {
            [SerializeField] private InventoryData inventoryData;
            [SerializeField] private List<ItemInstance> items = new();
            [SerializeField] private bool saveItems = false;
                
            public void AddItem(ItemInstance itemToAdd)
            {
                if (saveItems)
                    inventoryData.Bag.Add(itemToAdd);
                else
                    items.Add(itemToAdd);
            }
            public void RemoveItem(ItemInstance itemToRemove)
            {
                if (saveItems)
                    inventoryData.Bag.Remove(itemToRemove);
                else
                    items.Remove(itemToRemove);
            }
        }
}