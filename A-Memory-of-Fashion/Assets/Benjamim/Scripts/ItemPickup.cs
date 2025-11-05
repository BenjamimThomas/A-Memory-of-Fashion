using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public string itemName;
    [SerializeField] private Sprite emptyBoxSprite;

    private bool playerNear = false;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (playerNear && Input.GetKeyDown(KeyCode.E))
        {
            Inventory.instance.AddItem(itemName);

            if (emptyBoxSprite != null)
                spriteRenderer.sprite = emptyBoxSprite;

            Destroy(this); 
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
