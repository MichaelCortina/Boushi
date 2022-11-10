using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Vector3 openDistance;
    [SerializeField] private float timeToClose;
    [SerializeField] private float timeToOpen;

    public void OpenDoor() => StartCoroutine(OpenDoorCoroutine());
        
    public void CloseDoor() => StartCoroutine(CloseDoorCoroutine());

    private IEnumerator CloseDoorCoroutine()
    {
        yield return new WaitForSeconds(timeToClose);
        transform.position -= openDistance;
    }

    private IEnumerator OpenDoorCoroutine()
    {
        yield return new WaitForSeconds(timeToOpen);
        transform.position += openDistance;
    }
}