using UnityEngine;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour
{
    void Start()
    {

    }
    public void StartDialogue(List<DialogueLine> lines)
    {
        Debug.Log("Iniciando diálogo com " + lines.Count + " linhas.");
    }

    



}