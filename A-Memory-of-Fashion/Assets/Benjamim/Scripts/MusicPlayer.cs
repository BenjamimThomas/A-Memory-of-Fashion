using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip musicClip;  // A música específica dessa cena
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = musicClip;
        audioSource.loop = true;
        audioSource.playOnAwake = false;
        audioSource.Play();
    }
}