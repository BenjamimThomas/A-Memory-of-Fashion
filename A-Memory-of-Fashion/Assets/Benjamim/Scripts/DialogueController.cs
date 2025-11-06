using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    [Header("Referência ao controlador de diálogo")]
    public DialogueController dialogueController;

    [Header("Linhas de diálogo do rádio")]
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
        if (dialogueController != null)
        {
            dialogueController.StartDialogue(radioLines);
        }
        else
        {
            Debug.LogWarning("DialogueController não atribuído no inspector!");
        }
    }
}
