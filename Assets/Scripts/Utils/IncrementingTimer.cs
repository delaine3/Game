using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class IncrementingTimer : MonoBehaviour
{
    bool timerRunning;

    float minutes;
    double seconds;
    public float gameTime;
    public TMP_Text timeText;
    GlobalPlayer globalPlayer;

    GameManager gameManager;

    void Start(){

        timerRunning = true;
        globalPlayer = GameObject.Find("GlobalPlayer").GetComponent<GlobalPlayer>();

    }

    
    void Update(){


        gameTime += Time.deltaTime;
       
        DisplayTime(gameTime);
        

    }

    void DisplayTime(float timeToDisplay)
    {
         minutes = Mathf.Floor(gameTime / 60);
         seconds = (gameTime % 60);
         seconds = System.Math.Round(seconds,0);
         timeText.text = "Time Left: " + minutes + ":" + seconds;
    }


   
}


