using UnityEngine.Events;

//This is just a container class so it can be an object that extends from nothing
public class Events 
{
    [System.Serializable]public class EventFadeComplete : UnityEvent<bool> {}

    //We will use the EventSytem to track state changes and serialize it so that it is available in the inspector
    [System.Serializable]public class EventGameMode : UnityEvent<GameManager.GameMode, GameManager.GameMode> {}

}
