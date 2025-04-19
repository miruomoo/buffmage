using UnityEngine;

public class LeaderboardManager : MonoBehaviour
{
    public GameObject leaderboardPanel;
    public SpriteRenderer ezekielSprite;
    public SpriteRenderer ezekielSprite1;
    public SpriteRenderer ezekielSprite2;
    private bool isShowing = false;
    public GameObject leftArrow;
    public GameObject rightArrow;

    // Toggle Leaderboard visibility
    public void ToggleLeaderboard()
    {
        isShowing = !isShowing;
        leaderboardPanel.SetActive(isShowing);

        if (isShowing)
        {
            DimSprite(ezekielSprite, 0); // Dim Ezekiel when settings open
            DimSprite(ezekielSprite1, 0); // Dim Ezekiel when settings open
            DimSprite(ezekielSprite2, 0); // Dim Ezekiel when settings open
            leftArrow.SetActive(false);
            rightArrow.SetActive(false);
        }
        else
        {
            DimSprite(ezekielSprite, 1); // Restore Ezekiel visibility
            DimSprite(ezekielSprite1, 1); // Dim Ezekiel when settings open
            DimSprite(ezekielSprite2, 1); // Dim Ezekiel when settings open
            leftArrow.SetActive(true);
            rightArrow.SetActive(true);
        }
    }
    void DimSprite(SpriteRenderer sprite, float alpha)
    {
        if (sprite != null)
        {
            Color color = sprite.color;
            color.a = alpha;
            sprite.color = color;
        }
    }
}
