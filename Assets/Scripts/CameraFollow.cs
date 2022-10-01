using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Bounds _bounds;

    private Vector3 _playerPosition;

    private void Update()
    {
        transform.position = new Vector3(_playerPosition.x, _playerPosition.y, transform.position.z);
    }

    private void Awake()
    {
        _playerPosition = player.transform.position;
    }
}