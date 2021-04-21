using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewWorld : MonoBehaviour
{

 
    bool nextLevelCalled;

    GameManager gameManager;
    public string nextLevel;
    public string currentLevel;
    GlobalPlayer globalPlayer;

    public int currentindex;



    void Start(){

        nextLevelCalled = false;
        
        //Get the Global Player Script
        globalPlayer = GameObject.Find("GlobalPlayer").GetComponent<GlobalPlayer>();

        globalPlayer.currentHealth = globalPlayer.maxHealth;
        
    }
 

   private void OnTriggerEnter(Collider other)
    {
         if (other.gameObject.CompareTag("HomePlanetPlayer") && nextLevelCalled ==false)
        {
            nextLevelCalled = true;
           
            globalPlayer.isInHomePlanet = false;
            globalPlayer.theScene += 1;
            if(globalPlayer.theScene == 4)
            {
                globalPlayer.flowerCanvas.SetActive(true);
            }
            GameManager.Instance.LoadThisScene(globalPlayer.worlds[globalPlayer.theScene]);
            GameManager.Instance.UnLoadThisScene("HomeUniverse");
            

    }
}
}
