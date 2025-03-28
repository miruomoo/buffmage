using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player hits the Finish object
        if (other.CompareTag("Player"))
        {
            // Load the Main Menu scene
            SceneManager.LoadScene("MainMenu");
        }
    }
}
