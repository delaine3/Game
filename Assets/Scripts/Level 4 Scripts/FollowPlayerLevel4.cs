using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerLevel4 : MonoBehaviour
{
    Rigidbody enemyRb;
    GameObject player;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody> ();
        player = GameObject.Find("Player");
    }

          private void OnTriggerEnter(Collider other)
      {

        if(other.gameObject.CompareTag("Hex")){
    
                Destroy(gameObject);

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        //follow enemy get the direction you need to go. Normalized makes sure that it's strength doesnt increase over time. It will alwasy move at the same speed
        enemyRb.AddForce(lookDirection * speed);

        
    }
}
