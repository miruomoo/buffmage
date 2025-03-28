using UnityEngine;

public class LeaderboardManager : MonoBehaviour
{
    public GameObject leaderboardPanel;  
    public SpriteRenderer ezekielSprite;  
    private bool isShowing = false;

    // Toggle Leaderboard visibility
    public void ToggleLeaderboard()
    {
        isShowing = !isShowing;
        leaderboardPanel.SetActive(isShowing);

        if (isShowing)
        {
            DimEzekiel(0f);  
        }
        else
        {
            DimEzekiel(1f);  // Restore to full visibility
        }
    }
    void DimEzekiel(float alpha)
    {
        if (ezekielSprite != null)
        {
            Color color = ezekielSprite.color;
            color.a = alpha;
            ezekielSprite.color = color;
        }
    }
}
