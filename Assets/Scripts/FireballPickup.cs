using UnityEngine;
using TMPro;


public class FireballPickup : MonoBehaviour
{
    public GameObject closedChest;
    public GameObject openChest;
    public GameObject fireballPickup;
    private bool chestOpened = false;

    // Reference to this object's collider
    private Collider2D chestTrigger;

    private void Start()
    {
        chestTrigger = GetComponent<Collider2D>();

        if (closedChest != null) closedChest.SetActive(true);
        if (openChest != null) openChest.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !chestOpened)
        {
            OpenChest();
        }
    }

    void OpenChest()
    {
        fireballPickup.SetActive(true);

        if (chestOpened) return;

        chestOpened = true;

        // Switch chest visuals
        if (closedChest != null) closedChest.SetActive(false);
        if (openChest != null) openChest.SetActive(true);

        // Disable the trigger after opening
        if (chestTrigger != null) chestTrigger.enabled = false;

    }
}