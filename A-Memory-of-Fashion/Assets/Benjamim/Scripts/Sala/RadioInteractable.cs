using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class RadioInteractable : MonoBehaviour 
{
    [Header("Referência ao Gerenciador de Diálogo")]
    public DialogueManager dialogueManager;

    public static bool radioFoiClicado = false;
    public GameObject spriteParaSumir;
    public GameObject botaoCorredor;

    [Header("Linhas de diálogo que este rádio deve tocar")]
    public List<DialogueLine> radioLines = new List<DialogueLine>();

    private Button radioButton;

    void Awake()
    {
        radioButton = GetComponent<Button>();

        radioFoiClicado = PlayerPrefs.GetInt("RadioClicado", 0) == 1;

        if (radioButton != null)
        {
            radioButton.onClick.AddListener(PlayRadioDialogue);
        }
        else
        {
            Debug.LogError("Nenhum componente Button encontrado neste objeto!");
        }
    }


    void PlayRadioDialogue()
    {
        if (dialogueManager != null)
        {
            dialogueManager.StartDialogue(radioLines);
            radioFoiClicado = true;
            PlayerPrefs.SetInt("RadioClicado", 1);
            PlayerPrefs.Save();
            spriteParaSumir.SetActive(false);
            botaoCorredor.SetActive(true);
        }
        else
        {
            Debug.LogWarning("DialogueManager não atribuído no inspector!");
        }
    }
}