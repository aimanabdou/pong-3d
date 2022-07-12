using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 Vec;
    private float speed;
    private float boundary; 
    public Rigidbody playerObject;

    public Player player;

    // public Transform ball;
    // private float aiPlayerSpeed;
    // private float boundary; 

    public enum Player
    {
        PLAYER_ONE,
        PLAYER_TWO
    }

    

    // Start is called before the first frame update
    void Start()
    {
        this.playerObject = GetComponent<Rigidbody>();
        this.speed = 5000.0f;
        this.boundary = 280.0f;
        //this.boundary = 10.0f;
        
        // this.aiPlayerSpeed = 2.0f; 


    }

    // Update is called once per frame
    void Update()
    {
        if(this.player == Player.PLAYER_ONE){
            this.playerOne();
        } else if(this.player == Player.PLAYER_TWO /*&& PlayerPrefs.GetString("PlayerTwo") == "secondPlayer"*/){
            this.playerTwo();
        } 
        // else if(this.player == Player.PLAYER_TWO && PlayerPrefs.GetString("PlayerTwo") == "PongAI"){
        //     this.pongAI();
        // }
        



        // bool keyPressUP = Input.GetKey(KeyCode.UpArrow);
        // bool keyPressDown = Input.GetKey(KeyCode.DownArrow);

        // float positionZ = this.transform.position.z;
        
        // if (Input.GetKey(KeyCode.UpArrow))
        // {
        //     // Debug.Log(this.playerObject.toString());
        //     if (positionZ<this.boundary) {
        //         Vector3 tempVect = new Vector3(0, 0, 1);
        //         tempVect = tempVect.normalized * Time.deltaTime * speed;
        //         playerObject.MovePosition(transform.position  + tempVect);
        //         // //this.transform.Translate(Vector3.down * this.speed);
        //     }
        // }

        // if (Input.GetKey(KeyCode.DownArrow))
        // {
        //     if (positionZ > -this.boundary)
        //     {
        //         Vector3 tempVect = new Vector3(0, 0, -1);
        //         tempVect = tempVect.normalized * Time.deltaTime * speed;
        //         playerObject.MovePosition(transform.position  + tempVect);

        //         //this.transform.Translate(Vector3.up * this.speed);
        //     }
        // }

        // //if (Input.GetKey(KeyCode.LeftArrow))
        // //{
        // //    this.transform.Rotate(Vector3.up, -10);
        // //}

        // //if (Input.GetKey(KeyCode.RightArrow))
        // //{
        // //    this.transform.Rotate(Vector3.up, 10);
        // //}
    }

    private void playerOne(){
        keyboardControl(KeyCode.W, KeyCode.S);
        // keyboardControl(KeyCode.UpArrow, KeyCode.DownArrow);
    }

    private void playerTwo(){
        keyboardControl(KeyCode.UpArrow, KeyCode.DownArrow);
        // keyboardControl(KeyCode.UpArrow, KeyCode.DownArrow);
        // Debug.Log(PlayerPrefs.GetString("PlayerTwo"));
    }

    // private void pongAI(){
    //     // Debug.Log(PlayerPrefs.GetString("PlayerTwo"));
    //     if (ball.transform.position.z > transform.position.z && transform.position.z < this.boundary)
    //     {
    //         transform.Translate(0, 0, this.aiPlayerSpeed);
    //     }

    //     if (ball.transform.position.z < transform.position.z && transform.position.z > -this.boundary)
    //     {
    //         transform.Translate(0, 0, -this.aiPlayerSpeed);
    //     }

    // }


    private void keyboardControl(KeyCode up, KeyCode down){
        // bool keyPressUP = Input.GetKey(KeyCode.UpArrow);
        // bool keyPressDown = Input.GetKey(KeyCode.DownArrow);

        bool keyPressUP = Input.GetKey(up);
        bool keyPressDown = Input.GetKey(down);

        float positionZ = this.transform.position.z;
        
        if (keyPressUP)
        {
            // Debug.Log(this.playerObject.toString());
            if (positionZ<this.boundary) {
                Vector3 tempVect = new Vector3(0, 0, 1);
                tempVect = tempVect.normalized * Time.deltaTime * speed;
                playerObject.MovePosition(transform.position  + tempVect);
                // //this.transform.Translate(Vector3.down * this.speed);
            }
        }

        if (keyPressDown)
        {
            if (positionZ > -this.boundary)
            {
                Vector3 tempVect = new Vector3(0, 0, -1);
                tempVect = tempVect.normalized * Time.deltaTime * speed;
                playerObject.MovePosition(transform.position  + tempVect);

                //this.transform.Translate(Vector3.up * this.speed);
            }
        }
    }
}

