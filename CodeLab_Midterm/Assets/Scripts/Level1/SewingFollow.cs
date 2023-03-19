using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SewingFollow : MonoBehaviour
{
    private bool dragging = false;
    private Vector2 objectPos1;
    private Vector3 objectPosxyz;
    private int clickTimes = 0;

    public static bool sewingOnPlate;
    private bool firstPickUp = false;
    public static bool sewingFollow;

    private Vector3 offset;

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
        if (sewingOnPlate)
        {
            if (clickTimes % 2 == 1)
            {
                UpdateMousePosition();
                objectPosxyz = objectPos1;
                transform.position = objectPosxyz;
                transform.rotation = Quaternion.Euler(0,0,45);

                sewingFollow = true;
            }
            else
            {
                sewingFollow = false;
                transform.rotation = Quaternion.identity;
            }
        }

        if (!sewingOnPlate)
        {
            if (clickTimes != 0)
            {
                UpdateMousePosition();
                objectPosxyz = objectPos1;
                transform.position = objectPosxyz;
                transform.rotation = Quaternion.Euler(0,0,45);

                sewingFollow = true;
            }
        }
    }
    
    private void OnMouseDown()
    {
        clickTimes++;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Contains("Plate"))
        {
            sewingOnPlate = true;
            boxCol.enabled = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name.Contains("Plate"))
        {
            sewingOnPlate = false;
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
