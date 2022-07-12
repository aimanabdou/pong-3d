using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SinglePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playSinglePlayerGame(){
        PlayerPrefs.SetString("PlayerTwo","secondPlayer"); 
        SceneManager.LoadScene("Pong3DField", LoadSceneMode.Single);
    }

    public void playMultiPlayerGame(){
        PlayerPrefs.SetString("PlayerTwo","PongAI"); 
        SceneManager.LoadScene("Pong3DField", LoadSceneMode.Single);
    }

    public void quitGame(){
        Application.Quit();
    }
}
