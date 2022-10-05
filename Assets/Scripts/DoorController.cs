using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private bool isFade;
    [SerializeField] private float distanceInX;
    [SerializeField] private float distanceInY;

    public void OpenDoor()
    {
        var doorPosition = transform.position;
        transform.position = new Vector3(doorPosition.x + distanceInX, doorPosition.y + distanceInY);
    }

    public void CloseDoor()
    {
        var doorPosition = transform.position;
        transform.position = new Vector3(doorPosition.x - distanceInX, doorPosition.y - distanceInY);
    }
}