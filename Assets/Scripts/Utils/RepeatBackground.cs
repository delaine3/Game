using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 beginningPlace;
    private float halfWay;

    // Start is called before the first frame update
    void Start()
    {
        //The start position is whereer we are at the beginning
        beginningPlace = transform.position;

        //Get halfway point of the box collider around the background plane
        halfWay = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        //Once we get halfway
        if(transform.position.x < beginningPlace.x -halfWay)
        {
            //return to the starting position
            transform.position = beginningPlace;
        }
    }
}
