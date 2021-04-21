using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1MoveLeft : MonoBehaviour
{
    private float speed = 30;
    private PlayerControllerLevel1 playerControllerScript;
    private float leftBound = -15;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerLevel1>();
    }

    // Update is called once per frame
    void Update()
    {
        //if game is not over move to the left
       
            transform.Translate(Vector3.left * Time.deltaTime * speed);


        if (transform.position.x < leftBound && gameObject.CompareTag("Rock"))
        {
            Destroy(gameObject);
        }

        
    }
}
