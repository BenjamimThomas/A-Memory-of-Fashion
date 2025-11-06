using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    [Header("Configurações de Slots")]
    public Transform slotsParent; 
    public GameObject slotPrefab;
    public int slotCount = 6;

    private List<Image> slots = new List<Image>();
    private List<Sprite> items = new List<Sprite>();

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        for (int i = 0; i < slotCount; i++)
        {
            GameObject newSlot = Instantiate(slotPrefab, slotsParent);
            Image img = newSlot.GetComponent<Image>();
            img.sprite = null;
            img.enabled = false;
            slots.Add(img);
        }
    }

    public void AddItem(Sprite itemSprite)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (!slots[i].enabled)
            {
                slots[i].sprite = itemSprite;
                slots[i].enabled = true;
                items.Add(itemSprite);
                return;
            }
        }

        Debug.Log("Inventário cheio!");
    }
}
