using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public string itemName; // exemplo: "Vestido" ou "Sapato"
    private bool playerNear = false;

    void Update()
    {
        if (playerNear && Input.GetKeyDown(KeyCode.E))
        {
            Inventory.instance.AddItem(itemName);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            playerNear = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            playerNear = false;
    }
}
