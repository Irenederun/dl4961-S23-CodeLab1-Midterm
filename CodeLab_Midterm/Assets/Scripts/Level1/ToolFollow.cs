using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ToolFollow : MonoBehaviour
{
    private bool dragging = false;
    private Vector2 objectPos1;
    private Vector3 objectPosxyz;
    private int clickTimes = 0;

    public static bool onPlate;
    public static bool knifeFollow;

    private BoxCollider2D boxCol;
    private CircleCollider2D cirCol;

    // Start is called before the first frame update
    void Start()
    {
        boxCol = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (onPlate)
        {
            if (clickTimes % 2 == 1)
            {
                objectPos1 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                objectPosxyz = objectPos1;
                transform.position = objectPosxyz;
                transform.rotation = Quaternion.Euler(0,0,45);

                knifeFollow = true;

                //Cursor.visible = false;
            }
            else
            {
                knifeFollow = false;
                transform.rotation = Quaternion.identity;
                
                //Cursor.visible = true;
            }
        }

        if (!onPlate)
        {
            if (clickTimes != 0)
            {
                objectPos1 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                objectPosxyz = objectPos1;
                transform.position = objectPosxyz;
                transform.rotation = Quaternion.Euler(0,0,45);
                
                knifeFollow = true;
                
                //Cursor.visible = false;
            }
        }
    }
    
    private void OnMouseDown()
    {
        clickTimes++;
        Table.instance.KnifeCanFollow++;
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.name.Contains("Plate"))
        {
            onPlate = true;
            boxCol.enabled = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name.Contains("Plate"))
        {
            onPlate = false;
            boxCol.enabled = false;
        }
    }
}
