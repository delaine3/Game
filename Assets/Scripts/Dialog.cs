using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Dialog : MonoBehaviour {
    
    public TextMeshProUGUI leftText;
    public TextMeshProUGUI rightText;

    public string[] sentences;
    private int index;
    public float typingSpeed;
    public Camera nonVRCamera;

    bool nextLevelCalled;
    GlobalPlayer globalPlayer;


    GameManager gameManager;
    public string nextLevel;
    public string currentLevel;


    void Start(){

        StartCoroutine(LeftTextBox());
                nextLevelCalled = false;
                        globalPlayer = GameObject.Find("GlobalPlayer").GetComponent<GlobalPlayer>();


    }

    IEnumerator LeftTextBox(){

        foreach(char letter in sentences[index].ToCharArray()){
            leftText.text += letter;

            yield return new WaitForSeconds(typingSpeed);
        }
    }

    IEnumerator RightTextBox(){

        foreach(char letter in sentences[index].ToCharArray()){
            rightText.text += letter;

            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void Update(){

          if (Input.GetKeyDown(KeyCode.Space))
        {
                if(index < sentences.Length - 1){
                  index++;

                    if(index % 2 == 0){

                        leftText.text = "";

                        StartCoroutine (LeftTextBox());

                    } else if(index == sentences.Length - 1){
                    
                         if(nextLevelCalled == false)
                        {
                             NextLevel();
                        }
                    
                    } else {

                         rightText.text = "";

                        StartCoroutine (RightTextBox());

                    }
                }
          }
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