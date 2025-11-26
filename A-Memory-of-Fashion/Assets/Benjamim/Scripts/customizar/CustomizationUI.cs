using UnityEngine;

public class CustomizationUI : MonoBehaviour
{
    public GameObject btnVestidoVermelho;
    public GameObject btnVestidoAzul;
    public GameObject btnSapatoVermelho;
    public GameObject btnSapatoAzul;

  void Start()
{
    var inv = Inventory.instance;

    btnVestidoVermelho.SetActive(inv.temVestidoVermelho);
    btnVestidoAzul.SetActive(inv.temVestidoAzul);
    btnSapatoVermelho.SetActive(inv.temSapatoVermelho);
    btnSapatoAzul.SetActive(inv.temSapatoAzul);
}

}
