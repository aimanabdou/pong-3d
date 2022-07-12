using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongAI : MonoBehaviour
{
    public Transform ball;
    private float aiPlayerSpeed;
    private float boundary; 

    // Use this for initialization
    void Start()
    {
        this.aiPlayerSpeed = 3.0f; 
        this.boundary = 265.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (PlayerPrefs.GetString("PlayerTwo") == "PongAI"){
            if (ball.transform.position.z > transform.position.z && transform.position.z < this.boundary)
            {
                transform.Translate(0, 0, this.aiPlayerSpeed);
            }

            if (ball.transform.position.z < transform.position.z && transform.position.z > -this.boundary)
            {
                transform.Translate(0, 0, -this.aiPlayerSpeed);
            }
        }
        
    }
}