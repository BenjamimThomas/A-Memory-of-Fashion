using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_sala : MonoBehaviour
{
    public void TrocarCena(string nomeDaCena)
    {

        {
           SceneManager.LoadScene(nomeDaCena);
        }
    }
}
