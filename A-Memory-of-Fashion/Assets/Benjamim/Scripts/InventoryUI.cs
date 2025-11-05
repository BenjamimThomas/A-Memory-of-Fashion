using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [Header("Painel do Inventário")]
    public GameObject inventoryPanel; // arraste seu painel aqui
    private bool isOpen = false;

    void Start()
    {
        if (inventoryPanel != null)
            inventoryPanel.SetActive(false); // começa fechado
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isOpen = !isOpen;

            if (inventoryPanel != null)
                inventoryPanel.SetActive(isOpen);
        }
    }
}
