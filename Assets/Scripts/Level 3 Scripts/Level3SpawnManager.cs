using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3SpawnManager : MonoBehaviour
{
    private float spawnRangeX = 20;
    private float spawnPosZ = 20;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;
    public GameObject[] prefabList;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomPrefab", startDelay, spawnInterval);
    }

    void SpawnRandomPrefab() {

        //Random Spawn Position
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 1, spawnPosZ);
        int animalIndex = Random.Range(0, prefabList.Length);

        Instantiate(prefabList[animalIndex], spawnPos, prefabList[animalIndex].transform.rotation);
    }
}
