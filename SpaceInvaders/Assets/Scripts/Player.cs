using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private float boundX = 10f;
    [SerializeField]
    private float speed = 10f;
    private Rigidbody2D body;
	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {

            
            float h = Input.GetAxis("Horizontal");
            body.velocity = Vector2.right * h * speed;
            var pos = transform.position;           // Acessa a Posição da raquete
            if (pos.x > boundX) {                  
                pos.x = boundX;                     // Corrige a posicao da raquete caso ele ultrapasse o limite superior
            }
            else if (pos.x < -boundX) {
                pos.x = -boundX;                    // Corrige a posicao da raquete caso ele ultrapasse o limite inferior
            }
            transform.position = pos;               // Atualiza a posição da raquete
        
       
    }
}