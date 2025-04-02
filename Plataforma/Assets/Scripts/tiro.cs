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
        transform.position += new Vector3(velTiro, 0, 0)*Time.deltaTime;
    }
/*
    void OnTriggerEnter2D(Collider2D coll){
        if (coll.gameObject.tag == "Invader_1"){
            FindFirstObjectByType<UIManager>().AdicionarScore(300);
            FindFirstObjectByType<UIManager>().Matando(multiplicadorTiro);
            Desligar();
        }if (coll.gameObject.tag == "Invader_2"){
            FindFirstObjectByType<UIManager>().AdicionarScore(250);
            FindFirstObjectByType<UIManager>().Matando(multiplicadorTiro);
            Desligar();
        }if (coll.gameObject.tag == "Invader_3"){
            FindFirstObjectByType<UIManager>().AdicionarScore(175);
            FindFirstObjectByType<UIManager>().Matando(multiplicadorTiro);
            Desligar();
        }
        if (coll.gameObject.tag == "Invader_4"){
            //Destroy(coll.gameObject);  
            FindFirstObjectByType<UIManager>().AdicionarScore(100);
            FindFirstObjectByType<UIManager>().Matando(multiplicadorTiro);
            //FindObjectOfType<UIManager>().AdicionarScore(100);
            Desligar();
        }
    }*/

}
