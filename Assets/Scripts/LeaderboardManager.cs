using UnityEngine;
using TMPro;                     //add TMP support

public class LeaderboardManager : MonoBehaviour
{
    [Header("UI")]
    public GameObject leaderboardPanel;   // panel you show / hide
    public TMP_Text leaderboardText;    // drag the pink label here

    [Header("Sprites to dim")]
    public SpriteRenderer ezekielSprite;
    public SpriteRenderer ezekielSprite1;
    public SpriteRenderer ezekielSprite2;
    public GameObject leftArrow;
    public GameObject rightArrow;

    bool isShowing = false;
    public void ToggleLeaderboard()       // called by your button
    {
        isShowing = !isShowing;
        leaderboardPanel.SetActive(isShowing);

        if (isShowing)
        {
            RefreshList();                // build the text each time

            DimSprite(ezekielSprite, 0);
            DimSprite(ezekielSprite1, 0);
            DimSprite(ezekielSprite2, 0);
            leftArrow.SetActive(false);
            rightArrow.SetActive(false);
        }
        else
        {
            DimSprite(ezekielSprite, 1);
            DimSprite(ezekielSprite1, 1);
            DimSprite(ezekielSprite2, 1);
            leftArrow.SetActive(true);
            rightArrow.SetActive(true);
        }
    }

    void RefreshList()
    {
        if (leaderboardText == null) return;

        var runs = RunLedger.Instance.runs;
        if (runs.Count == 0)
        {
            leaderboardText.text = "NO RUNS YET!";
            return;
        }

        System.Text.StringBuilder sb = new();
        int max = Mathf.Min(10, runs.Count);          // show top10
        for (int i = 0; i < max; i++)
        {
            sb.AppendLine($"{i + 1}.  {runs[i].name.ToUpper()}  -  " +
                          TimerManager.Format(runs[i].time));
        }
        leaderboardText.text = sb.ToString();
    }

    void DimSprite(SpriteRenderer sprite, float alpha)
    {
        if (sprite == null) return;
        Color c = sprite.color;
        c.a = alpha;
        sprite.color = c;
    }
    void OnEnable()
    {
        // when MainMenu scene is loaded again, rebuilt list once
        leaderboardPanel.SetActive(false);   // keep hidden
        RefreshList();
    }

}
