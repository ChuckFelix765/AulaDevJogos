using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList.Element_Adder_Menu;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour{
    // Start is called before the first frame update
    public float jumpForce = 0;

    private Rigidbody2D rb; // Referência ao Rigidbody2D do jogador
    private Animator animations;
    [SerializeField] private Transform pos_tiro;// coordenadas de onde o tiro vai sair 
    [SerializeField] private GameObject[] balas; //tiro propriamente diro

    private bool grounded;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        animations = GetComponent<Animator>();
    }

    // Update is called once per frame

    void Update(){
        //isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        float Horizontali = Input.GetAxis("Horizontal");
        Vector3 direc = new Vector3(Horizontali, 0, 0);
        transform.Translate(direc * 5 * Time.deltaTime);

        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && grounded){ // Verifica se a tecla de pulo foi pressionada e se está no chão
            jump();
        }
        /*Virar para o lado que está andando*/
        if(Horizontali>0.01f){
            transform.localScale = new Vector3(-5, 5, 1);
        }else if(Horizontali<-0.01f){
            transform.localScale = new Vector3(5, 5, 1);
        }else{
            transform.localScale = transform.localScale;
        }
        animations.SetBool("Run", Horizontali !=0);
        animations.SetBool("grounded", grounded);
        print(Horizontali!=0);

         if(Input.GetKeyDown(KeyCode.Space)){
             Atira();
         }
    }
    private void jump(){
            rb.velocity = Vector2.up * jumpForce;
            grounded = false;
        
    }
    void Atira(){
        animations.SetTrigger("atira");

        balas[FindTiro()].transform.position = pos_tiro.transform.position;
        balas[FindTiro()].GetComponent<tiroPlayer>().SetDirecao(Mathf.Sign(transform.localScale.x));
        animations.SetTrigger("atira");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground"){
            grounded = true;
        }
        if(collision.gameObject.tag == "morte"){
            SceneManager.LoadScene("Derrota");
        }
    }
    private int FindTiro(){
        for(int i=0 ; i<balas.Length ; i++){
            if(!balas[i].activeInHierarchy) return i;
        }
        return 0;
    }
}
