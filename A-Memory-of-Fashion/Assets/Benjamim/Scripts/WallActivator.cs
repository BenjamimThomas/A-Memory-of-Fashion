using UnityEngine;
using TMPro; 
using UnityEngine.UI; 

public class ChallengeInputManager : MonoBehaviour
{
    public RectTransform targetRect;
    public TextMeshProUGUI letterText; 

    [SerializeField] private float marginPercentage = 0.1f;
    
    private WallChallenge activeChallenge;
    private string requiredLetter;
    
    public void SetupChallenge(WallChallenge challenge, string letter)
    {
        activeChallenge = challenge;
        requiredLetter = letter;
        letterText.text = requiredLetter.ToUpper();
        gameObject.SetActive(true);
    }

    void Update()
    {
        if (activeChallenge == null) return;

        if (Input.GetKeyDown(requiredLetter))
        {
            HandleSuccess();
        }
    }

    private void HandleSuccess()
    {
        MoveToRandomPosition();
        activeChallenge.ChallengeSuccess();
        activeChallenge = null;
        gameObject.SetActive(false);
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
}