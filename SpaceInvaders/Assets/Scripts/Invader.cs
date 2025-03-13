using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


public class Invader : MonoBehaviour
{


    public GameObject tiro;
    private Rigidbody2D rb2d;
    private float timer = 0.0f;
    private float timer_y = 0.0f;
    private float waitTime = 1.0f;
    //private int state = 0;
    private float x;
    public float speed = 2.0f;
    public float atira;

    private GameObject obj;
    

    // Start is called before the first frame update
    void Start()
    {
        
        rb2d = GetComponent<Rigidbody2D>();  
        x = transform.position.x;

        var vel = rb2d.velocity;
        vel.x = speed;
        rb2d.velocity = vel;
    }

    void Atirar(){
        obj = (GameObject)Instantiate(tiro);
        obj.transform.position = transform.position;
        obj.transform.rotation = transform.rotation;
        obj.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        float atira_0 = atira;

        // int numeroAleatorio = random.Next(1, 40); // Gera um número entre 1 e 100
        // Debug.log(random);
  
        int prob =UnityEngine.Random.Range(1,3000); //prob para atirar


        
        atira = atira - 1*Time.deltaTime;
        if(atira<= 0 ){
            if (prob==1){
            Atirar();
            //Invoke("Atirar", atira);
            atira = atira_0;
            }
            
        }

        timer += Time.deltaTime;
        timer_y += Time.deltaTime;
        if (timer >= waitTime){
            ChangeState();
            timer = 0.0f;
        }
        if (timer_y >= waitTime*5){
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.6f, transform.position.z);
            timer_y = 0.0f;
        }
        changeVel(speed);
    }

    void ChangeState(){
        var vel = rb2d.velocity;
        vel.x *= -1;
        rb2d.velocity = vel;
    }

    public void changeVel(float nv){
        speed = nv;
    }

    void OnTriggerEnter2D(Collider2D coll){
        if (coll.gameObject.tag == "Tiro"){
            //Destroy(coll.gameObject); 
            Destroy(gameObject);
        }
    }


}
