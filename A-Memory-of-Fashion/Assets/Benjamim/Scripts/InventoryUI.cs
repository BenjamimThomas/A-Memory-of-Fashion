using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public Animator animator;
    private bool isOpen = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInventory();
        }
    }

    void ToggleInventory()
    {
        isOpen = !isOpen;

        if (isOpen)
        {
            inventoryPanel.SetActive(true);
            animator.SetTrigger("Open");
        }
        else
        {
            animator.SetTrigger("Close");
            StartCoroutine(CloseAfterAnimation());
        }
    }

    System.Collections.IEnumerator CloseAfterAnimation()
    {
        yield return new WaitForSeconds(0.3f); // tempo da animação de fechar
        inventoryPanel.SetActive(false);
    }
}
