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
        
        score.text = this.scorePlayerTwo + ":" + this.scorePlayerOne;

        if(this.scorePlayerOne >= this.winningScore){
            this.winnerMessage.text = "RED\nWINS";
            this.winnerMessage.color = Color.red;

            this.restartGame.text = "Press [Return] to go back to the menu";
            this.ball.GetComponent<BallMovement>().stopBall();
            return;
        }

        if(this.scorePlayerTwo >= this.winningScore){

            this.winnerMessage.text = "BLUE\nWINS";
            this.winnerMessage.color = Color.blue;

            this.restartGame.text = "Press [Return] to go back to the menu";
            this.ball.GetComponent<BallMovement>().stopBall();

            return;
        }
    }
}
