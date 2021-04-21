using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GlobalPlayer : Singleton<GlobalPlayer>
{
    //Health
    public int currentHealth;
    public int maxHealth = 7;

    //UI
    public TMP_Text gameOverText;
    public TMP_Text winText;
    public Image[] heartsList;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    
    //Resources
    public int currentWater = 100;    
    public TMP_Text  waterText;

    public int currentSun = 100;    
    public TMP_Text  sunText;

    public int currentNutrients = 100;    
    public TMP_Text  nutrientsText;

    //Inventory
    int currentHomePlanetItems;
    public TMP_Text  homePlanetItemsText;

    //Pets
    int numberOfpets = 1;
    public TMP_Text  petsText;



    //Gold
    public int currentGold;    
    public TMP_Text  goldText;


    //Score
     public int currentScore;    
    public TMP_Text  scoreText;
    
    
    public float timeInvincible = 2.0f;
    public bool isInvincible;
    float invincibleTimer;

    //Game state
    public bool gameOver;
    public int theScene;

    //Sound
    public AudioClip goldSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;
    public bool isInHomePlanet;   


    public string[] worlds;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        currentWater = 100;
        currentSun = 100;   
        currentNutrients = 100;   
        currentGold = 0; 
        currentHomePlanetItems = 0;

        gameOverText.enabled = false;
        winText.enabled = false;
        DontDestroyOnLoad(gameObject);
        gameOver = false;
        playerAudio = GetComponent<AudioSource>();
        waterText.text = "Water " + currentWater;
        nutrientsText.text = "Nutrients " + currentNutrients;
        sunText.text = "Sun " + currentSun;
        petsText.text = "Pets " + numberOfpets;

        theScene = (-1);



    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth> maxHealth){
            currentHealth= maxHealth;
        }
        for (int i = 0; i < heartsList.Length; i++)
        {
            if(i<currentHealth){
                heartsList[i].sprite = fullHeart;
            }else{
                heartsList[i].sprite = emptyHeart;
            }
        }
        for (int i = 0; i < heartsList.Length; i++)
        {
            if(i < maxHealth){
                heartsList[i].enabled = true;
            } else{
                heartsList[i].enabled = false;
            }
        }

         if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }

        if ((Input.GetKeyDown(KeyCode.L)) && (currentGold >= 100))
        {
           
           ChangeGold(-100);
           currentHealth = maxHealth;
        }
        
    }
    

    public void RestartGame()
    {
       currentHealth = maxHealth;
       gameOverText.enabled = false;
       currentGold = 0;
       currentNutrients = 0;
       currentSun = 0;
       currentWater = 0;
       
    }

     public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
                return;
            
            isInvincible = true;
            invincibleTimer = timeInvincible;
        }
        
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);

        if(amount == 1)
        {
            playerAudio.PlayOneShot(goldSound, 1.0f);
        }else{
            playerAudio.PlayOneShot(crashSound, 1.0f);

        }

        
        if(currentHealth == 0){
            gameOver= true;
            GameOver();
        }
        Debug.Log("Health - 1");


    }

//Change Water amount
    public void ChangeWater(int amount)
    {
        playerAudio.PlayOneShot(goldSound, 0.90f);
        currentWater = currentWater + amount;
        waterText.text = "Water " + currentWater;
        
    }

    public void ChangeHomePlanetItems(int amount)
    {
        playerAudio.PlayOneShot(goldSound, 0.90f);
        currentHomePlanetItems = currentHomePlanetItems + amount;
        homePlanetItemsText.text = "Home Planet Items " + currentHomePlanetItems;
    }

    public void ChangePets(int amount)
    {
        playerAudio.PlayOneShot(goldSound, 0.90f);
        numberOfpets = numberOfpets + amount;
        petsText.text = "Pets " + numberOfpets;
    }

    //Change Gold amount
    public void ChangeGold(int amount)
    {
        playerAudio.PlayOneShot(goldSound, 0.90f);
        currentGold = currentGold + amount;
        goldText.text = "Gold " + currentGold;
        
    }

    public void ChangeNutrients(int amount)
    {
        playerAudio.PlayOneShot(goldSound, 0.90f);
        currentNutrients= currentNutrients + amount;
        nutrientsText.text = "Nutrients " + currentNutrients;
        
    }

    public void ChangeSun(int amount)
    {
        playerAudio.PlayOneShot(goldSound, 0.90f);
        currentSun = currentSun + amount;
        sunText.text = "Sun " + currentSun;
        
    }


    public void GameOver()
    { 
        if(gameOver){

            gameOverText.enabled = true;
            Time.timeScale = 0.0f;
            GameManager.Instance.TogglePause();
            
        } else{
            winText.enabled = true;
        } 

    }
    
}
