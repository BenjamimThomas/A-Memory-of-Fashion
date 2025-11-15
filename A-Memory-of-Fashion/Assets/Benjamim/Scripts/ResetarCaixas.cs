using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetarCaixas : MonoBehaviour
{
    public string sceneParaRecarregar;

    public void Resetar()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();

        Inventory.instance.vestidoVermelhoSlot.SetActive(false);
        Inventory.instance.vestidoAzulSlot.SetActive(false);
        Inventory.instance.sapatoAzulSlot.SetActive(false);
        Inventory.instance.sapatoVermelhoSlot.SetActive(false);

        if (CharacterOutfit.instance != null)
        {
            CharacterOutfit.instance.vestidoRenderer.sprite = null;
            CharacterOutfit.instance.sapatoRenderer.sprite = null;
            CharacterOutfit.instance.vestidoEscolhido = false;
            CharacterOutfit.instance.sapatoEscolhido = false;
        }

        SceneManager.LoadScene(sceneParaRecarregar);
    }
}
