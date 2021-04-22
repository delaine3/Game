using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NameTransfer : MonoBehaviour
{
    public string levelInt;
    public GameObject inputField;
    public GameObject textToDisplay;
   
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StoreName(){

        levelInt = inputField.GetComponent<TMP_Text>().text;
        textToDisplay.GetComponent<TMP_Text>().text = "Welcome " + levelInt + " to the game"; 
    }
}
