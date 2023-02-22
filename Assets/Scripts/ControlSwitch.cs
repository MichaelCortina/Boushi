using UnityEngine;
using UnityEngine.Events;

public class ControlSwitch : MonoBehaviour
{
    [SerializeField] private int currentActivations;
    [SerializeField] private int requiredActivations;
    [SerializeField] private UnityEvent onActivate;
    [SerializeField] private UnityEvent onExit;

    public void Activate()
    {
        currentActivations++;
        if (currentActivations == requiredActivations)
            onActivate?.Invoke();
    }

    public void Deactivate()
    {
        currentActivations--;
        if (currentActivations == requiredActivations - 1)
            onExit?.Invoke();
    }
}
