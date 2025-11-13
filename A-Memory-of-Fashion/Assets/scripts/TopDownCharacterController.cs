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
            // 🔹 Teste: mudar Sorting Layer com teclas numéricas
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                spriteRenderer.sortingLayerName = "Layer 1";
                Debug.Log("Sorting Layer -> Layer 1");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                spriteRenderer.sortingLayerName = "Layer 2";
                Debug.Log("Sorting Layer -> Layer 2");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                spriteRenderer.sortingLayerName = "Layer 3";
                Debug.Log("Sorting Layer -> Layer 3");
            }
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("HighArea"))
            {
                spriteRenderer.sortingLayerName = "Layer 2";
            }
        }
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("HighArea"))
            {
                spriteRenderer.sortingLayerName = "Layer 1";
            }
        }

    }
}