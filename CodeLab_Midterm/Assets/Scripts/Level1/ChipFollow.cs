using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class ChipFollow : MonoBehaviour
{
    private bool dragging = false;
    private Vector2 objectPos1;
    private Vector3 objectPosxyz;
    private int clickTimes = 0;

    private bool chipOnPlate;
    private bool firstPickUp = false;
    public static bool chipFollow;

    private BoxCollider2D boxCol;
    private CircleCollider2D cirCol;

    // Start is called before the first frame update
    void Start()
    {
        boxCol = gameObject.GetComponent<BoxCollider2D>();
        cirCol = gameObject.GetComponent<CircleCollider2D>();
        TurnOnCollider();
    }

    // Update is called once per frame
    void Update()
    {
        if (chipOnPlate)
        {
            if (clickTimes % 2 == 1)
            {
                UpdateMousePosition();
                objectPosxyz = objectPos1;
                transform.position = objectPosxyz;
                
                chipFollow = true;
                
            }
            else
            {
                chipFollow = false;
            }
        }

        if (!chipOnPlate)
        {
            if (clickTimes != 0)
            {
                UpdateMousePosition();
                objectPosxyz = objectPos1;
                transform.position = objectPosxyz;

                chipFollow = true;
            }
        }
    }
    
    private void OnMouseDown()
    {
        clickTimes++;
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.layer == 13)
        {
            chipOnPlate = true;
            boxCol.enabled = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.layer == 13)
        {
            chipOnPlate = false;
            boxCol.enabled = false;
        }
    }
    
    private void UpdateMousePosition()
    {
        objectPos1 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void TurnOnCollider()
    {
        boxCol.enabled = true;
        cirCol.enabled = true;
    }
}
