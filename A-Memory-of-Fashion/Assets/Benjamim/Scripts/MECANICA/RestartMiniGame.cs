using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartMiniGame : MonoBehaviour
{
    public void Restart()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
