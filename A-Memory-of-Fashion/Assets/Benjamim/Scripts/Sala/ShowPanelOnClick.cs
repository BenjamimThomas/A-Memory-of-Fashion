using UnityEngine;

public class ToggleAnyPanel : MonoBehaviour
{
    public GameObject panel;
    public GameObject[] paineisParaFechar;

    public void Toggle()
    {
        foreach (var p in paineisParaFechar)
            if (p != null)
                p.SetActive(false);

        panel.SetActive(!panel.activeSelf);
    }
}
