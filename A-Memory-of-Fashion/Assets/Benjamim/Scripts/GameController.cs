using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public WallChallenge activeWall;
    private string requiredKey;
    private bool keyWasPressed;

    [Header("Botoes de Desafio")]
    public GameObject[] keyButtons;
    public GameObject[] successButtons;

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
        keyButtons[wallIndex].GetComponentInChildren<Text>().text = key.ToUpper();
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
        {
            btn.SetActive(false);
        }
        foreach (GameObject btn in successButtons)
        {
            btn.SetActive(false);
        }
    }
}