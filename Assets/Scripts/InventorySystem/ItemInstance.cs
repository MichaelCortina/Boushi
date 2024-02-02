using System;

namespace InventorySystem
{
    [Serializable]
    public class ItemInstance
    {
        public ItemData itemType;
        
        public ItemInstance(ItemData itemData)
        {
            itemType = itemData;
        }
    }
}