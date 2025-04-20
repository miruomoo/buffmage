using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [Header("Timer Setup")]
    [SerializeField] string firstTimerScene = "Level1";
    [SerializeField] string lastTimerScene = "Level3";

    [Header("(Optional) Win UI")]
    [SerializeField] GameObject winCanvas;
    [SerializeField] TMP_Text finalTimeText;

    /* ───────── Scene Entry ───────── */
    void Start()
    {
        // If we've just landed in the first timed level, create/start the clock
        if (SceneManager.GetActiveScene().name == firstTimerScene)
        {
            EnsureTimerExists();
            TimerManager.Instance.StartTimer();
        }
    }

    /* ───────── Door Collision ───────── */
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        bool isLast = SceneManager.GetActiveScene().name == lastTimerScene;

        if (isLast)
        {
            TimerManager.Instance.StopTimer();
            float runSec = TimerManager.Instance.ElapsedSeconds;

            /* +++++++++ SAVE the run to RunLedger +++++++++ */
            string pName = PlayerPrefs.GetString("PlayerName", "-----");
            RunLedger.Instance.AddRun(pName, runSec);

            /* +++++++++ Show WinCanvas +++++++++ */
            if (winCanvas && finalTimeText)
            {
                finalTimeText.text = $"Time: {TimerManager.Format(runSec)}";
                winCanvas.SetActive(true);
                Time.timeScale = 0f;        // pause gameplay
            }
        }

        LoadNextLevel();
    }

    /* ───────── Scene Loading ───────── */
    void LoadNextLevel()
    {
        Time.timeScale = 1f;                // un‑pause before scene change

        int next = SceneManager.GetActiveScene().buildIndex + 1;

        if (next < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(next);
        else
            Debug.Log("No more levels! Game finished.");
    }

    /* ───────── Helpers ───────── */
    void EnsureTimerExists()
    {
        if (TimerManager.Instance != null) return;

        GameObject go = new GameObject("TimerManager");
        go.AddComponent<TimerManager>();    // Awake will call DontDestroyOnLoad
    }
}
