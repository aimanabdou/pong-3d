using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 Vec;
    private float speed;
    private float boundary; 
    public Rigidbody playerObject;

    public enum Player
    {
        PLAYER_ONE,
        PLAYER_TWO
    }

    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        this.playerObject = GetComponent<Rigidbody>();
        this.speed = 5000.0f;
        this.boundary = 280.0f;
        //this.boundary = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {

        bool keyPressUP = Input.GetKey(KeyCode.UpArrow);
        bool keyPressDown = Input.GetKey(KeyCode.DownArrow);

        float positionZ = this.transform.position.z;
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            // Debug.Log(this.playerObject.toString());
            if (positionZ<this.boundary) {
                Vector3 tempVect = new Vector3(0, 0, 1);
                tempVect = tempVect.normalized * Time.deltaTime * speed;
                playerObject.MovePosition(transform.position  + tempVect);
                // //this.transform.Translate(Vector3.down * this.speed);
            }
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (positionZ > -this.boundary)
            {
                Vector3 tempVect = new Vector3(0, 0, -1);
                tempVect = tempVect.normalized * Time.deltaTime * speed;
                playerObject.MovePosition(transform.position  + tempVect);

                //this.transform.Translate(Vector3.up * this.speed);
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

