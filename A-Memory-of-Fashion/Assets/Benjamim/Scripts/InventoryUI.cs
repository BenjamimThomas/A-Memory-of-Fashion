using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;
    private bool isOpen = false;
    private Animator animator;

    void Start()
    {
        animator = inventoryPanel.GetComponent<Animator>();
        inventoryPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (isOpen)
                CloseInventory();
            else
                OpenInventory();
        }
    }

    void OpenInventory()
    {
        inventoryPanel.SetActive(true);
        animator.SetTrigger("Open");
        isOpen = true;

        PlayerMovements1.canMove = false;
    }

    void CloseInventory()
    {
        animator.SetTrigger("Close");
        isOpen = false;

        PlayerMovements1.canMove = true;

        StartCoroutine(HideAfterDelay());
    }

    System.Collections.IEnumerator HideAfterDelay()
    {
        yield return new WaitForSeconds(0.3f);
        if (!isOpen)
            inventoryPanel.SetActive(false);
    }
}
