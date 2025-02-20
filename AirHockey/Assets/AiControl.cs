using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiControl : MonoBehaviour
{


    public float speed = 5.0f;
    private float boundY = 5.8f;            // Define os limites em Y
    private float boundX = 3.8f;            // Define os limites em X
    private Rigidbody2D rb2d;
    GameObject TheBall;

    void Start()
    {
        TheBall = GameObject.FindGameObjectWithTag("Ball");
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update () {
        var Ball = TheBall.transform.position;
        var pos = transform.position;
        var vel = rb2d.velocity;                // Acessa a velocidade da raquete
        if (Ball.x > pos.x) {             // Velocidade da Raquete para ir para cima
            vel.x = speed;
        }
        else if (Ball.x < pos.x) {      // Velocidade da Raquete para ir para cima
            vel.x = -speed;                    
        }
        else {
            vel.x = 0;                          // Velociade para manter a raquete parada
        }
        if (Ball.y > 0 && pos.y < Ball.y){
            vel.y = speed;
        }
        else if(Ball.y > 0 && pos.y > Ball.y){
            vel.y = -speed;
        }
        else{
            vel.y = 0;
            /*
            vel.x = 0;
            if(pos.y > -4.0f){
                while(pos.y > -4.0f){
                    vel.y = -speed;
                }
            }else if(pos.y < -4.0f){
                while(pos.y < -4.0f){
                    vel.y = speed;
                }
            }
            */
        }
        rb2d.velocity = vel;                    // Atualizada a velocidade da raquete

        


        if (pos.y > boundY) {                  
            pos.y = boundY;                     // Corrige a posicao da raquete caso ele ultrapasse o limite superior
        }
        else if (pos.y < -0.6f) {
            pos.y = -0.6f;                    // Corrige a posicao da raquete caso ele ultrapasse o limite superior
        }

        if (pos.x > boundX) {                  
            pos.x = boundX;                     // Corrige a posicao da raquete caso ele ultrapasse o limite superior
        }
        else if (pos.x < -boundX) {
            pos.x = -boundX;                    // Corrige a posicao da raquete caso ele ultrapasse o limite superior
        }
        transform.position = pos;               // Atualiza a posição da raquete
    
    }

}
