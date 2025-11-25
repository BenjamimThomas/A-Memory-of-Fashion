using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public WallChallenge activeWall;
    private string requiredKey;
    private bool keyWasPressed;

    [Header("Botões de Desafio")]
    public GameObject[] keyButtons;
    public GameObject[] successButtons;

    private TextMeshProUGUI[] keyButtonTexts;

    void Awake()
    {
        keyButtonTexts = new TextMeshProUGUI[keyButtons.Length];

        for (int i = 0; i < keyButtons.Length; i++)
        {
            keyButtonTexts[i] = keyButtons[i].GetComponentInChildren<TextMeshProUGUI>(true);

            if (keyButtonTexts[i] == null)
            {
                Debug.LogError($"ERRO: O botão {i} não possui TextMeshProUGUI como filho!");
            }
        }
    }
    public void StartWalls()
    {
        WallChallenge[] allWalls = FindObjectsOfType<WallChallenge>();

        foreach (WallChallenge wall in allWalls)
        {
            wall.StartMovement();
        }

        Debug.Log("Todas as paredes foram iniciadas!");
    }

    void Update()
    {
        if (activeWall != null && keyWasPressed == false)
        {
            CheckInput();
        }
    }

    private void CheckInput()
    {
        if (Input.GetKeyDown(requiredKey))
        {
            keyWasPressed = true;
            OnKeySuccess();
        }
    }

    private void OnKeySuccess()
    {
        if (activeWall == null) return;

        keyButtons[activeWall.wallIndex].SetActive(false);
        successButtons[activeWall.wallIndex].SetActive(true);
    }

    public void ShowChallengeUI(WallChallenge wall, string key, int wallIndex)
    {
        activeWall = wall;
        requiredKey = key.ToLower();
        keyWasPressed = false;

        DeactivateAllButtons();

        keyButtons[wallIndex].SetActive(true);

        keyButtonTexts[wallIndex].text = key.ToUpper();
    }

    public void OnSuccessButtonClicked()
    {
        if (activeWall == null) return;

        activeWall.ChallengeSuccess();
        activeWall = null;
        DeactivateAllButtons();
    }

    private void DeactivateAllButtons()
    {
        foreach (GameObject btn in keyButtons)
            btn.SetActive(false);

        foreach (GameObject btn in successButtons)
            btn.SetActive(false);
    }
}
