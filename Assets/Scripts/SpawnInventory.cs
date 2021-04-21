using UnityEngine;
using System.Collections;
 
/// <summary>
/// Spawns a prefab randomly throughout the volume of a Unity transform. Attach to a Unity cube to visually scale or rotate. For best results disable collider and renderer.
/// </summary>
public class SpawnInventory : MonoBehaviour {
 
public GameObject ObjectToSpawn;   
public float RateOfSpawn = 15;
   
private float nextSpawn = 0;

GlobalPlayer globalPlayer;
 
 private void Start()
    {
        globalPlayer = GameObject.Find("GlobalPlayer").GetComponent<GlobalPlayer>();

    }
    // Update is called once per frame
    void Update () {           
       
        if(Time.time > nextSpawn && globalPlayer.isInHomePlanet == true)
        {
            nextSpawn = Time.time + RateOfSpawn;
           
            // Random position within this transform
            Vector3 rndPosWithin;
            rndPosWithin = new Vector3(Random.Range(-450f, -70f), 3, Random.Range(70f, 400));
            Instantiate(ObjectToSpawn, rndPosWithin, transform.rotation);      
        }
    }
}
 
