using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [Header("Painel do Inventário")]
    public GameObject inventoryPanel;

    [Header("Slots dos Itens na UI")]
    public GameObject slotVestidoVermelho;
    public GameObject slotVestidoAzul;
    public GameObject slotSapatoVermelho;
    public GameObject slotSapatoAzul;

    private bool isOpen = false;

    void Start()
    {
        inventoryPanel.SetActive(false);
        AtualizarUI();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isOpen = !isOpen;
            inventoryPanel.SetActive(isOpen);

            if (isOpen)
                AtualizarUI();
        }
    }

    public void AtualizarUI()
    {
        if (Inventory.instance == null)
            return;

        var inv = Inventory.instance;

        slotVestidoVermelho.SetActive(inv.temVestidoVermelho);
        slotVestidoAzul.SetActive(inv.temVestidoAzul);
        slotSapatoVermelho.SetActive(inv.temSapatoVermelho);
        slotSapatoAzul.SetActive(inv.temSapatoAzul);
    }
}
