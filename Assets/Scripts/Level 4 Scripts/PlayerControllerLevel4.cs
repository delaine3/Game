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
        }

           if (Input.GetKey(KeyCode.O) && sceneLoaded == false)
        {
            sceneLoaded = true;
            GameManager.Instance.LoadThisScene("Level 5");
            GameManager.Instance.UnLoadThisScene("Level 4");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
           // hasPowerUp = true;
            Destroy(other.gameObject);
            //powerupIndicator.gameObject.SetActive(true);
        }
        StartCoroutine(PowerupCountdownRoutine());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();

            //Fly away from the player
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            //enemyRigidBody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
        }

        if (collision.gameObject.CompareTag("Enemy") && !hasPowerUp)
        {
            globalPlayer.ChangeHealth(-1);
           
        }

    }

    IEnumerator PowerupCountdownRoutine() {

        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        //powerupIndicator.gameObject.SetActive(false);
    }
}
