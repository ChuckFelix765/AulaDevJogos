using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum GameState {Stop, Play, Win, GameOver,Pause};
public class GameManager : MonoBehaviour {
    public static GameManager instance;
    //Coisas da tela
    [SerializeField]
    Text txtVida;
    [SerializeField]
    Text txtScore;
    [SerializeField]
    Text txtMsg;
    //Bola e player
    [SerializeField]
    private GameObject Ball;
    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private GameObject BotWall;
    public GameState gameState;

    private float score = 0f;
    public float vidas = 3f;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            if(instance !=this)
            {
                Destroy(this);
            }
        }

    }
    void Start () {
        gameState = GameState.Stop;
	}
	
	//Update is called once per frame
	void Update () {
        
        if (Input.GetKeyUp(KeyCode.Space) && gameState == GameState.Stop)
        {
            StartGame();
        }
        txtScore.text = "Score " + score;
        txtVida.text = "Vidas: " + vidas;
        if ((Input.GetKeyDown(KeyCode.Space) && gameState == GameState.Play) || (Input.GetKeyDown(KeyCode.Space) && gameState == GameState.Pause))
        {
            PauseGame();
        }

        if (BlockController.instance.GetTLBlocks() <= 0 && gameState == GameState.Play)
        {
            LoadEndGame(GameState.Win);
        }
    }
    public void StartGame()
    {
        gameState = GameState.Play;
        score = 0;
        Ball.GetComponent<Ball>().GoBall();
        txtMsg.gameObject.SetActive(false);
    }

    public void ResetBall(){

    }
    public void LoadEndGame(GameState valor)
    {
        
        gameState = valor;
        txtMsg.gameObject.SetActive(true);

        if(this.vidas < 0){ 
            GameManager.instance.LoadEndGame(GameState.GameOver);
        }

        if(gameState == GameState.GameOver)
        {
            SceneManager.LoadScene("Derrota");
            txtMsg.text = "GAME OVER";
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
            txtMsg.text = "WIN!!!!";
        }
        if(Ball != null)
        {
            Ball.SetActive(false);
        }
        Invoke("RestartGame", 5);
    }

    public void AddPoints(float valor)
    {
        this.score += valor;
    }
    public void SubVida(float valor)
    {
        this.vidas -= valor;


    }


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PauseGame()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            gameState = GameState.Play;
            txtMsg.gameObject.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            gameState = GameState.Pause;
            txtMsg.gameObject.SetActive(true);
            txtMsg.text = "PAUSE \n PRESS SPACE TO CONTINUE";
        }
    }
}