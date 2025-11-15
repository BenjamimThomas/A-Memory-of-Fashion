using UnityEngine;

public class CharacterOutfit : MonoBehaviour
{
    public static CharacterOutfit instance;

    [Header("Renderers do Personagem")]
    public SpriteRenderer vestidoRenderer;
    public SpriteRenderer sapatoRenderer;

    [Header("Sprites dos Vestidos")]
    public Sprite vestidoVermelho;
    public Sprite vestidoAzul;

    [Header("Sprites dos Sapatos")]
    public Sprite sapatoVermelho;
    public Sprite sapatoAzul;

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

    public void Equipar(string itemName)
    {
        switch (itemName)
        {
            // Vestidos
            case "VestidoVermelho":
                vestidoRenderer.sprite = vestidoVermelho;
                break;

            case "VestidoAzul":
                vestidoRenderer.sprite = vestidoAzul;
                break;

            // Sapatos
            case "SapatoVermelho":
                sapatoRenderer.sprite = sapatoVermelho;
                break;

            case "SapatoAzul":
                sapatoRenderer.sprite = sapatoAzul;
                break;

            default:
                Debug.LogWarning("Item não existe: " + itemName);
                break;
        }
    }
}
