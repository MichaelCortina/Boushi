using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class LoadNewScene : MonoBehaviour
{
    private bool _canEnter;
    [SerializeField] private String scene;
    [SerializeField] private int spawnPoint;
    
    private void Update()
    {
        if (_canEnter && Input.GetKey(Keybindings.InteractKey))
        {
            PlayerPrefs.SetInt("SpawnPoint", spawnPoint);
            UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            _canEnter = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            _canEnter = false;
        }
    }
}
