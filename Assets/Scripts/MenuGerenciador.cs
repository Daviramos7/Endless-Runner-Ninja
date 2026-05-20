using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGerenciador : MonoBehaviour
{
    public void ComecarJogo()
    {
        // Carrega a sua fase principal (garanta que o nome esteja idêntico)
        SceneManager.LoadScene("Fase_Principal");
    }

    public void SairDoJogo()
    {
        Debug.Log("O jogo fechou!");
        Application.Quit(); // Só funciona no executável final (.exe)
    }
}