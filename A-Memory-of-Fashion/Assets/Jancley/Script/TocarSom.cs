using UnityEngine;

public class TocarSom : MonoBehaviour
{
    private AudioSource radioAudioSource;

    void Start()
    {
        // Pega o componente AudioSource que está no mesmo objeto
        radioAudioSource = GetComponent<AudioSource>();
    }

    // Método que você chama para tocar o som
    public void TocarRadio()
    {
        if (radioAudioSource != null && !radioAudioSource.isPlaying)
        {
            radioAudioSource.Play();
        }
    }
}