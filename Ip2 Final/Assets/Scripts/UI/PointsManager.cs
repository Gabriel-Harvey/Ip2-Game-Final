using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PointsManager : MonoBehaviour
{
    public static PointsManager instance;

    [Header("GameObjects")]
    public GameObject endscreen;
    public Text TotalTime;
    public Text TotalScore;
    public Text TotalSouls;
    public Text TotalDeaths;
    public Text inGameTimer;

    public GameObject eventSystem;
    public GameObject button;


    public HeartSystem heart;
    public SoulsManager souls;
    public TimerController timer;

    public int score;
    public int maxScore;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenScreen()
    {
        Time.timeScale = 0;
        endscreen.SetActive(true);
        heart = GameObject.FindGameObjectWithTag("InputManager").GetComponent<HeartSystem>();

        if (heart.life == 3)
        {
            TotalSouls.text = "0 = 150";
            score = score + 150;
        }
        else if (heart.life == 2)
        {
            TotalDeaths.text = "1 = 100";
            score = score + 100;
        }
        else if (heart.life == 1)
        {
            TotalDeaths.text = "2 = 50";
            score = score + 50;
        }

        if (souls.souls == 3)
        {
            TotalSouls.text = "3 = 150";
            score = score + 150;
        }
        else if (souls.souls == 2)
        {
            TotalSouls.text = "2 = 100";
            score = score + 100;
        }
        else if (souls.souls == 1)
        {
            TotalSouls.text = "1 = 50";
            score = score + 50;
        }

        TotalTime.text = inGameTimer.text;
        TotalScore.text = "" + score + "/" + maxScore;
    }
    

    public void Nextlvl()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuScreen");
        
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
