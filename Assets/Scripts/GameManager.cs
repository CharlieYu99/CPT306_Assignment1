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
}
