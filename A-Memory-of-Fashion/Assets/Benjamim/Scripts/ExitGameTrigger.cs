using UnityEngine;

public class ExitGameTrigger : MonoBehaviour
{
    public string playerTag = "Player";

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
            Application.Quit();
    }
}
