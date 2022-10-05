using UnityEngine;
using System;
public class PressurePlateSensor : MonoBehaviour
{
    [SerializeField] private int activateID;
    [SerializeField] private int id;

    private void OnTriggerEnter2D(Collider2D col)
    {
        GameEvents.Current.PressurePlateDown(id);
    }
 
    private void OnTriggerExit2D(Collider2D other)
    {
        GameEvents.Current.PressurePlateUp(id);
    }
}