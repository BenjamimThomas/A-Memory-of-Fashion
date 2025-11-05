using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public GameObject inventoryUI;
    public TMP_Text itemListText;

    private List<string> items = new List<string>();
    private bool inventoryOpen = false;
    private Vector3 closedScale = Vector3.zero;
    private Vector3 openScale = Vector3.one;
    private float animSpeed = 8f; 

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        inventoryUI.transform.localScale = closedScale;
        inventoryUI.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inventoryOpen = !inventoryOpen;
            UpdateInventoryText();
        }

        // animação suave abrindo/fechando
        Vector3 targetScale = inventoryOpen ? openScale : closedScale;
        inventoryUI.transform.localScale = Vector3.Lerp(
            inventoryUI.transform.localScale,
            targetScale,
            Time.deltaTime * animSpeed
        );
    }

    public void AddItem(string item)
    {
        items.Add(item);
        Debug.Log("Item adicionado: " + item);
    }

    void UpdateInventoryText()
    {
        if (itemListText == null) return;

        itemListText.text = "Inventário:\n";
        foreach (string item in items)
            itemListText.text += "- " + item + "\n";
    }
}
