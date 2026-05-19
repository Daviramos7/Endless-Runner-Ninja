using UnityEngine;

public class PlayerAtaque : MonoBehaviour
{
    public GameObject shurikenPrefab;
    public Transform pontoDeDisparo;

    private int shurikensAtuais = 0; // Começa com 0, precisa coletar no mapa
    private int limiteMaximo = 3;

    void Update()
    {
        // Só atira se apertar X E tiver munição no bolso
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (shurikensAtuais > 0)
            {
                Atirar();
            }
            else
            {
                Debug.Log("Sem munição! Procure itens de Shuriken na fase.");
            }
        }
    }

    void Atirar()
    {
        Instantiate(shurikenPrefab, pontoDeDisparo.position, Quaternion.identity);
        shurikensAtuais--; // Gasta 1
        Debug.Log("Munição Restante: " + shurikensAtuais);
    }

    // Função pública que o script de colisão vai chamar ao coletar o item
    public void RecarregarShuriken()
    {
        if (shurikensAtuais < limiteMaximo)
        {
            shurikensAtuais++;
            Debug.Log("Shuriken coletada! Total: " + shurikensAtuais);
        }
    }
}