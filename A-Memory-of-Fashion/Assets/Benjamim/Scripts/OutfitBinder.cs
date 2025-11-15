using UnityEngine;

public class OutfitBinder : MonoBehaviour
{
    public SpriteRenderer vestidoRendererDaCena;
    public SpriteRenderer sapatoRendererDaCena;

    void Start()
    {
        CharacterOutfit.instance.vestidoRenderer = vestidoRendererDaCena;
        CharacterOutfit.instance.sapatoRenderer  = sapatoRendererDaCena;
    }
}
