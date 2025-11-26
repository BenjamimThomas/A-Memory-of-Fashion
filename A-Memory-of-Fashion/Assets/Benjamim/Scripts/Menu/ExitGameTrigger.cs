using UnityEngine;

public class ExitGameTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        if (GameManagerMenu.instance == null || !GameManagerMenu.instance.interactionsEnabled)
        {
            Debug.Log("ExitGame: interações desativadas (clique no espelho primeiro).");
            return;
        }

        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
