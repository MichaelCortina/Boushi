using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject player;
    
    private void Update()
    {
        var (x, y, _) = player.transform.position;
        transform.position = new Vector3(x, y, transform.position.z);
    }
}