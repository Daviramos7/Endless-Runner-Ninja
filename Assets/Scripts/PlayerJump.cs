using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float forcaPulo = 20f;
    private Rigidbody2D rb;
    public LayerMask oQueEChao; // Ensina ao script quem é o chão
    public float distanciaRaycast = 1.2f; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // O Laser: Atira um raio para baixo saindo do pé do Samurai
        bool estaNoChao = Physics2D.Raycast(transform.position, Vector2.down, distanciaRaycast, oQueEChao);

        // Debug: Vai desenhar uma linha na tela Scene para você VER o laser funcionando
        Debug.DrawRay(transform.position, Vector2.down * distanciaRaycast, estaNoChao ? Color.green : Color.red);

        // Se apertar Espaço E o laser estiver tocando no chão -> Pula
        if (Input.GetKeyDown(KeyCode.Space) && estaNoChao)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, forcaPulo);
        }
    }
}