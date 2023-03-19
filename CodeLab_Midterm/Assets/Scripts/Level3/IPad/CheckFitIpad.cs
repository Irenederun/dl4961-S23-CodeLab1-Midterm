using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFitIpad : MonoBehaviour
{
    private int layer = 24;
    private bool partiallyInTarget;
    private BoxCollider2D boxCol;
    private LayerMask targetMask;
    public Vector3[] edgePoints;
    private float colliderL;
    private float colliderH;

    public bool IsFullyInTarget => partiallyInTarget && CheckIfFullyInTarget();
    
    private void Awake()
    {
        boxCol = GetComponent<BoxCollider2D>();
        colliderL = boxCol.bounds.extents.x;
        colliderH = boxCol.bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (ClickToRotateIpad.direction == 'l')
        {
            SetUpEdgePoints();
        }
        Debug.Log("Ipad " + CheckIfFullyInTarget());
    }

    private void SetUpEdgePoints()
    {
        edgePoints[0] = Vector3.zero;
        edgePoints[1] = Vector3.zero + new Vector3(colliderH, colliderL);
        edgePoints[2] = Vector3.zero + new Vector3(colliderH, -colliderL);
        edgePoints[3] = Vector3.zero + new Vector3(-colliderH, colliderL);
        edgePoints[4] = Vector3.zero + new Vector3(-colliderH, -colliderL);
    }
    
    public bool CheckIfFullyInTarget()
    {
        if (ClickToRotateIpad.direction != 'l')
        {
            return false;
        }
        
        foreach (var edgePoint in edgePoints)
        {
            Vector3 pointToCheck = transform.position + edgePoint;
            Collider2D targetCollider = Physics2D.OverlapPoint(pointToCheck, 1 << layer);
            if (targetCollider == null)
            {
                return false;
            }
        }
        return true;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer.Equals(layer))
        {
            partiallyInTarget = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer.Equals(layer))
        {
            partiallyInTarget = false;
        }
    }
}
