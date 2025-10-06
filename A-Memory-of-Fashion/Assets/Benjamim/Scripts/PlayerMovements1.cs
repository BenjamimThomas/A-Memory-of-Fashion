using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovements1 : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private Rigidbody2D rb;
    private bool isGrounded = false;
    [HideInInspector] public float baseSpeed; 

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    

    public float KBForce;
    public float KBCount;
    public float KBTime;
    public float KBDirection = 1;

    public bool isKnockRight;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        baseSpeed = moveSpeed; 
    }

    void Update()
    {
        KnockLogic();

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        // Pular
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Vector2 force = new Vector2(rb.linearVelocity.x, jumpForce);
            rb.AddForce(force, ForceMode2D.Impulse);
        }
    }

    void KnockLogic()
    {
        if (KBCount < 0)
        {
            if (Input.GetKey(KeyCode.D))
            {
                rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);
            }
        }
        else
        {
            if (isKnockRight == true)
            {
                rb.linearVelocity = new Vector2(KBDirection * KBForce, rb.linearVelocity.y);
            }
        }
        KBCount -= Time.deltaTime;
    }
}
