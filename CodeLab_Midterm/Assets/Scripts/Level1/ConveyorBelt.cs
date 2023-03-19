using System.Collections.Generic;
using UnityEngine;
using Collision2D = UnityEngine.Collision2D;
using Debug = UnityEngine.Debug;

public class ConveyorBelt : MonoBehaviour
{
    public static ConveyorBelt Instance;
    
    private bool dragging = false;
    private bool onTable = false;
    private bool clicking = false;
   
    public float speed = 2;
    private int clickTimes = 0;

    private Vector3 objectPos;
    private Vector2 objectPos1;
    private Vector3 objectPosxyz;

    public List<Sprite> mouseSprites;
    private SpriteRenderer mouseRenderer;

    void Start()
    {
        objectPos = gameObject.transform.position;
        
        mouseRenderer = gameObject.GetComponent<SpriteRenderer>();
        mouseRenderer.sprite = mouseSprites[GameManager.NumberCount];
    }
    
    void Update()
    {       
        if (!dragging)
        {
            objectPos.y -= speed * Time.deltaTime;
            transform.position = objectPos;
        }
             
        if (dragging)
        {
            objectPos1 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            objectPosxyz = objectPos1;
            transform.position = objectPosxyz;
        }
    }
    
    private void OnMouseDown()
    {
        Instance = this;//make every dragged object the instance 
        GameManager.buttonPressable = false;
        Instance.dragging = true;
    }

    private void OnMouseUp()
    {
        Instance.dragging = false;
    }

    private void OnMouseUpAsButton()
    {
        Instance.clicking = true;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == 10)
        {
            Debug.Log("Destroyed In!");
            GameManager.buttonPressable = true;
            Destroy(this.gameObject);
        }
    }
}
