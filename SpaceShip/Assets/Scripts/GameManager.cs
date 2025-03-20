using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    Text Life;

    Text Score;
    GameObject hp1, hp2;
    public int vidas = 3;
    public int pontos = 0;
    private int num_inimigos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ModificarVelocidade(float valor){
        Parallax.slw = valor;
    }


        void AtualizarUI()
    {
        
        Life.text = "Life: " + vidas;

        Score.text = "Score: " + Score;
    }

        public void AdicionarScore(int valor)
    {
        pontos += valor;
        
        AtualizarUI();

    }
        public void Matando(int valor){
            num_inimigos = num_inimigos-valor;
            if(num_inimigos <= 0){
                SceneManager.LoadScene("Vitoria");
            }
        }


}
