using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerLevel1 : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    //public ParticleSystem explosionParticle;
    //public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    private AudioSource playerAudio;
    GlobalPlayer globalPlayer;
    //public ParticleSystem fireworksParticle;
    GameManager gameManager;
    private bool sceneLoaded;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

        sceneLoaded = false;
        //Get the physics of our game
        Physics.gravity *= gravityModifier;

        playerAudio = GetComponent<AudioSource>();

        //Get the Global Player Script
        globalPlayer = GameObject.Find("GlobalPlayer").GetComponent<GlobalPlayer>();

    }

    // Update is called once per frame
    void Update()
    {
        //Jump
        if (Input.GetKeyDown(KeyCode.W) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            //dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
            
    }

    private void OnCollisionEnter(Collision collision)
    {
        //If the player is on the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;

        }
         else if (collision.gameObject.CompareTag("Life"))
        {
            globalPlayer.ChangeHealth(1);

        }

        else if (collision.gameObject.CompareTag("water"))
        {
            globalPlayer.ChangeWater(5);
            GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

        }

        else if (collision.gameObject.CompareTag("sun"))
        {
            globalPlayer.ChangeSun(4);

        }

          else if (collision.gameObject.CompareTag("nutrients"))
        {
            globalPlayer.ChangeNutrients(3);
        }


        else if (collision.gameObject.CompareTag("Rock"))
        {

            globalPlayer.ChangeHealth(-1);
            
        }

         // if player collides with gold, play the fireworks particles
        else if (collision.gameObject.CompareTag("Gold"))
        {
           // fireworksParticle.Play();
            Destroy(collision.gameObject);
            globalPlayer.ChangeGold(10);

        }

          // if player collides with gold, play the fireworks particles
        else if (collision.gameObject.CompareTag("Silver"))
        {
            //fireworksParticle.Play();
            Destroy(collision.gameObject);
            globalPlayer.ChangeGold(7);

        }

          // if player collides with gold, play the fireworks particles
        else if (collision.gameObject.CompareTag("Copper"))
        {
           // fireworksParticle.Play();
            Destroy(collision.gameObject);
            globalPlayer.ChangeGold(3);

        }
    }
}
