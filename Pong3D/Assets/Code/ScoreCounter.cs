using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class ScoreCounter : MonoBehaviour
{
    public Text score;
    private GameObject ball;
    private int scorePlayerOne = 0;
    private int scorePlayerTwo = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.ball
        
        
 = GameObject.Find("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        setScore();
    }

    private void setScore(){
        if(ball
        
        
 != null){
            this.scorePlayerOne = this.ball
            
            
            
    .GetComponent<BallMovement>().getScorePlayerOne();
            this.scorePlayerTwo = this.ball
            
            
            
    .GetComponent<BallMovement>().getScorePlayerTwo();
        }

        if(score != null){
            score.text = this.scorePlayerTwo + ":" + this.scorePlayerOne;
        }
    }

    // private void ballCollisionDetection(){
    //     if(this.ball == null){
    //         return; 
    //     }

    //     if(ball.name == "PlayerOnePointCounter"){
    //         this.scorePlayerOne++; 
    //         Debug.Log("SCORE: " + this.ball.name);
    //         score.text = scorePlayerOne + ":" + scorePlayerTwo;
    //     }
        
        
    // }

    // void OnCollisionEnter(Collision collision) {
    //     GameObject ball = collision.ball;

    //     Debug.Log("SCORE: " + this.ball.name);
    // }
}
