using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float moveSpeed = 7f; // Velocidade de movimentação
    private Rigidbody2D rb; // Referência para o Rigidbody2D
    private Vector2 md; // Direção do movimento
    private float boundX = 12f;            // Define os limites em Y
    // Start is called before the first frame update
    void Start () {
        rb = GetComponent<Rigidbody2D>();     // Inicializa a raquete
    }


    // Update is called once per frame
    void Update () {
        float moveX = Input.GetAxis("Horizontal");
        md = new Vector2(moveX, 0f).normalized;

        var pos = transform.position;           // Acessa a Posição da raquete
        if (pos.x > boundX) {                  
            pos.x = boundX;                     // Corrige a posicao da raquete caso ele ultrapasse o limite superior
        }
        else if (pos.x < -boundX) {
            pos.x = -boundX;                    // Corrige a posicao da raquete caso ele ultrapasse o limite inferior
        }
        transform.position = pos;               // Atualiza a posição da raquete
    
    }

        void FixedUpdate()
    {
        // Aplicando a movimentação no Rigidbody2D
        rb.MovePosition(rb.position + md * moveSpeed * Time.fixedDeltaTime);
    }

}