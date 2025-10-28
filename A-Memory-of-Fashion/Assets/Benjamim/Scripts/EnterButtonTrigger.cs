using UnityEngine;

public class EnterButtonTrigger : MonoBehaviour
{
    public string playerTag = "Player";
    public Rigidbody2D[] newspapers;
    public float gravityScale = 1f;
    public KeyCode activateKey = KeyCode.E;

    private bool playerInside = false;
    private bool activated = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
            playerInside = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
            playerInside = false;
    }

    void Update()
    {
        if (playerInside && !activated && Input.GetKeyDown(activateKey))
        {
            foreach (Rigidbody2D rb in newspapers)
            {
                if (rb == null) continue;
                rb.bodyType = RigidbodyType2D.Dynamic;
                rb.gravityScale = gravityScale;
                rb.simulated = true;
            }

            activated = true;
        }
    }
}
