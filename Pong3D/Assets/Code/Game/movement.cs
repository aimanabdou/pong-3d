using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class movement : MonoBehaviour
{
    private float movementSpeed = 0.1f;
    private int steps = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Vector3 position = this.transform.position;
            //position.x--;
            for (int i = 0; i< steps; i++) {
                Thread.Sleep(100);
                //Task.Delay(1000);
                position.x += movementSpeed;
            }
            
            this.transform.position = position;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Vector3 position = this.transform.position;
            //position.x++;
            for (int i = 0; i < steps; i++)
            {
                position.x -= movementSpeed;
            }
            position.x -= movementSpeed;
            this.transform.position = position;
        }

    }
}
