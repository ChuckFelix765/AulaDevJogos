using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Invader : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float timer = 0.0f;
    private float waitTime = 1.0f;
    //private int state = 0;
    private float x;
    private float speed = 2.0f;
    public int atira = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();  
        x = transform.position.x;

        var vel = rb2d.velocity;
        vel.x = speed;
        rb2d.velocity = vel;
    }

    // void Atirar()
    // {
    //     for(int i=0 ; i<listaTiros.Count ; i++){
    //         if(!listaTiros[i].activeInHierarchy){
    //             listaTiros[i].transform.position = transform.position;
    //             listaTiros[i].transform.rotation = transform.rotation;
    //             listaTiros[i].SetActive(true);
    //             break;
    //         }
    //     }
    // }

    // Update is called once per frame
    void Update()
    {
        // Random random = new Random();
        // int numeroAleatorio = random.Next(1, 40); // Gera um número entre 1 e 100
        // Debug.log(random);

        timer += Time.deltaTime;
        if (timer >= waitTime){
            ChangeState();
            timer = 0.0f;
        }
    }

    void ChangeState(){
        var vel = rb2d.velocity;
        vel.x *= -1;
        rb2d.velocity = vel;
    }

    void OnTriggerEnter2D(Collider2D coll){
        if (coll.gameObject.tag == "Tiro"){
            //Destroy(coll.gameObject);  
            Destroy(gameObject);
        }
    }


}
