using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;


public class Player : MonoBehaviour {
    public float tiroInicial;
    public float tiroContinuo;
    public GameObject tiros;
    public int numTiros;
    List<GameObject> listaTiros;
    private float boundX = 10f;
    [SerializeField]
    private float speed = 10f;
    private Rigidbody2D body;
    //private int vida = 3;
    public int inv = 0;
	// Use this for initialization
	void Start () {
        listaTiros = new List<GameObject>();
        for(int i=0 ; i<=numTiros ; i++){
            GameObject obj = (GameObject)Instantiate(tiros);
            obj.SetActive(false);
            listaTiros.Add(obj);
        }
        body = GetComponent<Rigidbody2D>();
	}
	
    void Atirar()
    {
        for(int i=0 ; i<listaTiros.Count ; i++){
            if(!listaTiros[i].activeInHierarchy){
                listaTiros[i].transform.position = transform.position;
                listaTiros[i].transform.rotation = transform.rotation;
                listaTiros[i].SetActive(true);
                break;
            }
        }
    }
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
            InvokeRepeating("Atirar", tiroInicial, tiroContinuo);
        }else if(Input.GetKeyUp(KeyCode.Space)){
            CancelInvoke("Atirar");
        }
        /*Scene scene = SceneManager.GetActiveScene();
        if(inv == 5){
            if (scene.name == "Principal"){
                SceneManager.LoadScene("Vitoria");
            }
        }*/
	}

    private void FixedUpdate()
    {
            float h = Input.GetAxis("Horizontal");
            body.velocity = Vector2.right * h * speed;
            var pos = transform.position;           // Acessa a Posição da raquete
            if (pos.x > boundX) {                  
                pos.x = boundX;                     // Corrige a posicao da raquete caso ele ultrapasse o limite superior
            }
            else if (pos.x < -boundX) {
                pos.x = -boundX;                    // Corrige a posicao da raquete caso ele ultrapasse o limite inferior
            }
            transform.position = pos;               // Atualiza a posição da raquete
    }
}