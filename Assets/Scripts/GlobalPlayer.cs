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
    public int currentSelfCare = 100;    
    public TMP_Text  selfCareText;

    public int currentPositiveEnergy = 100;    
    public TMP_Text  positiveEnergyText;

    public int currentPerseverance = 100;    
    public TMP_Text  perseveranceText;

    //Inventory
    int currentKindness;
    public TMP_Text  kindnessText;

    //Dreams
    int numberOfDreams = 1;
    public TMP_Text  dreamsText;

    public GameObject flowerCanvas;


    //love
    public int currentLove;    
    public TMP_Text  loveText;


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
    public AudioClip loveSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;
    public bool isInHomePlanet;   


    public string[] worlds;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        currentSelfCare = 100;
        currentPositiveEnergy = 100;   
        currentPerseverance = 100;   
        currentLove = 0; 
        currentKindness = 0;

        gameOverText.enabled = false;
        winText.enabled = false;
        flowerCanvas.SetActive(false);
        DontDestroyOnLoad(gameObject);
        gameOver = false;
        playerAudio = GetComponent<AudioSource>();
        selfCareText.text = "Self Care " + currentSelfCare;
        perseveranceText.text = "Perseverance " + currentPerseverance;
        positiveEnergyText.text = "Positive Energy " + currentPositiveEnergy;
        dreamsText.text = "Dreams " + numberOfDreams;

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

        if ((Input.GetKeyDown(KeyCode.L)) && (currentLove >= 100))
        {
           
           ChangeLove(-100);
           currentHealth = maxHealth;
        }
        
    }
    

    public void RestartGame()
    {
       currentHealth = maxHealth;
       gameOverText.enabled = false;
       currentLove = 0;
       currentPerseverance = 0;
       currentPositiveEnergy = 0;
       currentSelfCare = 0;
       
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
            playerAudio.PlayOneShot(loveSound, 1.0f);
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
    public void ChangeSelfCare(int amount)
    {
        playerAudio.PlayOneShot(loveSound, 0.90f);
        currentSelfCare = currentSelfCare + amount;
        selfCareText.text = "Self Care " + currentSelfCare;
        
    }

    public void ChangeKindness(int amount)
    {
        playerAudio.PlayOneShot(loveSound, 0.90f);
        currentKindness = currentKindness + amount;
        kindnessText.text = "Kindness " + currentKindness;
    }

    public void ChangeDreams(int amount)
    {
        playerAudio.PlayOneShot(loveSound, 0.90f);
        numberOfDreams = numberOfDreams + amount;
        dreamsText.text = "Dreams " + numberOfDreams;
    }

    //Change love amount
    public void ChangeLove(int amount)
    {
        playerAudio.PlayOneShot(loveSound, 0.90f);
        currentLove = currentLove + amount;
        loveText.text = "Love " + currentLove;
        
    }

    public void ChangePerseverance(int amount)
    {
        playerAudio.PlayOneShot(loveSound, 0.90f);
        currentPerseverance= currentPerseverance + amount;
        perseveranceText.text = "Perserverance " + currentPerseverance;
        
    }

    public void ChangePositiveEnergy(int amount)
    {
        playerAudio.PlayOneShot(loveSound, 0.90f);
        currentPositiveEnergy = currentPositiveEnergy + amount;
        positiveEnergyText.text = "Positive Energy " + currentPositiveEnergy;
        
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
