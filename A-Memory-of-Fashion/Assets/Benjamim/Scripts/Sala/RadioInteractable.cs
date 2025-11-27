using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class RadioInteractable : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public static bool radioFoiClicado = false;

    public GameObject botaoCorredor;
    public List<DialogueLine> radioLines = new List<DialogueLine>();

    private Button radioButton;

    void Awake()
    {
        radioButton = GetComponent<Button>();

        radioFoiClicado = PlayerPrefs.GetInt("RadioClicado", 0) == 1;

        if (radioFoiClicado)
        {
            botaoCorredor.SetActive(true);
            botaoCorredor.GetComponent<Button>().interactable = true;
        }
        else
        {
            botaoCorredor.SetActive(false);
        }

        radioButton.onClick.AddListener(PlayRadioDialogue);
    }

    void PlayRadioDialogue()
    {
        dialogueManager.StartDialogue(radioLines);

        radioFoiClicado = true;
        PlayerPrefs.SetInt("RadioClicado", 1);
        PlayerPrefs.Save();

        botaoCorredor.SetActive(true);
        botaoCorredor.GetComponent<Button>().interactable = true;
    }
}
