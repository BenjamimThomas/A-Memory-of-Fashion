using UnityEngine;

public class TocarSomNaParede : MonoBehaviour
{
    private AudioSource audioSource;
    private bool somJaTocado = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource faltando no Child da Parede. Adicione um componente Audio Source!");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!somJaTocado)
            {
                if (audioSource != null)
                {
                    audioSource.Play();
                    somJaTocado = true;
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            somJaTocado = false;
        }
    }
}