using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private float distanceInZ;
    [SerializeField] private float distanceInX;
    [SerializeField] private float distanceInY;
    [SerializeField] private float timeToClose;
    [SerializeField] private float timeToOpen;
    public void OpenDoor()
    {
        var doorPosition = transform.position;
        transform.position = new Vector3(doorPosition.x + distanceInX, doorPosition.y + distanceInY, doorPosition.z + distanceInZ);
    }

    public void CloseDoor()
    {
        var doorPosition = transform.position;
        transform.position = new Vector3(doorPosition.x - distanceInX, doorPosition.y - distanceInY);
    }
}