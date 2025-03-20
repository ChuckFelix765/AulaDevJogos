using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour{
    public TMP_Text Life;
    public TMP_Text Score;
    GameObject hp1, hp2;
    private int vidas = 3;
    private int pontos = 0;
    private int num_inimigos = 20;

    public void ModificarVelocidade(float valor){
        Parallax.slw = valor;
    }

    public void AdicionarScore(int valor){
        pontos += valor;
        AtualizarUI();
    }

    public void MudarVida(int valor){
        vidas += valor;
        if(vidas == 0){
            SceneManager.LoadScene("Derrota");
        }
        AtualizarUI();
    }

    void AtualizarUI(){
        Life.text = "Life: " + vidas;        
        Score.text = "Score: " + pontos;
    }

    public void Matando(int valor){
        num_inimigos = num_inimigos-valor;
        if(num_inimigos <= 0){
            SceneManager.LoadScene("Vitoria");
        }
    }
}
