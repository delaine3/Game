using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomePlanetPlayer : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    float m_Speed;
    GlobalPlayer globalPlayer;
    public GameObject pet;


    void Start()
    {
        //Fetch the Rigidbody component you attach from your GameObject
        m_Rigidbody = GetComponent<Rigidbody>();
        //Set the speed of the GameObject
        m_Speed = 50.0f;
        globalPlayer = GameObject.Find("GlobalPlayer").GetComponent<GlobalPlayer>();

    }


    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))  
        {  
            this.transform.Translate(Vector3.forward * Time.deltaTime * m_Speed);  
        }  
         
        if (Input.GetKey(KeyCode.DownArrow))  
        {  
            this.transform.Translate(Vector3.back * Time.deltaTime * m_Speed);  
        }  
         
        if (Input.GetKey(KeyCode.LeftArrow))  
        {  
            this.transform.Translate(Vector3.left * Time.deltaTime * m_Speed);  
 
        }  
        
        if (Input.GetKey(KeyCode.RightArrow))  
        {  
            this.transform.Translate(Vector3.right * Time.deltaTime * m_Speed);  

        } 

          //Get new pet
        if (Input.GetKeyDown(KeyCode.P) && (globalPlayer.currentPerseverance >= 20) && (globalPlayer.currentPositiveEnergy >= 20) && (globalPlayer.currentSelfCare >= 20))
        {
            globalPlayer.ChangeSelfCare(-20);
            globalPlayer.ChangePositiveEnergy(-20);
            globalPlayer.ChangePerseverance(-20);
    
            Instantiate(pet, transform.position, transform.rotation);
             globalPlayer.ChangeDreams(1);
        }

          //Buy resources
        if ((Input.GetKeyDown(KeyCode.B)) && (globalPlayer.currentLove >= 40))
        {
            globalPlayer.ChangeSelfCare(10);
            globalPlayer.ChangePositiveEnergy(10);
            globalPlayer.ChangePerseverance(10);
            globalPlayer.ChangeLove(-40);
        }
        
    }

      private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("exports"))
        {
            globalPlayer.ChangeHomePlanetItems(2);
        }

    
    }

   
}
