using UnityEngine;
using TMPro;

public class TextTrigger : MonoBehaviour
{
    public TextMeshProUGUI promptText;
    private Collider2D textTrigger;

    private void Start()
    {
        textTrigger = GetComponent<Collider2D>();
        textTrigger.enabled = true;

        if (promptText != null)
        {
            promptText.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (promptText != null)
            {
                promptText.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (promptText != null)
            {
                promptText.gameObject.SetActive(false);
            }
        }
    }
}