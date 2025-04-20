using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TimerHUD : MonoBehaviour
{
    public static TimerHUD Instance;
    public TMP_Text timerText;

    /*singleton & persistence*/
    void Awake()
    {
        if (Instance != null) { Destroy(gameObject); return; }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;   // listen for scene swaps
    }

    /* show / hide depending on scene  */
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Show only in Level1 to 3; hide in MainMenu (and any other)
        bool gameplay = scene.name == "Level1" ||
                        scene.name == "Level2" ||
                        scene.name == "Level3";

        gameObject.SetActive(gameplay);
    }

    /*update the label*/
    void Update()
    {
        if (!gameObject.activeSelf) return;          // skip when hidden
        if (TimerManager.Instance == null) return;

        timerText.text =
            TimerManager.Format(TimerManager.Instance.ElapsedSeconds);
    }
}
