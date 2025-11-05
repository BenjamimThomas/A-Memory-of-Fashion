using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public GameObject inventoryUI;
    public Text itemListText;

    private List<string> items = new List<string>();
    private bool inventoryOpen = false;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inventoryOpen = !inventoryOpen;
            inventoryUI.SetActive(inventoryOpen);
            UpdateInventoryText();
        }
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
