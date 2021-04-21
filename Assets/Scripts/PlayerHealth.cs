using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : Singleton<GlobalPlayer>
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




   

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
         gameOverText.enabled = false;
        winText.enabled = false;
        DontDestroyOnLoad(gameObject);
        gameOver = false;
        playerAudio = GetComponent<AudioSource>();

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
        
    }
    

    public void RestartGame()
    {
       currentHealth = 7;
       gameOverText.enabled = false;
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


    public void GameOver()
    { 
        if(gameOver){

            gameOverText.enabled = true;
            Time.timeScale = 0.0f;
            //GameManager.Instance.TogglePause();
            
        } else{
            winText.enabled = true;
        } 

    }
    
}
