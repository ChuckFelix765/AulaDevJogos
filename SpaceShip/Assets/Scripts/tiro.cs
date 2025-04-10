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
        if(transform.position.x >1024){
            Desligar();
        }
        transform.position += new Vector3(velTiro, 0, 0)*Time.deltaTime;
    }

    

    void OnTriggerEnter2D(Collider2D coll){
        if (coll.gameObject.tag == "Inimigo"){
            FindFirstObjectByType<GameManager>().AdicionarScore(100);
            FindFirstObjectByType<GameManager>().Matando(multiplicadorTiro);
            Desligar();
        }
    }

}
