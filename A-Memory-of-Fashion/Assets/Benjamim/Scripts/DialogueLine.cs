using UnityEngine;

[System.Serializable]
public class DialogueLine
{
    public string characterName;
    [TextArea(3, 10)] 
    public string lineText;
}