using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryDefeatManager : MonoBehaviour
{
    public static VictoryDefeatManager instance;

    public GameObject victoryPanel;
    public GameObject defeatPanel;

    public AudioSource audioSource;
    public AudioClip victoryMusic;
    public AudioClip defeatMusic;

    private int totalWalls = 10;
    private int wallsCompleted = 0;

    void Awake()
    {
        instance = this;
    }

    public void RegisterWallCompleted()
    {
        wallsCompleted++;

        if (wallsCompleted >= totalWalls)
        {
            Time.timeScale = 0;
            victoryPanel.SetActive(true);

            if (audioSource != null && victoryMusic != null)
                audioSource.PlayOneShot(victoryMusic);
        }
    }

    public void PlayerDied()
    {
        Time.timeScale = 0;
        defeatPanel.SetActive(true);

        if (audioSource != null && defeatMusic != null)
            audioSource.PlayOneShot(defeatMusic);
    }

    public void RestartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
