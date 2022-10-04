using System;
using UnityEngine;
using UnityEngine.Events;

public class GameEvents : MonoBehaviour
{
    [SerializeField] private float timeOpen;
    [SerializeField] private int id;
    public static GameEvents Current;
    
    private void Awake()
    {
        Current = this;
    }

    public event Action OnPressurePlateDown;
    public void PressurePlateDown(int otherId)
    {
        if (id == otherId){
            OnPressurePlateDown?.Invoke();
        }
    }
    
    public event Action OnPressurePlateUp;

    public void PressurePlateUp(int otherId)
    {
        if (id == otherId){
            OnPressurePlateUp?.Invoke();
        }
    }
}