using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneTrigger : MonoBehaviour
{
    public string sceneToLoad;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        if (GameManagerMenu.instance == null || !GameManagerMenu.instance.interactionsEnabled)
        {
            Debug.Log("StartTrigger: interações desativadas (clique no espelho primeiro).");
            return;
        }
        SceneManager.LoadScene(sceneToLoad);
    }
}
