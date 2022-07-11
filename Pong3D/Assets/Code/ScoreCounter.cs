using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class ScoreCounter : MonoBehaviour
{
    public Text score;
    public Text winnerMessage;
    private GameObject ball;
    private int scorePlayerOne = 0;
    private int scorePlayerTwo = 0;
    private int winningScore = 3;

    // Start is called before the first frame update
    void Start()
    {
        this.ball = GameObject.Find("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        setScore();
    }

    private void setScore(){
        if(ball == null){
            return;
        }


        if(score == null){
            return;
        }

        this.scorePlayerOne = this.ball.GetComponent<BallMovement>().getScorePlayerOne();
        this.scorePlayerTwo = this.ball.GetComponent<BallMovement>().getScorePlayerTwo();

        // score.color = Color.white;
        score.text = this.scorePlayerTwo + ":" + this.scorePlayerOne;
        
        if(this.scorePlayerOne >= this.winningScore){
            winnerMessage.text = "RED\nWINS";
            winnerMessage.color = Color.red;
            // this.ball.GetComponent<BallMovement>().resetBall();
            this.ball.GetComponent<BallMovement>().stopBall();
            return;
        }

        if(this.scorePlayerTwo >= this.winningScore){

            winnerMessage.text = "BLUE\nWINS";
            winnerMessage.color = Color.blue;

            // this.ball.GetComponent<BallMovement>().resetBall();
            this.ball.GetComponent<BallMovement>().stopBall();

            return;
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
