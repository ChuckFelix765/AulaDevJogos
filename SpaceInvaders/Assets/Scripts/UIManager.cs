using UnityEngine;
using UnityEngine.UI; // Para UI padrão
using TMPro; // Se estiver usando TextMeshPro
using UnityEngine.SceneManagement;
using System.Numerics;
using System;

public class UIManager : MonoBehaviour
{
    public TMP_Text Lifetxt;
    public TMP_Text Scoretxt;
    GameObject hp1, hp2;

    private int Life = 3;
    public int Score = 0;
    private int scr = 0;

    public int matar;
    public float nv = 5f;
    
    void Start()
    {
        String cena = SceneManager.GetActiveScene().name;
        if(cena == "Principal"){
            matar = 40;
        }
        hp1 = GameObject.FindGameObjectWithTag("HP1");
        hp2 = GameObject.FindGameObjectWithTag("HP2");
        AtualizarUI();
    }

    public void velo(float vl){
        Invader[] inimigos = FindObjectsOfType<Invader>();
        foreach (Invader inimigo in inimigos)
        {
            inimigo.changeVel(vl); // Altera a velocidade de cada inimigo
        }
    }

    public void ModificarVida(int valor)
    {
        Life += valor;
        AtualizarUI();
        if(Life==2){
            hp1.SetActive(false);
        }
        else if(Life==1){
            hp2.SetActive(false);
        }
        if(Life == 0){
            SceneManager.LoadScene("Derrota");
        }
    }

    public void AdicionarScore(int valor)
    {
        Score += valor;
        scr++;
        AtualizarUI();

    }
    public void Matando(int valor){
        
        matar = matar-valor;
        if(matar <= 35){
            velo(nv);
        }
        if(matar<=0){
            SceneManager.LoadScene("Vitoria");
        }
    }

    void AtualizarUI()
    {
        
        Lifetxt.text = "Life: ";

        Scoretxt.text = "Score: " + Score;
    }
}
