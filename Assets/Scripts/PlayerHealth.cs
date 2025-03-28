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

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthDisplay();
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
        // Restart the scene when player dies
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}