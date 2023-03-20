using System;
using System;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject button;
    public GameObject parts;
    public GameObject operationObject;
    public GameObject fakeButton;

    public static bool objIsDestroyed = false;
    public static bool buttonPressable = true;
    public static int numberCount = 0;

    public TextMeshPro scoreText;
    
    static float timer = 0;
    static int dayNumber = 279;

    public static int NumberCount
    {
        get
        {
            return numberCount;
        }
        set
        {
            numberCount = value;
            Debug.Log("Number: " + numberCount);

            if (numberCount > HighScore)
            {
                highScore = numberCount;
                Debug.Log("high Score!");
                File.WriteAllText(FILE_PATH,"" + highScore);
            }

            if (timer > 30)
            {
                dayNumber++;
                File.WriteAllText(FILE_PATH_DAY, "" + dayNumber);
                SceneManager.LoadScene("Level3");
            }
        }
    }

    public static string FILE_PATH;
    private const string FILE_DIR = "/Data/";
    private const string FILE_NAME = "records.txt";
    
    public static string FILE_PATH_DAY;
    private const string FILE_NAME_DAY = "date.txt";


    static int highScore = 1;
    private bool resetDate = false;

    public static int HighScore
    {
        get
        {
            return highScore;
        }
        set
        {
            highScore = value;
        }
    }

    private void Start()
    {
        FILE_PATH = Application.dataPath + FILE_DIR + FILE_NAME;
        FILE_PATH_DAY = Application.dataPath + FILE_DIR + FILE_NAME_DAY;

        if (File.Exists(FILE_PATH) == false)
        {
            File.WriteAllText(FILE_PATH, "1");
        }
        else
        {
            HighScore = Int32.Parse(File.ReadAllText(FILE_PATH));
        }

        if (File.Exists(FILE_PATH_DAY) == false)
        {
            File.WriteAllText(FILE_PATH_DAY, "279");
            dayNumber = 279;
        }
        else
        {
            dayNumber = Int32.Parse(File.ReadAllText(FILE_PATH_DAY));
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            File.Delete(FILE_PATH);
            resetDate = true;
        }
        
        scoreText.text= 
            "Day " + dayNumber + "\n" + "High Record: " + "\n" + HighScore + "\n" + "Mice" + "\n" + "Good Job!";

        if (Input.GetMouseButtonUp(0) && !objIsDestroyed)
        {
            if (!Table.instance.onBelt)
            {
                Destroy(ConveyorBelt.Instance.gameObject);
                Table.instance.onBelt = true;

                Vector2 platePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 platePosxyz = platePos;

                Instantiate(operationObject, platePosxyz, Quaternion.identity);
                objIsDestroyed = true;
            }
        }

        if (buttonPressable)
        {
            button.SetActive(true);
            fakeButton.SetActive(false);
        }

        if (!buttonPressable)
        {
            button.SetActive(false);
            fakeButton.SetActive(true);
        }

        if (NumberCount > 5)
        {
            NumberCount = 0;
        }

        if (ToolFollow.knifeFollow || SewingFollow.sewingFollow || SpawnChip.chipIsFollow)
        {
            Cursor.visible = false;
        }
        else
        {
            Cursor.visible = true;
        }

        timer += Time.deltaTime;
    }

    public void Spawn()
    {
        Instantiate(parts, new Vector3(-7f, 7.5f, 10), Quaternion.identity);
    }

    private void OnApplicationQuit()
    {
        if (resetDate)
        {
            dayNumber = 278;
        }
        dayNumber++;
        File.WriteAllText(FILE_PATH_DAY, "" + dayNumber);
    }
}
