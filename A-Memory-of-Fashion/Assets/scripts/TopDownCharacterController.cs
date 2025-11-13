using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    public class TopDownCharacterController : MonoBehaviour
    {
        public float speed;
        private Animator animator;
        private SpriteRenderer spriteRenderer;

        private void Start()
        {
            animator = GetComponent<Animator>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            // Movimento --------------------------
            Vector2 dir = Vector2.zero;
            if (Input.GetKey(KeyCode.A))
            {
                dir.x = -1;
                animator.SetInteger("Direction", 3);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                dir.x = 1;
                animator.SetInteger("Direction", 2);
            }

            if (Input.GetKey(KeyCode.W))
            {
                dir.y = 1;
                animator.SetInteger("Direction", 1);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                dir.y = -1;
                animator.SetInteger("Direction", 0);
            }

            dir.Normalize();
            animator.SetBool("IsMoving", dir.magnitude > 0);
            GetComponent<Rigidbody2D>().linearVelocity = speed * dir;

            // -------------------------------------
            // 🔹 Teste: mudar a Ordem de Renderização (Sorting Order) com teclas numéricas
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                spriteRenderer.sortingOrder = 0;
                Debug.Log("Sorting Order -> 0");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                spriteRenderer.sortingOrder = 1; // Usando números sequenciais para teste
                Debug.Log("Sorting Order -> 1");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                spriteRenderer.sortingOrder = 2;
                Debug.Log("Sorting Order -> 2");
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("HighArea"))
            {
                // Mude a ordem de renderização para um valor menor (renderiza "atrás" de objetos com 0 ou mais)
                spriteRenderer.sortingOrder = -1;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("HighArea"))
            {
                // Retorne à ordem de renderização padrão
                spriteRenderer.sortingOrder = 0;
            }
        }
    }
}