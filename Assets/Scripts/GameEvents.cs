using System;
using UnityEngine;
using UnityEngine.Events;

public class GameEvents : MonoBehaviour
{
    [SerializeField] private float timeOpen;
    public static GameEvents Current;
    
    private void Awake()
    {
        Current = this;
    }
    public event Action<int> OnPressurePlateDown;
    public void PressurePlateDown(int id)
    {
        OnPressurePlateDown?.Invoke(id);
    }
    
    public event Action<int> OnPressurePlateUp;

    public void PressurePlateUp(int id)
    {
        OnPressurePlateUp?.Invoke(id);
    }
}