using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenuManager : MonoBehaviour
{
    public void RestartGame()
    {
        Debug.Log("Restart button clicked");
        Time.timeScale = 1f; 
        SceneManager.LoadScene("Level1"); 
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // Unpause the game
        SceneManager.LoadScene("MainMenu"); // Go back to Main Menu
    }
}
