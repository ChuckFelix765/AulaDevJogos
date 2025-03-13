using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{
    public float moveSpeed = 5f; // Velocidade de movimentação
    private Rigidbody2D rb; // Referência para o Rigidbody2D
    private Vector2 moveDirection; // Direção do movimento

    // Start é chamado antes do primeiro frame de atualização
    void Start(){
        rb = GetComponent<Rigidbody2D>(); // Pegando o componente Rigidbody2D
    }

    // Update é chamado uma vez por quadro
    void Update(){
        // Obtendo a entrada do usuário para movimentação
        float moveX = Input.GetAxis("Horizontal"); // Movimento na horizontal (A/D ou setas)
        float moveY = Input.GetAxis("Vertical"); // Movimento na vertical (W/S ou setas)

        // Calculando a direção do movimento
        moveDirection = new Vector2(moveX, moveY).normalized; // Normalizando para evitar velocidade maior na diagonal
    }

    // FixedUpdate é chamado de forma mais consistente para física
    void FixedUpdate(){
        // Aplicando a movimentação no Rigidbody2D
        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
    }
}
