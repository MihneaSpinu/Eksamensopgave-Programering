using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthSlider : MonoBehaviour
{
    public Slider healthSlider;
    PlayerStats playerStats;
    public TextMeshProUGUI healthText;

    private void Start()
    {
        playerStats = GameObject.FindObjectOfType<PlayerStats>(); // Find the player stats
        healthSlider.maxValue = playerStats.maxHealth; // Set the max value of the health slider
        healthSlider.value = playerStats.health; // Set the value of the health slider
        healthText.text = "Health: " + playerStats.health.ToString(); // Set the text of the health text
    }

    private void Update()
    {
        healthSlider.value = playerStats.health;
        healthText.text = "Health: " + playerStats.health.ToString(); // Update the health text
    }
}
