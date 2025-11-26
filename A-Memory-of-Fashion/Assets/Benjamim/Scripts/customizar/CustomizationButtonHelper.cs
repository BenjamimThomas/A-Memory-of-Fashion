using UnityEngine;
using UnityEngine.UI;

public class CustomizationButtonHelper : MonoBehaviour
{
    public void OnClick_SetOutfit(string itemName)
    {
        if (CharacterOutfit.instance != null)
        {
            CharacterOutfit.instance.Equipar(itemName); 
            
            OutfitBinder binder = FindObjectOfType<OutfitBinder>();
            if (binder != null)
            {
                binder.ApplySavedOutfit();
            }
            
            Debug.Log($"Customização definida: {itemName}");
        }
        else
        {
            Debug.LogError("CharacterOutfit não encontrado!");
        }
    }
}