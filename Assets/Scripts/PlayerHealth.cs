using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;
    public string levelName;
    [SerializeField] private GameObject player;

    // Array of health images (hearts)
    public GameObject[] healthImages = new GameObject[3];
    public GameObject deathMenuPanel;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthDisplay();
        deathMenuPanel.SetActive(false);
        if (levelName == "level2")
        {
            FireballShoot fireballShoot = player.GetComponent<FireballShoot>();
            if (fireballShoot != null)
            {
                fireballShoot.EnableFireballPower();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object is an enemy
        if (other.CompareTag("Enemy"))
        {
            TakeDamage();
        }
        if (other.CompareTag("Health"))
        {
            Heal();
        }
    }

    private void TakeDamage()
    {
        currentHealth--;
        UpdateHealthDisplay();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Heal()
    {
        currentHealth++;
        UpdateHealthDisplay();
    }

    private void UpdateHealthDisplay()
    {
        // Deactivate health images based on current health
        for (int i = 0; i < healthImages.Length; i++)
        {
            if (healthImages[i] != null)
            {
                // Show image if i is less than currentHealth
                healthImages[i].SetActive(i < currentHealth);
            }
        }
    }

     private void Die()
    {
        deathMenuPanel.SetActive(true);
        Time.timeScale = 0f; 
    }
}