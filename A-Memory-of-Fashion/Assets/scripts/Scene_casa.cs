using UnityEngine;
using UnityEngine.SceneManagement;

public class MudarDeCena : MonoBehaviour
{
    // Esta função será chamada pelo botão da UI
    public void TrocarCena(string nomeDaCena)
    {

        {
            SceneManager.LoadScene(nomeDaCena);
        }
    }
}