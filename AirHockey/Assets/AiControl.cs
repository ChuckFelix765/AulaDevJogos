using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiControl : MonoBehaviour
{


    public float speed = 5.0f;
    public float boundTopY = 2.25f;
    public float boundBotY = 0.0f;
    public float boundTopX = -2.25f;
    public float boundBotX = 2.25f;

    private Rigidbody2D rb2d

    void Start()
    {
        
        Puck = GameObject.FindObjectWithTag("Ball");
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update () {
        

        var vel = rb2d.velocity;                // Acessa a velocidade da raquete
        if (Puck.x > rb2d.x) {             // Velocidade da Raquete para ir para cima
            vel.x = speed;
        }
        else if (Puck.x < rb2d.x) {      // Velocidade da Raquete para ir para cima
            vel.x = -speed;                    
        }
        else {
            vel.x = 0;                          // Velociade para manter a raquete parada
        }
        if (Puck.y > 0 && rb2d.y < Puck.y){
            vel.x = speed;
        }
        else if(Puck.y > 0 && rb2d.y > Puck.y){
            vel.x = -speed;
        }
        else{
            if(rb2d.y > -4){
                while(rb2d.y >-4){
                    vel.y = -speed;
                }
            }else if(rb2d < -4){
                while(rb2d.y < -4){
                    vel.y = speed;
                }
            }
            vel.x = 0;
        }
        rb2d.velocity = vel;                    // Atualizada a velocidade da raquete

        var pos = transform.position;           // Acessa a Posição da raquete
        if (pos.y > boundY) {                  
            pos.y = boundY;                     // Corrige a posicao da raquete caso ele ultrapasse o limite superior
        }
        else if (pos.y < -boundY) {
            pos.y = -boundY;                    // Corrige a posicao da raquete caso ele ultrapasse o limite superior
        }
        transform.position = pos;               // Atualiza a posição da raquete
    
    }

}
