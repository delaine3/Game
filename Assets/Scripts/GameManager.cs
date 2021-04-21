using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

/*
 MAIN Objectives 
- What level the game is currently in
- Load and unload game levels
- Keep track of the game mode
  ->Pregame
  ->Running
  ->Paused
- Generate other persistent systems

Objectives for Pause mode
    -Function to enter and exit pause mode
    -Trigger method via 'escape' key
    -Trigger method via pause menue
    -Pause simulation while in pause mode
    -Modify cursor to use pointer when in pause mode


*/
//This class extends the Singleton class.
public class GameManager : Singleton<GameManager>
{

public enum GameMode
{
    PREGAME,
    RUNNING,
    PAUSED
}

//Functionality for generating other game mangaers later without changing this main game manager.
public GameObject [] SystemPrefabs;// Things the game manager need to keep track of, things that may need to live in the scope of the boot scene.

public Events.EventGameMode OnGameModeChanged;

private List<GameObject> _instancedSystemPrefabs;//List of system prefabs that we want the game mangaer to keep track of.

//We need to keep track of how many async opperations are happening incase we want to control how many are loading at a given time, do transitions etc.
List<AsyncOperation> _listOfThingsThatAreLoading;

GameMode _currentGameMode = GameMode.PREGAME;

//Store current level as a string because unity can access scenes by their names. We can also use the build index but we’ll use a string for today because indexes can change and get messy. 
private string _thisLevelIs = string.Empty;

private GlobalPlayer globalPlayer;





//We need other systems to be able to get access to the current game mode so we will use a public accessor
public GameMode CurrentGameMode
{
    //This passes game mode information to other systems 
    get{return _currentGameMode;}

    //The setter is private because I dont want other systems changing the game mode
    private set{_currentGameMode = value;}
}

private void Start()
{
    //Make sure that the GameManager is not destroyed during scene changes or ever. Not destroyed by events, cleanups or anything at all. 
    //This will make sure that the game object that the game manger is attached to is never destroyed.
    DontDestroyOnLoad(gameObject);

    /*Everytime we make a new load opperation, we will add it to this list. 
    when the load is completed, we will remove it from this list.*/
    _listOfThingsThatAreLoading = new List<AsyncOperation>();
    
    //Instantiate whatever need to be instancited when the game starts
    IterateThroughTheSystemPrefabsAndInstantiateThem();

    UIManager.Instance.OnMainMenueFadeComplete.AddListener(WhenTheMainMenueIsDoneFading);

    //Get the Global Player Script
    globalPlayer = GameObject.Find("GlobalPlayer").GetComponent<GlobalPlayer>();

}

 private void Update()
    { 

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        } 

    }


void RemoveCompletedOpperationsFromOperationsList(AsyncOperation asyncOpperation)
{
    //We need to make sure that the async opperation has been properly registered
    if(_listOfThingsThatAreLoading.Contains(asyncOpperation))//check if the asyncOpperation exists in the list. this makes sure that people with no permission, do not add their ownn asyncOpperations.
    {
        //If it exists, remove it
        _listOfThingsThatAreLoading.Remove(asyncOpperation);
        Debug.Log("The current game mode is " + _currentGameMode);

        //If the number of load operations is 0, it means that all items have been loaded and we can start running the game
        if(_listOfThingsThatAreLoading.Count == 0)
        {
            UpdateMode(GameMode.RUNNING);

        }

    }
    Debug.Log("Load Complete");
}

//Iterate accross all the instacne prefabs and instantiate them into real objects that the 
//game can use.
void IterateThroughTheSystemPrefabsAndInstantiateThem()
{
    //Temporary variable to store whatever thing is instantiated for each run of the loop. This could be sound manager, followed by a UIManger etc.
    GameObject aPrefab;

    //iterate accross all the entries in sytem prefabs.
    for(int i = 0; i < SystemPrefabs.Length; ++i)
    {
        aPrefab = Instantiate(SystemPrefabs[i]);

        //Add to system prefabs list
        _instancedSystemPrefabs.Add(aPrefab);

        /*Now we can create the game objects. This is useful for if we want to clean them up at some point.
        This make debugging easier*/
    }

}

void WhenLevelHasBeenUnLoaded(AsyncOperation asyncOpperation)
{
    if (asyncOpperation == null)
    {
        Debug.Log("[Game Manager Script] This level could not be unloaded " + _thisLevelIs);
        return;
    }
     Debug.Log("Level has been unloaded");
}

void WhenTheMainMenueIsDoneFading(bool fade)
{
    if(!fade)
    {
        UnLoadThisScene(_thisLevelIs);
    }
}

void UpdateMode(GameMode mode)
{
        GameMode previousGameMode = _currentGameMode;

    _currentGameMode = mode;
    
    Debug.Log("The previous game mode is " + previousGameMode);

    switch (_currentGameMode)
    {
        case GameMode.PREGAME:
            Time.timeScale = 1.0f;
            break;
        
        case GameMode.RUNNING:
        //All simulation runs at normal speed
            Time.timeScale = 1.0f;
            break;

        case GameMode.PAUSED:
        //This pauses all simulation in the game by stopping updates.
            Time.timeScale = 0.0f;
            break;
        
        default:
            break;
    }

    OnGameModeChanged.Invoke(_currentGameMode, previousGameMode);
    //Debug.Log("The current game mode is " + _currentGameMode);

}



//This function loads a scene
public void LoadThisScene(string sceneName)
{
	/*We are loading this scene asynchronously because we want our scenes to load smoothly. 
    Using a blocking call like LoadScene would make everything else stop which could cause glitchy behavior. 
    Loading asynchronously will allow other things to happen in the background while our scene is loading.*/
	AsyncOperation asyncOpperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive); /*This returns an async object. 
    It knows everything that happens inside of it and contains events. Including a completed event.
    This will tell us when the scene is done loading. Because we are using Async, we won’t know when the scene 
    is done loading, big scene may take longer and smaller one will be faster. This handles that problem. We are loading the scenes
    additively and manging them ourselves becasue we want the game manager to persist throught the game*/
	
    
    /*We need to check if a scene is loaded by SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive). If 
    the scene == null, we need to return an error.*/
    if (asyncOpperation == null)
    {
        Debug.Log("[Game Manager Script] Unable to load level " + sceneName);
        return;
    }
    asyncOpperation.completed +=  RemoveCompletedOpperationsFromOperationsList; //This is the method we want called once the scene has been loaded.

    //Add load opperation to list
    _listOfThingsThatAreLoading.Add(asyncOpperation);

	//We are setting the current level string to a variable, which is also a parameter for this function, called current level name
	_thisLevelIs = sceneName;
}


//This function unloads a scene.
public void UnLoadThisScene(string sceneName)
{
    AsyncOperation asyncOpperation = SceneManager.UnloadSceneAsync(sceneName);
    if (asyncOpperation == null)
    {
        Debug.Log("[Game Manager Script] Unable to unload level " + _thisLevelIs);
        return;
    }

	SceneManager.UnloadSceneAsync(sceneName);
    asyncOpperation.completed += WhenLevelHasBeenUnLoaded;
    }

    public void Play()
    {
        LoadThisScene("Beginning");
    }

    public void TogglePause()
    {
        
        if(_currentGameMode == GameMode.RUNNING)
        {
            UpdateMode(GameMode.PAUSED);
        }
        else
        {
            UpdateMode(GameMode.RUNNING);
        }
        
    }

    public void ReStartGame()
    {
        //Revert back tp the pregame mode
        UpdateMode(GameMode.PREGAME);

        //Restart the game in the global player too
        globalPlayer.RestartGame();
    }

    public void ExitGame()
    {
        //This Exits whatever application is running
        Application.Quit();
    }

}
