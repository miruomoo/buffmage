using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class NameManager : MonoBehaviour
{
    public TMP_InputField nameInput;
    private string playerName;

    public void StartGame()
    {
        playerName = nameInput.text;

        if (playerName.Length > 0 && playerName.Length <= 5)
        {
            PlayerPrefs.SetString("PlayerName", playerName);  // Save the name
            SceneManager.LoadScene("Scene1");  // Load the next scene
        }
        else
        {
            Debug.Log("Invalid name! Name must be between 1 and 5 characters.");
        }
    }
}
