using UnityEngine;

public class WallChallenge : MonoBehaviour
{
    [Header("Wall Settings")]
    [SerializeField] private float wallSpeed = 2f;
    [SerializeField] private float knockbackForce = 8f;
    [SerializeField] private float resetXPosition = -10f;
    [SerializeField] private float startXPosition = 10f;

    private string correctLetter = "w";
    private bool challengeSuccess = false;
    public int wallIndex;

    [HideInInspector] public bool challengeStarted = false;

    private Transform player;
    private Rigidbody2D playerRb;
    private GameController gameController;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        if (player != null)
            playerRb = player.GetComponent<Rigidbody2D>();
        else
            Debug.LogError("ERRO: Player não encontrado na cena!");

        gameController = FindObjectOfType<GameController>();
        if (gameController == null)
            Debug.LogError("ERRO: GameController não encontrado na cena!");
    }

    void Update()
    {
        if (!challengeStarted) return;

        transform.Translate(Vector2.left * wallSpeed * Time.deltaTime);

        if (transform.position.x <= resetXPosition)
            ResetWall();
    }

    public void StartMovement()
    {
        gameObject.SetActive(true);
        challengeStarted = true;
        challengeSuccess = false;

        string[] movementLetters = { "w", "a", "s", "d" };
        int randomIndex = Random.Range(0, movementLetters.Length);
        correctLetter = movementLetters[randomIndex];
    }

    public void ActivateChallengeUI()
    {
        if (challengeStarted && !challengeSuccess && gameController != null)
            gameController.ShowChallengeUI(this, correctLetter, wallIndex); 
    }

    public void ChallengeSuccess()
    {
        challengeSuccess = true;
        ResetWall();
    }

    private void ResetWall()
    {
        transform.position = new Vector3(startXPosition, transform.position.y, transform.position.z);
        gameObject.SetActive(false);
        challengeStarted = false;
        challengeSuccess = false;
        VictoryDefeatManager.instance.RegisterWallCompleted();
    }
}