using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    [SerializeField] private AudioSource clickSound;
    [SerializeField] private Button button;

    void Start()
    {
        if (button != null)
            button.onClick.AddListener(PlayClickSound);
    }

    void PlayClickSound()
    {
        if (clickSound != null)
            clickSound.Play();
    }
}
