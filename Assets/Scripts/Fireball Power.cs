using UnityEngine;
using TMPro;

public class FireballPower : MonoBehaviour
{
    public TextMeshProUGUI promptText;
    private Collider2D fireballTrigger;
    public GameObject fireballPickup;
    private bool playerInRange = false;

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
            playerInRange = true;
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
            playerInRange = false;
            if (promptText != null)
            {
                promptText.gameObject.SetActive(false);
            }
        }
    }

    private void Update()
    {
        // Check if player is in range and presses E
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            fireballPickup.SetActive(false);
        }
    }
}