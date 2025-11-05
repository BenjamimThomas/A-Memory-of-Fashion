using UnityEngine;

public class MirrorButtonEnable : MonoBehaviour
{
    public void OnMirrorButtonPressed()
    {
        if (GameManagerMenu.instance != null)
            GameManagerMenu.instance.EnableInteractions();
    }
}
