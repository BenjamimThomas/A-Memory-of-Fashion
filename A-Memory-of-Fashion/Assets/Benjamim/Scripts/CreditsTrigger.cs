using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsTrigger : MonoBehaviour
{
    [SerializeField] private string creditsSceneName = "Creditos";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        if (GameManagerMenu.instance == null || !GameManagerMenu.instance.interactionsEnabled)
        {
            Debug.Log("CreditsTrigger: interações desativadas (clique no espelho primeiro).");
            return;
        }

        SceneManager.LoadScene(creditsSceneName);
    }
}
