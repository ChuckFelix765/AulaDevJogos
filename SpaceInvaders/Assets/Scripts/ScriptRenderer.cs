using UnityEngine;

public class SpriteController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;  // Referência ao SpriteRenderer
    public float tempoAparicao = 2f;  // Tempo que o sprite vai aparecer na tela (em segundos)
    public float velocidade = 5f;  // Velocidade da ação (por exemplo, movimento)
    private bool estaAtivo = false;  // Verifica se o sprite está ativo ou não

    void Start()
    {
        // Obtendo o componente SpriteRenderer do GameObject
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;  // Começa invisível
    }

    void Update()
    {
        if (estaAtivo)
        {
            if(UnityEngine.Random.Range(1,51) < 25){
            MostrarSprite();
        }
            // Ação que o sprite vai realizar enquanto visível
            // Exemplo: mover para a direita
            transform.Translate(Vector3.right * velocidade * Time.deltaTime);

            // Se o tempo de aparição acabou, o sprite some
            tempoAparicao -= Time.deltaTime;
            if (tempoAparicao <= 0)
            {
                EsconderSprite();
            }
        }
    }

    // Função para ativar o sprite
    public void MostrarSprite()
    {
        spriteRenderer.enabled = true;  // Torna o sprite visível
        estaAtivo = true;  // Marca que o sprite está ativo
        tempoAparicao = 2f;  // Reinicia o tempo de aparição (caso precise)
    }

    // Função para esconder o sprite
    private void EsconderSprite()
    {
        spriteRenderer.enabled = false;  // Torna o sprite invisível
        estaAtivo = false;  // Marca que o sprite não está mais ativo
    }
}
