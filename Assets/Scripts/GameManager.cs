using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameState
{
    menu,
    inGame,
    gameOver
}
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameState currentGameState = GameState.menu;
    public static GameManager instance;

    private void Awake() {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        if (Input.GetKeyDown(KeyCode.S)) StartGame();
    }


    public void StartGame(){
        SetGameState(GameState.inGame);
    }

    public void GameOver(){
        SetGameState(GameState.gameOver);
    }

    public void BackToMenu(){
        SetGameState(GameState.menu);
    }

        void SetGameState (GameState newGameState)
    {
        if (newGameState == GameState.menu)
        {
            //  setup Unity scene for menu state

        }
        else if (newGameState == GameState.inGame)
        {
            //  setup Unity scene for inGame state

        }
        else if (newGameState == GameState.gameOver)
        {
            //  setup Unity scene for gameOver state

        }

        currentGameState = newGameState;
    }
}
