using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerColisao : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.CompareTag("Inimigo"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (outro.CompareTag("Moeda"))
        {
            FindAnyObjectByType<GerenciadorPlacar>().AdicionarBonus(50f);
            Destroy(outro.gameObject);
        }
        // NOVA REGRA: Coleta de Munição
        else if (outro.CompareTag("ItemShuriken"))
        {
            // Acessa o script de ataque do próprio Samurai e dá 1 shuriken
            GetComponent<PlayerAtaque>().RecarregarShuriken();
            
            // Destrói o item da tela
            Destroy(outro.gameObject);
        }
    }
}