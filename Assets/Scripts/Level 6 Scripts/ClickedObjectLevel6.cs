using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickedObjectLevel6 : MonoBehaviour
{
    private GameManagerLeve6 gameManager;
    public GameObject fireworks;
    private float minX = -4.0f; 
    private float minY = -4.0f; 
    public float timeOnScreen = 1.5f;
 

    void Start()
    {
        gameManager = GameObject.Find("GameManagerLeve6").GetComponent<GameManagerLeve6>();

        transform.position = RandomInstantatePosition(); 

    }

    // When target is clicked, destroy it, update score, and generate explosion
    private void OnMouseDown()
    {
    
            Destroy(gameObject);
            Fireworks();
               
    }

    // Generate a random spawn position based on a random index from 0 to 3
    Vector3 RandomInstantatePosition()
    {
        float positionX = minX + (Random.Range(0, 6) );
        float positionY = minY + (Random.Range(0, 3) );

        Vector3 spawnPosition = new Vector3(positionX, positionY, 0);
        return spawnPosition;

    }

    // Display explosion particle at object's position
    void Fireworks ()
    {
        Instantiate(fireworks, transform.position, fireworks.transform.rotation);
    }


}
