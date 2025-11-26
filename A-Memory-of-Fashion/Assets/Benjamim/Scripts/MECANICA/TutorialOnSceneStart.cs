using UnityEngine;

public class TutorialOnSceneStart : MonoBehaviour
{
    [Header("Painel de Tutorial")]
    public GameObject tutorialPanel;

    void Start()
    {
        if (tutorialPanel == null)
        {
            Debug.LogWarning("Nenhum painel de tutorial atribuído no TutorialOnSceneStart!");
            return;
        }

        tutorialPanel.SetActive(true);
    }

    public void CloseTutorial()
    {
        tutorialPanel.SetActive(false);
    }
}
