using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public GameState currentGameState = GameState.inGame;
    public static GameManager instance;

    // public Canvas menuCanvas;
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

    public Text Text_DH;
    public Text Text_IPG;
    public Text Text_S;
    public Text Text_T;
    public Text Text_R;
    public Text Text_G;
    public Text Text_B;
    public Text Text_RGB;
    public Text Text_Gameover;
    public Text Text_Gameover_detail;
    private float timeSpend = 0.0f;



    private void Awake() {
        instance = this;
    }
    void Start()
    {
        StartGame();
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) GamePause();
    }

    private void FixedUpdate() {
        
        timeSpend += Time.fixedDeltaTime;

        int hour = (int)timeSpend / 3600;
        int minute = ((int)timeSpend - hour * 3600) / 60;
        int second = (int)timeSpend - hour * 3600 - minute * 60;
        int millisecond = (int)((timeSpend - (int)timeSpend) * 1000);

        Text_T.text = string.Format("{0:D2}:{1:D2}",minute,second);


    }


    public void StartGame(){

        SetGameState(GameState.inGame);
    }

    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame(){
        Application.Quit();
    }

    public void GameOver(bool win, string text, Color color){
        if (win){
            Text_Gameover.text = "You win!";
        }
        Text_Gameover_detail.text = text;
        Text_Gameover_detail.color = color;

        SetGameState(GameState.gameOver);
    }

    public void GamePause(){
        if (Time.timeScale == 1){
            Time.timeScale = 0;
            SetGameState(GameState.pause);
        }else{
            Time.timeScale = 1;
            SetGameState(GameState.inGame);
        }
        
    }

    public void BackToMenu(){
        SetGameState(GameState.menu);
    }

    void SetGameState (GameState newGameState)
    {
        if (newGameState == GameState.menu)
        {
            //  setup Unity scene for menu state
            // menuCanvas.enabled = true;
            inGameCanvas.enabled = false;
            pauseCanvas.enabled = false;
            gameOverCanvas.enabled = false;
        }
        else if (newGameState == GameState.inGame)
        {
            //  setup Unity scene for inGame state
            // menuCanvas.enabled = false;
            inGameCanvas.enabled = true;
            pauseCanvas.enabled = false;
            gameOverCanvas.enabled = false;

        }
        else if (newGameState == GameState.pause)
        {
            //  setup Unity scene for pause state
            // menuCanvas.enabled = false;
            inGameCanvas.enabled = true;
            pauseCanvas.enabled = true;
            gameOverCanvas.enabled = false;

            // 

        }
        else if (newGameState == GameState.gameOver)
        {
            //  setup Unity scene for gameOver state
            // menuCanvas.enabled = false;
            inGameCanvas.enabled = true;
            pauseCanvas.enabled = false;
            gameOverCanvas.enabled = true;
            // SpaceFighter.instance.enabled = false;
            // ParticalGenerator.instance.enabled = false;
            Time.timeScale = 0;

        }

        currentGameState = newGameState;
    }

    public void DebrisAdded(){
        debrisCounter ++;
        if (debrisCounter > 5){
            // "Opps! Debris are filled in the storage!" in Black
            GameOver(false, "Opps! Debris are filled in the storage!", Color.black);
        }
    }

    public void DHAdded(){
        DH++;
        S += ScoreValue_DH;
        Text_DH.text = DH.ToString();
        Text_S.text = S.ToString();
        checkWin();
    
    }

    public void RAdded(){
        R++;
        IPG++;
        S += ScoreValue_RRRGGGBBB;
        Text_R.text = R.ToString();
        Text_IPG.text = IPG.ToString();
        Text_S.text = S.ToString();
        checkWin();
    }
    
    public void GAdded(){
        G++;
        IPG++;
        S += ScoreValue_RRRGGGBBB;
        Text_G.text = G.ToString();
        Text_IPG.text = IPG.ToString();
        Text_S.text = S.ToString();
        checkWin();
    }
    
    public void BAdded(){
        B++;
        IPG++;
        S += ScoreValue_RRRGGGBBB;
        Text_B.text = B.ToString();
        Text_IPG.text = IPG.ToString();
        Text_S.text = S.ToString();
        checkWin();
    }

    public void RGBAdded(){
        RGB++;
        IPG++;
        S += ScoreValue_RGB;
        Text_RGB.text = RGB.ToString();
        Text_IPG.text = IPG.ToString();
        Text_S.text = S.ToString();
        checkWin();
    }


    private void checkWin(){
        if (S >= 100){
            GameOver(true, "Congratulations! You Won! ", Color.yellow);
        }
    }
}
