using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleHat : MonoBehaviour
{
    private LineRenderer line;

    [SerializeField] private LayerMask grapplableMask;

    [SerializeField] private float maxDistance = 10f;

    [SerializeField] private float grappleSpeed = 10f;

    [SerializeField] private float grappleShootSpeed = 20f;

    private bool isGrappling = false;

    [HideInInspector] private bool retracting = false;

    private Vector2 target;
    
    private void Start() {
        line = GetComponent<LineRenderer>();
    }
    
    private void Update() {
        if (Input.GetMouseButton(0) && !isGrappling) {
            StartGrapple();
        }

        if (retracting)
        {
            Vector2 grapplePos = Vector2.Lerp(transform.position, target, grappleSpeed * Time.deltaTime);
            transform.position = grapplePos;
            line.SetPosition(0, transform.position);

            if (Vector2.Distance(transform.position, target) < 0.5f)
            {
                retracting = false;
                isGrappling = false;
                line.enabled = false;
            }
        }
    }

    private void StartGrapple()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
       
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, maxDistance, grapplableMask);

        if (hit.collider != null)
        {
            isGrappling = true;
            target = hit.point;
            line.enabled = true;
            line.positionCount = 2;

            StartCoroutine(Grapple());
        }
    }

    IEnumerator Grapple()
    {
        float t = 0;
        float time = 10;
        line.SetPosition(0, transform.position);
        line.SetPosition(1, transform.position);

        Vector2 newPos;

        for (; t < time; t += grappleShootSpeed * Time.deltaTime)
        {
            newPos = Vector2.Lerp(transform.position, target, t / time);
            line.SetPosition(0, transform.position);
            line.SetPosition(1, newPos);
            yield return null;
        }
        line.SetPosition(1, target);
        retracting = true;
    }
}
