using UnityEngine;
using UnityEngine.UI;

public class CustomizationButtonHelper : MonoBehaviour
{
    public Sprite vestidoVermelhoSprite;

    public void OnClick_SetVestidoVermelho()
    {
        CharacterOutfit.Instance.SetVestidoVermelho(vestidoVermelhoSprite);
    }
}