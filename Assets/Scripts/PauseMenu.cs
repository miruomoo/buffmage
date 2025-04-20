using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;  // Assign your Pause Menu Canvas here
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);  // Hide pause menu
        Time.timeScale = 1f;           // Set time scale back to normal
        isPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);   // Show pause menu
        Time.timeScale = 0f;           // Freeze time
        isPaused = true;
    }

    public void Restart()
    {
        Time.timeScale = 1f;           // Reset time scale before reloading
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // Reload current scene
    }

    public void ExitToIntro()
    {
        Time.timeScale = 1f;   
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);  //Initial Scence index (game is at 1)
    }
}
