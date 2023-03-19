using System;
using System.Collections.Generic;
using UnityEngine;

public class AwayMouse : MonoBehaviour
{
    Vector3 awayPos;
    public List<Sprite> awayMouseSprite;
    private SpriteRenderer mouseRenderer;

    private void Start()
    {
         mouseRenderer = gameObject.GetComponent<SpriteRenderer>();
         mouseRenderer.sprite = awayMouseSprite[GameManager.NumberCount];
    }

    void Update()
    {
        awayPos = transform.position;
        awayPos.y += 2 * Time.deltaTime;
        transform.position = awayPos;
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == 10)
        {
            Debug.Log("Destroyed Out!");
            Destroy(this.gameObject);
        }
    }
}
