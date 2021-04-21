using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerLeve6 : MonoBehaviour
{
    public GameObject titleScreen;
    public List<GameObject> clickPrefabs;

    private float spawnRate = 2.5f;
    public bool isGameActive;

    private float minValueX = -4.00f;   
    private float minValueY = -4.00f; 
    private float timeLeft;

    // Start the game, remove title screen and change spawnRate according to the tier button clicked
    public void StartGame(int tier)
    {
        spawnRate /= tier;
        isGameActive = true;
        StartCoroutine(PrefabOnScreen());
        titleScreen.SetActive(false);
    }


    // While game is active spawn a random target
    IEnumerator PrefabOnScreen()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, clickPrefabs.Count);

            if (isGameActive)
            {
                Instantiate(clickPrefabs[index], RandomPosition(), clickPrefabs[index].transform.rotation);
            }
            
        }
    }

    // Generate a random spawn position based on a random index from 0 to 3
    Vector3 RandomPosition()
    {
        float positionX = minValueX + (RandomIndex() * 2.5f);
        float positionY = minValueY + (RandomIndex() * 2.5f);

        Vector3 spawnPosition = new Vector3(positionX, positionY, 0);
        return spawnPosition;

    }

    // Generates random square index from 0 to 3, which determines which square the target will appear in
    int RandomIndex()
    {
        return Random.Range(0, 5);
    }


}
