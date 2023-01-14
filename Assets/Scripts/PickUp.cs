
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private bool _canPickUp;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _canPickUp)
        {
            Destroy(gameObject);
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
