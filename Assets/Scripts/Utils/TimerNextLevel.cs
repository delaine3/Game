using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TimerNextLevel : MonoBehaviour
{
    bool timerRunning;

    float minutes;
    double seconds;
    public float gameTimeRemaining = 60;
    public TMP_Text timeText;
    bool nextLevelCalled;
    GlobalPlayer globalPlayer;

    GameManager gameManager;
    public string nextLevel;
    public string currentLevel;


    void Start(){

        timerRunning = true;
        nextLevelCalled = false;
        globalPlayer = GameObject.Find("GlobalPlayer").GetComponent<GlobalPlayer>();

    }

    
    void Update(){


        gameTimeRemaining -= Time.deltaTime;
        if (gameTimeRemaining <0){
            timerRunning = false;
            if(!nextLevelCalled)
            {
                NextLevel();
            }
        }
  
             DisplayTime(gameTimeRemaining);
        

    }

    void DisplayTime(float timeToDisplay)
    {
         minutes = Mathf.Floor(gameTimeRemaining / 60);
         seconds = (gameTimeRemaining % 60);
         seconds = System.Math.Round(seconds,0);
         timeText.text = "Time Left: " + minutes + ":" + seconds;
    }

    public void NextLevel()
    {
       //Refer to the instance of the GameManager, Load the next level and unload the current one
        nextLevelCalled = true;
        globalPlayer.isInHomePlanet = true;

        GameManager.Instance.LoadThisScene(nextLevel);
        GameManager.Instance.UnLoadThisScene(currentLevel);


    }

   
}


