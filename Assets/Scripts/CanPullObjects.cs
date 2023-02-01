using System;
using UnityEngine;

public class CanPullObjects : MonoBehaviour
{
    [SerializeField] private KeyCode pullButton = KeyCode.A;
    private Transform _beingPulled;
    private Transform _parentOfBeingPulled;

    private void Update()
    {
        if (_beingPulled is null) return;
        
        if (Input.GetKeyDown(pullButton))
            _beingPulled.parent = transform;

        if (Input.GetKeyUp(pullButton))
            _beingPulled.parent = _parentOfBeingPulled;
    }

    private void OnCollisionEnter(Collision collision)
    {
        var movable = collision.gameObject.GetComponent<IMovable>();

        if (movable is null || _beingPulled != null) return;
           
        _beingPulled = collision.transform;
        _parentOfBeingPulled = _beingPulled.parent;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform != _beingPulled) return;

        _beingPulled.parent = _parentOfBeingPulled;
        _beingPulled = _parentOfBeingPulled = null;
    }
}