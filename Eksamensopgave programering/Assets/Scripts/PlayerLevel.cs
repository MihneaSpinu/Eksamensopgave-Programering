using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerLevel : MonoBehaviour
{
    public int level = 0;
    public int experience = 0;
    public int experienceToNextLevel = 100;
    public TextMeshProUGUI PlayerLevelText;

    public void GainExperience(int amount)
    {
        experience += amount;
        if (experience >= experienceToNextLevel)
        {
            LevelUp(); // Local level up function
            GameObject.FindObjectOfType<PlayerStats>().LevelUp(); // PlayerStats level up function
        }
    }

    private void LevelUp()
    {
        level++; // Increment the level
        experience -= experienceToNextLevel; // Reset the experience
        experienceToNextLevel = (int)(experienceToNextLevel * 1.2f); // Increase the experience needed for the next level
    }

    // Update is called once per frame
    void Update()
    {
        PlayerLevelText.text = "Level: " + level.ToString(); // Update the player level text
    }
}
