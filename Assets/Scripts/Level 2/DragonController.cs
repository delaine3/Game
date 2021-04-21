using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    public float speed = 15.0f;

    public float floatForce;
    private float gravityModifier = 2.5f;
    private Rigidbody playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip upSound;

    GlobalPlayer globalPlayer;
    GameManager gameManager;
    private bool sceneLoaded;



    //PowerUp
    public bool hasPowerUp;
    public float powerUpTime = 2.0f;
    //public GameObject powerup;

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
        sceneLoaded = false;
        playerRb = GetComponent<Rigidbody>();

        // raise dragon up when the game starts
        playerRb.AddForce(Vector3.up * 50, ForceMode.Impulse);

        //powerup.SetActive(false);

        //Get the Global Player Script
        globalPlayer = GameObject.Find("GlobalPlayer").GetComponent<GlobalPlayer>();


    }

    // Update is called once per frame
    void Update()
    {
          if (hasPowerUp)
        {
            //powerup.SetActive(true);
            //powerup.transform.position = transform.position;


            powerUpTime -= Time.deltaTime;
            Debug.Log("Time: "+powerUpTime);

            if (powerUpTime < 0)
                Debug.Log("No PowerUp");
                //hasPowerUp = false;
                //powerup.SetActive(false);
                powerUpTime = 2.0f;
        }
        // While space is pressed and game is not over float up
        if (Input.GetKey(KeyCode.Space))
        {
            playerRb.AddForce(Vector3.up * floatForce);
        }

        if (Input.GetKey(KeyCode.O) && sceneLoaded == false)
        {
            sceneLoaded = true;
            GameManager.Instance.LoadThisScene("Level 3");
            GameManager.Instance.UnLoadThisScene("Level 2");
        }


    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode
        if (other.gameObject.CompareTag("Rock") && !hasPowerUp)
        {
            //explosionParticle.Play();
            Destroy(other.gameObject);
            globalPlayer.ChangeHealth(-1);
        } 

        else if (other.gameObject.CompareTag("Gold"))
        {
            Destroy(other.gameObject);
            globalPlayer.ChangeGold(10);

        }
        else if (other.gameObject.CompareTag("Silver"))
        {
            Destroy(other.gameObject);
            globalPlayer.ChangeGold(7);

        }
        else if (other.gameObject.CompareTag("Copper"))
        {
            Destroy(other.gameObject);
            globalPlayer.ChangeGold(3);

        }

        else if (other.gameObject.CompareTag("Life"))
        {

            globalPlayer.ChangeHealth(1);
        
        }

    }

}
