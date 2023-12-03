
using InventorySystem;
using UnityEngine;

public class CanBePickedUp : MonoBehaviour
{
    [SerializeField] private KeyCode _pickUpKey = KeyCode.E;
    private bool _canPickUp;
    private ItemData item;

    private void Update()
    {
        if (Input.GetKeyDown(_pickUpKey) && _canPickUp)
        {
            Destroy(gameObject);
            //inventory.AddItem(item.TakeItem());
            _canPickUp = false;
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
