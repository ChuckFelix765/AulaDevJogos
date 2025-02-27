using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    [SerializeField]
    private float speed = 10f;
    private Rigidbody2D body;
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
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

        if(col.gameObject.name == "GameOver" && GetComponent<GameManager>())
        {
            if (this.gameObject.CompareTag("BotWall")) GameManager.vida.SubVida(1);

            //GameManager.instance.LoadEndGame(GameState.GameOver);
            //gameObject.SetActive(false);

            
        }

        
    }
}