using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LightRay : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    private int _index;
    
    private void FixedUpdate()
    {
        _index = 1;
        Vector2 origin = _lineRenderer.GetPosition(0);

        CastRay(origin, Vector2.up);
    }

    public void CastRay(Vector2 origin, Vector2 direction)
    {
        RaycastHit2D rayHit = Physics2D.Raycast(origin, direction);
        var rayController = rayHit.collider?.GetComponent<IRayController>();

        _lineRenderer.SetPosition(_index, rayHit.point.Extend(-0.1f));
        _index++;
        
        rayController?.OnRayHit(this, rayHit.point, direction);
    }

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }
}