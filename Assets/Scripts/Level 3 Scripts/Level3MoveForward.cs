using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3MoveForward : MonoBehaviour
{
    public float speed = 3;

    void Start()
    {
        Destroy(gameObject,25);

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

    }
}
