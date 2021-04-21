using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerLevel4 : MonoBehaviour
{
    //Movement
    private CharacterController controller;
    private float playerSpeed = 10.0f;

    private Rigidbody playerRb;

    //PowerUp
    public bool hasPowerUp;
    private float powerUpStrength = 15.0f;
    //public GameObject powerupIndicator;
    
    public GameObject projectilePrefab;

    private GlobalPlayer globalPlayer;
    GameManager gameManager;
    private bool sceneLoaded;



    
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

        //Get the Global Player Script
        globalPlayer = GameObject.Find("GlobalPlayer").GetComponent<GlobalPlayer>();

        
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxisRaw ("Horizontal");
        float moveVertical = Input.GetAxisRaw ("Vertical");
        
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.rotation = Quaternion.LookRotation(movement);
        
        
        transform.Translate (movement * playerSpeed * Time.deltaTime, Space.World);
        //powerupIndicator.transform.position = transform.position + new Vector3(0, Random.Range(2.0f, 9.0f), 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Launch projectile from the player
            Instantiate(projectilePrefab, transform.position, transform.rotation * Quaternion.Euler(Random.Range(-30.0f, -10.0f), 0, 0));
            Instantiate(projectilePrefab, transform.position, transform.rotation * Quaternion.Euler(Random.Range(-30.0f, -10.0f), Random.Range(-30.0f, -10.0f), 0));

        }

    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode
        if (other.gameObject.CompareTag("Enemy"))
        {
            //explosionParticle.Play();
            Destroy(other.gameObject);
            globalPlayer.ChangeHealth(-1);
        } 

        else if (other.gameObject.CompareTag("Gold"))
        {
            Destroy(other.gameObject);
            globalPlayer.ChangeLove(10);

        }
        else if (other.gameObject.CompareTag("Silver"))
        {
            Destroy(other.gameObject);
            globalPlayer.ChangeLove(7);

        }
        else if (other.gameObject.CompareTag("Copper"))
        {
            Destroy(other.gameObject);
            globalPlayer.ChangeLove(3);

        }

        else if (other.gameObject.CompareTag("Life"))
        {

            globalPlayer.ChangeHealth(1);
        
        }

         else if (other.gameObject.CompareTag("water"))
        {
            globalPlayer.ChangeSelfCare(5);
            GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

        }

        else if (other.gameObject.CompareTag("sun"))
        {
            globalPlayer.ChangePositiveEnergy(4);

        }

          else if (other.gameObject.CompareTag("nutrients"))
        {
            globalPlayer.ChangePerseverance(3);
        }

    }

}


