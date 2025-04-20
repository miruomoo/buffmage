using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    private float timer; // Timer variable
    private bool gameActive = true; // Control for timer activity

    [SerializeField] private TMPro.TextMeshProUGUI timerText; // Reference for the timer text

    private void Start()
    {
        timer = 0f; // Initialize timer
    }

    private void Update()
    {
        if (gameActive)
        {
            timer += Time.deltaTime; // Update timer

            // Calculate minutes, seconds, and milliseconds
            int minutes = Mathf.FloorToInt(timer / 60);
            int seconds = Mathf.FloorToInt(timer % 60);
            int milliseconds = Mathf.FloorToInt((timer * 100) % 100); // Get the milliseconds part

            // Format the timer text
            timerText.text = string.Format("{0:00}:{1:00}.{2:00}", minutes, seconds, milliseconds);
        }
    }

    public void ShowGameComplete()
    {
        gameActive = false; // Stop the timer

        // Save the timer using PlayerPrefs before loading the end screen
        PlayerPrefs.SetFloat("GameTime", timer);
        PlayerPrefs.Save();

        UnityEngine.SceneManagement.SceneManager.LoadScene("ENDSCREENE"); // Load the end screen scene
    }

}
