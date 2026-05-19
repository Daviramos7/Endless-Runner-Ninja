using UnityEngine;

public class ParallaxControl : MonoBehaviour
{
    public float velocidadeParallax;
    private float larguraSprite;
    private Vector3 posicaoInicial;

    void Start()
    {
        posicaoInicial = transform.position;
        larguraSprite = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        transform.Translate(Vector2.left * velocidadeParallax * Time.deltaTime);

        if (transform.position.x < posicaoInicial.x - larguraSprite)
        {
            transform.position = posicaoInicial;
        }
    }
}