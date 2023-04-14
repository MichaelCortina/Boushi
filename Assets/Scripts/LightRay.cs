using System;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LightRay : MonoBehaviour
{
    [SerializeField] private float lightOffset = 0.02f;
    
    private LineRenderer _lineRenderer;
    private int _index;

    private void FixedUpdate()
    {
        _index = 1;
        Vector3 origin = _lineRenderer.GetPosition(0);
        
        //reset position of the ray each frame
        for (int i = 0; i < _lineRenderer.positionCount; i++)
            _lineRenderer.SetPosition(0, origin);

        CastRay(origin, Vector2.up);
    }

    public void CastRay(Vector2 origin, Vector2 direction)
    {
        if (_index >= _lineRenderer.positionCount)
            return;
        
        RaycastHit2D rayHit = Physics2D.Raycast(origin, direction);
        var rayController = rayHit.collider?.GetComponent<IRayController>();
        
        // create small offset so a reflection does not hit the same contact point again
        Vector2 offset = rayHit.point * direction * lightOffset;
        rayHit.point += offset;
        
        //set each point in the lineRenderer past index to the target position (rayHit)
        for (int i = _index++; i < _lineRenderer.positionCount; i++)
            _lineRenderer.SetPosition(i, rayHit.point.Extend(-0.1f));

        rayController?.OnRayHit(this, rayHit.point, direction);
    }

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }
}