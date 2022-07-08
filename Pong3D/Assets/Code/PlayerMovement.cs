using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 Vec;

    private float speed;
    private float boundary; 

    // Start is called before the first frame update
    void Start()
    {
        this.speed = 0.05f;
        this.boundary = 1000.0f;
        //this.boundary = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        float positionZ = this.transform.position.z;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (positionZ<this.boundary) {
                this.transform.Translate(Vector3.down * this.speed);
            }
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (positionZ > -this.boundary)
            {
                this.transform.Translate(Vector3.up * this.speed);
            }
        }

        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    this.transform.Rotate(Vector3.up, -10);
        //}

        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    this.transform.Rotate(Vector3.up, 10);
        //}
    }
}

