using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class ScoreCounter : MonoBehaviour
{
    public Text score;
    public Text winnerMessage;
    public Text restartGame;
    private GameObject ball;
    private int scorePlayerOne = 0;
    private int scorePlayerTwo = 0;
    private int winningScore = 3;

    // Start is called before the first frame update
    void Start()
    {
        this.ball = GameObject.Find("Ball");

        this.winnerMessage.text = "";
        this.restartGame.text = "";

        // this.winnerMessage.SetActive(false);
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
            this.winnerMessage.text = "RED\nWINS";
            this.winnerMessage.color = Color.red;

            this.restartGame.text = "Press [Return] to restart game";
            this.ball.GetComponent<BallMovement>().stopBall();
            return;
        }

        if(this.scorePlayerTwo >= this.winningScore){

            this.winnerMessage.text = "BLUE\nWINS";
            this.winnerMessage.color = Color.blue;

            this.restartGame.text = "Press [Return] to restart game";
            this.ball.GetComponent<BallMovement>().stopBall();

            return;
        }

        // if(this.scorePlayerOne >= this.winningScore || this.scorePlayerTwo >= this.winningScore){
        //     this.restartGame.text = "Press [Return] to restart game";
        //     this.ball.GetComponent<BallMovement>().stopBall();
        // }



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
