using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2MoveLeft : MonoBehaviour
{
    private float speed = 30;
    private float offScreen = -15;

    // Update is called once per frame
    void Update()
    {
        //if game is not over move to the left
       
            transform.Translate(Vector3.left * Time.deltaTime * speed);


        if (transform.position.x < offScreen && gameObject.CompareTag("Rock"))
        {
            Destroy(gameObject);
        }
    }
}
