using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Cenas : MonoBehaviour
{
    public void inicio (){
        SceneManager.LoadScene("Principal");
    }
    public void Reset(){
        SceneManager.LoadScene("Menu");
    }
    public void sair(){
        Debug.Log("Sair!");
        Application.Quit();
    }
}
