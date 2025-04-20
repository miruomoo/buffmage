using UnityEngine;
using TMPro;

public class TimerHUD : MonoBehaviour
{
    public static TimerHUD Instance;
    public TMP_Text timerText;
    void Awake()
    {
        if (Instance != null) { Destroy(gameObject); return; }
        Instance = this;
        DontDestroyOnLoad(gameObject);   // makes the label persist
    }

    void Update()
    {
        if (TimerManager.Instance == null) return;
        timerText.text = TimerManager.Format(
            TimerManager.Instance.ElapsedSeconds);
    }
}
