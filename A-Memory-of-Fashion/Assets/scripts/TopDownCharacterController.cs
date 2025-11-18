using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    public class TopDownCharacterController : MonoBehaviour
    {
        public float speed;
        public AudioClip stepSound;
        public float stepInterval = 0.35f;

        private Animator animator;
        private SpriteRenderer spriteRenderer;
        private AudioSource audioSource;
        private float stepTimer;

        private void Start()
        {
            animator = GetComponent<Animator>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            audioSource = GetComponent<AudioSource>();

            if (audioSource != null && stepSound != null)
            {
                audioSource.clip = stepSound;
            }

            stepTimer = stepInterval;
        }

        private void Update()
        {
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
            bool isMoving = dir.magnitude > 0;
            animator.SetBool("IsMoving", isMoving);
            GetComponent<Rigidbody2D>().linearVelocity = speed * dir;

            if (isMoving && audioSource != null)
            {
                stepTimer -= Time.deltaTime;

                if (stepTimer <= 0)
                {
                    audioSource.Play();
                    stepTimer = stepInterval;
                }
            }
            else
            {
                stepTimer = stepInterval;
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                spriteRenderer.sortingOrder = 0;
                Debug.Log("Sorting Order -> 0");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                spriteRenderer.sortingOrder = 1;
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
                spriteRenderer.sortingOrder = -1;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("HighArea"))
            {
                spriteRenderer.sortingOrder = 0;
            }
        }
    }
}