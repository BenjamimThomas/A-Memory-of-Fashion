using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class RadioInteractable : MonoBehaviour 
{
    [Header("Referência ao Gerenciador de Diálogo")]
    public DialogueManager dialogueManager;

    public static bool radioFoiClicado = false;

    [Header("Botão do corredor")]
    public GameObject botaoCorredor;

    [Header("Linhas de diálogo do rádio")]
    public List<DialogueLine> radioLines = new List<DialogueLine>();

    private Button radioButton;
    private Button corredorBtn;

    void Awake()
    {
        radioButton = GetComponent<Button>();

        radioFoiClicado = PlayerPrefs.GetInt("RadioClicado", 0) == 1;

        corredorBtn = botaoCorredor.GetComponent<Button>();

        if (radioFoiClicado)
            botaoCorredor.SetActive(true);
        else
            botaoCorredor.SetActive(false);

        radioButton.onClick.AddListener(PlayRadioDialogue);
    }

    void PlayRadioDialogue()
    {
        dialogueManager.StartDialogue(radioLines);

        radioFoiClicado = true;
        PlayerPrefs.SetInt("RadioClicado", 1);
        PlayerPrefs.Save();

        botaoCorredor.SetActive(true);
        corredorBtn.interactable = true;
    }
}
