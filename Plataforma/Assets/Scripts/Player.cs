using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{
    // Start is called before the first frame update
    //public float jumpForce = 0;

    private Rigidbody2D rb; // Referência ao Rigidbody2D do jogador
    private Animator animations;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update(){
        //isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        float Horizontali = Input.GetAxis("Horizontal");
        float Verticali = Input.GetAxis("Vertical");
        Vector3 direc = new Vector3(Horizontali, Verticali, 0);
        transform.Translate(direc * 5 * Time.deltaTime);

        // if (Input.GetButtonDown("KeyCode.Space") && isGrounded) // Verifica se a tecla de pulo foi pressionada e se está no chão
        // {
        //     rb.velocity = Vector2.up * jumpForce;
        // }
    }
}
