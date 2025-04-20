using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreenUI : MonoBehaviour
{
    // Called by MENU button
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;                 // resume game clock
        SceneManager.LoadScene("MainMenu");
    }

    // Called by RESTART button
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level1");     // or build index 1
    }
}
