using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using Debug = System.Diagnostics.Debug;

namespace InventorySystem
{
    public class Inventory : MonoBehaviour
    {
            [SerializeField] private InventoryData inventoryData;
            [SerializeField] private bool saveItems;

            private ICollection<ItemData> _items;
            
            /// <summary>
            /// adds item <c>itemToAdd</c> to the inventory
            /// </summary>
            /// <param name="itemToAdd">non null ItemInstance</param>
            public void AddItem([NotNull] ItemInstance itemToAdd)
            {
                Debug.Assert(itemToAdd != null, nameof(itemToAdd) + " != null");
                
                _items.Add(itemToAdd.ItemType);
            }

            public bool ContainsItem(ItemData item)
            {
                return _items.Contains(item);
            }

            private void Awake()
            {
                _items = saveItems ? inventoryData.bag : new List<ItemData>();
            }
        }
}