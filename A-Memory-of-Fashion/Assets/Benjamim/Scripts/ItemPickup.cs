using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public string itemName; 
    private bool playerNear = false;

    private void Update()
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
    if (playerNear && Input.GetKeyDown(KeyCode.E))
{
    Inventory.instance.AddItem(itemName);

    // Salvar que o item já foi coletado
    PlayerPrefs.SetInt(itemName, 1);
    PlayerPrefs.Save();

    Destroy(gameObject);
}

}
