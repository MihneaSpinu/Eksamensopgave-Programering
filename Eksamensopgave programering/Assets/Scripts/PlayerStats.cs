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
    public TextMeshProUGUI experienceText;

    public void Update()
    {
        if (experience >= experienceToNextLevel)
        {
            Debug.Log("Level up!");
            LevelUp();
        }

        levelText.text = "Level: " + level.ToString();
        upgradePointsText.text = "Upgrade Points: " + upgradePoints.ToString();
        experienceText.text = "Experience: " + experience.ToString() + "/" + experienceToNextLevel.ToString();
    }

    public void LevelUp()
    void OnTriggerEnter2D(Collider2D collider)
    {
        level++;
        experience = 0; // Reset the experience
        experienceToNextLevel = (int)(experienceToNextLevel * 1.2f); // Increase the experience needed for the next level

        upgradePoints++;
        if (collider.gameObject.CompareTag("Enemy"))
        {
                health -= 10;
        }
    }
}