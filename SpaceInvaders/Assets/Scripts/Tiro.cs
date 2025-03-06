using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{

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
            FindObjectOfType<UIManager>().AdicionarScore(100);
            Desligar();
        }
    }

}
