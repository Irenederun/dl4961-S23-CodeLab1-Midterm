using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePlate : MonoBehaviour
{
    public static MousePlate instance;
    public bool inPlate; 
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Contains("Mouse"))
        {
            inPlate = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("Mouse"))
        {
            inPlate = false;
        }
    }
}
