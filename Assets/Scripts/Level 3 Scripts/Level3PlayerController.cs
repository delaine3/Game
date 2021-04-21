using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10.0f;
    public float xRange = 10.0f;
    public GameObject projectilePrefab;
    private float fireRate = 2; // time the player has to wait to fire again
    private float nextFire = 0; // time since start after which player can fire again
    GameManager gameManager;
    private bool sceneLoaded;
        GlobalPlayer globalPlayer;



    void Start(){

        globalPlayer = GameObject.Find("GlobalPlayer").GetComponent<GlobalPlayer>();

    }
    // Update is called once per frame
    void Update()
    {
     
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        /*Time.time tells us how long the application has been running. here we allow the player to fire agin when the time that the 
        application has been running is greater than next fire. This works becasue the fire rate is incremented each time*/
        if (Input.GetKeyDown(KeyCode.Space)&& Time.time > nextFire)
        {
            nextFire = Time.time + fireRate; // reset nextFire to current time + fireRate

            //Launch projectile from the player at a -32 degree angle from the x-axis
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation *  Quaternion.Euler(-32, 0, 0));
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

