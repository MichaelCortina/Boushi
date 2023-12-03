using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNewScene : MonoBehaviour
{
    private bool _canEnter;
    [SerializeField] private String scene;
    
    private void Update()
    {
        if (Input.GetKey(KeyCode.Return) && _canEnter)
        {
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
