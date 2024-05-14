using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    // Declare the player stats
    public int health = 100;
    public float movementSpeed = 5f;
    public float shootCooldown;
    public int damage = 10;
    public int maxHealth = 100;
    public int level = 0;
    public int experience = 0;
    public int experienceToNextLevel = 100;
    public int upgradePoints = 0;

    public TextMeshProUGUI levelText;
    public TextMeshProUGUI upgradePointsText;


    void Start()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        levelText.text = "Level: " + level.ToString();
        upgradePointsText.text = "Upgrade Points: " + upgradePoints.ToString();
    }


    public void Update()
    {
        if (experience >= experienceToNextLevel)
        {
            Debug.Log("Level up!");
            LevelUp();
        }
        if (Input.GetKeyDown(KeyCode.L) & upgradePoints > 0) // Check if the player pressed the space key
        {
            GameObject.FindObjectOfType<PlayerStats>().Upgrade(); // PlayerStats StatsUp function
        }
    }

    public void LevelUp()
    {
        level++;
        experience = 0; // Reset the experience
        experienceToNextLevel = (int)(experienceToNextLevel * 1.2f); // Increase the experience needed for the next level

        upgradePoints++;
        UpdateUI();
    }

    public void Upgrade()
    {
        if (upgradePoints > 0)
        {
            // Implement your upgrade functionality here
            Debug.Log("Upgrade applied!");

            upgradePoints--;
            UpdateUI();
        }
        else
        {
            Debug.Log("Not enough upgrade points!");
        }
    }
}