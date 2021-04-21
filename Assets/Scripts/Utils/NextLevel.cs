using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    GameManager gameManager;
    public string nextLevel;
    public string currentLevel;

    bool scene_loaded;

    void Start(){

        scene_loaded = false;

    }

    private void OnTriggerEnter(Collider other)
    {
        if(scene_loaded == false){
            scene_loaded = true;
            //Refer to the instance of the GameManager, Load the next level and unload the current one
            GameManager.Instance.LoadThisScene(nextLevel);
            GameManager.Instance.UnLoadThisScene(currentLevel);
        }
 



    }

    
}
