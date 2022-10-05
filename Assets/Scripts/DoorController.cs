using System;
using System.Collections;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private int id;
    private void Start()
    {
        GameEvents.Current.OnPressurePlateDown += OnDoorOpen;
        GameEvents.Current.OnPressurePlateUp += OnDoorClose;
    }

    public void OpenDoor()
    {
        
    }

    public void CloseDoor()
    {
        
    }

    private void OnDoorOpen(int otherId)
    {
        if (id == otherId)
        {
            Debug.Log("door");
        }
        
    }

    private void OnDoorClose(int otherId)
    {
        if (id == otherId)
        {
            Debug.Log("door close");
        }
        
    }
}