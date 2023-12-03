using UnityEngine;
using UnityEngine.Events;

/// Invokes the UnityEvent onActivate when the switch has been activated
/// requiredActivation times. When deactivate is called the current activations
/// decreases by 1, if this would bring the current activations to below the required
/// activations the onExit UnityEvent is invoked.
public class ControlSwitch : MonoBehaviour
{
    [SerializeField] private int currentActivations;
    [SerializeField] private int requiredActivations;
    [SerializeField] private UnityEvent onActivate;
    [SerializeField] private UnityEvent onExit;

    /// increments currentActivations by 1, and invokes onActivate
    /// if currentActivations is equal to required activations
    public void Activate()
    {
        if (++currentActivations == requiredActivations)
            onActivate?.Invoke();
    }

    /// decrements currentActivations by one, and invokes onExit
    /// if currentActivations has decreased to below requiredActivations
    public void Deactivate()
    {
        if (currentActivations-- == requiredActivations)
            onExit?.Invoke();
    }
}
