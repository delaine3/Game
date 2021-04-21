using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerLevel4 : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    private float spawnRangeX = 30;
    private float spawnRangeZ = 30;
    private float startDelay = 2;
    private float spawnInterval = 1f;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnItem", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
      
        
    }

    void SpawnItem() {

        //Random Spawn Position
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 4, Random.Range(-spawnRangeZ, spawnRangeZ));
        int animalIndex = Random.Range(0, enemyPrefabs.Length);

        Instantiate(enemyPrefabs[animalIndex], spawnPos, enemyPrefabs[animalIndex].transform.rotation );
    }
}
