using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinManager : MonoBehaviour
{
    [Header("Skin Previews")]
    public GameObject[] skinImages;
    
    [Header("UI Elements")]
    public GameObject leftButton;
    public GameObject rightButton;
    
    private int currentSkinIndex = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        // Load the previously selected skin index if it exists
        currentSkinIndex = PlayerPrefs.GetInt("SelectedSkinIndex", 0);
        
        // Make sure the loaded index is valid
        if (currentSkinIndex >= skinImages.Length)
        {
            currentSkinIndex = 0;
        }
        
        // Initialize the UI with the loaded skin
        UpdateSkinDisplay();
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    public void NextSkin()
    {
        currentSkinIndex++;
        
        // Loop back to the first skin if we go beyond the last one
        if (currentSkinIndex >= skinImages.Length)
        {
            currentSkinIndex = 0;
        }
        
        UpdateSkinDisplay();
    }
    
    public void PreviousSkin()
    {
        currentSkinIndex--;
        
        // Loop to the last skin if we go before the first one
        if (currentSkinIndex < 0)
        {
            currentSkinIndex = skinImages.Length - 1;
        }
        
        UpdateSkinDisplay();
    }
    
    private void UpdateSkinDisplay()
    {
        // Make sure we have skins to work with
        if (skinImages == null || skinImages.Length == 0)
        {
            Debug.LogError("Skin images array is empty or not assigned!");
            return;
        }
        
        // Deactivate all skin images
        for (int i = 0; i < skinImages.Length; i++)
        {
            if (skinImages[i] != null)
            {
                skinImages[i].SetActive(false);
            }
        }
        
        // Activate only the current skin image
        if (skinImages[currentSkinIndex] != null)
        {
            skinImages[currentSkinIndex].SetActive(true);
        }
        
        // Save the selected skin index for use in the game
        PlayerPrefs.SetInt("SelectedSkinIndex", currentSkinIndex);
        PlayerPrefs.Save();
    }
    
    // Get current skin index (can be called from other scripts)
    public int GetCurrentSkinIndex()
    {
        return currentSkinIndex;
    }
}
