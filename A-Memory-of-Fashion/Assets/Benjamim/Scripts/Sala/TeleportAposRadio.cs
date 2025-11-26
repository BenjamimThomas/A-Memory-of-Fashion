using UnityEngine;

public class TeleportAposRadio : MonoBehaviour
{
    void Start()
    {
        if (!RadioInteractable.radioFoiClicado)
            gameObject.SetActive(false);
    }

    void Update()
    {
        if (!gameObject.activeSelf && RadioInteractable.radioFoiClicado)
        {
            gameObject.SetActive(true);
        }
    }
}
