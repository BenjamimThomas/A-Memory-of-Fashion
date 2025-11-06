using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    [Header("Itens do Inventário")]
    public GameObject vestidoVermelhoSlot;
    public GameObject vestidoAzulSlot;
    public GameObject sapatoAzulSlot;
    public GameObject sapatoVermelhoSlot;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddItem(string itemName)
    {
        switch (itemName)
        {
            case "VestidoVermelho":
                vestidoVermelhoSlot.SetActive(true);
                break;
            case "VestidoAzul":
                vestidoAzulSlot.SetActive(true);
                break;

            case "SapatoAzul":
                sapatoAzulSlot.SetActive(true);
                break;
            case "SapatoVermelho":
                sapatoVermelhoSlot.SetActive(true);
                break;

            default:
                Debug.LogWarning("Item não reconhecido: " + itemName);
                break;
        }
    }
}