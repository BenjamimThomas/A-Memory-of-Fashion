using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    private Camera cam;
    private float halfHeight;
    private float halfWidth;

    [Header("Som do Teleporte")]
    public AudioSource audioSource;
    public AudioClip teleportSound;

    void Start()
    {
        cam = Camera.main;
        halfHeight = cam.orthographicSize;
        halfWidth = halfHeight * cam.aspect;
    }

    void Update()
    {
        Vector3 pos = transform.position;
        bool teleported = false;

        if (pos.x > halfWidth)
        {
            pos.x = -halfWidth;
            teleported = true;
        }
        else if (pos.x < -halfWidth)
        {
            pos.x = halfWidth;
            teleported = true;
        }

        if (pos.y > halfHeight)
        {
            pos.y = -halfHeight;
            teleported = true;
        }
        else if (pos.y < -halfHeight)
        {
            pos.y = halfHeight;
            teleported = true;
        }

        if (teleported)
        {
            if (audioSource != null && teleportSound != null)
            {
                audioSource.PlayOneShot(teleportSound);
            }
        }

        transform.position = pos;
    }
}
