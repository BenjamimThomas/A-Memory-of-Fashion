using UnityEngine;
using TMPro; 
using UnityEngine.UI;

public class ChallengeInputManager : MonoBehaviour
{
    public RectTransform targetRect;
    public TextMeshProUGUI letterText; 
    public Button successButton; 

    [SerializeField] private float marginPercentage = 0.1f;
    
    private WallChallenge activeChallenge;
    private string requiredLetter;
    
    private string[] movementLetters = { "w", "a", "s", "d" }; 
    
    void Start()
    {
        if (successButton != null)
        {
            successButton.onClick.AddListener(FinalizeChallenge);
            successButton.interactable = false; // Começa desabilitado
        }
    }

    public void SetupChallenge(WallChallenge challenge, string letter)
    {
        activeChallenge = challenge;
        gameObject.SetActive(true);
        StartNewInputRound();
        if (successButton != null)
        {
            successButton.interactable = false; 
        }
    }

    void Update()
    {
        if (activeChallenge == null) return;

        if (Input.GetKeyDown(requiredLetter))
        {
            HandleSuccessfulKeyInput();
        }
    }

    private void HandleSuccessfulKeyInput()
    {
        MoveToRandomPosition();
        StartNewInputRound(); 
        if (successButton != null)
        {
            successButton.interactable = true; 
        }
    }

    private void StartNewInputRound()
    {
        int randomIndex = Random.Range(0, movementLetters.Length);
        requiredLetter = movementLetters[randomIndex];
        letterText.text = requiredLetter.ToUpper();
    }
    
    public void MoveToRandomPosition()
    {
        float safeXMin = marginPercentage;
        float safeXMax = 1f - marginPercentage;
        float safeYMin = marginPercentage;
        float safeYMax = 1f - marginPercentage;

        float randomX = Random.Range(safeXMin, safeXMax);
        float randomY = Random.Range(safeYMin, safeYMax);

        targetRect.anchorMin = new Vector2(randomX, randomY);
        targetRect.anchorMax = new Vector2(randomX, randomY);
        targetRect.pivot = new Vector2(0.5f, 0.5f);
        targetRect.localPosition = Vector3.zero;
    }

    public void FinalizeChallenge()
    {
        if (activeChallenge != null)
        {
            activeChallenge.ChallengeSuccess(); 
            activeChallenge = null;
            gameObject.SetActive(false); 
        }
    }
}