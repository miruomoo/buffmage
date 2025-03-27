using UnityEngine;
using TMPro;

public class LeaderboardManager : MonoBehaviour
{
    public GameObject leaderboardPanel;  // Assign the panel
    private bool isShowing = false;

    // Toggle Leaderboard visibility
    public void ToggleLeaderboard()
    {
        isShowing = !isShowing;
        leaderboardPanel.SetActive(isShowing);
    }
}
