using UnityEngine;
using System.Collections.Generic;
using TMPro;


public class DialogueManager : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject dialogueBox; 
    public TextMeshProUGUI nameText; 
    public TextMeshProUGUI dialogueText; 
    
    private List<DialogueLine> currentLines;
    private int currentLineIndex;

    void Start()
    {
        if (dialogueBox != null)
        {
            dialogueBox.SetActive(false);
        }
    }

    public void StartDialogue(List<DialogueLine> lines)
    {
        currentLines = lines;
        currentLineIndex = 0;
        
        dialogueBox.SetActive(true);
        DisplayCurrentLine();
    }
    
    void Update()
    {
        if (dialogueBox != null && dialogueBox.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            NextLine();
        }
    }

    void DisplayCurrentLine()
    {
        if (currentLines != null && currentLineIndex < currentLines.Count)
        {
            DialogueLine line = currentLines[currentLineIndex];
            nameText.text = line.characterName;
            dialogueText.text = line.lineText;
        }
        else
        {
            EndDialogue();
        }
    }

    void NextLine()
    {
        currentLineIndex++;
        DisplayCurrentLine();
    }

    void EndDialogue()
    {
        dialogueBox.SetActive(false);
        currentLines = null;
        currentLineIndex = 0;
        Debug.Log("Diálogo finalizado.");
    }
}