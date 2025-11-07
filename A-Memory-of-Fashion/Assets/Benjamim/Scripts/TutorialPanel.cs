using UnityEngine;

public class TutorialPanel : MonoBehaviour
{
    [Header("Painel do Tutorial")]
    public GameObject tutorialPanel;

    private bool isOpen = false;

    void Start()
    {
        if (tutorialPanel != null)
            tutorialPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            isOpen = !isOpen;
            tutorialPanel.SetActive(isOpen);

            PlayerMovements1.canMove = !isOpen;
        }
    }
}
