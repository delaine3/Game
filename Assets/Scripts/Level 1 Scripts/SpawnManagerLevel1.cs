using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerLevel1 : MonoBehaviour
{
    public GameObject rockPrefab;
    private Vector3 spawnPosition = new Vector3(25,0,-6);
    private float startDelay = 3;
    private float repeatRate = 3;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRock", startDelay, repeatRate);
    }

    void SpawnRock()
    {
        
            Instantiate(rockPrefab, spawnPosition, rockPrefab.transform.rotation);

    }
}
