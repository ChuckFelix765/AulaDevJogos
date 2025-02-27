using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour {
    [SerializeField]
    private float speed = 10f;
    private Rigidbody2D body;

    GameObject Player;


    public GameManager gameManager;
    // Use this for initialization
    void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void ResetBall()
    {
        float bola_posx = Player.GetComponent<Transform>().position.x;
        transform.position = new Vector2(bola_posx,-3.5f);
        GameManager.instance.PauseGame();


    }
    public void GoBall()
    {
        body = GetComponent<Rigidbody2D>();
        body.velocity = Vector2.up * speed;
    }
    float HitFactor(Vector2 ball, Vector2 player, float playerWidth)
    {
        //-1 -0.5 0 0.5 1
        return (ball.x - player.x) / playerWidth;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name != "GameOver")
        {
            GetComponent<AudioSource>().Play();
        }

        if (col.gameObject.name == "Player")
        {
            //descobrir o valor do x
            float x = HitFactor(
                transform.position,
                col.transform.position,
                col.collider.bounds.size.x); 
            
            // caclular a direção da bola
            Vector2 dir = new Vector2(x, 1).normalized;

            //velocidade da bola
            body.velocity = dir * speed;
        }
/*
        if(col.gameObject.name == "GameOver")
        {
            //GameManager.instance.SubVida(1);
            //transform.position = new Vector2(0,-3.5f);

            

            //
            //

            
        }
*/
        
    }
}