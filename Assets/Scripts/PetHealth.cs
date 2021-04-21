using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PetHealth : MonoBehaviour
{
    int food = 100;
    int water = 100;
    int warmth = 100;

    private const float speed = 10;
    private Vector3 direction;

    public GameObject foodItem;

    private Transform target;

    private Vector3 scaleChange,positionChange;
    private Vector3 negativeScaleChange;

    int foodEaten = 0;

    public float unchangingTime = 10;

    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    float y_position = 0.0f;

    GlobalPlayer globalPlayer;
    


    void Start()
    {
        foodItem = GameObject.FindGameObjectWithTag("Food");

        globalPlayer = GameObject.Find("GlobalPlayer").GetComponent<GlobalPlayer>();


        // Grab cylinder values and place on the target.
        target = foodItem.transform;

        scaleChange = new Vector3(0.01f, 0.01f, 0.01f);

        negativeScaleChange = new Vector3(0.01f, 0.01f, 0.01f);

        timerIsRunning = true;
    }
    
    void Update()
    {
        foodItem = GameObject.FindGameObjectWithTag("Food");
        if(food < 0){
            globalPlayer.ChangePets(-1);
            Destroy(gameObject);
        }
      
        if(foodItem != null){
            target = foodItem.transform;
            float step = Time.deltaTime * 10;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }

        if(foodEaten % 15 == 0){
            transform.localScale += scaleChange;
        }

        
        direction = new Vector3(Random.Range(-10.0f, 10.0f), 0.0f, Random.Range(-10.0f, 10.0f));
        transform.position += direction * speed * Time.deltaTime;

        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                timeRemaining = unchangingTime;
                scaleChange = -scaleChange;

                GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
                food -= 10;
            }
        }
        

         transform.localScale += scaleChange;
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            food += 5;
            GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            foodEaten += 1;


        }
    }


}

