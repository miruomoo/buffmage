using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMana : MonoBehaviour
{
    public int maxMana = 10;
    public int currentMana;
    [SerializeField] private GameObject player;


    public GameObject[] manaImages = new GameObject[10];

    void Start()
    {
        currentMana = maxMana;
        UpdateManaDisplay();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Mana"))
        {
            AddMana();
        }
    }

    public void UseSpell(string spellName)
    {
        if (spellName == "fireball")
        {
            currentMana -= 1;
        }
        if (spellName == "freeze")
        {
            currentMana -= 2;
        }

        UpdateManaDisplay();

    }

    private void AddMana()
    {
        currentMana = maxMana;
        UpdateManaDisplay();
    }

    private void UpdateManaDisplay()
    {
        // Deactivate health images based on current health
        for (int i = 0; i < manaImages.Length; i++)
        {
            if (manaImages[i] != null)
            {
                // Show image if i is less than currentHealth
                manaImages[i].SetActive(i < currentMana);
            }
        }
    }
}
