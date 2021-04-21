using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : ICommand
{
    private GameObject _objectToMove;
    private float _distance;
    private Vector3 _direction = Vector3.zero;

    //This is a contructor for everytime a click happens on a objectToMove
    public MoveObject(GameObject objectToMove, Vector3 direction, float distance = 1.0f)
    {
        //The objectToMove you pass in from the user
        this._objectToMove = objectToMove;
        this._direction = direction;
        this._distance = distance;


    }

    public void Execute()
    {
        _objectToMove.transform.position += _direction * _distance;
    }

   public void Undue()
    {
        //To revert back or undo
        _objectToMove.transform.position -= _direction * _distance;
    }

    public Vector3 GetMove()
    {
        return _direction * _distance;
    }
}