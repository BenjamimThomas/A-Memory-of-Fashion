using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class RadioInteractable : MonoBehaviour 
{
    [Header("Referência ao Gerenciador de Diálogo")]
    public DialogueManager dialogueManager; 

    [Header("Linhas de diálogo que este rádio deve tocar")]
    public List<DialogueLine> radioLines = new List<DialogueLine>();

    private Button radioButton;

    void Awake()
    {
        radioButton = GetComponent<Button>();
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
        }
        else
        {
            Debug.LogWarning("DialogueManager não atribuído no inspector!");
        }
    }
}