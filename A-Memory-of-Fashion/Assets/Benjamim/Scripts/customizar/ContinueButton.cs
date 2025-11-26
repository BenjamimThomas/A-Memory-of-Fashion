using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueButton : MonoBehaviour
{
    public string proximaScene;

    public void TentarAvancar()
    {
        if (CharacterOutfit.instance.PodeAvancar())
        {
            SceneManager.LoadScene(proximaScene);
        }
        else
        {
            Debug.Log("Escolha um vestido e um sapato antes!");
        }
    }
}
