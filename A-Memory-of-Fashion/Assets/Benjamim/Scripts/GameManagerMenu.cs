using UnityEngine;

public class GameManagerMenu : MonoBehaviour
{
    public static GameManagerMenu instance;
    public bool interactionsEnabled = false;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public void EnableInteractions()
    {
        interactionsEnabled = true;
        Debug.Log("GameManager: Interactions ENABLED.");
    }
}