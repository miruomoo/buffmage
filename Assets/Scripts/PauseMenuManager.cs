using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenuManager : MonoBehaviour
{
    public static PauseMenuManager Instance;

    [Header("UI")]
    [SerializeField] GameObject pauseCanvas;       // root of the panel
    [SerializeField] TMP_Text timerSnapshot;      // optional : show time at pause

    bool paused;

    /* singleton */
    void Awake()
    {
        if (Instance != null) { Destroy(gameObject); return; }
        Instance = this;

        DontDestroyOnLoad(gameObject);
        if (pauseCanvas != null)
            DontDestroyOnLoad(pauseCanvas);      //keep the HUD alive too

        SceneManager.sceneLoaded += OnSceneLoaded;
        pauseCanvas.SetActive(false);
    }


    /*hotkey*/
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused) Resume();
            else Pause();
        }
    }

    public void Pause()
    {
        if (paused) return;
        Time.timeScale = 0f;
        paused = true;
        if (timerSnapshot && TimerManager.Instance)
            timerSnapshot.text = "TIME  " +
                TimerManager.Format(TimerManager.Instance.ElapsedSeconds);
        pauseCanvas.SetActive(true);
    }

    public void Resume()
    {
        if (!paused) return;
        pauseCanvas.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }

    public void RestartLevel()
    {
        Resume();
        SceneManager.LoadScene("Level1");
    }

    public void QuitToMainMenu()
    {
        Resume();
        SceneManager.LoadScene("MainMenu");
    }

    /* hide on MainMenu */
    void OnSceneLoaded(Scene s, LoadSceneMode m)
    {
        bool showInScene = s.name.StartsWith("Level");
        gameObject.SetActive(showInScene);   // disables Update() in menu
    }
}
