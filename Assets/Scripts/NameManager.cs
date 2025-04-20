using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class NameManager : MonoBehaviour
{
    public TMP_InputField nameInput;
    const int MAX_LEN = 5;

    void Start()
    {
        // Autofill previous name if it exists
        if (PlayerPrefs.HasKey("PlayerName"))
            nameInput.text = PlayerPrefs.GetString("PlayerName");

        // Enforce the 5 char limit in the InputField itself
        nameInput.characterLimit = MAX_LEN;
    }

    public void StartGame()      // hooked to the PLAY button
    {
        string raw = nameInput.text.Trim().ToUpper();

        if (raw.Length == 0 || raw.Length > MAX_LEN)
        {
            Debug.Log("Invalid name! Name must be 1 to 5 characters.");
            return;
        }

        PlayerPrefs.SetString("PlayerName", raw);
        PlayerPrefs.Save();                       // flush to disk

        SceneManager.LoadScene("Level1");         
    }
}
