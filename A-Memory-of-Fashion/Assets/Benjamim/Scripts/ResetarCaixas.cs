using UnityEngine;

public class ResetarCaixas : MonoBehaviour
{
    public GameObject slotVestidoVermelho;
    public GameObject slotVestidoAzul;
    public GameObject slotSapatoVermelho;
    public GameObject slotSapatoAzul;

    public GameObject caixaVestidoVermelho;
    public GameObject caixaVestidoAzul;
    public GameObject caixaSapatoVermelho;
    public GameObject caixaSapatoAzul;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        Resetar();
    }

    void Resetar()
    {
        Inventory.instance.temVestidoVermelho = false;
        Inventory.instance.temVestidoAzul = false;
        Inventory.instance.temSapatoVermelho = false;
        Inventory.instance.temSapatoAzul = false;

        slotVestidoVermelho.SetActive(false);
        slotVestidoAzul.SetActive(false);
        slotSapatoVermelho.SetActive(false);
        slotSapatoAzul.SetActive(false);

        caixaVestidoVermelho.SetActive(true);
        caixaVestidoAzul.SetActive(true);
        caixaSapatoVermelho.SetActive(true);
        caixaSapatoAzul.SetActive(true);
    }
}
