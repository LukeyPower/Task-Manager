using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public static UI_Manager instance;
    public TextMeshProUGUI Shotcount;
    public TextMeshProUGUI Accuracy;
    public TextMeshProUGUI Timeelapsed;
    public TextMeshProUGUI Popupsterminated;
    public TextMeshProUGUI Finalscore;

    public GameObject ScoreScreen;


    public GameObject crashScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    public void Score()
    {
        Shotcount.text = "Shots Fired: " + Game_Manager.instance.shotcount.ToString();
        Accuracy.text = "Accuracy: " + Game_Manager.instance.accuracy.ToString("F2") + "%";
        Timeelapsed.text = "Time Survived: " + Game_Manager.instance.timeSurvived.ToString("F2") + "s";
        Popupsterminated.text = "Pop-ups Terminated: " + Game_Manager.instance.windowsClosed.ToString();
        Finalscore.text = "Final Score: " + Game_Manager.instance.finalScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
