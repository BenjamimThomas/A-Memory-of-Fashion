using UnityEngine;

public class WallChallenge : MonoBehaviour
{
    [Header("Wall Settings")]
    [SerializeField] private float wallSpeed = 2f;
    [SerializeField] private float resetXPosition = -10f;
    [SerializeField] private float startXPosition = 10f;

    private string correctLetter = "w";
    private bool challengeSuccess = false;
    public int wallIndex;

    [HideInInspector] public bool challengeStarted = false;

    private GameController gameController;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 

        gameController = FindObjectOfType<GameController>();
        if (gameController == null)
            Debug.LogError("ERRO: GameController não encontrado na cena!");
    }

    void Update()
    {
        if (!challengeStarted) return;


        
        rb.MovePosition(rb.position + Vector2.left * wallSpeed * Time.deltaTime);

        if (rb.position.x <= resetXPosition)
            ResetWall();
    }

    public void StartMovement()
    {
        this.enabled = true;
        gameObject.SetActive(true);

        challengeStarted = true;
        challengeSuccess = false;

        string[] letters = { "w", "a", "s", "d" };
        correctLetter = letters[Random.Range(0, letters.Length)];


        Debug.Log(gameObject.name + " START MOVEMENT! posX = " + transform.position.x);

    }

    public void ActivateChallengeUI()
    {
        if (challengeStarted && !challengeSuccess)
            gameController.ShowChallengeUI(this, correctLetter, wallIndex);
    }

    public void ChallengeSuccess()
{
    challengeSuccess = true;

    if (VictoryDefeatManager.instance != null)
        VictoryDefeatManager.instance.RegisterWallCompleted();

    ResetWall();
}

    private void ResetWall()
    {
        rb.position = new Vector2(startXPosition, rb.position.y);

        challengeStarted = false;
        challengeSuccess = false;
    }

    public void ResetForRestart()
    {
        rb.position = new Vector2(startXPosition, rb.position.y);
        challengeStarted = false;
        challengeSuccess = false;
        Debug.Log(gameObject.name + " RESET! posX = " + transform.position.x);

    }
}
