using UnityEngine;
using TMPro;

public class FireballPower : MonoBehaviour
{
    public TextMeshProUGUI promptText;
    private Collider2D fireballTrigger;

    private void Start()
    {
        fireballTrigger = GetComponent<Collider2D>();
        fireballTrigger.enabled = true;

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