using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    public float velocidade = 6f; // Mesma velocidade da grama
    private float limiteEsquerdo = -30f; // Ponto onde ele some da tela

    void Update()
    {
        // Move o inimigo para a esquerda
        transform.Translate(Vector2.left * velocidade * Time.deltaTime);

        // Destrói o objeto se ele sair da tela para não gastar memória do PC
        if (transform.position.x < limiteEsquerdo)
        {
            Destroy(gameObject);
        }
    }
}