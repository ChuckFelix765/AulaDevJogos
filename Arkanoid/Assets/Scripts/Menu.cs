using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void start(){
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene("Intro");
    }
    public void reset(){
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene("Menu");
    }
    public void jogar(){
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene("CenaJupiter");
    }
    public void sair(){
        Debug.Log("Sair!");
        Application.Quit();
    }
}
