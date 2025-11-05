using UnityEngine;

public class EnterButtonTrigger : MonoBehaviour
{
    [Tooltip("Arraste aqui os Collider2D dos triggers (Start, Creditos, Sair)")]
    public Collider2D[] triggersToEnable;

    [Tooltip("Se true, também ativa GameObjects inteiros ao invés de apenas colliders")]
    public GameObject[] objectsToEnable;

    public void OnMirrorButtonPressed()
    {
        if (triggersToEnable != null)
        {
            foreach (var col in triggersToEnable)
            {
                if (col != null) col.enabled = true;
            }
        }
        if (objectsToEnable != null)
        {
            foreach (var go in objectsToEnable)
            {
                if (go != null) go.SetActive(true);
            }
        }

        Debug.Log("Espelho: triggers ativados.");
    }
}
