using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;        // remove this line if you don’t show WinCanvas here

public class LevelManager : MonoBehaviour
{
    [Header("Timer Setup")]
    [SerializeField] string firstTimerScene = "Level1";   // clock starts here
    [SerializeField] string lastTimerScene = "Level3";   // clock stops here

    [Header("(Optional) Win UI")]
    [SerializeField] GameObject winCanvas;   // leave null if you use a separate FinishFlag
    [SerializeField] TMP_Text finalTimeText;

    /*Scene Entry*/
    void Start()
    {
        // If we’ve just landed in the first timed level, create/start the clock
        if (SceneManager.GetActiveScene().name == firstTimerScene)
        {
            EnsureTimerExists();
            TimerManager.Instance.StartTimer();
        }
    }

    /*Door Collision*/
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        // If this door is in the last timed level, stop & show results *before* loading next
        if (SceneManager.GetActiveScene().name == lastTimerScene)
        {
            TimerManager.Instance.StopTimer();
            if (winCanvas != null && finalTimeText != null)
            {
                finalTimeText.text = "Time: " +
                    TimerManager.Format(TimerManager.Instance.ElapsedSeconds);
                winCanvas.SetActive(true);
                Time.timeScale = 0f;              // pause gameplay (optional)
            }
        }

        LoadNextLevel();
    }

    /*Scene Loading*/
    void LoadNextLevel()
    {
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextScene < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(nextScene);
        else
            Debug.Log("No more levels! Game finished.");
    }

    /*Helpers*/
    void EnsureTimerExists()
    {
        if (TimerManager.Instance != null) return;

        GameObject go = new GameObject("TimerManager");
        go.AddComponent<TimerManager>();          // Awake will call DontDestroyOnLoad
    }
}
