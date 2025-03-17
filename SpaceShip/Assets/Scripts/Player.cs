using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{
    public float moveSpeed = 5f; // Velocidade de movimentação
    private Rigidbody2D rb; // Referência para o Rigidbody2D
    private Vector2 moveDirection; // Direção do movimento
    private float boundY = 3.5f;            // Define os limites em Y
    private float boundX = 4.6f;            // Define os limites em X
    //GameObject slow = GameObject.FindwithTag("Bg");

    private GameObject tiro;
    // Start é chamado antes do primeiro frame de atualização
    void Start(){
        rb = GetComponent<Rigidbody2D>(); // Pegando o componente Rigidbody2D
    }

        void Atirar()
    {
            obj = (GameObject)Instantiate(tiro);
            obj.transform.position = transform.position;
            obj.transform.rotation = transform.rotation;
            obj.SetActive(true);
    }

    // Update é chamado uma vez por quadro
    void Update(){
        // Obtendo a entrada do usuário para movimentação
        float moveX = Input.GetAxis("Horizontal"); // Movimento na horizontal (A/D ou setas)
        float moveY = Input.GetAxis("Vertical"); // Movimento na vertical (W/S ou setas)
        var pos = transform.position;
        transform.position = pos;               // Atualiza a posição da raquete

        if(Input.GetKeyDown(KeyCode.Space)){
            Atirar();
        }

        // Calculando a direção do movimento
        moveDirection = new Vector2(moveX, moveY).normalized; // Normalizando para evitar velocidade maior na diagonal
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("O jogador apertou a tecla Espaço!");
            // if(slwt != 1f){
            //     Debug.Log("Aqui");
            //     //slwt.slow = 0.5f;
            // }
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
}
