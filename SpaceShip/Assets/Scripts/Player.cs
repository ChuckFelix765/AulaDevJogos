using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{
    public float moveSpeed = 5f; // Velocidade de movimentação
    private Rigidbody2D rb; // Referência para o Rigidbody2D
    private Vector2 moveDirection; // Direção do movimento
    private float boundY = 3.5f;            // Define os limites em Y
    private float boundX = 4.6f;            // Define os limites em X
    public GameObject tiro;
    private float tempo_efeito = 5.0f;
    private int ativado = 0;

    // Start é chamado antes do primeiro frame de atualização
    void Start(){
        rb = GetComponent<Rigidbody2D>(); // Pegando o componente Rigidbody2D
    }

     void Atirar(){
             tiro = (GameObject)Instantiate(tiro);
             tiro.transform.position = transform.position;
             tiro.transform.rotation = transform.rotation;
             tiro.SetActive(true);
     }

    // Update é chamado uma vez por quadro
    void Update(){
        // Obtendo a entrada do usuário para movimentação
        float moveX = Input.GetAxis("Horizontal"); // Movimento na horizontal (A/D ou setas)
        float moveY = Input.GetAxis("Vertical"); // Movimento na vertical (W/S ou setas)
        var pos = transform.position;
        transform.position = pos;               // Atualiza a posição da raquete

        tempo_efeito -= 1*Time.deltaTime;
        print(tempo_efeito);
        if(tempo_efeito <=0 && ativado == 1){
            ativado = 0;
            Parallax.slw = Parallax.slw * 2.0f;
            Inimigo.speed = Inimigo.speed * 2.0f;
        }
        // Calculando a direção do movimento
        moveDirection = new Vector2(moveX, moveY).normalized; // Normalizando para evitar velocidade maior na diagonal
        if (Input.GetKeyDown(KeyCode.Space)){
            Atirar();
        }

        if (pos.y > boundY) {                  
            pos.y = boundY;                     // Corrige a posicao da raquete caso ele ultrapasse o limite superior
        }
        else if (pos.y < -boundY) {
            pos.y = -boundY;                    // Corrige a posicao da raquete caso ele ultrapasse o limite superior
        }

        if (pos.x > boundX) {                  
            pos.x = boundX;                     // Corrige a posicao da raquete caso ele ultrapasse o limite superior
        }
        else if (pos.x < -boundX) {
            pos.x = -boundX;                    // Corrige a posicao da raquete caso ele ultrapasse o limite superior
        }
        transform.position = pos;               // Atualiza a posição da raquete

        


    }

    // FixedUpdate é chamado de forma mais consistente para física



    void FixedUpdate(){
        // Aplicando a movimentação no Rigidbody2D
        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D coll){
        if(coll.gameObject.tag == "Inimigo"){
            FindFirstObjectByType<GameManager>().MudarVida(-1);
        }
        else if (coll.gameObject.tag == "SlowTime"){
            tempo_efeito = 5.0f;
            if(ativado == 0){
                ativado = 1;
                FindFirstObjectByType<GameManager>().ModificarVelocidade(0.5f);
            }
        }

    }

}
