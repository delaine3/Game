using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudLevel3 : MonoBehaviour
{
    public int count = 20;
    GameManager gameManager;
    public string nextLevel;
    public string currentLevel;
    bool scene_loaded;

    void Start(){

        scene_loaded = false;

    }

      private void OnTriggerEnter(Collider other)
      {

        if(other.gameObject.CompareTag("projectile")){

            count -= 1; 
            Debug.Log("Count " + count);

            if(count == 0 && scene_loaded == false)
            {
                scene_loaded = true;
                gameObject.SetActive(false);
                 //Refer to the instance of the GameManager, Load the next level and unload the current one
                GameManager.Instance.LoadThisScene(nextLevel);
                GameManager.Instance.UnLoadThisScene(currentLevel);


            }
        }
    }
}
