using System;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private void Start()
    {
        GameEvents.Current.OnPressurePlate += OnDoorOpen;
    }

    private void OnDoorOpen()
    {
        
    }
}