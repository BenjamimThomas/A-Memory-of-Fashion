using UnityEngine;

public class WallActivator : MonoBehaviour
{
    public WallChallenge parentWall;
    [Tooltip("Índice da parede (0 = primeira) para reduzir tempo progressivamente)")]
    public int wallIndex = 0;

    void Reset()
    {
        if (parentWall == null) parentWall = GetComponentInParent<WallChallenge>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();
        if (playerRb == null) return;
        parentWall.StartChallenge(playerRb, wallIndex);
    }
}
