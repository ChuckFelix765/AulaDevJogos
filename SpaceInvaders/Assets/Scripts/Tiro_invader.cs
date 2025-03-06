using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro_invader : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject tiro;
    public float tiroCoolDown;
    public float velTiro;
    public float tempoVida;
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

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, velTiro, 0)*Time.deltaTime;
    }


        void OnTriggerEnter2D(Collider2D coll){
        if (coll.gameObject.tag == "Invader"){
            //Destroy(coll.gameObject);  
            FindFirstObjectByType<UIManager>().ModificarVida(-1);
            Desligar();
        }
    }
}
