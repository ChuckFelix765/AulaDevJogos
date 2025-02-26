using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int PlayerScore1 = 0; // Pontuação do player 1
    public static int PlayerScore2 = 0; // Pontuação do player 2

    public GUISkin layout;              // Fonte do placar
    GameObject theBall;                 // Referência ao objeto bola
    // Start is called before the first frame update
    void Start () {
        theBall = GameObject.FindGameObjectWithTag("Ball"); // Busca a referência da bola
    }

    // incrementa a potuação
    public static void Score (string wallID) {
        if (wallID == "Bw")
        {
            PlayerScore2++;
        }
    }
    // Gerência da pontuação e fluxo do jogo
    void OnGUI () {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 350, 100, 100), "" + PlayerScore2);

        if(PlayerScore2 == 3){
            
            PlayerScore2 = 0;

            theBall.SendMessage("RestartGame", null, SendMessageOptions.RequireReceiver);

            GUI.Button(new Rect(Screen.width / 2 - 60, 35, 120, 53), "RESTART");
        }

        // if (PlayerScore2 == 10)
        // {
        //     GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER TWO WINS");
        //     theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        // }
    }
}