using UnityEngine;

public class BlocoCai : MonoBehaviour
{
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic; // começa travado
    }

    public void Cair()
    {
        rb.bodyType = RigidbodyType2D.Dynamic; // libera para cair
    }
}