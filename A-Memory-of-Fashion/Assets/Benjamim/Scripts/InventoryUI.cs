using UnityEngine;
using System.Collections; 
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
        animator.SetBool("IsOpen", true); 
        isOpen = true;
    }
    void CloseInventory()
    {
        animator.SetBool("IsOpen", false);

        StopAllCoroutines();
        StartCoroutine(HideAfterDelay());

        isOpen = false;
    }
    IEnumerator HideAfterDelay()
    {
        yield return new WaitForSeconds(0.5f);
        if (!isOpen)
        {
            inventoryPanel.SetActive(false);
        }
    }
}