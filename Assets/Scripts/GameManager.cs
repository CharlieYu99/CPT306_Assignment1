using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameState
{
    menu,
    inGame,
    pause,
    gameOver
}
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameState currentGameState = GameState.menu;
    public static GameManager instance;

    public Canvas menuCanvas;
    public Canvas inGameCanvas;
    public Canvas pauseCanvas;
    public Canvas gameOverCanvas;

    public int debrisCounter = 0;
    public int DH = 0;
    public int IPG = 0;
    public int S = 0;
    public int R = 0;
    public int G = 0;
    public int B = 0;
    public int RGB = 0;

    private int ScoreValue_DH = 5;
    private int ScoreValue_RGB = 15;
    private int ScoreValue_RRRGGGBBB = 10;



    private void Awake() {
        instance = this;
    }
    void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        // if (Input.GetKeyDown(KeyCode.S)) StartGame();
    }


    public void StartGame(){

        SetGameState(GameState.inGame);
    }

    public void GameOver(){
        SetGameState(GameState.gameOver);
    }

    public void GamePause(){
        SetGameState(GameState.pause);
    }

    public void BackToMenu(){
        SetGameState(GameState.menu);
    }

    void SetGameState (GameState newGameState)
    {
        if (newGameState == GameState.menu)
        {
            //  setup Unity scene for menu state
            menuCanvas.enabled = true;
            inGameCanvas.enabled = false;
            pauseCanvas.enabled = false;
            gameOverCanvas.enabled = false;
        }
        else if (newGameState == GameState.inGame)
        {
            //  setup Unity scene for inGame state
            menuCanvas.enabled = false;
            inGameCanvas.enabled = true;
            pauseCanvas.enabled = false;
            gameOverCanvas.enabled = false;

        }
        else if (newGameState == GameState.pause)
        {
            //  setup Unity scene for pause state
            menuCanvas.enabled = false;
            inGameCanvas.enabled = true;
            pauseCanvas.enabled = true;
            gameOverCanvas.enabled = false;

            // 

        }
        else if (newGameState == GameState.gameOver)
        {
            //  setup Unity scene for gameOver state
            menuCanvas.enabled = false;
            inGameCanvas.enabled = false;
            pauseCanvas.enabled = false;
            gameOverCanvas.enabled = true;

        }

        currentGameState = newGameState;
    }

    public void DebrisAdded(){
        debrisCounter ++;
        if (debrisCounter >= 5){
            // "Opps! Debris are filled in the storage! " in Black
            GameOver();
        }
    }

    public void DHAdded(){
        DH++;
        S += ScoreValue_DH;
    }

    public void RAdded(){
        R++;
        IPG++;
        S += ScoreValue_RRRGGGBBB;
    }
    
    public void GAdded(){
        G++;
        IPG++;
        S += ScoreValue_RRRGGGBBB;
    }
    
    public void BAdded(){
        B++;
        IPG++;
        S += ScoreValue_RRRGGGBBB;
    }

    public void RGBAdded(){
        RGB++;
        IPG++;
        S += ScoreValue_RGB;
    }


}
