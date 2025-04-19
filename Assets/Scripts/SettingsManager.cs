using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsManager : MonoBehaviour
{
    public AudioSource backgroundMusic;  // This will be dynamically assigned
    public GameObject infoText;
    public GameObject settingsPanel;
    public SpriteRenderer ezekielSprite;
    public SpriteRenderer ezekielSprite1;
    public SpriteRenderer ezekielSprite2;
    public GameObject leftArrow;
    public GameObject rightArrow;


    void Start()
    {
        // Find and assign the background music dynamically
        FindBackgroundMusic();
    }

    // Method to re-assign the AudioSource after scene load
    void FindBackgroundMusic()
    {
        GameObject musicObject = GameObject.FindGameObjectWithTag("MenuMusic");

        if (musicObject != null)
        {
            backgroundMusic = musicObject.GetComponent<AudioSource>();
        }
        else
        {
            Debug.LogWarning("MenuMusic AudioSource not found! Make sure it's tagged correctly.");
        }
    }

    // Open Settings Panel
    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
        DimSprite(ezekielSprite, 0); // Dim Ezekiel when settings open
        DimSprite(ezekielSprite1, 0); // Dim Ezekiel when settings open
        DimSprite(ezekielSprite2, 0); // Dim Ezekiel when settings open
        leftArrow.SetActive(false);
        rightArrow.SetActive(false);
    }

    // Close Settings Panel
    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
        DimSprite(ezekielSprite, 1); // Restore Ezekiel visibility
        DimSprite(ezekielSprite1, 1); // Dim Ezekiel when settings open
        DimSprite(ezekielSprite2, 1); // Dim Ezekiel when settings open
        leftArrow.SetActive(true);
        rightArrow.SetActive(true);
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

    // Mute Music
    public void MuteMusic()
    {
        if (backgroundMusic == null)
        {
            FindBackgroundMusic();  // Recheck if AudioSource exists after changing scenes
        }

        if (backgroundMusic != null)
        {
            backgroundMusic.mute = true;
            Debug.Log("Music Muted");
        }
    }

    // Play Music
    public void PlayMusic()
    {
        if (backgroundMusic == null)
        {
            FindBackgroundMusic();  // Recheck if AudioSource exists after changing scenes
        }

        if (backgroundMusic != null)
        {
            backgroundMusic.mute = false;
            Debug.Log("Music Playing");
        }
    }

    // Toggle Info Text
    public void ToggleInfo()
    {
        infoText.SetActive(!infoText.activeSelf);
    }
}
