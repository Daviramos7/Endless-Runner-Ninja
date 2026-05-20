using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerColisao : MonoBehaviour
{
    // Campo para arrastar o painel de Game Over lá na Unity
    public GameObject painelGameOver;

    private void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.CompareTag("Inimigo"))
        {
            Morrer();
        }
        else if (outro.CompareTag("Moeda"))
        {
            FindAnyObjectByType<GerenciadorPlacar>().AdicionarBonus(50f);
            Destroy(outro.gameObject);
        }
        else if (outro.CompareTag("ItemShuriken"))
        {
            GetComponent<PlayerAtaque>().RecarregarShuriken();
            Destroy(outro.gameObject);
        }
    }

    void Morrer()
    {
        Time.timeScale = 0f; // Pausa o motor do jogo (para o gerador e o movimento)
        painelGameOver.SetActive(true); // Faz a tela de Game Over aparecer
    }

    // Funções públicas que os botões do seu painel vão chamar:
    public void ReiniciarJogo()
    {
        Time.timeScale = 1f; // OBRIGATÓRIO: Despausa o jogo antes de recarregar
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void VoltarAoMenu()
    {
        Time.timeScale = 1f; // Despausa o jogo
        SceneManager.LoadScene("Menu_Inicial"); // Nome da cena do menu que faremos a seguir
    }
}