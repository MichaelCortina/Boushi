using System;

namespace InventorySystem
{
    [Serializable]
    public class ItemInstance
    {
        public ItemData ItemType { get; init; }

        public ItemInstance(ItemData itemData)
        {
            ItemType = itemData;
        }
    }
}