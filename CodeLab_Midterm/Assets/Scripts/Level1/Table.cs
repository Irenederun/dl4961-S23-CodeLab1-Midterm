using System;
using UnityEngine;

public class Table : MonoBehaviour
{
    public static Table instance;
    public bool onBelt = true;
    private int knifeCanFollow = 0;
    public BoxCollider2D tableCol;

    private void Awake()
    {
        instance = this;
        tableCol = gameObject.GetComponent<BoxCollider2D>();
    }

    public int KnifeCanFollow
    {
        get { return knifeCanFollow; }
        set
        {
            knifeCanFollow = value;
            tableCol.size = new Vector2(0.81f,0.81f);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("Mouse"))
        {
            Debug.Log("mouse enter");
            onBelt = false;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("Mouse"))
        {
            Debug.Log("mouse exit");
            onBelt = true;
        }
    }
}
