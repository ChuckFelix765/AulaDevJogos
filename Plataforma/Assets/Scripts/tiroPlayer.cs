using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiroPlayer : MonoBehaviour
{
    [SerializeField] private float speed;
    private Animator anim;
    private CircleCollider2D col;
    private bool hit;
    private float direcao;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        col = GetComponent<CircleCollider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hit) return;
        float vel_tiro = speed * Time.deltaTime * direcao;
        transform.Translate(vel_tiro, 0, 0);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        col.enabled = false;
        anim.SetTrigger("explode");
        if (collision.gameObject.tag == "Alien"){
            FindFirstObjectByType<GameManager>().AdicionarScore(100);
            Desativa();
        }
    }
    public void SetDirecao(float _direcao){
        direcao = _direcao;
        gameObject.SetActive(true);
        hit = false;
        col.enabled = true;

        float localScaleX = transform.localScale.x;
        if(Mathf.Sign(localScaleX)!=_direcao){
            localScaleX = -localScaleX;

            transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
        }
    }
    private void Desativa(){
        gameObject.SetActive(false);
    }
}
