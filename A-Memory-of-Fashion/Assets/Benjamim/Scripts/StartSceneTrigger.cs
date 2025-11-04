using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneTrigger : MonoBehaviour
{
    [SerializeField] private string casaSceneName = "Casa 1";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(casaSceneName);
        }
    }
}

