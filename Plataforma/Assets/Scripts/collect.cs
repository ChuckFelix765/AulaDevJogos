using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Inimigo : MonoBehaviour{
    private Rigidbody2D rb2d;
    public GameObject obj;

    // Start is called before the first frame update
    void Start(){
        rb2d = GetComponent<Rigidbody2D>();  
    }

    // Update is called once per frame

    void OnTriggerEnter2D(Collider2D coll){
        if(coll.gameObject.tag == "Player"){
            FindFirstObjectByType<GameManager>().AdicionarScore(100);
            //FindFirstObjectByType<GameManager>().Matando(multiplicadorTiro);
            Destroy(this.gameObject);     
        }
    }
}
