using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsManager : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public GameObject infoText;
    public GameObject settingsPanel;
    public SpriteRenderer ezekielSprite;

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
        DimEzekiel(0f);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
        DimEzekiel(1f);
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

    // Mute Music
    public void MuteMusic()
    {
        backgroundMusic.mute = true;
    }

    // Play Music
    public void PlayMusic()
    {
        backgroundMusic.mute = false;
    }

    // Toggle Info Text
    public void ToggleInfo()
    {
        infoText.SetActive(!infoText.activeSelf);
    }
}
