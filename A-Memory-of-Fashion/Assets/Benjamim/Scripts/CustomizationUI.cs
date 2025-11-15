using UnityEngine;

public class CustomizationUI : MonoBehaviour
{
    public GameObject btnVestidoVermelho;
    public GameObject btnVestidoAzul;
    public GameObject btnSapatoVermelho;
    public GameObject btnSapatoAzul;

    void Start()
    {
        btnVestidoVermelho.SetActive(Inventory.instance.vestidoVermelhoSlot.activeSelf);
        btnVestidoAzul.SetActive(Inventory.instance.vestidoAzulSlot.activeSelf);
        btnSapatoVermelho.SetActive(Inventory.instance.sapatoVermelhoSlot.activeSelf);
        btnSapatoAzul.SetActive(Inventory.instance.sapatoAzulSlot.activeSelf);
    }
}
