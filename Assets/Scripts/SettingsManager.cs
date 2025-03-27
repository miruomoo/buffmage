using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsManager : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public GameObject infoText;
    public GameObject settingsPanel;

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
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
