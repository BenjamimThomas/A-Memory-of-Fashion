using UnityEngine;

public class ToggleAnyPanel : MonoBehaviour
{
    [Header("Painel que será aberto/fechado")]
    public GameObject panel; 

    public void Toggle()
    {
        if (panel == null)
        {
            Debug.LogWarning($"Nenhum painel atribuído ao botão {gameObject.name}!");
            return;
        }

        panel.SetActive(!panel.activeSelf); 
    }
}
