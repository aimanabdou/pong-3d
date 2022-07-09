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

    // private GameObject playerOneGameObject = GameObject.Find("Players/PlayerOne");
    

    public AudioClip playerOneSoundEffect;
    public AudioClip playerTwoSoundEffect;
    public AudioClip wallSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        // this.playerOneGameObject = GameObject.Find("Players/PlayerOne");

        this.ballSpeed = 25;

        this.initialImpulse = calculateBallDirection(ballDirection);
        this.ballObject = GetComponent<Rigidbody>();
        this.ballObject.AddForce(initialImpulse, ForceMode.Impulse);

        GetComponent<AudioSource>().playOnAwake = false;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        this.ballObject.velocity = this.ballSpeed * (ballObject.velocity.normalized);
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
        GameObject gameObject = collision.gameObject;
        Transform parentGameObject = gameObject.transform.parent;
        // Debug.Log("Collided with: " + gameObject.name);


        
        if(gameObject.name == "PlayerOne"){
            GetComponent<AudioSource>().clip = playerOneSoundEffect;
            GetComponent<AudioSource>().Play();
            this.ballSpeed++;
        }

        if(gameObject.name == "PlayerTwo"){
            GetComponent<AudioSource>().clip = playerTwoSoundEffect;
            GetComponent<AudioSource>().Play();
            this.ballSpeed++;
        }

        Debug.Log("Collided with: " + parentGameObject.name);
        if(parentGameObject.name == "Upper Wall" || parentGameObject.name == "Lower Wall"){
            GetComponent<AudioSource>().clip = wallSoundEffect;
            GetComponent<AudioSource>().Play();
        }
        
        

        // switch (gameObject.name)
        // {
        //     case "PlayerOne":
                
        //         break;

        //     case "PlayerTwo":
  
        //         break;

        //     case "UpperLongWall":
        //         GetComponent<AudioSource>().clip = wallSoundEffect;
        //         GetComponent<AudioSource>().Play();
        //         break;

        //     default:

        //         break;
        // }

        
    }

}
