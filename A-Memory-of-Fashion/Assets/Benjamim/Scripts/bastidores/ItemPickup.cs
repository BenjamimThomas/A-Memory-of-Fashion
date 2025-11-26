using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public string itemName;
    private bool playerNear = false;

    private AudioSource pickupSound;

    void Start()
    {
        pickupSound = GetComponent<AudioSource>();

        if (PlayerPrefs.GetInt(itemName, 0) == 1)
        {
            gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (playerNear && Input.GetKeyDown(KeyCode.E))
        {
            if (pickupSound != null && pickupSound.clip != null)
            {
                pickupSound.Play();
            }
            float soundDuration = pickupSound.clip.length;

            Invoke("CollectItem", soundDuration);

            enabled = false;
        }
    }
    void CollectItem()
    {
        Inventory.instance.AddItem(itemName);
        PlayerPrefs.SetInt(itemName, 1);
        PlayerPrefs.Save();
        gameObject.SetActive(false);
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerNear = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerNear = false;
        }
    }
}