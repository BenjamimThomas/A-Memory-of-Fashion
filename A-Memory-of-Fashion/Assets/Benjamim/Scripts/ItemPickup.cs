using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public string itemName;
    private bool playerNear = false;

    void Start()
    {
        if (PlayerPrefs.GetInt(itemName, 0) == 1)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (playerNear && Input.GetKeyDown(KeyCode.E))
        {
            Inventory.instance.AddItem(itemName);
            PlayerPrefs.SetInt(itemName, 1);
            PlayerPrefs.Save();
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            playerNear = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            playerNear = false;
    }
}
