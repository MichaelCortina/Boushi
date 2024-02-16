
using InventorySystem;
using UnityEngine;
using UnityEngine.Serialization;

public class Collectable : MonoBehaviour
{
    [SerializeField] private KeyCode pickUpKey = KeyCode.E;
    [SerializeField] private ItemData data;
    private bool _canPickUp;
    

    private void OnTriggerStay2D(Collider2D col)
    {
        if (_canPickUp && Input.GetKey(pickUpKey))
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
