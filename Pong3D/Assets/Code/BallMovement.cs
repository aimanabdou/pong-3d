using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random=UnityEngine.Random;


public class BallMovement : MonoBehaviour
{
    public enum BallDirection
    {
        TO_PLAYER_ONE,
        TO_PLAYER_TWO
    }

    private Vector3 initialImpulse;
    private Rigidbody ballObject;
    private int ballSpeed; 
    public BallDirection ballDirection;
    






    // Start is called before the first frame update
    void Start()
    {
        this.ballSpeed = 30;

        this.initialImpulse = calculateBallDirection(ballDirection);
        this.ballObject = GetComponent<Rigidbody>();
        this.ballObject.AddForce(initialImpulse, ForceMode.Impulse);
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private Vector3 calculateBallDirection(BallDirection ballDirection){


        int xValue = this.ballSpeed;
        int yValue = 4;


    Vector3 directionVector;

    switch (ballDirection)
    {
        case BallDirection.TO_PLAYER_ONE:
            directionVector = new Vector3(-xValue,0,yValue);
            break;

        case BallDirection.TO_PLAYER_TWO:
            directionVector = new Vector3(xValue,0,yValue);
            break;

        default:
            directionVector = new Vector3(-xValue,0,yValue);
            break;
    }
        
        return directionVector;
    }

    void OnCollisionEnter(Collision collision) {
        GameObject otherObj = collision.gameObject;
        Debug.Log("Collided with: " + otherObj);
    }
    
}
