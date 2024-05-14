// Not using anymore 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering;

public class PlayerLevel : MonoBehaviour
{
    private int level;
    private int experience;
    private PlayerStats playerStats;
    private int experienceToNextLevel;

    private void Awake()
    {
        playerStats = GameObject.FindObjectOfType<PlayerStats>();
        level = playerStats.level;
        experience = playerStats.experience;
        experienceToNextLevel = playerStats.experienceToNextLevel;
    }

    
    public TextMeshProUGUI PlayerLevelText;

    public void GainExperience(int amount)
    {
        experience += amount;
        if (experience >= experienceToNextLevel)
        {
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerLevelText.text = "Level: " + level.ToString(); // Update the player level text
    }
}
