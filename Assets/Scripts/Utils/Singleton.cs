using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//We are creating a template for things that can only exist as a singleton. 
//We will use generics so that various types of objects can be passed in.

//This is a public generic class called Singleton that can be accessed from anywhere in the project. Because it is generic,
//it will be told what type of class it is each time it is used.
//The sington of this type extends a monoBehaviour. It requires that this particular version of singleton passes in a type 
//of object that is meant to extend a singleton of that same type. This prevents the creation of arbitrary singletons that have no business being singletons.
public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
        //We need to make sure that this is the only object of this type at any given 
//time. This below is a unique instance because we use "static"
    private static T instance;

    //Access this global instance but nt change it externally
    public static T Instance
    {
        get{ return instance;}
        
        //We dont have a setter becasue we don't want other people changing anything in this class
    }

    //We need to check if an instance has already been set
    public static bool IsInitialized
    {
        //Check if instance == null
        get { return instance != null;}
    }


    protected virtual void Awake()
    {
        //Check if there is an instance of a gameManager
         if(instance != null)
        {
            //If there is a an instance of this object
            Debug.LogError("[Singleton scripts] Trying to instanciate a second instance of a singleton class");
        }
        else
        {
            //set instance to this particular gameManager
            instance = (T)this;

        }
    }

//If this object is destroyed another singleton can be created. I am making these protected so that they are accessibe
//To other classes that extend this class and virtual so that they can be overwritten. 
    protected virtual void OnDestroy()
    {
        //If the instance is the particular object that's being destroyed
        if(instance == this)
        {
            //set instance to null. This allows for other game objects to be created in the future
            instance = null;
        }
    }
}
