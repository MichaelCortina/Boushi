﻿using InventorySystem;
using UnityEngine;
using UnityEngine.Events;
using Utilities;

namespace Modifiers.Interact
{
    public class Lock : MonoBehaviour
    {
        [SerializeField] private ItemData key;
        [SerializeField] private UnityEvent onUnlock;
        
        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag("Player")
                && Input.GetKey(Keybindings.InteractKey)
                && other.GetComponent<Inventory>().ContainsItem(key))
            {
                onUnlock.Invoke();
                Destroy(this);
            }
        }
    }
}