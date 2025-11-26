using UnityEngine;

public class CharacterOutfit : MonoBehaviour
{
    public static CharacterOutfit instance;

    public bool vestidoEscolhido = false;
    public bool sapatoEscolhido = false;

    public Sprite currentVestidoSprite; 
    public Sprite currentSapatoSprite; 

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
                currentVestidoSprite = vestidoVermelho;
                vestidoEscolhido = true;
                break;

            case "VestidoAzul":
                currentVestidoSprite = vestidoAzul;
                vestidoEscolhido = true;
                break;

            case "SapatoVermelho":
                currentSapatoSprite = sapatoVermelho;
                sapatoEscolhido = true;
                break;

            case "SapatoAzul":
                currentSapatoSprite = sapatoAzul;
                sapatoEscolhido = true;
                break;
        }
    }
}