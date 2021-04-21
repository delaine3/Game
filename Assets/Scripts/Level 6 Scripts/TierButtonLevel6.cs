using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TierButtonLevel6 : MonoBehaviour
{
    private GameManagerLeve6 gameManager;
    private GameObject buttons;

    // Start is called before the first frame update
    void Start()
    {

        gameManager = GameObject.Find("GameManagerLeve6").GetComponent<GameManagerLeve6>();
        buttons = GameObject.Find("Title Screen");

    }

    /* When a button is clicked, call the StartGame() method
     * and pass it the tier value (1, 2, 3) from the button 
    */
    public void SetTier1()
    {
        gameManager.StartGame(1);
        buttons.SetActive(false);

    }

    public void SetTier2()
    {
        gameManager.StartGame(2);
        buttons.SetActive(false);

    }

    public void SetTier3()
    {
        gameManager.StartGame(3);
        buttons.SetActive(false);

    }



}
