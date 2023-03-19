using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipFollowVer2 : MonoBehaviour
{
    private Vector2 objectPos;
    private Vector3 objectPosxyz;
    private bool chipOnPlate;

    // Start is called before the first frame update
    void Start()
    {
        //boxCol = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        objectPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        objectPosxyz = objectPos;
        transform.position = objectPosxyz;
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 13)
        {
            chipOnPlate = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.layer == 13)
        {
            chipOnPlate = false;
        }
    }
}
