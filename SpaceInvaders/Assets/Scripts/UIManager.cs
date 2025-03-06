using UnityEngine;
using UnityEngine.UI; // Para UI padrão
using TMPro; // Se estiver usando TextMeshPro
using UnityEngine.SceneManagement;
using System.Numerics;

public class UIManager : MonoBehaviour
{
    public TMP_Text Lifetxt;
    public TMP_Text Scoretxt;
    GameObject hp1, hp2;

    private int Life = 3;
    private int Score = 0;
    private int scr = 0;

    
    void Start()
    {
        hp1 = GameObject.FindGameObjectWithTag("HP1");
        hp2 = GameObject.FindGameObjectWithTag("HP2");
        AtualizarUI();
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
        if(scr == 40){
            SceneManager.LoadScene("Vitoria");
        }
    }

    void AtualizarUI()
    {
        
        Lifetxt.text = "Life: " + Life;

        Scoretxt.text = "Score: " + Score;
    }
}
