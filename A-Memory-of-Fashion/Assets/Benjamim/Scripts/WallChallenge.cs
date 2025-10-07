using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WallChallenge : MonoBehaviour
{
    [Header("Configurações do Desafio")]
    public float startTime = 12f;
    public float timeDecreasePerWall = 1f;
    public float moveSpeed = 2f;
    public float knockbackForce = 5f;

    [Header("Referências")]
    public Rigidbody2D rb; // -> setar no inspector (Body Type = Kinematic)
    public TextMeshProUGUI letterText;
    public TextMeshProUGUI timerText;
    public Button clickButton;

    // estado
    private char currentLetter;
    private float currentTime;
    private bool canClick = false;
    private bool challengeActive = false;
    private int wallIndex = 0;
    private Rigidbody2D playerRb;

    void Reset()
    {
        // tenta achar o Rigidbody2D automaticamente ao adicionar o componente
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        if (rb == null) rb = GetComponent<Rigidbody2D>();
        if (clickButton != null) clickButton.onClick.AddListener(OnClickWall);
        clickButton.interactable = false;
        HideUI();
    }

    void FixedUpdate()
    {
        // mover com física para evitar tunneling
        Vector2 newPos = rb.position + Vector2.left * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(newPos);
    }

    void Update()
    {
        if (!challengeActive) return;

        currentTime -= Time.deltaTime;
        timerText.text = Mathf.Max(0, currentTime).ToString("F1");

        if (!canClick)
        {
            // aceita a tecla correta (a string "a","s","w","d" funciona com Input.GetKeyDown)
            if (Input.GetKeyDown(currentLetter.ToString().ToLower()))
            {
                canClick = true;
                if (clickButton != null) clickButton.interactable = true;
            }
        }

        if (currentTime <= 0f && !canClick)
        {
            ApplyKnockback();
        }
    }

    // chamado pelo WallActivator (trigger child)
    public void StartChallenge(Rigidbody2D playerRigidbody, int index = 0)
    {
        if (challengeActive) return;
        playerRb = playerRigidbody;
        wallIndex = index;
        challengeActive = true;
        currentTime = Mathf.Max(3f, startTime - wallIndex * timeDecreasePerWall); // garante mínimo de 3s
        GenerateRandomLetter();
        ShowUI();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // colisão física com o jogador (parede corpo -> IsTrigger = false)
        if (collision.collider.CompareTag("Player"))
        {
            if (challengeActive && !canClick)
            {
                if (playerRb == null) playerRb = collision.rigidbody;
                ApplyKnockback();
            }
        }
    }

    void OnClickWall()
    {
        if (!canClick) return;
        // sucesso: passar pela parede
        challengeActive = false;
        clickButton.interactable = false;
        HideUI();

        // comportamento: wall "cai" ou é destruída
        Destroy(gameObject, 1.2f);
    }

    void GenerateRandomLetter()
    {
        char[] letters = { 'A', 'S', 'W', 'D' };
        currentLetter = letters[Random.Range(0, letters.Length)];
        if (letterText != null) letterText.text = currentLetter.ToString();
    }

    void ApplyKnockback()
    {
        if (playerRb != null)
        {
            // empurra o jogador para a esquerda — ajuste a direção se quiser outro efeito
            playerRb.AddForce(Vector2.left * knockbackForce, ForceMode2D.Impulse);
        }

        Debug.Log("Empurrado! Letra mudou!");
        GenerateRandomLetter();
        challengeActive = false;
        HideUI();
        canClick = false;
        if (clickButton != null) clickButton.interactable = false;
    }

    void ShowUI()
    {
        if (letterText != null) letterText.gameObject.SetActive(true);
        if (timerText != null) timerText.gameObject.SetActive(true);
        if (clickButton != null) clickButton.gameObject.SetActive(true);
    }

    void HideUI()
    {
        if (letterText != null) letterText.gameObject.SetActive(false);
        if (timerText != null) timerText.gameObject.SetActive(false);
        if (clickButton != null) clickButton.gameObject.SetActive(false);
    }
}
