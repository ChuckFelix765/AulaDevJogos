using UnityEngine;

public class SpriteController : MonoBehaviour
{
    public GameObject tiro;
    public float velocidade = 0;  // Velocidade da ação (por exemplo, movimento)
    private UIManager pont;
    private Rigidbody2D rb2d;



    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); 
        // Obtendo o componente SpriteRenderer do GameObject
        //spriteRenderer.enabled = false;  // Começa invisível
        pont = FindFirstObjectByType<UIManager>();
    }

    void Update()
    {
            if(pont != null && pont.Score >= 2000){
                velocidade = 2;
                //MostrarSprite();
            }else{
                velocidade = 0;
            }
            // Ação que o sprite vai realizar enquanto visível
            // Exemplo: mover para a direita
            transform.Translate(Vector3.left * velocidade * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D coll){
        if (coll.gameObject.tag == "Tiro"){
            int pontos = UnityEngine.Random.Range(400, 600);
            //Destroy(coll.gameObject); 
            FindFirstObjectByType<UIManager>().AdicionarScore(pontos);
            Destroy(gameObject);
        }
    }
}
