using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Text Lifetxt;
    public Text Scoretxt;
    GameObject hp1, hp2;
    private int Life = 3;
    public int Score = 0;
    private int scr = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
        void AtualizarUI()
    {
        
        Lifetxt.text = "Life: ";

        Scoretxt.text = "Score: " + Score;
    }

        public void AdicionarScore(int valor)
    {
        Score += valor;
        scr++;
        AtualizarUI();

    }
    void update()
    {

    }
}
