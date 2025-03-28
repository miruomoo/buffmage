using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FreezePower : MonoBehaviour
{
    public TextMeshProUGUI promptText;
    private Collider2D freezeTrigger;
    public GameObject freezePickup;
    private bool playerInRange = false;
    [SerializeField] private GameObject player;
    public GameObject freezeUI;

    private void Start()
    {
        freezeTrigger = GetComponent<Collider2D>();
        freezeTrigger.enabled = true;

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
            freezePickup.SetActive(false);
            freezeUI.SetActive(true);
            IceballShoot iceballShoot = player.GetComponent<IceballShoot>();
            if (iceballShoot != null)
            {
                iceballShoot.EnableFreezePower();
            }
        }
    }
}
