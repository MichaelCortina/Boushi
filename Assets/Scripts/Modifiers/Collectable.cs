using InventorySystem;
using UnityEngine;
using Utilities;

namespace Modifiers
{
    public class Collectable : MonoBehaviour
    {
        [SerializeField] private ItemData data;
        private bool _canPickUp;
    

        private void OnTriggerStay2D(Collider2D col)
        {
            if (_canPickUp && Input.GetKey(Keybindings.Instance.InteractKey))
            {
                var inventory = col.GetComponent<Inventory>();
                inventory.AddItem(new ItemInstance(data));
            
                _canPickUp = false;
            
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                _canPickUp = true;
            }
        }

        private void OnTriggerExit2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                _canPickUp = false;
            }
        }
    }
}
