
using InventorySystem;
using UnityEngine;
using UnityEngine.Serialization;

public class Collectable : MonoBehaviour
{
    [SerializeField] private KeyCode pickUpKey = KeyCode.E;
    [SerializeField] private ItemData data;
    private bool _canPickUp;

    private void Update()
    {
        if (Input.GetKeyDown(pickUpKey) && _canPickUp)
        {
            Destroy(gameObject);
            //inventory.AddItem(new ItemInstance(data));
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
