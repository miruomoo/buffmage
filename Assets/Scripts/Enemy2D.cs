using UnityEngine;
using UnityEngine.SceneManagement; // Import SceneManagement to restart the scene

public class Enemy2D : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Restart the current scene
            Debug.Log("Scene Restarted!");
        }
    }
}