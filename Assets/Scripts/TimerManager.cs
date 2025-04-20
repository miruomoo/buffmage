using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public static TimerManager Instance { get; private set; }

    float startTime;
    float stoppedTime;
    bool running;

    void Awake()
    {
        // enforce single instance
        if (Instance != null) { Destroy(gameObject); return; }

        Instance = this;
        DontDestroyOnLoad(gameObject);  // survive scene loads
    }
    public void StartTimer()
    {
        startTime = Time.time;
        running = true;
    }

    public void StopTimer()
    {
        stoppedTime = Time.time - startTime;
        running = false;
    }

    public float ElapsedSeconds =>
        running ? Time.time - startTime : stoppedTime;

    public static string Format(float s)
    {
        int m = Mathf.FloorToInt(s / 60f);
        int ss = Mathf.FloorToInt(s % 60f);
        return $"{m:00}:{ss:00}";
    }
}
