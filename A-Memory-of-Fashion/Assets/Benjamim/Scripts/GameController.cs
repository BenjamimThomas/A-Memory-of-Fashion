using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameController : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Button startButton;

    [Header("Referências")]
    [SerializeField] private WallChallenge[] todasAsParedes;

    [Header("Áudio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] public AudioClip startSound;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (startButton != null)
        {
            startButton.onClick.AddListener(StartGame);
        }

        todasAsParedes = FindObjectsOfType<WallChallenge>();
    }

    public void StartGame()
    {
        if (audioSource != null && startSound != null)
        {
            audioSource.PlayOneShot(startSound);
        }

        if (startButton != null)
        {
            startButton.gameObject.SetActive(false);
        }

        foreach (WallChallenge wall in todasAsParedes)
        {
            if (wall != null)
            {
                wall.StartMovement();
            }
        }
    }

    internal void ShowChallengeUI(WallChallenge wallChallenge, string correctLetter)
    {
        throw new NotImplementedException();
    }
}