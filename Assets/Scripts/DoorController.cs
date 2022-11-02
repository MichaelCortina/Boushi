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
        StartCoroutine(OpenDoorCoroutine());
        var doorPosition = transform.position;
        transform.position = new Vector3(doorPosition.x + distanceInX, doorPosition.y + distanceInY, doorPosition.z + distanceInZ);
    }

    public void CloseDoor()
    {
        StartCoroutine(CloseDoorCoroutine());
        var doorPosition = transform.position;
        transform.position = new Vector3(doorPosition.x - distanceInX, doorPosition.y - distanceInY);
    }

    private IEnumerator CloseDoorCoroutine()
    {
        yield return new WaitForSeconds(timeToClose);
    }

    private IEnumerator OpenDoorCoroutine()
    {
        yield return new WaitForSeconds(timeToOpen);
    }
}