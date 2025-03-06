using UnityEngine;
using UnityEngine.UI; // Para UI padrão
using TMPro; // Se estiver usando TextMeshPro
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public TMP_Text Lifetxt;
    public TMP_Text Scoretxt;

    private int Life = 3;
    private int Score = 0;
    private int scr = 0;

    void Start()
    {
        AtualizarUI();
    }

    public void ModificarVida(int valor)
    {
        Life += valor;
        AtualizarUI();
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
        Lifetxt.text = "Vida: " + Life;
        Scoretxt.text = "Score: " + Score;
    }
}
