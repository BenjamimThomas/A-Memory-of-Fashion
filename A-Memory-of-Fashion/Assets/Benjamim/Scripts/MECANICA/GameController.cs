using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [Header("Walls")]
    public WallChallenge[] walls;   // Todas as paredes via Inspector

    [Header("Botoes de Desafio")]
    public GameObject[] keyButtons;
    public GameObject[] successButtons;

    [Header("Botao Start")]
    public GameObject startButton;

    private TextMeshProUGUI[] keyButtonTexts;

    private WallChallenge activeWall;
    private string requiredKey;
    private bool keyWasPressed;

    void Awake()
    {
        keyButtonTexts = new TextMeshProUGUI[keyButtons.Length];

        for (int i = 0; i < keyButtons.Length; i++)
        {
            keyButtonTexts[i] = keyButtons[i].GetComponentInChildren<TextMeshProUGUI>(true);

            if (keyButtonTexts[i] == null)
                Debug.LogError($"ERRO: O botao {i} nao possui TextMeshProUGUI como filho!");
        }
    }

    void Start()
    {
        DeactivateAllButtons();
    }

    void Update()
    {
        if (activeWall != null && keyWasPressed == false)
            CheckInput();
    }

    public void StartAllWalls()
    {
        foreach (var wall in walls)
        {
            wall.StartMovement();
        }

        startButton.SetActive(false);
    }

    public void RestartGame()
    {
        Debug.Log("RESTART chamado");

        foreach (var wall in walls)
        {
            wall.ResetForRestart();
            wall.StartMovement();
        }

        DeactivateAllButtons();
        activeWall = null;
        keyWasPressed = false;

        startButton.SetActive(false);
    }

    public void OnStartButton()
    {
        StartAllWalls();
    }

    public void OnRestartButton()
    {
        RestartGame();
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
