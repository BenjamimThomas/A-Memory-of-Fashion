using UnityEngine;

public class CharacterOutfit : MonoBehaviour
{
    public static CharacterOutfit instance;

    public bool vestidoEscolhido = false;
    public bool sapatoEscolhido = false;

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
    public bool PodeAvancar()
    {
        return vestidoEscolhido && sapatoEscolhido;
    }

    public void Equipar(string itemName)
    {
        switch (itemName)
        {
            case "VestidoVermelho":
                vestidoRenderer.sprite = vestidoVermelho;
                vestidoEscolhido = true;
                break;

            case "VestidoAzul":
                vestidoRenderer.sprite = vestidoAzul;
                vestidoEscolhido = true;
                break;

            case "SapatoVermelho":
                sapatoRenderer.sprite = sapatoVermelho;
                sapatoEscolhido = true;
                break;

            case "SapatoAzul":
                sapatoRenderer.sprite = sapatoAzul;
                sapatoEscolhido = true;
                break;
        }
    }
}
