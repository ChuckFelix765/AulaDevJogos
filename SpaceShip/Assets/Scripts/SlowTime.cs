using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro_invader : MonoBehaviour
{
    // Start is called before the first frame update
    public float vel;
    public float tempoVida;
    public float tempo_efeito;
    private int ativado = 0;

    void OnEnable(){
        Invoke("Desligar", tempoVida);
    }
    
    void Desligar(){
        gameObject.SetActive(false);
    }

    void OnDesabled(){
        CancelInvoke();
    }


    // Update is called once per frame
    void Update(){
        transform.position += new Vector3(-vel, 0, 0)*Time.deltaTime;


    }

    void OnTriggerEnter2D(Collider2D coll){
        if (coll.gameObject.tag == "Player"){
            Destroy(gameObject);
        }
    }
}
