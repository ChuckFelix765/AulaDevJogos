using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text livesText;

    private Player player;
    private Invaders invaders;
    //private MysteryShip mysteryShip;
    //private Bunker[] bunkers;

    public int score { get; private set; } = 0;
    public int lives { get; private set; } = 3;
    // Start is called before the first frame update
    public void start(){
        this.lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (lives <= 0 && Input.GetKeyDown(KeyCode.Return)) {
            if (scene.name == "Principal"){
                SceneManager.LoadScene("Vitoria");
            }
        }
    }
}
