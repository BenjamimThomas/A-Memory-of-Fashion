using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class WallChallenge : MonoBehaviour
{
    [Header("Configurações do Desafio")]
    public float startTime = 12f;
    public float timeDecreasePerWall = 1f;
    public float moveSpeed = 2f;
    public float knockbackForce = 5f;

    [Header("Referências")]
    public TextMeshProUGUI letterText;
    public TextMeshProUGUI timerText;
    public Button clickButton;
    public Transform player;

    private char currentLetter;
    private float currentTime;
    private bool canClick = false;
    private bool challengeActive = false;
    private int wallIndex = 0;
    private Rigidbody2D playerRb;

    void Start()
    {
        clickButton.onClick.AddListener(OnClickWall);
        clickButton.interactable = false;
        HideUI();
    }

    void Update()
    {
        // Movimento da parede para a esquerda
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

        // Se estiver ativa, atualiza o tempo
        if (challengeActive)
        {
            currentTime -= Time.deltaTime;
            timerText.text = currentTime.ToString("F1");

            if (Input.GetKeyDown(currentLetter.ToString().ToLower()))
            {
                canClick = true;
                clickButton.interactable = true;
            }

            // Se o tempo acabar e o jogador não tiver desbloqueado
            if (currentTime <= 0 && !canClick)
            {
                ApplyKnockback();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !challengeActive)
        {
            playerRb = other.GetComponent<Rigidbody2D>();
            player = other.transform;
            StartChallenge();
        }
    }

    void StartChallenge()
    {
        challengeActive = true;
        currentTime = startTime - (wallIndex * timeDecreasePerWall);
        GenerateRandomLetter();
        ShowUI();
    }

    void OnClickWall()
    {
        if (canClick)
        {
            Debug.Log("Pulou a parede!");
            wallIndex++;
            challengeActive = false;
            HideUI();

            // Você pode fazer a parede “cair” ou desativar aqui
            Destroy(gameObject, 2f);
        }
    }

    void GenerateRandomLetter()
    {
        char[] letters = { 'A', 'S', 'W', 'D' };
        currentLetter = letters[Random.Range(0, letters.Length)];
        letterText.text = currentLetter.ToString();
    }

    void ApplyKnockback()
    {
        if (playerRb != null)
        {
            playerRb.AddForce(Vector2.left * knockbackForce, ForceMode2D.Impulse);
        }

        Debug.Log("Empurrado! Letra mudou!");
        GenerateRandomLetter();
        challengeActive = false;
        HideUI();
    }

    void ShowUI()
    {
        letterText.gameObject.SetActive(true);
        timerText.gameObject.SetActive(true);
        clickButton.gameObject.SetActive(true);
    }

    void HideUI()
    {
        letterText.gameObject.SetActive(false);
        timerText.gameObject.SetActive(false);
        clickButton.gameObject.SetActive(false);
    }
}
