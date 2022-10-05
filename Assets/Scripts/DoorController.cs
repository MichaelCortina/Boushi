using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private float positionZ;
    [SerializeField] private float distanceInX;
    [SerializeField] private float distanceInY;

    public void OpenDoor()
    {
        var doorPosition = transform.position;
        transform.position = new Vector3(doorPosition.x + distanceInX, doorPosition.y + distanceInY, positionZ);
    }

    public void CloseDoor()
    {
        var doorPosition = transform.position;
        transform.position = new Vector3(doorPosition.x - distanceInX, doorPosition.y - distanceInY);
    }
}