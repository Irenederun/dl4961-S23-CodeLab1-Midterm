using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClicktoRotateMouse : MonoBehaviour
{
    private int inPlateClickTimes = 0;
    private int outOfPlateClickTimes = 0;
    public static char direction;
    private bool follow = false;
    private Vector2 objectPos;
    private Vector3 objectPosxyz;
    
    public static bool mouseIsInPosition;
    private int inTargetClick = 0;

    // Update is called once per frame
    void Update()
    {
        if (follow)
        {
            objectPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            objectPosxyz = objectPos;
            transform.position = objectPosxyz;
        }
        if (!follow && MousePlate.instance.inPlate)
        {
            transform.rotation = Quaternion.identity;
        }
    }

    private void OnMouseDown()
    {
        if (MousePlate.instance.inPlate)
            inPlateClickTimes++;
        {
            switch (inPlateClickTimes % 2)
            {
                case 1:
                    follow = true;
                    break;
                case 0:
                    follow = false;
                    break;
            }
        }
        if (!MousePlate.instance.inPlate)
        {
            if (gameObject.GetComponent<CheckFitMouse>().CheckIfFullyInTarget())
            {
                inTargetClick++;
                switch (inTargetClick % 2)
                {
                    case 1:
                        follow = false;
                        mouseIsInPosition = true;
                        break;
                    case 0:
                        follow = true;
                        mouseIsInPosition = false;
                        break;
                }
            }
            else
            {
                outOfPlateClickTimes++;
                switch (outOfPlateClickTimes)
                {
                    case 1:
                        transform.rotation = Quaternion.Euler(0, 0, 90);
                        direction = 'l';
                        break;
                    case 2:
                        transform.rotation = Quaternion.Euler(0, 0, 180);
                        direction = 'd';
                        break;
                    case 3:
                        transform.rotation = Quaternion.Euler(0, 0, 270);
                        direction = 'r';
                        break;
                    case 4:
                        transform.rotation = Quaternion.Euler(0, 0, 0);
                        direction = 'u';
                        outOfPlateClickTimes = 0;
                        break;
                }
            }
        }
    }
}
