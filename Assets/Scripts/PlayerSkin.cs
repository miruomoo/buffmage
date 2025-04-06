using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkin : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] skinSprites;
    
    // Start is called before the first frame update
    void Start()
    {
        LoadSelectedSkin();
    }

    private void LoadSelectedSkin()
    {
        // Get the selected skin index from PlayerPrefs
        int selectedSkinIndex = PlayerPrefs.GetInt("SelectedSkinIndex", 0);
        
        // Make sure the index is valid
        if (skinSprites != null && selectedSkinIndex >= 0 && selectedSkinIndex < skinSprites.Length)
        {
            // Set the sprite
            spriteRenderer.sprite = skinSprites[selectedSkinIndex];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
