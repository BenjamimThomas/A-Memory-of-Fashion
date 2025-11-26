using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    [Header("Flags dos Itens")]
    public bool temVestidoVermelho;
    public bool temVestidoAzul;
    public bool temSapatoVermelho;
    public bool temSapatoAzul;
    
    void Start()
{
    temVestidoVermelho = PlayerPrefs.GetInt("VestidoVermelho", 0) == 1;
    temVestidoAzul = PlayerPrefs.GetInt("VestidoAzul", 0) == 1;
    temSapatoVermelho = PlayerPrefs.GetInt("SapatoVermelho", 0) == 1;
    temSapatoAzul = PlayerPrefs.GetInt("SapatoAzul", 0) == 1;
}


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

    public void AddItem(string itemName)
    {
        switch (itemName)
        {
            case "VestidoVermelho":
                temVestidoVermelho = true;
                break;

            case "VestidoAzul":
                temVestidoAzul = true;
                break;

            case "SapatoAzul":
                temSapatoAzul = true;
                break;

            case "SapatoVermelho":
                temSapatoVermelho = true;
                break;

            default:
                Debug.LogWarning("Item não reconhecido: " + itemName);
                break;
        }
    }
}
