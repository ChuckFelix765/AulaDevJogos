using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MP : MonoBehaviour
{
    Scene scene = SceneManager.GetActiveScene();
    public void start(){
        SceneManager.LoadScene("Principal");
    }
    // public void reset(){
    //     SceneManager.LoadScene("Menu");
    // }
    // public void jogar(){
    //     SceneManager.LoadScene("CenaJupiter");
    // }
    // public void sair(){
    //     Debug.Log("Sair!");
    //     Application.Quit();
    // }
}