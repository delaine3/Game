using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public GameObject[] objectPrefabs;
    private float spawnDelay = 2;
    private float spawnInterval = 1.5f;
    public int randomMinX;
    public int randomMaxX;
    public int randomMaxZ;
    public int randomMinZ;
    int count = 0;


    // Start is called before the first frame update
    void Start()
    {
            
            
            InvokeRepeating("SpawnObjects", spawnDelay, spawnInterval);

        
    }

    void SpawnObjects ()
    {
        if (count == 10){
            
            Destroy(gameObject,10);

        }

        if (count < 10){

            // Set random spawn location and random object index
            Vector3 spawnLocation = new Vector3(transform.position.x + Random.Range(randomMinX, randomMaxX),2.41f , transform.position.z + Random.Range(randomMinZ, randomMaxZ));
            int index = Random.Range(0, objectPrefabs.Length);
            count += 1;
            Instantiate(objectPrefabs[index], spawnLocation, objectPrefabs[index].transform.rotation);

        }else{
            CancelInvoke();

        }

    }


}
