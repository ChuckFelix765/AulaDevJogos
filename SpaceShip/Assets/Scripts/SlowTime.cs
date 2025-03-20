using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro_invader : MonoBehaviour
{
    // Start is called before the first frame update
    public float vel;
    public float tempoVida;
    private float tempo_efeito = 5.0f;

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

        tempo_efeito -= Time.deltaTime;
        transform.position += new Vector3(-vel, 0, 0)*Time.deltaTime;

        if(tempo_efeito <=0){
            FindAnyObjectByType<GameManager>().ModificarVelocidade(2f);
            print("Efeito Desativado");
        }

        // print(tempo_efeito);
        // if(tempo_efeito != 0){
        //     print("Aqui1");
        //     tempo_efeito -= Time.deltaTime;
        //     if (tempo_efeito == 0){
        //         print("Aqui2");
        //         tempo_efeito = 0;
        //         FindAnyObjectByType<GameManager>().ModificarVelocidade(1.0f);
        //     }
        // }
    }

    void OnTriggerEnter2D(Collider2D coll){
        if (coll.gameObject.tag == "Player"){
            FindFirstObjectByType<GameManager>().ModificarVelocidade(0.5f);
            tempo_efeito = 5.0f;
            Destroy(gameObject);
            print("Efeito ativado");
        }
    }
}
