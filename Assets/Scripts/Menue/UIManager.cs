using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//We only want one at a time
public class UIManager : Singleton<UIManager>
{
    [SerializeField] private MainMenue _mainMenue;
    [SerializeField] private PauseMenue _pauseMenue;
    [SerializeField] private Camera _dummyCamera; //We need to turn it on and off
    
    public Events.EventFadeComplete OnMainMenueFadeComplete;

    private void Start()
    {
        _mainMenue.OnMainMenueFadeComplete.AddListener(HandleMainMenuFadeComplete);

        //We need to register for the OnGameModeChanged event.
        //Debug.Log("[Main Menue]Listening for OnGameModeChanged event");
        GameManager.Instance.OnGameModeChanged.AddListener(HandleGameModeChanged);

    }

    void HandleMainMenuFadeComplete(bool fadeOut)
    {
        OnMainMenueFadeComplete.Invoke(fadeOut);
    }

      void HandleGameModeChanged(GameManager.GameMode currentState, GameManager.GameMode previousState)
     {  
         //If current state is PAUSED, turn pause off, else turn it on
         Debug.Log("WE ARE PAUSED");
             _pauseMenue.gameObject.SetActive(currentState == GameManager.GameMode.PAUSED);
         
     }

    private void Update()
    { 
        //Make sure the game is startable
        if(GameManager.Instance.CurrentGameMode != GameManager.GameMode.PREGAME)
        {
            return;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Game start called from UIManager");
            GameManager.Instance.Play();
        }

    }

    public void SetDummyCameraActive(bool active)
    {
        _dummyCamera.gameObject.SetActive(active);
    }
}
