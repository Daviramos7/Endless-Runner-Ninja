using UnityEngine;

public class GeradorMestre : MonoBehaviour
{
    public GameObject padraoMoedaCaixa;
    public GameObject padraoSoCaixa;
    public GameObject padraoItemShuriken; // Nova gaveta para o item raro

    public float tempoSpawn = 1.5f;
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= tempoSpawn)
        {
            SpawnarObstaculoComPeso();
            timer = 0f;
        }
    }

    void SpawnarObstaculoComPeso()
    {
        // Rola um dado de 1 a 100
        int chance = Random.Range(1, 101);
        GameObject objetoSelecionado;

        // MATEMÁTICA DA RARIDADE:
        // 1 a 10 (10% de chance) -> Item de Shuriken Raro
        if (chance <= 10) 
        {
            objetoSelecionado = padraoItemShuriken;
        }
        // 11 a 50 (40% de chance) -> Combo Moeda + Caixa
        else if (chance <= 50) 
        {
            objetoSelecionado = padraoMoedaCaixa;
        }
        // 51 a 100 (50% de chance) -> Só a Caixa Normal
        else 
        {
            objetoSelecionado = padraoSoCaixa;
        }

        if (objetoSelecionado != null)
        {
            Instantiate(objetoSelecionado, transform.position, Quaternion.identity);
        }
    }
}