using UnityEngine;
using UnityEngine.SceneManagement; // Import SceneManagement to restart the scene

public class Enemy2D : MonoBehaviour
{
    private int health = 3;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
            health--;
            if (health <= 0)
            {
                gameObject.SetActive(false);
                other.gameObject.SetActive(false);
            }
        }
    }
}