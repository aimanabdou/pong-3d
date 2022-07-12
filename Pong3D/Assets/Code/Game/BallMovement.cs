using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random=UnityEngine.Random;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour
{
    public enum BallDirection
    {
        TO_PLAYER_ONE,
        TO_PLAYER_TWO
    }

    private Vector3 initialImpulse;
    private Rigidbody ballObject;
    public const int STANDARD_BALL_SPEED = 800;
    private int ballSpeed; 
    public BallDirection ballDirection;
    

    // private GameObject playerOneGameObject = GameObject.Find("Players/PlayerOne");
    

    public AudioClip playerOneSoundEffect;
    public AudioClip playerTwoSoundEffect;
    public AudioClip wallSoundEffect;
    public AudioClip goalSoundEffect;

    private int scorePlayerOne = 0; 
    private int scorePlayerTwo = 0; 

    private Vector3 originalPosition;

    // public Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        // this.playerOneGameObject = GameObject.Find("Players/PlayerOne");
        this.ballSpeed = STANDARD_BALL_SPEED;

        this.initialImpulse = calculateBallDirection(ballDirection);
        this.ballObject = GetComponent<Rigidbody>();
        this.ballObject.AddForce(initialImpulse, ForceMode.Impulse);

        GetComponent<AudioSource>().playOnAwake = false;

        this.originalPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        
        GetComponent<Rigidbody>().AddForce(initialImpulse, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        this.ballObject.velocity = this.ballSpeed * (ballObject.velocity.normalized);

        if (Input.GetKey(KeyCode.Return))
        {
            if(ballObject.velocity.magnitude == 0.0f){
                // Application.LoadLevel(Application.loadedLevel);
                SceneManager.LoadScene("Pong3DField", LoadSceneMode.Single);

                // this.ballObject.velocity = this.ballSpeed * (ballObject.velocity.normalized);
                // GetComponent<Rigidbody>().AddForce(initialImpulse, ForceMode.Impulse);
            }
        }
    }

    private Vector3 calculateBallDirection(BallDirection ballDirection){
        

        int xValue = this.ballSpeed;
        int yValue = 300;


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

        if(parentGameObject == null){
            return;
        }
        // Debug.Log("Collided with: " + parentGameObject.name);
        if(gameObject.name == "PlayerOne"){
            this.playSound(playerOneSoundEffect);
            // GetComponent<AudioSource>().clip = playerOneSoundEffect;
            // GetComponent<AudioSource>().Play();
            this.ballSpeed += 32;
        }

        if(gameObject.name == "PlayerTwo"){
            this.playSound(playerTwoSoundEffect);
            // GetComponent<AudioSource>().clip = playerTwoSoundEffect;
            // GetComponent<AudioSource>().Play();
            this.ballSpeed += 32;
        }

        // Debug.Log("Collided with: " + parentGameObject.name);

        if(parentGameObject.name == "Upper Wall" || parentGameObject.name == "Lower Wall"){
            this.playSound(wallSoundEffect);
            // GetComponent<AudioSource>().clip = wallSoundEffect;
            // GetComponent<AudioSource>().Play();
        }

        if(gameObject.name == "PlayerOnePointCounter"){
            this.scorePlayerOne++;
            this.playSound(goalSoundEffect);
            this.resetBall();
        }

        if(gameObject.name == "PlayerTwoPointCounter"){
            this.scorePlayerTwo++;
            this.playSound(goalSoundEffect);
            this.resetBall();
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

    private void resetBall(){
        this.ballSpeed = STANDARD_BALL_SPEED;
        transform.position = originalPosition;
    }

    private void playSound(AudioClip audioClip){
        if(audioClip == null){
            return; 
        }
        GetComponent<AudioSource>().clip = audioClip;
        GetComponent<AudioSource>().Play();
    }

    public int getScorePlayerOne(){
        return this.scorePlayerOne; 
    }

    public int getScorePlayerTwo(){
        return this.scorePlayerTwo; 
    }

    public void resetScore(){
        this.scorePlayerOne = 0;
        this.scorePlayerTwo = 0; 
    }

    public void stopBall(){
        this.ballObject.velocity = Vector3.zero;

        if(ballObject.velocity.magnitude > 0.0f){
            this.ballObject.velocity = Vector3.zero;
        }
    }

    

}
