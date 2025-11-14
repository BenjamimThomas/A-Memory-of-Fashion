using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Cainos.PixelArtTopDown_Basic
{
    public class PropsAltar : MonoBehaviour
    {
        public List<SpriteRenderer> runes;
        public float lerpSpeed;
        public GameObject teleportButton;
        public string sceneToLoad;

        private Color curColor;
        private Color targetColor;

        private void Awake()
        {
            targetColor = runes[0].color;
            teleportButton.SetActive(false);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Caixa")) return;
            targetColor.a = 1.0f;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (!other.CompareTag("Caixa")) return;
            targetColor.a = 0.0f;
        }

        private void Update()
        {
            curColor = Color.Lerp(curColor, targetColor, lerpSpeed * Time.deltaTime);

            foreach (var r in runes)
            {
                r.color = curColor;
            }

            if (curColor.a > 0.95f)
                teleportButton.SetActive(true);
            else
                teleportButton.SetActive(false);
        }

        public void Teleport()
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
