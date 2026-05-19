using UnityEngine;
using TMPro;

public class GerenciadorPlacar : MonoBehaviour
{
    public TextMeshProUGUI textoNaTela;
    public TextMeshProUGUI textoRecorde; // O novo espaço para o Recorde

    private float pontuacao;
    private int recordeAtual;

    void Start()
    {
        // Ao iniciar, ele vai no HD do PC buscar o recorde salvo. Se não achar nada, assume que é 0.
        recordeAtual = PlayerPrefs.GetInt("RecordeSalvo", 0);
        textoRecorde.text = "RECORDE: " + recordeAtual.ToString();
    }

    void Update()
    {
        // Aumenta a pontuação
        pontuacao += 10f * Time.deltaTime;
        int pontosAtuais = Mathf.FloorToInt(pontuacao);
        
        textoNaTela.text = "PONTOS: " + pontosAtuais.ToString();

        // Lógica de Retenção: Se a pontuação atual passar do recorde...

        if (pontosAtuais > recordeAtual)
        {
            recordeAtual = pontosAtuais;
            textoRecorde.text = "RECORDE: " + recordeAtual.ToString();
            
            // Grava a nova marca na memória
            PlayerPrefs.SetInt("RecordeSalvo", recordeAtual);
            
            // FORÇA o commit físico no disco rígido na mesma hora
            PlayerPrefs.Save();
        }
    }

    // Função acionada quando o Samurai pega a moeda
    public void AdicionarBonus(float pontosExtras)
    {
        pontuacao += pontosExtras;
    }
}