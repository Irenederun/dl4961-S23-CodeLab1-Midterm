
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IpadPlate : MonoBehaviour
{
    public static IpadPlate instance;
    public bool inPlate; 
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Contains("Ipad"))
        {
            inPlate = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("Ipad"))
        {
            inPlate = false;
        }
    }
}
