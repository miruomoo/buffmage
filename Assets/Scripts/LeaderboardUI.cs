using UnityEngine;
using TMPro;

public class LeaderboardUI : MonoBehaviour
{
    public TMP_Text rowPrefab;   // disabled template row
    public Transform parent;     // Content object of ScrollView

    void Start()
    {
        foreach (var run in RunLedger.Instance.runs)
        {
            TMP_Text r = Instantiate(rowPrefab, parent);
            r.gameObject.SetActive(true);
            r.text = $"{run.name.PadRight(5)}  {TimerManager.Format(run.time)}";
        }
    }
}
