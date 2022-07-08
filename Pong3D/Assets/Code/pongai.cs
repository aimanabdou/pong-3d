using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pongai : MonoBehaviour
{
    public Transform ball;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (ball.transform.position.y > transform.position.y)
        {
            transform.Translate(0, .1f, 0);
        }

        if (ball.transform.position.y < transform.position.y)
        {
            transform.Translate(0, -.1f, 0);
        }

        if (transform.position.y > 7.5f)
        {
            transform.position = new Vector3(-15, 7.5f, 0);
        }

        if (transform.position.y < -7.5f)
        {
            transform.position = new Vector3(-15, -7.5f, 0);
        }
    }
}