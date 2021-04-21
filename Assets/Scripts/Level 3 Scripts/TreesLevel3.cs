using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreesLevel3 : MonoBehaviour
{
    GlobalPlayer globalPlayer;


    void Start()
    {
        
        globalPlayer = GameObject.Find("GlobalPlayer").GetComponent<GlobalPlayer>();
        Destroy(gameObject,25);

    }
     
     private void OnTriggerEnter(Collider other)
      {

        if(other.gameObject.CompareTag("Player")){

            globalPlayer.ChangeHealth(-1);

        }
    }
 
}
