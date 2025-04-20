using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

[Serializable] public class Run { public string name; public float time; }

public class RunLedger : MonoBehaviour
{
    public static RunLedger Instance { get; private set; }
    public List<Run> runs = new();

    string SavePath => Path.Combine(Application.persistentDataPath, "leaderboard.json");

    void Awake()
    {
        if (Instance != null) { Destroy(gameObject); return; }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void OnEnable()
    {
        if (Instance == null) Instance = this;
    }
    [RuntimeInitializeOnLoadMethod]
    static void AutoCreate()
    {
        if (Instance == null)
            new GameObject("RunLedger").AddComponent<RunLedger>();
    }
    public void AddRun(string name, float time)
    {
        runs.Add(new Run { name = name, time = time });
        runs = runs.OrderBy(r => r.time).Take(10).ToList();
        Save();
    }

    void Save() =>
        File.WriteAllText(SavePath,
            JsonUtility.ToJson(new Wrapper { list = runs }, true));

    void Load()
    {
        if (!File.Exists(SavePath)) return;
        runs = JsonUtility.FromJson<Wrapper>(File.ReadAllText(SavePath)).list;
    }
    [Serializable] class Wrapper { public List<Run> list; }
}
