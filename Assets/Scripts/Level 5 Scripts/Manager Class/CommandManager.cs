using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CommandManager : MonoBehaviour
{
    private static CommandManager _instance;
    public static CommandManager Instance
    {

        get
        {
            if(_instance == null)
            {
                Debug.Log("[Command Manager] There is no command manager");
            }

            return _instance;
        }
    }

    private List<ICommand> _commandBuffer = new List<ICommand>();

    private void Awake()
    {
        _instance = this;
    }

    //Method to "add" commands to the command list/buffer
    public void AddCommand(ICommand command)
    {
        _commandBuffer.Add(command);
    }

    //Play routine triggered by a play method that's going to play back all the commands
    //1 second delay
    public void Play()
    {
        StartCoroutine(PlayRoutine());
    }

    IEnumerator PlayRoutine()
    {
        foreach(var command in _commandBuffer)
        {
            command.Execute();
            yield return new WaitForSeconds(1.0f);
        }

        Debug.Log("Finish");
    }

    public void Rewind()
    {
        StartCoroutine(RewindRoutine());

    }

    IEnumerator RewindRoutine()
    {
        foreach (var command in Enumerable.Reverse(_commandBuffer))
        {
            command.Undue();
            yield return new WaitForSeconds(1.0f);

        }
    }


    public void Reset()
    {
        _commandBuffer.Clear();
    }
}
