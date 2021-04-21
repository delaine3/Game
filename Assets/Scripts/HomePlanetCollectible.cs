using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomePlanetCollectible : MonoBehaviour
{

    void Start(){
        
        Destroy(gameObject,3);

    }

     private void OnTriggerEnter(Collider other)
    {

         Destroy(gameObject);
    }

}
