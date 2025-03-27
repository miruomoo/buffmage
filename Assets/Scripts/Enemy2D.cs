using UnityEngine;
using UnityEngine.SceneManagement; // Import SceneManagement to restart the scene

public class Enemy2D : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Hit!");
        }
        if (other.CompareTag("Projectile"))
        {
            Debug.Log("Enemy Hit!");
            gameObject.SetActive(false);
            other.gameObject.SetActive(false);
        }
    }
}