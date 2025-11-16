using UnityEngine;

public class OutfitBinder : MonoBehaviour
{
    public SpriteRenderer vestidoRendererDaCena;
    public SpriteRenderer sapatoRendererDaCena;

    void Start()
    {
        ApplySavedOutfit();
    }
    
    public void ApplySavedOutfit()
    {
        if (CharacterOutfit.instance != null)
        {
            vestidoRendererDaCena.sprite = CharacterOutfit.instance.currentVestidoSprite;
            sapatoRendererDaCena.sprite = CharacterOutfit.instance.currentSapatoSprite;
        }
    }
}