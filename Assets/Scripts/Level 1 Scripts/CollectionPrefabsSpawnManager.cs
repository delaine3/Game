using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionPrefabsSpawnManager : MonoBehaviour
{

    public GameObject[] objectPrefabs;
    private float spawnDelay = 2;
    private float spawnInterval = 1.5f;
    public int randomMinY;
    public int randomMaxY;
    public float axisZ;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObjects", spawnDelay, spawnInterval);
    }

    void SpawnObjects ()
    {
        // Set random spawn location and random object index
        Vector3 spawnLocation = new Vector3(30, Random.Range(randomMinY, randomMaxY), axisZ);
        int index = Random.Range(0, objectPrefabs.Length);

        Instantiate(objectPrefabs[index], spawnLocation, objectPrefabs[index].transform.rotation);
        

    }

}
