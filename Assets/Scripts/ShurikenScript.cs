using UnityEngine;

public class ShurikenScript : MonoBehaviour
{
    public float velocidade = 15f;
    public float tempoDeVida = 2f; // Garbage Collection: destrói após 2 segundos se não bater em nada

    void Start()
    {
        // Aciona o cronômetro de autodestruição assim que nasce
        Destroy(gameObject, tempoDeVida);
    }

    void Update()
    {
        // Voa reto para a DIREITA
        transform.Translate(Vector2.right * velocidade * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D outro)
    {
        // Garante que estamos destruindo o objeto específico que tem a Tag, e não o pai dele
        if (outro.CompareTag("Inimigo"))
        {
            // Adiciona pontos
            FindAnyObjectByType<GerenciadorPlacar>().AdicionarBonus(20f);

            // Destrói especificamente o objeto da caixa
            Destroy(outro.gameObject);
            
            // Destrói a Shuriken
            Destroy(gameObject);
        }
    }
}