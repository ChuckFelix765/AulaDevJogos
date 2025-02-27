using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{

    private float vel = 10.0f;
    private Rigidbody2D rb2d;               // Define o corpo rigido 2D que representa a bola
    // Start is called before the first frame update
    // inicializa a bola randomicamente para esquerda ou direita
    void GoBall(){                      
            rb2d.AddForce(new Vector2(1, -15));
            rb2d.velocity = Vector2.up * vel;
    }

    void Start () {
        rb2d = GetComponent<Rigidbody2D>(); // Inicializa o objeto bola
        
        Invoke("GoBall", 2);    // Chama a função GoBall após 2 segundos
    }
    

    // Determina o comportamento da bola nas colisões com os Players (raquetes)
    void OnCollisionEnter2D (Collision2D coll) {
        GetComponent<AudioSource>().Play();
        if(coll.collider.CompareTag("Player")){
            Vector2 vel;

            // vel.x = rb2d.velocity.x;
            // vel.y = (rb2d.velocity.y / 2) + (coll.collider.attachedRigidbody.velocity.y / 3);
            // rb2d.velocity = vel;
        }
    }
    // Reinicializa a posição e velocidade da bola
    void ResetBall(){
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    // Reinicializa o jogo
    void RestartGame(){
        ResetBall();
        Invoke("GoBall", 1);
    }


}
