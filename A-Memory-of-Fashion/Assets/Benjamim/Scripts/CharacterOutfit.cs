using UnityEngine;

public class CharacterOutfit : MonoBehaviour
{
    public static CharacterOutfit instance;

    [Header("Sprites do Personagem")]
    public SpriteRenderer vestidoRenderer;
    public SpriteRenderer sapatoRenderer;

    [Header("Sprites das Roupas")]
    public Sprite vestidoVermelho;
    public Sprite vestidoAzul;
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
            case "VestidoVermelho":
                vestidoRenderer.sprite = vestidoVermelho;
                break;

            case "VestidoAzul":
                vestidoRenderer.sprite = vestidoAzul;
                break;

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
