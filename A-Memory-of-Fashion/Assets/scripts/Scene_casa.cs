using UnityEngine;
using UnityEngine.SceneManagement;

public class MudarDeCena : MonoBehaviour
{
    // Esta fun��o ser� chamada pelo bot�o da UI
    public void TrocarCena(string nomeDaCena)
    {

        {
            SceneManager.LoadScene(nomeDaCena);
        }
    }
}