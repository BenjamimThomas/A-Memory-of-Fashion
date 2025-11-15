using UnityEngine;

public class OutfitSets : MonoBehaviour
{
    public static OutfitSets instance;

    [Header("Renderers do Personagem")]
    public SpriteRenderer vestidoRenderer;
    public SpriteRenderer sapatoRenderer;

    [Header("Vestidos")]
    public Sprite vestidoAzul;
    public Sprite vestidoVermelho;

    [Header("Sapatos")]
    public Sprite sapatoAzul;
    public Sprite sapatoVermelho;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void EquiparConjunto(int id)
    {
        switch (id)
        {
            case 1: 
                vestidoRenderer.sprite = vestidoAzul;
                sapatoRenderer.sprite = sapatoVermelho;
                break;

            case 2: 
                vestidoRenderer.sprite = vestidoAzul;
                sapatoRenderer.sprite = sapatoAzul;
                break;

            case 3: 
                vestidoRenderer.sprite = vestidoVermelho;
                sapatoRenderer.sprite = sapatoVermelho;
                break;

            case 4: 
                vestidoRenderer.sprite = vestidoVermelho;
                sapatoRenderer.sprite = sapatoAzul;
                break;
        }
    }
}
