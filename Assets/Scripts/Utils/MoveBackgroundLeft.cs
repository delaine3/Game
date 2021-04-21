using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackgroundLeft : MonoBehaviour
{
    private float speed = 28;
    
    // Update is called once per frame
    void Update()
    { 
        
            transform.Translate(Vector3.left * Time.deltaTime * speed);         
        

    }
}
