using UnityEngine;

public class TeleportManager : MonoBehaviour
{
    public GameObject teleporter; 
    public float checkInterval = 0.2f; 

    void Start()
    {
        bool radioClicado = PlayerPrefs.GetInt("RadioClicado", 0) == 1;
        teleporter.SetActive(radioClicado);

        if (!radioClicado) teleporter.SetActive(false);

        StartCoroutine(PollRadioFlag());
    }

    System.Collections.IEnumerator PollRadioFlag()
    {
        while (!teleporter.activeSelf)
        {
            if (PlayerPrefs.GetInt("RadioClicado", 0) == 1 || RadioInteractable.radioFoiClicado)
            {
                Debug.Log("TeleportManager: ativando teleporte porque rádio foi clicado");
                teleporter.SetActive(true);
                yield break;
            }
            yield return new WaitForSeconds(checkInterval);
        }
    }
}
