using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserClick : MonoBehaviour
{

    public void GoRight()
    {
        var player = GameObject.FindGameObjectWithTag("Player");

     
            ICommand newPosition = new MoveObject(player, Vector3.right, 1.0f);
            newPosition.Execute();
            CommandManager.Instance.AddCommand(newPosition);

    }

    public void GoLeft()
    {
        var player = GameObject.FindGameObjectWithTag("Player");

      
            ICommand newPosition = new MoveObject(player, Vector3.left, 1.0f);
            newPosition.Execute();
            CommandManager.Instance.AddCommand(newPosition);
        
    }

    public void GoUp()
    {
        //Find all the game objects tagged player
        var player = GameObject.FindGameObjectWithTag("Player");

            ICommand newPosition = new MoveObject(player, Vector3.forward, 1.0f);
            newPosition.Execute();
            CommandManager.Instance.AddCommand(newPosition);
        
    }

    public void GoDown()
    {
        //Find all the game object tagged player
        var player = GameObject.FindGameObjectWithTag("Player");

            ICommand newPosition = new MoveObject(player, Vector3.back,  1.0f);
            newPosition.Execute();
            CommandManager.Instance.AddCommand(newPosition);
    }
    
}