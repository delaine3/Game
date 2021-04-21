using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*  
    Objectives:
    Track animation Component
    Track the AnimationClip for fade in/out
    Recieve animation events
    Play fade in and out animations 
*/
public class MainMenue : MonoBehaviour
{
    //I want other systems to access these, but I do want to access them in the inspector so I will use decorators.
    [SerializeField] private Animation _mainMenueAnimator;
    [SerializeField] private AnimationClip _fadeOutAnimation;
    [SerializeField] private AnimationClip _fadeInAnimation;

    public Events.EventFadeComplete OnMainMenueFadeComplete;

    private void Start()
    {
        //We need to register for the OnGameModeChanged event.
        //Debug.Log("[Main Menue]Listening for OnGameModeChanged event");
        GameManager.Instance.OnGameModeChanged.AddListener(HandleGameModeChanged);

    }
    public void OnFadeOutComplete()
    {
        OnMainMenueFadeComplete.Invoke(true);
        Debug.LogWarning("FadeOut Complete");
    }

     public void OnFadeInComplete()
     {
        OnMainMenueFadeComplete.Invoke(false);
        Debug.LogWarning("FadeIn Complete");
        //Turn the dummy camera on
        UIManager.Instance.SetDummyCameraActive(true);
     }

     void HandleGameModeChanged(GameManager.GameMode currentState, GameManager.GameMode previousState)
     {  
         
         //Debug.Log("[MainMenue] The Game State is : " + GameManager.GameMode);

         //If the previous state was the PREGAME state and our new state is our RUNNING state, fadeout the main menue
         if(previousState == GameManager.GameMode.PREGAME && currentState == GameManager.GameMode.RUNNING)
         {
             FadeOut();
         }

         if(previousState != GameManager.GameMode.PREGAME && currentState == GameManager.GameMode.PREGAME)
         {
             Debug.Log("WE ARE FADING IN");
             FadeIn();
         }
     }

    public void FadeIn()
    {
        _mainMenueAnimator.Stop();
        _mainMenueAnimator.clip = _fadeInAnimation;
        _mainMenueAnimator.Play();
    }

    public void FadeOut()
    {
        //Turn the dummy camera off
        UIManager.Instance.SetDummyCameraActive(false);

        _mainMenueAnimator.Stop();
        _mainMenueAnimator.clip = _fadeOutAnimation;
        _mainMenueAnimator.Play();
    }
}
