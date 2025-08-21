using UnityEngine;
using UnityEngine.UI;

public class AtivarImagemProximidade : MonoBehaviour
{
    
    public Image imagem;

    // A tag do objeto do jogador. Verifique se a tag do seu jogador est� configurada corretamente
    public string tagDoJogador = "Plsayer";

    // O que acontece quando um objeto entra na �rea do gatilho
    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que entrou tem a tag do jogador
        if (other.CompareTag(tagDoJogador))
        {
            // Ativa a imagem
            imagem.enabled = true;
            Debug.Log("Jogador entrou na �rea. Imagem ativada.");
        }
    }

    // O que acontece quando um objeto sai da �rea do gatilho
    private void OnTriggerExit(Collider other)
    {
        // Verifica se o objeto que saiu tem a tag do jogador
        if (other.CompareTag(tagDoJogador))
        {
            // Desativa a imagem
            imagem.enabled = false;
            Debug.Log("Jogador saiu da �rea. Imagem desativada.");
        }
    }
}