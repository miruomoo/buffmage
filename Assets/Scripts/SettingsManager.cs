using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsManager : MonoBehaviour
{
    public AudioSource backgroundMusic;  // This will be dynamically assigned
    public GameObject infoText;
    public GameObject settingsPanel;
    public SpriteRenderer ezekielSprite;

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
        DimEzekiel(0f); // Dim Ezekiel when settings open
    }

    // Close Settings Panel
    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
        DimEzekiel(1f); // Restore Ezekiel visibility
    }

    // Dim or Restore Ezekiel
    void DimEzekiel(float alpha)
    {
        if (ezekielSprite != null)
        {
            Color color = ezekielSprite.color;
            color.a = alpha;
            ezekielSprite.color = color;
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
