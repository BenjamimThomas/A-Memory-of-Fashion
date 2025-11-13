using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SortingOrderByY : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    [Header("Ajuste fino (quanto maior, mais sensível a diferença de Y)")]
    public float offset = 0f;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void LateUpdate()
    {
        // Inverte Y para que objetos mais baixos fiquem na frente
        spriteRenderer.sortingOrder = Mathf.RoundToInt(-(transform.position.y + offset) * 100);
    }
}
