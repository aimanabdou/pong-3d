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

    public enum Player
    {
        PLAYER_ONE,
        PLAYER_TWO
    }

    void Start()
    {
        this.playerObject = GetComponent<Rigidbody>();
        this.speed = 1500.0f;
        this.boundary = 265.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.player == Player.PLAYER_ONE){
            this.playerOne();
        } else if(this.player == Player.PLAYER_TWO){
            this.playerTwo();
        } 
    }

    private void playerOne(){
        keyboardControl(KeyCode.W, KeyCode.S);
    }

    private void playerTwo(){
        keyboardControl(KeyCode.UpArrow, KeyCode.DownArrow);
    }

    private void keyboardControl(KeyCode up, KeyCode down){
        bool keyPressUP = Input.GetKey(up);
        bool keyPressDown = Input.GetKey(down);

        float positionZ = this.transform.position.z;
        
        if (keyPressUP)
        {
            if (positionZ<this.boundary) {
                Vector3 tempVect = new Vector3(0, 0, 1);
                tempVect = tempVect.normalized * Time.fixedDeltaTime * this.speed;
                playerObject.MovePosition(transform.position  + tempVect);
            }
        }

        if (keyPressDown)
        {
            if (positionZ > -this.boundary)
            {
                Vector3 tempVect = new Vector3(0, 0, -1);
                tempVect = tempVect.normalized * Time.fixedDeltaTime * speed;
                playerObject.MovePosition(transform.position  + tempVect);
            }
        }
    }
}

