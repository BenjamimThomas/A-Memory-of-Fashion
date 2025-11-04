using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsTrigger : MonoBehaviour
{
    [SerializeField] private string creditsSceneName = "Creditos";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(creditsSceneName);
        }
    }
}