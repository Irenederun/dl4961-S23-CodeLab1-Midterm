using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Proceed : MonoBehaviour
{
    public Button finishButton;
    private Image buttonImage;
    public GameObject endText;
        
    // Start is called before the first frame update
    void Start()
    {
        buttonImage = finishButton.image;
    }

    // Update is called once per frame
    void Update()
    {
        if (ClicktoRotate.clothIsInPosition && ClicktoRotateMouse.mouseIsInPosition &&
            ClickToRotateIpad.ipadIsInPosition)
        {
            buttonImage.color = Color.green;
            finishButton.GetComponent<Button>().interactable = true;
        }
        else
        {
            buttonImage.color = Color.white;
            finishButton.GetComponent<Button>().interactable = false;
        }
    }

    public void ShowEndText()
    {
        endText.SetActive(true);
    }
}
