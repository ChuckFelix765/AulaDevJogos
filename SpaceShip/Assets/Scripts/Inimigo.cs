using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    private Rigidbody2D rb2d;
    //private float timer = 5.0f;
    public static float speed = 2.0f;
    public GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();  

    }

    // Update is called once per frame
    void Update()
    {
        int prob = UnityEngine.Random.Range(0, 100);
        if(prob == 1){
            var vel = rb2d.velocity;
            vel.x = -speed;
            rb2d.velocity = vel;
        }
        if(transform.position.x<-5){
            gameObject.SetActive(false);
        }
        
    }

    void OnTriggerEnter2D(Collider2D coll){
        if(coll.gameObject.tag == "tiro"){
            Destroy(gameObject);
            int drop_rate = UnityEngine.Random.Range(0, 10);
                if(drop_rate==1){
                    GameObject.Instantiate(obj);
                    obj.transform.position = transform.position;
                }
            
        }
        
    }
}
