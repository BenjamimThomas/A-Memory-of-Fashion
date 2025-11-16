using UnityEngine;

public class WallActivator : MonoBehaviour
{
    public WallChallenge parentWall;

    void Reset()
    {
        if (parentWall == null) parentWall = GetComponentInParent<WallChallenge>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        
        parentWall.ActivateChallengeUI();
    }
}