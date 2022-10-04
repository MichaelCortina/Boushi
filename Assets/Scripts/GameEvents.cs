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

    public event Action OnPressurePlate;

    public void PressurePlate()
    {
        OnPressurePlate?.Invoke();
    }
}