using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro_invader : MonoBehaviour
{
    // Start is called before the first frame update
    public float vel;
    public float tempoVida;
    private float tempo_efeito;
        void OnEnable()
    {
        Invoke("Desligar", tempoVida);
    }
        void Desligar()
    {
        gameObject.SetActive(false);
    }
        void OnDesabled(){
        CancelInvoke();
    }


    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-vel, 0, 0)*Time.deltaTime;
        tempo_efeito = tempo_efeito - 1*Time.deltaTime;
        print(tempo_efeito);
        if(tempo_efeito == -5 ){
            FindAnyObjectByType<GameManager>().ModificarVelocidade(1.0f);
        }
    }


    void OnTriggerEnter2D(Collider2D coll){
        if (coll.gameObject.tag == "Player"){
            Destroy(gameObject);
            FindFirstObjectByType<GameManager>().ModificarVelocidade(0.5f);
            // tempo_efeito = tempo_efeito - 1*Time.deltaTime;
            // if(tempo_efeito == 0 ){
            //     FindAnyObjectByType<GameManager>().ModificarVelocidade(1.0f);
            // }

        }
    }
}
