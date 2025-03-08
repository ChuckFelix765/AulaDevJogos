using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{
    public int multiplicadorTiro;
    public float velTiro;
    public float tempoVida;
    // Start is called before the first frame update
    void OnEnable()
    {
        Invoke("Desligar", tempoVida);
    }

    void Desligar()
    {
        gameObject.SetActive(false);
    }
    void OnDesabled(){
        CancelInvoke();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, velTiro, 0)*Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D coll){
        if (coll.gameObject.tag == "Invader"){
            //Destroy(coll.gameObject);  
            FindFirstObjectByType<UIManager>().AdicionarScore(100);
            FindFirstObjectByType<UIManager>().Matando(multiplicadorTiro);
            //FindObjectOfType<UIManager>().AdicionarScore(100);
            Desligar();
        }//if (coll.gameObject.tag == "Secret"){
        //     //Destroy(coll.gameObject);  
        //     FindFirstObjectByType<UIManager>().AdicionarScore(500);
        //     //FindObjectOfType<UIManager>().AdicionarScore(100);
        //     gameObject.SetActive(false);
        //     Desligar();
        // }
    }

}
